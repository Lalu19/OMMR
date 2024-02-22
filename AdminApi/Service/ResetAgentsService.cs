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
                       // var twentyFourHoursAgo = now.AddMinutes(-10);
                         var twentyFourHoursAgo = now.AddHours(-1);
                        // var twentyFourHoursAgo = now.AddHours(-25);


                        var agentsToReset = context.Agents
                             .Where(hp => hp.NotificationSent == true && hp.NotifiedOn <= twentyFourHoursAgo)
                             .ToList();


                        foreach (var agent in agentsToReset)
                        {
                            agent.NotificationSent = false;
                            agent.TaskAccepted = false;
                            agent.IsTimeExpired = false;
                            // hallPass.UpdatedOn = now;
                        }


                        var primaryAgents = context.AgentMappings.Where(a => a.Agentrole == "Primary" && a.NotifiedOn <= twentyFourHoursAgo);


                        foreach (var primaryAgent in primaryAgents)
                        {
                            primaryAgent.TaskAccepted = false;
                            primaryAgent.TaskRejected = false;
                            primaryAgent.IsTimeExpired = false;
                            primaryAgent.NotificationSent = false;
                        }


                        var backUpAgents = context.AgentMappings
                             .Where(q => q.Agentrole == "Backup" && q.NotifiedOn <= twentyFourHoursAgo)
                             .ToList();


                        foreach (var agent1 in backUpAgents)
                        {
                            agent1.TaskAccepted = false;
                            agent1.TaskRejected = false;
                            agent1.IsTimeExpired = false;
                            agent1.NotificationSent = false;
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

        //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    while (!stoppingToken.IsCancellationRequested)
        //    {
        //        try
        //        {
        //            using (var scope = _services.CreateScope())
        //            {
        //                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        //                var now = DateTime.Now;
        //                var twentyFourHoursAgo = now.AddMinutes(-4);
        //                // var twentyFourHoursAgo = now.AddHours(-25);

        //                var agentsToReset = context.Agents
        //                    .Where(hp => hp.NotificationSent == true && hp.NotifiedOn <= twentyFourHoursAgo)
        //                    .ToList();

        //                var taskRejectedbyPrimary = context.AgentMappings
        //                    .Where(a => a.TaskRejected == true && a.NotifiedOn <= twentyFourHoursAgo)
        //                    .ToList();

        //                var taskAcceptedbyPrimary = context.AgentMappings
        //                    .Where(q => q.TaskAccepted == true && q.NotifiedOn <= twentyFourHoursAgo)
        //                    .ToList();

        //                foreach (var agent in agentsToReset)
        //                {
        //                    agent.NotificationSent = false;
        //                    agent.TaskAccepted = false;
        //                    agent.IsTimeExpired = false;
        //                    // hallPass.UpdatedOn = now;
        //                }

        //                foreach (var agent1 in taskRejectedbyPrimary)
        //                {
        //                    agent1.TaskRejected = false;
        //                }

        //                foreach (var agent2 in taskAcceptedbyPrimary)
        //                {
        //                    agent2.TaskAccepted = false;
        //                }

        //                context.SaveChanges();
        //            }

        //            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.LogError(ex, "An error occurred in the ResetAgentsService.");
        //        }
        //    }
        //}
    }
}
