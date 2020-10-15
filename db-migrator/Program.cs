using System;
using System.Reflection;
using DbUp;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace task_migrator
{
    /*
        Environment variables:
            POSTGRES_HOST
            POSTGRES_USER
            POSTGRES_PASSWORD
            POSTGRES_DATABASE
    */
    class Program
    {
        private const int RETRIES = 10;
        private const int INTERVALL_MS = 2000;

        static int Main(string[] args)
        {
            Console.WriteLine("-->> Started");
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();
            var connectionString = getConnectionString(config);

            EnsureDatabaseWithRetry(connectionString, RETRIES);
            var upgrader = DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();
            var result = upgrader.PerformUpgrade();
            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
                return -1;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(value: "Success!");
            Console.ResetColor();
            return 0;
        }

        private static void EnsureDatabaseWithRetry(String connectionString, int retries) {
            try { 
                Console.WriteLine($"Ensure database, retry: {retries}");
                EnsureDatabase.For.PostgresqlDatabase(connectionString);
            } catch (System.Net.Sockets.SocketException) {
                Thread.Sleep(INTERVALL_MS);
                if (retries == 0) {
                    throw new Exception("Timeout, unable to connect to db!");
                }
                EnsureDatabaseWithRetry(connectionString, --retries);
            }
        }

        private static string getConnectionString(IConfiguration config) {
            var host = config["POSTGRES_HOST"] ?? "na";
            var user = config["POSTGRES_USER"] ?? "na";
            var password = config["POSTGRES_PASSWORD"] ?? "na";
            var database = config["POSTGRES_DATABASE"] ?? "na";

            return $"Host={host};User Id={user};Password={password};Database={database};Port=5432";
        }
    }
}
