
using AdminApi.Models.Helper;
using AdminApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using AdminApi.Models.App.Agent;
using AdminApi.DTO.App.AgentDTO;
using AdminApi.DTO.App.LocationDTO;
using AdminApi.Models.App.Location;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Security.Cryptography;
using AdminApi.Models.User;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using AdminApi.Repository;
using Hangfire;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly ISqlRepository<Agent> _AgentRepo;
        public AgentController(IConfiguration config,
                                AppDbContext context,
                                ISqlRepository<Agent> AgentRepo)

        {
            _config = config;
            _context = context;
            _AgentRepo = AgentRepo;

        }

        [AllowAnonymous]
        [HttpGet("{AgentuserId}/{PassWord}")]
        public ActionResult AgentLogin(string AgentuserId, string PassWord)
        {
            try
            {
                //string encryptedPassword = EncryptPassword(PassWord);
                var list = (from u in _context.Agents
                            join a in _context.States on u.StateId equals a.StateId
                            select new
                            {
                                u.AgentId,
                                u.StateId,
                                a.StateName,
                                u.Cityname,
                                u.TheatreName,
                                u.AgentName,
                                u.Agentrole,
                                u.AgentPhoneNumber,
                                u.Address,
                                u.EmailId,
                                u.ProfilePhoto,
                                u.AgentuserId,
                                u.PassWord,
                                u.CreatedBy,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.AgentuserId == AgentuserId && x.PassWord == PassWord /*encryptedPassword*/).FirstOrDefault();

                if (list != null)
                {
                    return Ok(list);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }

        }

        //public static string EncryptPassword(string password)
        //{
        //    SHA256 sha256 = SHA256.Create();
        //    byte[] bytes = Encoding.UTF8.GetBytes(password);
        //    byte[] hash = sha256.ComputeHash(bytes);
        //    StringBuilder result = new StringBuilder();
        //    for (int i = 0; i < hash.Length; i++)
        //    {
        //        result.Append(hash[i].ToString("x2"));
        //    }
        //    return result.ToString();
        //}

        //[HttpPost]
        //public IActionResult AgentCreate(AgentCreateDTO AgentCreateDTO)
        //{
        //    var objcheck = _context.Agents.SingleOrDefault(opt => opt.AgentuserId == AgentCreateDTO.AgentuserId && opt.IsDeleted == false);

        //    var existingAgents = _context.Agents.Where(opt => opt.IsDeleted == false).ToList();

        //    foreach (var agent in existingAgents)
        //    {
        //        var theaterNames = agent.TheatreName.Split(',').Select(x => x.Trim()).ToList();
        //        var newTheaterNames = AgentCreateDTO.TheatreName.Split(',').Select(x => x.Trim()).ToList();


        //        foreach (var newTheaterName in newTheaterNames)
        //        {
        //            foreach (var theaterName in theaterNames)
        //            {
        //                if (theaterName.Equals(newTheaterName, StringComparison.OrdinalIgnoreCase))
        //                {
        //                    if (agent.Agentrole.Equals("Primary", StringComparison.OrdinalIgnoreCase) && AgentCreateDTO.Agentrole.Equals("Primary", StringComparison.OrdinalIgnoreCase))
        //                    {
        //                        return Accepted(new Confirmation { Status = "AlreadyExist", ResponseMsg = "A 'Primary' agent with the same TheatreName already exists!" });
        //                    }
        //                    else if (agent.Agentrole.Equals("Backup", StringComparison.OrdinalIgnoreCase) && AgentCreateDTO.Agentrole.Equals("Backup", StringComparison.OrdinalIgnoreCase))
        //                    {
        //                        return Accepted(new Confirmation { Status = "AlreadyExist", ResponseMsg = "A 'Backup' agent with the same TheatreName already exists!" });
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    try
        //    {
        //        if (objcheck == null)
        //        {
        //            Agent Agent = new Agent();
        //            Agent.AgentName = AgentCreateDTO.AgentName;
        //            Agent.Agentrole = AgentCreateDTO.Agentrole;
        //            Agent.Agentrole = AgentCreateDTO.Agentrole;
        //            Agent.StateId = AgentCreateDTO.StateId;
        //            //Agent.Statename = AgentCreateDTO.Statename;
        //            Agent.Cityname = AgentCreateDTO.Cityname;
        //            Agent.TheatreName = AgentCreateDTO.TheatreName;
        //            Agent.AgentPhoneNumber = AgentCreateDTO.AgentPhoneNumber;
        //            Agent.Address = AgentCreateDTO.Address;
        //            Agent.EmailId = AgentCreateDTO.EmailId;
        //            Agent.ProfilePhoto = AgentCreateDTO.ProfilePhoto;
        //            Agent.AgentuserId = AgentCreateDTO.AgentuserId;
        //            //Agent.PassWord = EncryptPassword(AgentCreateDTO.PassWord);
        //            Agent.PassWord = AgentCreateDTO.PassWord;
        //            Agent.CreatedBy = AgentCreateDTO.CreatedBy;
        //            Agent.CreatedOn = System.DateTime.Now;
        //            var obj = _AgentRepo.Insert(Agent);
        //            return Ok(obj);
        //        }
        //        else if (objcheck != null)
        //        {
        //            return Accepted(new Confirmation { Status = "Duplicate", ResponseMsg = "Duplicate User Id..!" });
        //        }
        //        return Accepted(new Confirmation { Status = "Error", ResponseMsg = "Something unexpected!" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }


        //}

        [HttpPost]
        public IActionResult AgentCreate(AgentCreateDTO AgentCreateDTO)
        {
            var objcheck = _context.Agents.SingleOrDefault(opt => opt.AgentuserId == AgentCreateDTO.AgentuserId && opt.IsDeleted == false);

            var existingAgents = _context.Agents.Where(opt => opt.IsDeleted == false).ToList();

            foreach (var agent in existingAgents)
            {
                var theaterNames = agent.TheatreName.Split(',').Select(x => x.Trim()).ToList();
                var newTheaterNames = AgentCreateDTO.TheatreName.Split(',').Select(x => x.Trim()).ToList();


                foreach (var newTheaterName in newTheaterNames)
                {
                    foreach (var theaterName in theaterNames)
                    {
                        if (theaterName.Equals(newTheaterName, StringComparison.OrdinalIgnoreCase))
                        {
                            if (agent.Agentrole.Equals("Primary", StringComparison.OrdinalIgnoreCase) && AgentCreateDTO.Agentrole.Equals("Primary", StringComparison.OrdinalIgnoreCase))
                            {
                                return Accepted(new Confirmation { Status = "AlreadyExist", ResponseMsg = "A 'Primary' agent with the same TheatreName already exists!" });
                            }
                            else if (agent.Agentrole.Equals("Backup", StringComparison.OrdinalIgnoreCase) && AgentCreateDTO.Agentrole.Equals("Backup", StringComparison.OrdinalIgnoreCase))
                            {
                                return Accepted(new Confirmation { Status = "AlreadyExist", ResponseMsg = "A 'Backup' agent with the same TheatreName already exists!" });
                            }
                        }
                    }
                }
            }
            try
            {
                if (objcheck == null)
                {
                    Agent Agent = new Agent();
                    Agent.AgentName = AgentCreateDTO.AgentName;
                    Agent.Agentrole = AgentCreateDTO.Agentrole;
                    Agent.Agentrole = AgentCreateDTO.Agentrole;
                    Agent.StateId = AgentCreateDTO.StateId;
                    Agent.Cityname = AgentCreateDTO.Cityname;
                    Agent.TheatreName = AgentCreateDTO.TheatreName;
                    Agent.AgentPhoneNumber = AgentCreateDTO.AgentPhoneNumber;
                    Agent.Address = AgentCreateDTO.Address;
                    Agent.EmailId = AgentCreateDTO.EmailId;
                    Agent.ProfilePhoto = AgentCreateDTO.ProfilePhoto;
                    Agent.AgentuserId = AgentCreateDTO.AgentuserId;
                    Agent.PassWord = AgentCreateDTO.PassWord;
                    Agent.CreatedBy = AgentCreateDTO.CreatedBy;
                    Agent.CreatedOn = System.DateTime.Now;
                    var insertedAgent = _AgentRepo.Insert(Agent);

                    // Create AgentMapping entries
                    foreach (var theaterName in AgentCreateDTO.TheatreName.Split(',').Select(x => x.Trim()))
                    {
                        AgentMapping agentMapping = new AgentMapping
                        {
                            AgentId = insertedAgent.AgentId,
                            StateId = AgentCreateDTO.StateId,
                            AgentName = AgentCreateDTO.AgentName,
                            Agentrole = AgentCreateDTO.Agentrole,
                            AgentPhoneNumber = AgentCreateDTO.AgentPhoneNumber,
                            EmailId = AgentCreateDTO.EmailId,
                            TheatreName = theaterName,
                            TaskAccepted = false, 
                            TaskRejected = false, 
                            IsTimeExpired = false, // or set based on your requirement
                            CreatedBy = AgentCreateDTO.CreatedBy,
                            CreatedOn = System.DateTime.Now
                        };
                        _context.AgentMappings.Add(agentMapping);
                    }

                    _context.SaveChanges();

                    return Ok(insertedAgent);
                }
                else if (objcheck != null)
                {
                    return Accepted(new Confirmation { Status = "Duplicate", ResponseMsg = "Duplicate User Id..!" });
                }
                return Accepted(new Confirmation { Status = "Error", ResponseMsg = "Something unexpected!" });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }



        //[HttpPost]
        //public IActionResult AgentCreate(AgentCreateDTO AgentCreateDTO)
        //{
        //    var objcheck = _context.Agents.SingleOrDefault(opt => opt.AgentuserId == AgentCreateDTO.AgentuserId && opt.IsDeleted == false);
        //    //Not Create Duplicate Theatre name for Primary and backup agent
        //    var existingPrimaryAgent = _context.Agents
        //.SingleOrDefault(opt => opt.TheatreName == AgentCreateDTO.TheatreName
        //    && opt.Agentrole == "Primary"
        //    && opt.IsDeleted == false);

        //    var existingBackupAgent = _context.Agents
        //        .SingleOrDefault(opt => opt.TheatreName == AgentCreateDTO.TheatreName
        //            && opt.Agentrole == "Backup"
        //            && opt.IsDeleted == false);

        //    if (AgentCreateDTO.Agentrole == "Primary" && existingPrimaryAgent != null)
        //    {

        //        return Accepted(new Confirmation { Status = "AlreadyExist", ResponseMsg = "A 'Primary' agent with the same TheatreName is already exists!" });
        //    }
        //    else if (AgentCreateDTO.Agentrole == "Backup" && existingBackupAgent != null)
        //    {

        //        return Accepted(new Confirmation { Status = "AlreadyExist", ResponseMsg = "A 'Backup' agent with the same TheatreName is already exists!" });
        //    }


        //    try
        //    {
        //        if (objcheck == null)
        //        {
        //            Agent Agent = new Agent();
        //            Agent.AgentName = AgentCreateDTO.AgentName;
        //            Agent.Agentrole = AgentCreateDTO.Agentrole;
        //            Agent.Agentrole = AgentCreateDTO.Agentrole;
        //            Agent.StateId = AgentCreateDTO.StateId;
        //           // Agent.Statename = AgentCreateDTO.Statename;
        //            Agent.Cityname = AgentCreateDTO.Cityname;
        //            Agent.TheatreName = AgentCreateDTO.TheatreName;
        //            Agent.AgentPhoneNumber = AgentCreateDTO.AgentPhoneNumber;
        //            Agent.Address = AgentCreateDTO.Address;
        //            Agent.EmailId = AgentCreateDTO.EmailId;
        //            Agent.ProfilePhoto = AgentCreateDTO.ProfilePhoto;
        //            Agent.AgentuserId = AgentCreateDTO.AgentuserId;
        //            //Agent.PassWord = EncryptPassword(AgentCreateDTO.PassWord);
        //            Agent.PassWord = AgentCreateDTO.PassWord;
        //            Agent.CreatedBy = AgentCreateDTO.CreatedBy;
        //            Agent.CreatedOn = System.DateTime.Now;
        //            var obj = _AgentRepo.Insert(Agent);
        //            return Ok(obj);
        //        }
        //        else if (objcheck != null)
        //        {
        //            return Accepted(new Confirmation { Status = "Duplicate", ResponseMsg = "Duplicate User Id..!" });
        //        }
        //        return Accepted(new Confirmation { Status = "Error", ResponseMsg = "Something unexpected!" });

        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }

        //}

        [HttpGet("{userId}")]
        public ActionResult AgentPassListbyUserId(int userId)
        {
            try
            {
                var list = (from u in _context.Agents
                            join a in _context.Users on u.CreatedBy equals a.UserId

                            select new
                            {
                                a.UserId,
                                u.AgentId,
                                u.AgentName,
                                u.Agentrole,
                                u.CreatedBy,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.UserId == userId).ToList();
                int totalRecords = list.Count();
                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }


        [HttpGet]
        public ActionResult GetAgentList()
        {
            try
            {
                var list = (from u in _context.Agents
                                //join c in _context.Citys on u.CityId equals c.CityId
                            join s in _context.States on u.StateId equals s.StateId
                            //join p in _context.Areas on u.AreaId equals p.AreaId
                            //join p in _context.ScreenList on u.StateId equals p.StateId

                            select new
                            {
                                u.AgentId,
                                u.StateId,
                                s.StateName,
                                u.Cityname,
                                u.TheatreName,
                                u.AgentName,
                                u.Agentrole,
                                u.AgentPhoneNumber,
                                u.Address,
                                u.EmailId,
                                u.ProfilePhoto,
                                u.AgentuserId,
                                u.PassWord,
                                u.NotificationSent,
                                u.NotifiedOn,
                                u.TaskAccepted,
                                u.CreatedBy,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false).ToList();


                int totalRecords = list.Count();


                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{stateId}")]
        public ActionResult GetAgentListbyStateId(int stateId)
        {
            try
            {
                var list = (from u in _context.Agents
                            join s in _context.States on u.StateId equals s.StateId

                            select new
                            {
                                u.AgentId,
                                u.StateId,
                                s.StateName,
                                u.Cityname,
                                u.TheatreName,
                                u.AgentName,
                                u.Agentrole,
                                u.AgentPhoneNumber,
                                u.Address,
                                u.EmailId,
                                u.ProfilePhoto,
                                u.AgentuserId,
                                u.PassWord,
                                u.CreatedBy,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.StateId == stateId).ToList();


                int totalRecords = list.Count();


                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{UserId}")]
        public ActionResult GetAgentListbyuserid(int UserId)
        {
            try
            {
                var list = (from u in _context.Agents
                                //join a in _context.Users on u.CreatedBy equals a.UserId
                            join s in _context.States on u.StateId equals s.StateId
                            where u.IsDeleted == false
                            join p in _context.StateUser on u.StateId equals p.StateId

                            select new
                            {
                                u.AgentId,
                                s.StateId,
                                s.StateName,
                                u.Cityname,
                                u.TheatreName,
                                u.AgentName,
                                u.Agentrole,
                                u.AgentPhoneNumber,
                                u.Address,
                                u.EmailId,
                                u.ProfilePhoto,
                                u.AgentuserId,
                                u.PassWord,
                                u.NotificationSent,
                                u.NotifiedOn,
                                u.TaskAccepted,
                                p.UserId,
                                u.DeleteRequested,
                                u.AdminDeletionResponse,
                                u.CreatedBy,
                                p.IsDeleted,
                            }).Where(x => x.IsDeleted == false && x.UserId == UserId && x.DeleteRequested == false).ToList();


                int totalRecords = list.Count();


                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //[HttpGet("{userId}")]
        //public ActionResult GetCityListbyuserId(int userId)
        //{
        //    try
        //    {
        //        var list = (from u in _context.Citys
        //                    join a in _context.Users on u.StateId equals a.StateId

        //                    select new
        //                    {
        //                        u.CityId,
        //                        u.CityName,
        //                        a.StateId,
        //                        u.CreatedBy,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false && x.StateId == userId).ToList();

        //        int totalRecords = list.Count();

        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }

        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        //single list

        [HttpGet("{AgentId}")]
        public ActionResult GetSingleAgent(int AgentId)
        {
            try
            {
                var singleAgent = _AgentRepo.SelectById(AgentId);
                return Ok(singleAgent);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //update
        [HttpPost]
        public ActionResult updateAgent(AgentUpdateDTO AgentUpdateDTO)
        {

            var objcheck = _context.Agents.SingleOrDefault(opt => opt.AgentuserId == AgentUpdateDTO.AgentuserId && opt.IsDeleted == false);

            var existingAgents = _context.Agents.Where(opt => opt.IsDeleted == false).ToList();


            foreach (var agent in existingAgents)
            {
                if (agent.AgentuserId == AgentUpdateDTO.AgentuserId)
                {
                    continue;
                }

                var theaterNames = agent.TheatreName.Split(',').Select(x => x.Trim()).ToList();
                var newTheaterNames = AgentUpdateDTO.TheatreName.Split(',').Select(x => x.Trim()).ToList();


                foreach (var newTheaterName in newTheaterNames)
                {
                    foreach (var theaterName in theaterNames)
                    {
                        if (theaterName.Equals(newTheaterName, StringComparison.OrdinalIgnoreCase))
                        {
                            if (agent.Agentrole.Equals("Primary", StringComparison.OrdinalIgnoreCase) && AgentUpdateDTO.Agentrole.Equals("Primary", StringComparison.OrdinalIgnoreCase))
                            {
                                return Accepted(new Confirmation { Status = "AlreadyExist", ResponseMsg = "A 'Primary' agent with the same TheatreName already exists!" });
                            }
                            else if (agent.Agentrole.Equals("Backup", StringComparison.OrdinalIgnoreCase) && AgentUpdateDTO.Agentrole.Equals("Backup", StringComparison.OrdinalIgnoreCase))
                            {
                                return Accepted(new Confirmation { Status = "AlreadyExist", ResponseMsg = "A 'Backup' agent with the same TheatreName already exists!" });
                            }
                        }
                    }
                }
            }

            try
            {
                var objAgent = _context.Agents.SingleOrDefault(opt => opt.AgentId == AgentUpdateDTO.AgentId);
                objAgent.AgentName = AgentUpdateDTO.AgentName;
                objAgent.Agentrole = AgentUpdateDTO.Agentrole;
                objAgent.Cityname = AgentUpdateDTO.Cityname;
                objAgent.TheatreName = AgentUpdateDTO.TheatreName;
                objAgent.AgentPhoneNumber = AgentUpdateDTO.AgentPhoneNumber;
                objAgent.Address = AgentUpdateDTO.Address;
                objAgent.EmailId = AgentUpdateDTO.EmailId;
                objAgent.ProfilePhoto = AgentUpdateDTO.ProfilePhoto;
                objAgent.AgentuserId = AgentUpdateDTO.AgentuserId;
                objAgent.PassWord = AgentUpdateDTO.PassWord;
                //objAgent.PassWord = EncryptPassword(AgentUpdateDTO.PassWord);
                objAgent.UpdatedBy = AgentUpdateDTO.UpdatedBy;
                objAgent.UpdatedOn = System.DateTime.Now;
                var obj = _AgentRepo.Update(objAgent);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }


        [HttpGet("{Id}/{DeletedBy}")]
        public ActionResult DeleteAgent(int Id, int DeletedBy)
        {
            try
            {
                var objabout = _context.Agents.SingleOrDefault(opt => opt.AgentId == Id);
                objabout.IsDeleted = true;
                objabout.UpdatedBy = DeletedBy;
                objabout.UpdatedOn = System.DateTime.Now;
                _context.SaveChanges();
                return Ok(objabout);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{Id}/{DeletedBy}")]
        public IActionResult SetDeleteRequest(int Id, int DeletedBy)
        {
            try
            {
                var agentToUpdate = _context.Agents.SingleOrDefault(u => u.AgentId == Id);

                if (agentToUpdate != null)
                {
                    agentToUpdate.DeleteRequested = true;
                    agentToUpdate.UpdatedOn = System.DateTime.Now;
                    agentToUpdate.UpdatedBy = DeletedBy;
                    _context.SaveChanges();

                }
                return Ok(agentToUpdate);

            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult DeleteAgentList()
        {
            try
            {
                var list = (from u in _context.Agents
                            join s in _context.States on u.StateId equals s.StateId
                            where u.DeleteRequested == true && u.IsDeleted == false

                            select new
                            {
                                u.AgentId,
                                u.AgentName,
                                u.StateId,
                                u.TheatreName,
                                s.StateName,
                                u.Cityname,

                            }).Distinct().ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });

            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> SendNotifications(string fcmToken, string message, string title)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://fcm.googleapis.com");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=AAAAuy-qyK0:APA91bGSfg44Q2EbjZGpoAaDvQkJn9bshg1NVhV15pc7R3Egb8wU8ZZDBhXkWb3Q-jNEkXT0H-XFS5VBnkmVh2bCuBC14Kh3o7cxrQLwaK9lq4rgUeuHzxfOAF9h_OyRJrp4Czf2knE_");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Sender", "id=803958605997");

                    var data = new
                    {
                        to = fcmToken,
                        notification = new
                        {
                            body = message,
                            head = title
                        }
                    };

                    var json = JsonConvert.SerializeObject(data);
                    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                    var result = await client.PostAsync("/fcm/send", httpContent);

                    if (result.IsSuccessStatusCode)
                    {
                        return Ok("Success");
                    }
                    else
                    {
                        return Ok("Unsuccessful");
                    }
                }
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> PrimaryAgentsForPushNotification()
        //{
        //    try
        //    {
        //        var agentService = new AgentRepository(_context);

        //        var resultList = await agentService.RunAgentProcessing();

        //        List<object> data = new List<object>();
        //        List<object> errorMessages = new List<object>();

        //        foreach (var result in resultList)
        //        {
        //            if (result.GetType().GetProperty("Status") != null && result.GetType().GetProperty("ResponseMsg") != null)
        //            {
        //                errorMessages.Add(result);
        //            }
        //            else
        //            {
        //                data.Add(result);

        //                var notification = (dynamic)result;
        //                var fcmToken = notification.FCMToken;

        //                await SendNotifications(fcmToken, "Theatre Assigned", "Hello");

        //            }
        //        }

        //        BackgroundJob.Schedule(() => PrimaryAgentNoResponseBackupAgentAssign(), TimeSpan.FromHours(24));

        //        var response = new
        //        {
        //            Data = data,
        //            //ErrorMessages = errorMessages
        //        };
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}




        [HttpGet]
        public async Task<IActionResult> PrimaryAgentsForPushNotification()
        {
            try
            {
                var agentService = new AgentRepository(_context);


                var resultList = await agentService.RunAgentProcessing();


                List<object> data = new List<object>();
                List<object> errorMessages = new List<object>();


                foreach (var result in resultList)
                {
                    if (result.GetType().GetProperty("Status") != null && result.GetType().GetProperty("ResponseMsg") != null)
                    {
                        errorMessages.Add(result);
                    }
                    else
                    {
                        data.Add(result);


                        var notification = (dynamic)result;
                        var fcmToken = notification.FCMToken;
                        //var mailTo = notification.Mail;
                        var mailTo = notification.EmailId;
                        string subject = "Important Notice: Non-Responsive Auto-Generated Email";
                        string body = "Dear Recipient,\r\n\r\nThis auto-generated email serves the sole purpose of maintaining records and tracking information. Kindly refrain from replying to this message, as responses will not be monitored or processed.\r\n\r\nThank you for your understanding.\r\n\r\nBest regards,\r\n Ommr";

                        await SendNotifications(fcmToken, "Theatre Assigned", "Hello");
                        await agentService.SendEmail("ommr.ibl@gmail.com", mailTo, subject, body);


                    }
                }

                //BackgroundJob.Schedule(() => PrimaryAgentNoResponseBackupAgentAssign(), TimeSpan.FromHours(24));
                BackgroundJob.Schedule(() => PrimaryAgentNoResponseBackupAgentAssign(), TimeSpan.FromMinutes(2));


                var response = new
                {
                    Data = data,
                    //ErrorMessages = errorMessages
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //[HttpGet("{AgentId}")]
        //public IActionResult AllAgentAccept(int AgentId)
        //{
        //    try
        //    {
        //        var agent = _context.Agents.FirstOrDefault(u => u.AgentId == AgentId && u.IsDeleted == false);

        //        if (agent == null)
        //        {
        //            return Accepted(new Confirmation { Status = "error", ResponseMsg = "Primary agent not found for the specified AgentId." });
        //        }

        //        if (agent.IsTimeExpired == true)
        //        {
        //            return Accepted(new Confirmation { Status = "error", ResponseMsg = "You didn't give any response in the first 30 minutes." });
        //        }

        //        if (!agent.TaskAccepted)
        //        {
        //            // If TaskAccepted is false, return no data.
        //            return Ok(new { data = new List<object>(), recordsTotal = 0, recordsFiltered = 0 });
        //        }

        //        // Continue with your existing logic to fetch and return data.
        //        agent.NotificationSent = true;
        //        _context.SaveChanges();

        //        var theatreNames = agent.TheatreName.Split(',').Select(t => t.Trim()).ToList();

        //        var list = _context.AdScreen
        //             .Where(u => theatreNames.Contains(u.TheatreName) && !u.IsDeleted)
        //             .Select(u => new
        //             {
        //                 u.StateId,
        //                 u.State,
        //                 u.TheatreName,
        //                 //u.Screen,
        //                 AgentId,
        //                 agent.AgentName
        //             })
        //             .Distinct()
        //             .ToList();

        //        int totalRecords = list.Count;
        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        /// <summary>
        /// Accept Button API
        /// </summary>

        [HttpGet("{AgentId}")]
        public IActionResult Activate(int AgentId)
        {
            try
            {
                var agent = _context.Agents.FirstOrDefault(u => u.AgentId == AgentId && u.IsDeleted == false);

                if (agent == null)
                {
                    return Accepted(new Confirmation { Status = "error", ResponseMsg = "Agent not found for the specified AgentId." });
                }

                agent.TaskAccepted = true;
                _context.SaveChanges();

                return Ok(new Confirmation { Status = "success", ResponseMsg = "Task for the agent has been activated successfully." });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        /// <summary>
        ///After Flutter login API
        /// </summary>
        /// 
        [HttpGet("{AgentId}")]
        public IActionResult AllAgentAccept(int AgentId)
        {
            try
            {
                var agent = _context.Agents.FirstOrDefault(u => u.AgentId == AgentId && u.IsDeleted == false);

                if (agent == null)
                {
                    return Accepted(new Confirmation { Status = "error", ResponseMsg = "Primary agent not found for the specified AgentId." });
                }

                if (agent.IsTimeExpired == true)
                {
                    return Accepted(new Confirmation { Status = "error", ResponseMsg = "You didn't give any response in the first 30 minutes." });
                }

                if (!agent.NotificationSent)
                {
                    // If NotificationSent is false, return no data.
                    return Ok(new { data = new List<object>(), recordsTotal = 0, recordsFiltered = 0 });
                }

                // If TaskAccepted is true, include theater names.
                if (agent.TaskAccepted)
                {
                    agent.NotificationSent = true;
                    _context.SaveChanges();

                    var theatreNames = agent.TheatreName.Split(',').Select(t => t.Trim()).ToList();

                    var list = _context.AdScreen
                        .Where(u => theatreNames.Contains(u.TheatreName) && !u.IsDeleted)
                        .Select(u => new
                        {
                            u.StateId,
                            u.State,
                            u.TheatreName,
                            //u.Screen,
                            AgentId,
                            agent.AgentName
                        })
                        .Distinct()
                        .ToList();

                    int totalRecords = list.Count;
                    return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
                }
                else
                {
                    // If TaskAccepted is false, return no data.
                    return Ok(new { data = new List<object>(), recordsTotal = 0, recordsFiltered = 0 });
                }
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{AgentId}")]
        public async Task<IActionResult> PrimaryAgentRejectNotificationToBackup(int AgentId)
        {
            try
            {
                var agentService = new AgentRepository(_context);
                var agent = _context.Agents.FirstOrDefault(u => u.AgentId == AgentId);

                if (agent == null)
                {
                    return Accepted(new Confirmation { Status = "error", ResponseMsg = "No Primary Agent Present!." });
                }

                var uniqueNotifications = new HashSet<string>(); // Using HashSet to keep track of unique notifications
                var resultList = new List<object>();

                var primaryAgentTheatreNames = agent.TheatreName.Split(',')
                                                     .Select(t => t.Trim())
                                                     .ToList();

                foreach (var theatreName in primaryAgentTheatreNames)
                {
                    var pushNotifications = _context.PushNotifications
                        .Where(u => !u.IsDeleted)
                        .ToList();

                    var backupAgents = _context.Agents
                         .Where(a => !a.IsDeleted && a.Agentrole == "Backup")
                         .AsEnumerable()
                         .Where(a => a.TheatreName.Split(',').Select(t => t.Trim()).Contains(theatreName, StringComparer.OrdinalIgnoreCase))
                         .ToList();

                    var filteredNotifications = pushNotifications
                         .Join(backupAgents,
                             p => p.AgentId,
                             a => a.AgentId,
                             (p, a) => new
                             {
                                 p.AgentId,
                                 p.DeviceId,
                                 p.IMEINumber,
                                 p.FCMToken,
                                 a.EmailId
                             })
                         .ToList();

                    var set = new HashSet<object>(resultList);
                   
                    foreach (var item in filteredNotifications)
                    {


                        var backupAg = _context.Agents.FirstOrDefault(z => z.EmailId == item.EmailId);
                        backupAg.NotificationSent = true;
                        _context.SaveChanges();


                        var notificationKey = $"{item.DeviceId}_{item.IMEINumber}_{item.FCMToken}";
                        if (!uniqueNotifications.Contains(notificationKey))
                        {
                            uniqueNotifications.Add(notificationKey);
                            set.Add(new { data = item });
                            await SendNotifications(item.FCMToken, "Theatre Assigned", "Hello");


                            var mailTo = item.EmailId;
                            string subject = "Important Notice: Non-Responsive Auto-Generated Email";
                            string body = "Dear Recipient,\r\n\r\nThis auto-generated email serves the sole purpose of maintaining records and tracking information. Kindly refrain from replying to this message, as responses will not be monitored or processed.\r\n\r\nThank you for your understanding.\r\n\r\nBest regards,\r\n Ommr";


                            await agentService.SendEmail("ommr.ibl@gmail.com", mailTo, subject, body);
                        }
                    }

                    resultList = set.ToList();
                }

                return Ok(resultList);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }


        [HttpGet("{AgentId}/{TheaterName}")]
        public async Task<IActionResult> RejectedTheatreNotificationToBackup(int AgentId, string TheaterName)
        {
            var agentService = new AgentRepository(_context);

            var priAgent = _context.AgentMappings.FirstOrDefault(a => a.AgentId == AgentId);
            priAgent.TaskRejected = true;
            _context.SaveChanges();

            var backUpAgents = _context.AgentMappings.FirstOrDefault(q => q.TheatreName == TheaterName && q.Agentrole == "Backup");

            if (backUpAgents != null)
            {                
                var fcm = _context.PushNotifications.Where(w => w.AgentId == backUpAgents.AgentId).Select(q=> q.FCMToken).FirstOrDefault();
                await SendNotifications(fcm, "Theatre Assigned", "Hello");
                backUpAgents.NotifiedOn = DateTime.Now;
                _context.SaveChanges();

                var mailTo = backUpAgents.EmailId;
                string subject = "Important Notice: Non-Responsive Auto-Generated Email";
                string body = "Dear Recipient,\r\n\r\nThis auto-generated email serves the sole purpose of maintaining records and tracking information. Kindly refrain from replying to this message, as responses will not be monitored or processed.\r\n\r\nThank you for your understanding.\r\n\r\nBest regards,\r\n Ommr";

                await agentService.SendEmail("ommr.ibl@gmail.com", mailTo, subject, body);
            }
            else
            {
                Ok("No Backup Agent is assigned to this Theatre");
            }

            var theatresNames = _context.AgentMappings.Where(z => z.AgentId == AgentId && z.TaskRejected == false && z.Agentrole == "Primary").Select(a=> a.TheatreName).ToList();

            return Ok(theatresNames);




            //var agent = _context.Agents.FirstOrDefault(a => a.AgentId == AgentId);
            //if (agent != null)
            //{
            //    var theatrenames = agent.TheatreName.Split(',').Select(t => t.Trim()).ToList();

            //    foreach (var theatre in theatrenames)
            //    {
            //        var backupAgents = _context.Agents
            //            .Where(a => !a.IsDeleted && a.Agentrole == "Backup")
            //            .AsEnumerable()
            //            .Where(a => a.TheatreName.Split(',').Select(t => t.Trim()).Contains(theatre, StringComparer.OrdinalIgnoreCase))
            //            .ToList();


            //        foreach (var bkAgent in backupAgents)
            //        {
            //            var fcm = _context.PushNotifications.Where(a => a.AgentId == bkAgent.AgentId).Select(z => z.FCMToken).FirstOrDefault();

            //            var backupAg = _context.Agents.FirstOrDefault();
            //            backupAg.NotificationSent = true;
            //            var 

            //            _context.SaveChanges();


            //            //var notificationKey = $"{item.DeviceId}_{item.IMEINumber}_{item.FCMToken}";
            //            //if (!uniqueNotifications.Contains(notificationKey))
            //            //{
            //            //    uniqueNotifications.Add(notificationKey);
            //            //    set.Add(new { data = item });
            //            //    await SendNotifications(item.FCMToken, "Theatre Assigned", "Hello");

            //            //}

            //            await SendNotifications(fcm, "Theatre Assigned", "Hello");


            //        }
            //    }
            //}
            //else
            //{

            //}


            ////var backupagents = _context.Agents.Where(a => a.TheatreName == TheaterName && a.Agentrole == "Backup").ToList();
            //var backupagents = _context.Agents.Where(a => a.TheatreName == TheaterName && a.Agentrole == "Backup").ToList();


            //return Ok();
        }

        [HttpGet]
        public IActionResult ReSendNotificationToUnsendPrimaryAgents()
        {
            var unsendAgents = _context.Agents.Where(u => u.NotificationSent == false && u.Agentrole == "Primary");
            return Ok(unsendAgents);
        }

        [HttpGet]
        public async Task<IActionResult> PrimaryAgentNoResponseBackupAgentAssign()
        {
            try
            {
                var agents = _context.Agents.Where(u => u.IsDeleted == false && u.NotificationSent == true && u.TaskAccepted == false && u.Agentrole == "Primary")
                                .ToList();


                var agentService = new AgentRepository(_context);
                var resultList = new List<object>();


                // Initialize the HashSet for unique email addresses
                var emailSet = new HashSet<string>();


                foreach (var agent in agents)
                {
                    agent.IsTimeExpired = true;
                    agent.UpdatedOn = DateTime.Now;
                    _context.SaveChanges();


                    var primaryAgentTheatreNames = agent.TheatreName.Split(',')
                                                      .Select(t => t.Trim())
                                                      .ToList();


                    foreach (var theatreName in primaryAgentTheatreNames)
                    {
                        var pushNotifications = _context.PushNotifications
                            .Where(u => !u.IsDeleted)
                            .ToList();


                        var backupAgents = _context.Agents
                              .Where(u => !u.IsDeleted
                                  && u.Agentrole == "Backup")
                              .AsEnumerable()
                              .Where(u => u.TheatreName.Split(',').Select(t => t.Trim()).Contains(theatreName, StringComparer.OrdinalIgnoreCase))
                              .ToList();


                        var filteredNotifications = pushNotifications
                              .Join(backupAgents,
                                  p => p.AgentId,
                                  a => a.AgentId,
                                  (p, a) => new
                                  {
                                      p.AgentId,
                                      p.DeviceId,
                                      p.IMEINumber,
                                      p.FCMToken,
                                      a.EmailId,
                                  })
                              .ToList();


                        foreach (var item in filteredNotifications)
                        {
                            if (emailSet.Add(item.EmailId))
                            {
                                await SendNotifications(item.FCMToken, "Theatre Assigned", "Hello");
                                var backupAg = _context.Agents.FirstOrDefault(z => z.EmailId == item.EmailId);
                                backupAg.NotificationSent = true;
                                backupAg.NotifiedOn = DateTime.Now;
                                _context.SaveChanges();


                                var mailTo = item.EmailId;
                                string subject = "Important Notice: Non-Responsive Auto-Generated Email";
                                string body = "Dear Recipient,\r\n\r\nThis auto-generated email serves the sole purpose of maintaining records and tracking information. Kindly refrain from replying to this message, as responses will not be monitored or processed.\r\n\r\nThank you for your understanding.\r\n\r\nBest regards,\r\n Ommr";


                                await agentService.SendEmail("ommr.ibl@gmail.com", mailTo, subject, body);


                                // Add the processed data to resultList
                                resultList.Add(new { data = item });
                            }
                        }
                    }
                }


                return Ok(resultList);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> PrimaryAgentNoResponseBackupAgentAssign()
        //{
        //    try
        //    {
        //        var agents = _context.Agents.Where(u => u.IsDeleted == false && u.NotificationSent == true && u.TaskAccepted == false && u.Agentrole == "Primary")
        //                        .ToList();


        //        var resultList = new List<object>();


        //        foreach (var agent in agents)
        //        {
        //            agent.IsTimeExpired = true;
        //            agent.UpdatedOn = DateTime.Now;
        //            _context.SaveChanges();

        //            //BackgroundJob.Schedule(() => BackupAgentNoResponse(), TimeSpan.FromMinutes(1));

        //            var primaryAgentTheatreNames = agent.TheatreName.Split(',')
        //                                             .Select(t => t.Trim())
        //                                             .ToList();


        //            foreach (var theatreName in primaryAgentTheatreNames)
        //            {
        //                var pushNotifications = _context.PushNotifications
        //                    .Where(u => !u.IsDeleted)
        //                    .ToList();


        //                var backupAgents = _context.Agents
        //                     .Where(u => !u.IsDeleted
        //                         && u.Agentrole == "Backup")
        //                     .AsEnumerable()
        //                     .Where(u => u.TheatreName.Split(',').Select(t => t.Trim()).Contains(theatreName, StringComparer.OrdinalIgnoreCase))
        //                     .ToList();


        //                var filteredNotifications = pushNotifications
        //                     .Join(backupAgents,
        //                         p => p.AgentId,
        //                         a => a.AgentId,
        //                         (p, a) => new
        //                         {
        //                             p.AgentId,
        //                             p.DeviceId,
        //                             p.IMEINumber,
        //                             p.FCMToken
        //                         })
        //                     .ToList();


        //                var set = new HashSet<object>(resultList);
        //                foreach (var item in filteredNotifications)
        //                {
        //                    set.Add(new { data = item });
        //                    await SendNotifications(item.FCMToken, "Your message here", "Your title here");
        //                }
        //                resultList = set.ToList();
        //            }
        //        }


        //        return Ok(resultList);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        [HttpPost]
        public IActionResult BackupAgentNoResponse()
        {
            try
            {
                var agents = _context.Agents.Where(u => u.IsDeleted == false && u.NotificationSent == true && u.TaskAccepted == false && u.Agentrole == "Backup")
                                .ToList();


                foreach (var agent in agents)
                {
                    agent.IsTimeExpired = true;
                    agent.UpdatedOn = DateTime.Now;


                    _context.SaveChanges();
                }


                return Ok();
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult BackupAgentReject()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //[HttpGet]
        //public ActionResult AgentTaskInspection()
        //{
        //    try
        //    {
        //        var list = (from u in _context.AgentMappings
        //                    join s in _context.States on u.StateId equals s.StateId
                           
        //                    select new
        //                    {
        //                        u.AgentId,
        //                        u.StateId,
        //                        s.StateName,
        //                        u.TheatreName,
        //                        u.AgentName,
        //                        u.Agentrole,
        //                        u.AgentPhoneNumber,
        //                        u.EmailId,
        //                        u.NotifiedOn,
        //                        u.TaskAccepted,
        //                        u.TaskRejected,
        //                        u.CreatedBy,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false).ToList();


        //        int totalRecords = list.Count();


        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        [HttpGet("{fromDate}/{toDate}")]
        public ActionResult AgentTaskInspection(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var list = (from u in _context.AgentMappings
                            join s in _context.States on u.StateId equals s.StateId
                            where u.IsDeleted == false && u.CreatedOn.Date >= fromDate.Date && u.CreatedOn.Date <= toDate.Date

                            select new
                            {
                                u.AgentId,
                                u.StateId,
                                s.StateName,
                                u.TheatreName,
                                u.AgentName,
                                u.Agentrole,
                                u.AgentPhoneNumber,
                                u.EmailId,
                                u.NotifiedOn,
                                u.TaskAccepted,
                                u.TaskRejected,
                                u.CreatedBy,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false).OrderByDescending(t => t.AgentId);


                int totalRecords = list.Count();


                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }


        //[HttpGet("{UserId}")]
        //public ActionResult AgentTaskInspectionbyUserId(int UserId)
        //{
        //    try
        //    {
        //        var list = (from u in _context.AgentMappings
        //                    join s in _context.States on u.StateId equals s.StateId
        //                    join p in _context.StateUser on u.StateId equals p.StateId

        //                    select new
        //                    {
        //                        u.AgentId,
        //                        u.StateId,
        //                        s.StateName,
        //                        u.TheatreName,
        //                        u.AgentName,
        //                        u.Agentrole,
        //                        u.AgentPhoneNumber,
        //                        u.EmailId,
        //                        u.NotifiedOn,
        //                        u.TaskAccepted,
        //                        u.TaskRejected,
        //                        p.UserId,
        //                        u.CreatedBy,
        //                        p.IsDeleted,
        //                    }).Where(x => x.IsDeleted == false && x.UserId == UserId).ToList();


        //        int totalRecords = list.Count();


        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        [HttpGet("{fromDate}/{toDate}/{UserId}")]
        public ActionResult AgentTaskInspectionbyUserId(DateTime fromDate, DateTime toDate, int UserId)
        {
            try
            {
                var list = (from u in _context.AgentMappings
                            join s in _context.States on u.StateId equals s.StateId
                            join p in _context.StateUser on u.StateId equals p.StateId
                           // where !p.IsDeleted && p.UserId == UserId && u.CreatedOn >= fromDate && u.CreatedOn <= toDate
                            where p.IsDeleted == false && p.UserId == UserId && u.CreatedOn.Date >= fromDate.Date && u.CreatedOn.Date <= toDate.Date
                            select new
                            {
                                u.AgentId,
                                u.StateId,
                                s.StateName,
                                u.TheatreName,
                                u.AgentName,
                                u.Agentrole,
                                u.AgentPhoneNumber,
                                u.EmailId,
                                u.NotifiedOn,
                                u.TaskAccepted,
                                u.TaskRejected,
                                p.UserId,
                                u.CreatedBy,
                                p.IsDeleted,
                            }).ToList();


                int totalRecords = list.Count();


                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult ForgotPassword(string email)
        {

            var agentService = new AgentRepository(_context);
            var user = _context.Users.Where(z => z.Email == email).FirstOrDefault();

            if (user != null)
            {

                var mailTo = user.Email;
                string subject = "Important Notice: Password Retrieval Request";
                string body = $"Dear {user.FullName},\r\n\r\nThis auto-generated email serves the purpose of providing you with your forgotten password.\r\n\r\n Password: {user.Password} \r\n\r\nBest regards,\r\n Ommr";

                agentService.SendEmail("ommr.ibl@gmail.com", mailTo, subject, body);

            }
            else
            {
                return Ok("This E-mail is not registered");
            }
            return Ok("Your Password is sent to your registered email");
        }
    }
}

}