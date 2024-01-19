using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdminApi.Models;
using Microsoft.Extensions.Logging;

namespace AdminApi.Services
{
    public class HallPassCleanUpService : BackgroundService
    {

        private readonly IServiceProvider _services;
        private readonly AppDbContext _context;


        public HallPassCleanUpService(IServiceProvider services, AppDbContext context)
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
                   // var threeDaysAgo = now.AddMinutes(-5);
                    var threeDaysAgo = now.AddDays(-3);

                    var hallPassesToDelete = context.HallPass
                        .Where(hp => !hp.IsDeleted && hp.CreatedOn <= threeDaysAgo)
                        .ToList();

                    foreach (var hallPass in hallPassesToDelete)
                    {
                        hallPass.IsDeleted = true;
                        hallPass.UpdatedOn = now;
                    }

                    context.SaveChanges();
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }




    }
}
