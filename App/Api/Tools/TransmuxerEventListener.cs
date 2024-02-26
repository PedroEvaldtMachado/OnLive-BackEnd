using LiveStreamingServerNet.Transmuxer.Contracts;

namespace Api.Tools
{
    public class TransmuxerEventListener : ITransmuxerEventHandler
    {
        private readonly string _trasmuxerOutputPath;
        private readonly ILogger _logger;

        public TransmuxerEventListener(string trasmuxerOutputPath, ILogger<TransmuxerEventListener> logger)
        {
            _trasmuxerOutputPath = trasmuxerOutputPath;
            _logger = logger;
        }

        public Task OnTransmuxerStartedAsync(uint clientId, string identifier, string inputPath, string outputPath, string streamPath, IDictionary<string, string> streamArguments)
        {
            outputPath = Path.GetRelativePath(_trasmuxerOutputPath, outputPath);
            _logger.LogInformation($"Transmuxer ({identifier}) started: {inputPath} -> {outputPath}");
            return Task.CompletedTask;
        }

        public Task OnTransmuxerStoppedAsync(uint clientId, string identifier, string inputPath, string outputPath, string streamPath, IDictionary<string, string> streamArguments)
        {
            outputPath = Path.GetRelativePath(_trasmuxerOutputPath, outputPath);
            _logger.LogInformation($"Transmuxer ({identifier}) stopped: {inputPath} -> {outputPath}");
            return Task.CompletedTask;
        }
    }
}
