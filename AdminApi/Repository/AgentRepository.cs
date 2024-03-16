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
using AdminApi.Models.App.Agent;

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
                var result = await ProcessAgentsFromTheaterName1(distinctTheatreNames);
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

        public async Task<List<object>> RunAgentProcessing2()
        {
            try
            {
                var distinctTheatreNames = _context.AdScreen.Select(a => a.TheatreName).Distinct().ToList();
                var result = await ProcessAgentsFromTheaterName2(distinctTheatreNames);
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

        //public async Task<List<object>> ProcessAgentsFromTheaterName1(List<string> distinctTheatreNames)
        //{
        //    try
        //    {
        //        var agents = _context.AgentMappings.Where(u => u.IsDeleted == false && u.Agentrole == "Primary").ToList();
        //        var resultList = new List<object>();

        //        foreach (var agent in agents)
        //        {
        //            var primaryAgentTheatreNames = new List<string> { agent.TheatreName.Trim() };

        //            // Check if any of the theater names assigned to the primary agent are present in AdScreen table
        //            var theatersAssignedToAgent = distinctTheatreNames.Where(theatre => primaryAgentTheatreNames.Contains(theatre)).ToList();

        //            if (theatersAssignedToAgent.Any())
        //            {
        //                var pushNotifications = _context.PushNotifications.Where(p => p.AgentId == agent.AgentId).ToList();
        //                foreach (var notification in pushNotifications)
        //                {
        //                    var result = new
        //                    {
        //                        agent.AgentId,
        //                        notification.FCMToken,
        //                        agent.EmailId,
        //                        agent.AgentName,
        //                        agent.TheatreName
        //                    };
        //                    resultList.Add(result);
        //                    agent.NotificationSent = true;
        //                    agent.NotifiedOn = DateTime.Now;
        //                    await _context.SaveChangesAsync();
        //                }
        //            }
        //        }
        //        return resultList;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new List<object> { new { Status = "error", ResponseMsg = "An error occurred while processing agents." } };
        //    }
        //}

        public async Task<List<object>> ProcessAgentsFromTheaterName1(List<string> distinctTheatreNames)
        {
            try
            {
                var agents = _context.AgentMappings.Where(u => u.IsDeleted == false && u.Agentrole == "Primary").ToList();
                var resultList = new List<object>();

                foreach (var agent in agents)
                {
                    var primaryAgentTheatreNames = new List<string> { agent.TheatreName.Trim() };

                    // Check if any of the theater names assigned to the primary agent are present in AdScreen table
                    var theatersAssignedToAgent = distinctTheatreNames.Where(theatre => primaryAgentTheatreNames.Contains(theatre)).ToList();

                    if (theatersAssignedToAgent.Any())
                    {
                        var pushNotifications = _context.PushNotifications.Where(p => p.AgentId == agent.AgentId).ToList();
                        foreach (var notification in pushNotifications)
                        {
                            var result = new
                            {
                                agent.AgentId,
                                notification.FCMToken,
                                agent.EmailId,
                                agent.AgentName,
                                agent.TheatreName
                            };
                            resultList.Add(result);

                            // Update AgentMappings table
                            agent.NotificationSent = true;
                            agent.NotifiedOn = DateTime.Now;

                            // Insert into AgentReport table
                            var newAgentReport = new AgentReport
                            {
                                AgentId = agent.AgentId,
                                StateId = agent.StateId,
                                AgentName = agent.AgentName,
                                Agentrole = agent.Agentrole,
                                AgentPhoneNumber = agent.AgentPhoneNumber,
                                EmailId = agent.EmailId,
                                TheatreName = agent.TheatreName,
                                TaskAccepted = false,
                                TaskRejected = false,
                                NotificationSent = true,
                                NotifiedOn = DateTime.Now,
                                IsTimeExpired = false,
                                CreatedOn = DateTime.Now
                            };
                            _context.AgentReports.Add(newAgentReport);
                        }
                        await _context.SaveChangesAsync();
                    }
                }
                return resultList;
            }
            catch (Exception ex)
            {
                return new List<object> { new { Status = "error", ResponseMsg = "An error occurred while processing agents." } };
            }
        }

        public async Task<List<object>> ProcessAgentsFromTheaterName2(List<string> distinctTheatreNames)
        {
            try
            {
                var agents = _context.AgentMappings.Where(u => u.IsDeleted == false && u.Agentrole == "Primary" && u.NotificationSent == false).ToList();
                var resultList = new List<object>();

                foreach (var agent in agents)
                {
                    var primaryAgentTheatreNames = new List<string> { agent.TheatreName.Trim() };

                    // Check if any of the theater names assigned to the primary agent are present in AdScreen table
                    var theatersAssignedToAgent = distinctTheatreNames.Where(theatre => primaryAgentTheatreNames.Contains(theatre)).ToList();

                    if (theatersAssignedToAgent.Any())
                    {
                        var pushNotifications = _context.PushNotifications.Where(p => p.AgentId == agent.AgentId).ToList();
                        foreach (var notification in pushNotifications)
                        {
                         
                             var result = new
                            {
                                agent.AgentId,
                                notification.FCMToken,
                                agent.EmailId,
                                agent.AgentName,
                                agent.TheatreName
                            };
                            resultList.Add(result);

                            // Update AgentMappings table
                            agent.NotificationSent = true;
                            agent.NotifiedOn = DateTime.Now;

                            // Insert into AgentReport table
                            var newAgentReport = new AgentReport
                            {
                                AgentId = agent.AgentId,
                                StateId = agent.StateId,
                                AgentName = agent.AgentName,
                                Agentrole = agent.Agentrole,
                                AgentPhoneNumber = agent.AgentPhoneNumber,
                                EmailId = agent.EmailId,
                                TheatreName = agent.TheatreName,
                                TaskAccepted = false,
                                TaskRejected = false,
                                NotificationSent = true,
                                NotifiedOn = DateTime.Now,
                                IsTimeExpired = false,
                                CreatedOn = DateTime.Now
                            };
                            _context.AgentReports.Add(newAgentReport);
                        }
                        await _context.SaveChangesAsync();
                    }
                }
                return resultList;
            }
            catch (Exception ex)
            {
                return new List<object> { new { Status = "error", ResponseMsg = "An error occurred while processing agents." } };
            }
        }


        //public async Task<List<object>> ProcessAgentsFromTheaterName(List<string> distinctTheatreNames)
        //{
        //    try
        //    {
        //        var agents = _context.Agents.Where(u => u.IsDeleted == false && u.Agentrole == "Primary").ToList();
        //        var resultList = new List<object>();

        //        foreach (var agent in agents)
        //        {
        //            var primaryAgentTheatreNames = agent.TheatreName.Split(',').Select(t => t.Trim()).ToList();

        //            // Check if any of the theater names assigned to the primary agent are present in AdScreen table
        //            var theatersAssignedToAgent = distinctTheatreNames.Where(theatre => primaryAgentTheatreNames.Contains(theatre)).ToList();

        //            if (theatersAssignedToAgent.Any())
        //            {
        //                var pushNotifications = _context.PushNotifications.Where(p => p.AgentId == agent.AgentId).ToList();
        //                foreach (var notification in pushNotifications)
        //                {
        //                    var result = new
        //                    {
        //                        agent.AgentId,
        //                        notification.FCMToken,
        //                        body = "Theatre Assigned",
        //                        title = "Hello",
        //                        agent.EmailId
        //                    };
        //                    resultList.Add(result);
        //                }
        //                agent.NotificationSent = true;
        //                agent.NotifiedOn = DateTime.Now;
        //            }
        //        }

        //        await _context.SaveChangesAsync();

        //        return resultList;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new List<object> { new { Status = "error", ResponseMsg = "An error occurred while processing agents." } };
        //    }
        //}


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

    }
}

