using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Calculator.DAL;
using Calculator.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {


            // NLog: setup the logger first to catch all errors
            var logger =NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("init main");
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                //NLog: catch setup errors
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }


            var webHost = CreateWebHostBuilder(args).Build();

            using (var scope = webHost.Services.CreateScope())
            {
                using (var db = scope.ServiceProvider.GetRequiredService<CalculatorDbContext>())
                {
                    var transaction = db.Database.BeginTransaction();

                    try
                    {
                        for (int i = 1; i <= 4; i++)
                        {
                            if (!db.Methods.Any(m => m.Id == i))
                            {
                                db.Methods.Add(new Method
                                {
                                    Id = i,
                                    INSERT_DATE = DateTime.Now,
                                });
                            }
                        }

                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        transaction.Dispose();
                    }
                }
            }
            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                   .ConfigureLogging(logging =>
                    {
                     logging.ClearProviders();
                     logging.SetMinimumLevel(LogLevel.Trace);
                    })
                     .UseNLog();  // NLog: setup NLog for Dependency injection
    }
}
