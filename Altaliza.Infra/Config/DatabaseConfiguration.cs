namespace Altaliza.Infra.Config
{
    public class DatabaseConfiguration
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }

        public string ToMySqlConnectionString()
        {
            return $"server={Server};port={Port};user={User};password={Password};database={Database}";
        }
    }
}
