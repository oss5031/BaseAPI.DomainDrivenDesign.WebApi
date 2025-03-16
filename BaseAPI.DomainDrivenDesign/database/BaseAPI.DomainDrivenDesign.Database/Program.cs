using DbUp;
using DbUp.Engine;
using Microsoft.Extensions.Configuration;

namespace BaseAPI.DomainDrivenDesign.Database
{
    class Program
    {
        static void Main(string[] args)
        {
            // Locate the configuration file in the App_Config directory
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Config", "Database.settings.json");

            if (!File.Exists(configPath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ Configuration file not found: {configPath}");
                Console.ResetColor();
                Environment.Exit(-1);
            }

            // Load configuration
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(configPath)!)
                .AddJsonFile("Database.settings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Connection string is missing in Database.settings.json");
                Console.ResetColor();
                Environment.Exit(-1);
            }

            var scriptsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts");
            var sqlScripts = Directory.GetFiles(scriptsPath, "*.sql", SearchOption.AllDirectories)
                         .Select(file => new SqlScript(Path.GetFileName(file), File.ReadAllText(file)))
                         .ToList();

            if (!Directory.Exists(scriptsPath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ Scripts folder not found: {scriptsPath}");
                Console.ResetColor();
                Environment.Exit(-1);
            }

            Console.WriteLine("🔄 Starting database migration...");

            var upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScripts(sqlScripts)
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();

            if (result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Database migration completed successfully!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Database migration failed!");
                Console.WriteLine(result.Error);
                Console.ResetColor();
                Environment.Exit(-1);
            }
        }
    }
}
