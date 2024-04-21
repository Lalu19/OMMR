using AdminApi.Models;
using AdminApi.Models.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;

namespace AdminApi.Service
{
    public class AdScreenService : IAdScreenService
    {
        private readonly AppDbContext _context;

        public AdScreenService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<object> GetScreenListbyTheaterName(string TheaterName, int Stateid, int AgentId)
        {
            try
            {
                var feedbackAdScreenIds = _context.AdScreenFeedbackForm
                    .Where(feedback => feedback.IsDeleted == false)
                    .Select(feedback => feedback.AdScreenId)
                    .Distinct()
                    .ToList();

                var adsList = _context.AdScreen
                    .Where(u => u.IsDeleted == false && u.TheatreName == TheaterName && u.StateId == Stateid
                                && !feedbackAdScreenIds.Contains(u.AdScreenId))
                    .ToList();

                var groupedAds = adsList
                    .GroupBy(u => new { u.StateId, u.TheatreName, u.Screen, u.AdsPlaytime })
                    .Select(group => new
                    {
                        StateId = group.Key.StateId,
                        TheatreName = group.Key.TheatreName,
                        Screen = group.Key.Screen,
                        AdsPlaytime = group.Key.AdsPlaytime,
                        AdsNames = group.Select(u => u.AdsName).ToArray(),
                        AdScreenId = group.Select(u => u.AdScreenId).ToArray(),
                        AdsYoutubeLink = group.Select(u => u.AdsYoutubeLink).ToArray(),
                        AdsSequence = group.Select(u => u.AdsSequence).ToArray(),
                        AdsDuration = group.Select(u => u.AdsDuration).ToArray(),
                        AdsLanguage = group.Select(u => u.AdsLanguage).ToArray(),
                        Media = group.Select(u => u.Media).ToArray(),
                        IsDeleted = group.Select(u => u.IsDeleted).FirstOrDefault(),
                    })
                    .ToList();

               // int totalRecords = groupedAds.Count();

                // Update AgentMapping table
               // var agentMappingsToUpdate = _context.AgentMappings
                   // .Where(mapping => mapping.StateId == Stateid && mapping.AgentId == AgentId && mapping.TheatreName == TheaterName)
                   // .ToList();

                //foreach (var mapping in agentMappingsToUpdate)
                //{
                //    mapping.TaskAccepted = true; // Set TaskAccepted to true
                //}

                // Update AgentReports table
              //  var agentReportsToUpdate = _context.AgentReports
              //  .Where(report => report.StateId == Stateid && report.AgentId == AgentId && report.TheatreName == TheaterName)
               // .OrderByDescending(report => report.NotifiedOn) // Order by Timestamp to get the latest entry
               // .FirstOrDefault(); // Get the latest entry

                //if (agentReportsToUpdate != null)
                //{
                //    agentReportsToUpdate.TaskAccepted = true; // Set TaskAccepted to true
                //    agentReportsToUpdate.TaskAcceptedTime = DateTime.Now;
                //}

                //_context.SaveChanges();
                return  groupedAds ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
    }
}
