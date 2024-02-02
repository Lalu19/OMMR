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
    public class ResetAgentsService : BackgroundService
    {

        private readonly IServiceProvider _services;
        private readonly AppDbContext _context;
        private readonly ILogger<ResetAgentsService> _logger;

        public ResetAgentsService(IServiceProvider services, AppDbContext context, ILogger<ResetAgentsService> logger)
        {
            _services = services;
            _context = context;
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
              try
              {
                    using (var scope = _services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    var now = DateTime.Now;
                   // var twentyFourHoursAgo = now.AddMinutes(-4);
                    var twentyFourHoursAgo = now.AddHours(-25);

                    var agentsToReset = context.Agents
                        .Where(hp => hp.NotificationSent == true && hp.NotifiedOn <= twentyFourHoursAgo)
                        .ToList();

                    foreach (var agent in agentsToReset)
                    {
                        agent.NotificationSent = false;
                        agent.TaskAccepted = false;
                        agent.IsTimeExpired = false;
                        //hallPass.UpdatedOn = now;
                    }

                    context.SaveChanges();
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
              }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred in the ResetAgentsService.");
                }
            }
        }
    }
}
