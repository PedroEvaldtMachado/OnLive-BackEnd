using Api.Tools;
using LiveStreamingServerNet;
using LiveStreamingServerNet.Networking.Helpers;
using LiveStreamingServerNet.Transmuxer.Installer;
using LiveStreamingServerNet.Transmuxer.Internal.Utilities;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using System.Net;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var trasmuxerOutputPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!, "TransmuxerOutputMQ");
new DirectoryInfo(trasmuxerOutputPath).Create();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddCors(Services => Services.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
builder.Services.AddConfiguration();

await using var liveStreamingServer = LiveStreamingServerBuilder.Create()
    .ConfigureRtmpServer(options => {
        options
            .AddBandwidthLimiter(25_000_000)
            .AddTransmuxer(options =>
                options.AddTransmuxerEventHandler(svc =>
                    new TransmuxerEventListener(trasmuxerOutputPath, svc.GetRequiredService<ILogger<TransmuxerEventListener>>()))
            )
            .AddFFmpeg(options =>
            {
                options.TransmuxerIdentifier = "ffmpeg264";
                options.FFmpegPath = ExecutableFinder.FindExecutableFromPATH("ffmpeg")!;
                options.OutputPathResolver = (streamPath, streamArguments)
                    => Task.FromResult(Path.Combine(trasmuxerOutputPath, streamPath.Trim('/'), "output.m3u8"));
            });
    })
    .ConfigureLogging(options => options.AddConsole())
    .Build();

builder.Services.AddBackgroundServer(liveStreamingServer, new IPEndPoint(IPAddress.Any, 5002));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.UseConfiguration();
app.UseCors("AllowAll");

var contentTypeProvider = new FileExtensionContentTypeProvider();
contentTypeProvider.Mappings[".m3u8"] = "application/x-mpegURL";

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(trasmuxerOutputPath),
    ContentTypeProvider = contentTypeProvider
});

await app.RunAsync();