using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdminApi.Models;
using Microsoft.Extensions.Logging;
using Example;
using Microsoft.EntityFrameworkCore;


namespace AdminApi.Service
{

    public class Adscreen30DaysCleanUp : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly AppDbContext _context;

        public Adscreen30DaysCleanUp(IServiceProvider services, AppDbContext context)
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
                   // var ThirtyDaysAgo = now.AddDays(-30);
                    var ThirtyDaysAgo = now.AddMinutes(-2);

                    var AdScreenToDelete = context.AdScreen
                        .Where(ad => ad.IsDeleted == false && ad.CreatedOn <= ThirtyDaysAgo)
                        .ToList();

                    foreach (var Screen in AdScreenToDelete)
                    {
                        Screen.IsDeleted = true;
                        Screen.UpdatedOn = now;
                    }

                    context.SaveChanges();
                }

                //await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
