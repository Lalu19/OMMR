using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdminApi.Models;
using AdminApi.Models.App;
using AdminApi.Models.Helper;
using Microsoft.EntityFrameworkCore;
using NPOI.XWPF.UserModel;
using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
namespace AdminApi.Repository
{
    public class AgentRepository
    {
        private readonly AppDbContext _context;
        public AgentRepository (AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<object>> RunAgentProcessing()
        {
            try
            {
                var distinctTheatreNames = _context.AdScreen.Select(a => a.TheatreName).Distinct().ToList();
                var result = await ProcessAgentsFromTheaterName(distinctTheatreNames);
                //return new List<object> { result };
                return result;

            }
            catch (Exception ex)
            {
                // Log the exception details
                //Console.WriteLine("Error occurred: " + ex.Message);
                return new List<object> { new { Status = "error", ResponseMsg = "An error occurred while processing agents." } };
            }
        }




        //public async Task<object> ProcessAgentsFromTheaterName(List<string> distinctTheatreNames)
        //{
        //    try
        //    {
        //        var agents = _context.Agents.Where(u => u.IsDeleted == false && u.Agentrole == "Primary").ToList();

        //        var resultList = new List<object>();

        //        foreach (var agent in agents)
        //        {
        //            var primaryAgentTheatreNames = agent.TheatreName.Split(',').Select(t => t.Trim()).ToList();

        //            if (distinctTheatreNames.Any(theatre => primaryAgentTheatreNames.Contains(theatre)))
        //            {
        //                var pushNotifications = _context.PushNotifications.Where(p => p.AgentId == agent.AgentId).ToList();
        //                foreach (var notification in pushNotifications)
        //                {
        //                    var result = new
        //                    {
        //                        agent.AgentId,
        //                        //agent.TheatreName,
        //                        notification.DeviceId,
        //                        notification.IMEINumber,
        //                        notification.FCMToken
        //                    };
        //                    resultList.Add(result);
        //                }
        //                agent.NotificationSent = true;
        //            }
        //        }

        //        await _context.SaveChangesAsync();

        //        //return new { data = resultList };
        //        return resultList;

        //    }
        //    catch
        //    {
        //        // Log the exception details
        //        //Console.WriteLine("Error occurred: " + ex.Message);
        //        return new { Status = "error", ResponseMsg = "An error occurred while processing agents." };
        //    }
        //}



        public async Task<List<object>> ProcessAgentsFromTheaterName(List<string> distinctTheatreNames)
        {
            try
            {
                var agents = _context.Agents.Where(u => u.IsDeleted == false && u.Agentrole == "Primary").ToList();

                var resultList = new List<object>();

                foreach (var agent in agents)
                {
                    var primaryAgentTheatreNames = agent.TheatreName.Split(',').Select(t => t.Trim()).ToList();

                    if (distinctTheatreNames.Any(theatre => primaryAgentTheatreNames.Contains(theatre)))
                    {
                        var pushNotifications = _context.PushNotifications.Where(p => p.AgentId == agent.AgentId).ToList();
                        foreach (var notification in pushNotifications)
                        {
                            var result = new
                            {
                                agent.AgentId,
                                //agent.TheatreName,
                                //notification.DeviceId,
                                //notification.IMEINumber,
                                notification.FCMToken,
                                body = "Theatre Assigned",
                                title = "Hello"
                            };
                            resultList.Add(result);
                        }
                        agent.NotificationSent = true;
                        agent.NotifiedOn = DateTime.Now;
                    }
                }

                await _context.SaveChangesAsync();

                return resultList;
            }
            catch (Exception ex)
            {
                // Log the exception details
                //Console.WriteLine("Error occurred: " + ex.Message);
                return new List<object> { new { Status = "error", ResponseMsg = "An error occurred while processing agents." } };
            }
        }


        public async Task<string> SendEmail(string from, string to, string subject, string msgBody)
        {
            try
            {
                using (var client = new AmazonSimpleEmailServiceClient("AKIAVKJ2J2YWBU2P6HU3", "p+mi2QpJsOky03imPdz5W/Hhe86y23I/BshScmGK", RegionEndpoint.APSouth1))
                {
                    var sendRequest = new SendEmailRequest
                    {
                        Source = from,
                        Destination = new Destination
                        {
                            ToAddresses = new List<string> { to }
                        },
                        Message = new Message
                        {
                            Subject = new Content(subject),
                            Body = new Body
                            {
                                Html = new Content(msgBody)
                            }
                        }
                    };


                    var response = await client.SendEmailAsync(sendRequest);
                    //Console.WriteLine(response.ToString());
                    return response.ToString();
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return err;
            }
        }



























        //public async Task<List<object>> RunAgentProcessing()
        //{
        //    try
        //    {
        //        var result = await ProcessAgentsFromTheaterName();
        //        return new List<object> { result };
        //    }
        //    catch
        //    {
        //        return new List<object> { new { Status = "error", ResponseMsg = "An error occurred while processing agents." } };
        //    }
        //}

        //public async Task<object> ProcessAgentsFromTheaterName()
        //{
        //    //var agents = _context.Agents.Where(u => !u.IsDeleted).ToList();

        //    //var primaryAgent = agents.FirstOrDefault(u => u.Agentrole == "Primary");
        //    //var backupAgent = agents.FirstOrDefault(u => u.Agentrole == "Backup");

        //    //if (primaryAgent == null && backupAgent == null)
        //    //{
        //    //    return new Confirmation { Status = "error", ResponseMsg = "No agents found." };
        //    //}

        //    //if (primaryAgent == null)
        //    //{
        //    //    return new Confirmation { Status = "error", ResponseMsg = "Primary agent not found." };
        //    //}

        //    var list = (from u in _context.PushNotifications
        //                join x in _context.Agents on u.AgentId equals x.AgentId


        //                where x.Agentrole == "Primary"
        //                where u.IsDeleted == false
        //                where x.IsDeleted == false




        //                select new
        //                {
        //                    u.AgentId,
        //                    u.DeviceId,
        //                    u.IMEINumber,
        //                    u.FCMToken,

        //                }).ToList();

        //    //int totalRecords = list.Count();

        //    if (list.Count == 0)
        //    {
        //        return new Confirmation { Status = "error", ResponseMsg = "AgentId not matching" };
        //    }

        //    var selectedAgentIds = list.Select(item => item.AgentId).ToList();
        //    var agentsToUpdate = _context.Agents.Where(agent => selectedAgentIds.Contains(agent.AgentId)).ToList();
        //        foreach (var agent in agentsToUpdate)
        //        {
        //            agent.NotificationSent = true;
        //        }

        //    await _context.SaveChangesAsync();

        //    return new { data = list };
        //}


        //public async Task<List<object>> RunAgentProcessing()
        //{
        //    try
        //    {

        //        var result = await ProcessAgentsFromTheaterName();
        //        return new List<object> { result };
        //    }
        //    catch
        //    {
        //        return new List<object> { new { Status = "error", ResponseMsg = "An error occurred while processing agents." } };
        //    }
        //}

        //public async Task<object> ProcessAgentsFromTheaterName()
        //{
        //    var distinctTheatreNames = _context.AdScreen.Select(a => a.TheatreName).Distinct().ToList();

        //    var list = (from u in _context.PushNotifications
        //                join x in _context.Agents on u.AgentId equals x.AgentId
        //                where x.Agentrole == "Primary"
        //                    && u.IsDeleted == false
        //                    && x.IsDeleted == false
        //                    && distinctTheatreNames.Any(theatre => Regex.IsMatch(x.TheatreName, $@"\b{theatre}\b"))

        //                select new
        //                {
        //                    x.AgentId,
        //                    x.TheatreName,
        //                    u.DeviceId,
        //                    u.IMEINumber,
        //                    u.FCMToken,
        //                }).ToList();

        //    if (list.Count == 0)
        //    {
        //        return new Confirmation { Status = "error", ResponseMsg = "AgentId not matching" };
        //    }

        //    var selectedAgentIds = list.Select(item => item.AgentId).ToList();
        //    var agentsToUpdate = _context.Agents.Where(agent => selectedAgentIds.Contains(agent.AgentId)).ToList();
        //    foreach (var agent in agentsToUpdate)
        //    {
        //        agent.NotificationSent = true;
        //    }

        //    await _context.SaveChangesAsync();

        //    return new { data = list };
        //}






        //public async Task<List<object>> RunAgentProcessing()
        //{
        //    try
        //    {
        //        var notificationToSend = _context.Agents.Where(ex => !ex.IsDeleted).ToList();

        //        var resultList = new List<object>();


        //            var allAgents = _context.Agents.Where(ex => !ex.IsDeleted)
        //                //.Select(agent => agent.TheatreName)
        //                .Distinct()
        //                .ToList();

        //            foreach (var agent in allAgents)
        //            {
        //                var result = await ProcessAgentsFromTheaterName();
        //                resultList.Add(result);
        //            }
        //            return resultList;
        //    }
        //    catch
        //    {
        //        return new List<object> { new { Status = "error", ResponseMsg = "An error occurred while processing agents." } };
        //    }
        //}


        //public async Task<object> ProcessAgentsFromTheaterName()
        //{
        //    var agents = _context.Agents.Where(u => u.IsDeleted == false).ToList();

        //    var primaryAgent = agents.FirstOrDefault(u => u.Agentrole == "Primary");
        //    var backupAgent = agents.FirstOrDefault(u => u.Agentrole == "Backup");

        //    if (primaryAgent == null && backupAgent == null)
        //    {
        //        return new Confirmation { Status = "error", ResponseMsg = "No agents found for the specified TheatreName." };
        //    }

        //    if (primaryAgent == null)
        //    {
        //        return new Confirmation { Status = "error", ResponseMsg = "Primary agent not found for the specified TheatreName." };
        //    }

        //    var list = (from u in _context.PushNotifications
        //                join x in _context.Agents on u.AgentId equals x.AgentId
        //                //where x.TheatreName == TheatreName


        //                select new
        //                {
        //                    u.AgentId,
        //                    u.DeviceId,
        //                    u.IMEINumber,
        //                    u.FCMToken,
        //                    u.IsDeleted
        //                }).Where(x => x.IsDeleted == false).ToList();

        //    int totalRecords = list.Count();

        //    if (list.Count == 0)
        //    {
        //        return new Confirmation { Status = "error", ResponseMsg = "AgentId not matching" };
        //    }


        //    var selectedAgentIds = list.Select(item => item.AgentId).ToList();
        //    var agentsToUpdate = _context.Agents.Where(agent => selectedAgentIds.Contains(agent.AgentId)).ToList();
        //    foreach (var agent in agentsToUpdate)
        //    {
        //        agent.NotificationSent = true;
        //    }


        //    await _context.SaveChangesAsync();

        //    return new { data = list };
        //}


    }
}

