using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DbUp;
using DbUp.Engine;
using DbUp.Helpers;
using Microsoft.Extensions.Configuration;

namespace BFinances.DbUp
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                    optional: true);

            var configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("BFinances");

            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            DbUpRunner(UpdateOnce, connectionString, "BFinances.DbUp.Scripts");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }

        public static DatabaseUpgradeResult UpdateOnce(string connectionString, string prefix)
        {
            return DeployChanges.To
                .SqlDatabase(connectionString)
                .WithTransaction()
                .WithScriptsEmbeddedInAssembly(typeof(Program).GetTypeInfo().Assembly, x => x.StartsWith(prefix))
                .WithExecutionTimeout(TimeSpan.FromMinutes(5))
                .LogToAutodetectedLog()
                .Build()
                .PerformUpgrade();
        }

        private static void DbUpRunner(Func<string, string, DatabaseUpgradeResult> dbUpExecution,
            string connectionString, string prefix)
        {
            var result = dbUpExecution(connectionString, prefix);
            if (!result.Successful)
            {
                throw new DbUpExecutionException(result.Error);
            }
        }

        public class DbUpExecutionException : Exception
        {
            public DbUpExecutionException(Exception exception) : base(nameof(DbUpExecutionException), exception)
            {
            }
        }
    }
}