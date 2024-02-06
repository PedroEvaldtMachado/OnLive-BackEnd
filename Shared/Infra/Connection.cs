namespace Shared.Infra
{
    public class DbConnection 
    {
        public bool UseCached { get; set; }
        public Connection ConnectionDatabase { get; set; } = new Connection();
    }

    public class Connection
    {
        public string? ConnectionStrings { get; set; }
        public string? DatabaseName { get; set; }
    }
}
