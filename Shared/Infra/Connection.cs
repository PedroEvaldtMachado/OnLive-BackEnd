namespace Shared.Infra
{
    public class Connection
    {
        public const string CONNECTION_SECTION = "ConnectionDatabase";
        public string? ConnectionStrings { get; set; }
        public string? DatabaseName { get; set; }
    }
}
