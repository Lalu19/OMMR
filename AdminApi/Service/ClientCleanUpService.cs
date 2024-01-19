using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdminApi.Models;
using Microsoft.Extensions.Logging;
namespace AdminApi.Service
{
    public class ClientCleanUpService : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly AppDbContext _context;

        public ClientCleanUpService(IServiceProvider services, AppDbContext context)
        {
            _services = services;
            _context = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    var now = DateTime.Now;
                   // var SevenDaysAgo = now.AddMinutes(1);
                    var SevenDaysAgo = now.AddDays(-7);

                    var ClientToDelete = context.Users
                        .Where(hp => hp.IsActive == true && hp.DateAdded <= SevenDaysAgo && hp.UserRoleId == 4)
                        .ToList();

                    foreach (var Client in ClientToDelete)
                    {
                        Client.IsActive = false;
                        Client.LastUpdatedDate = now;
                    }

                    context.SaveChanges();
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }


    }
}
