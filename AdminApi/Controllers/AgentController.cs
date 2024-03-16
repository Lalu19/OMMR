
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
using OfficeOpenXml.ConditionalFormatting.Contracts;
using Org.BouncyCastle.Asn1.Mozilla;
using OfficeOpenXml;
using System.IO;
using AdminApi.Models.App;
using Microsoft.EntityFrameworkCore;

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

        //[HttpPost]
        //public IActionResult UploadAgents(IFormFile file)
        //{
        //    try
        //    {
        //        if (file == null || file.Length == 0)
        //        {
        //            return BadRequest(new { status = "error", responseMsg = "No file uploaded" });
        //        }

        //        using (var package = new ExcelPackage(file.OpenReadStream()))
        //        {
        //            var worksheet = package.Workbook.Worksheets[0];

        //            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
        //            {
        //                var excelData = new Agent
        //                {
        //                    Statename = worksheet.Cells[row, 1].Value.ToString(),
        //                    Cityname = worksheet.Cells[row, 2].Value.ToString(),
        //                    TheatreName = worksheet.Cells[row, 3].Value.ToString(),
        //                    AgentName = worksheet.Cells[row, 4].Value.ToString(),
        //                    Agentrole = worksheet.Cells[row, 5].Value.ToString(),
        //                    AgentPhoneNumber = worksheet.Cells[row, 6].Value.ToString(),
        //                    EmailId = worksheet.Cells[row, 7].Value.ToString(),
        //                    Address = worksheet.Cells[row, 8].Value.ToString(),
        //                    AgentuserId = worksheet.Cells[row, 9].Value.ToString(),
        //                    PassWord = worksheet.Cells[row, 10].Value.ToString(),
        //                    CreatedOn = System.DateTime.Now
        //                };

        //                // Check duplicacy
        //                var existingAgentByPhoneNumber = _context.Agents.FirstOrDefault(opt => opt.AgentPhoneNumber == excelData.AgentPhoneNumber && opt.IsDeleted == false);
        //                var existingAgentByUserId = _context.Agents.FirstOrDefault(opt => opt.AgentuserId == excelData.AgentuserId && opt.IsDeleted == false);
        //                var existingAgentByEmail = _context.Agents.FirstOrDefault(opt => opt.EmailId == excelData.EmailId && opt.IsDeleted == false);

        //                if (existingAgentByPhoneNumber != null)
        //                {
        //                    return Accepted(new Confirmation { Status = "Duplicate", ResponseMsg = "An agent with the same phone number already exists!" });
        //                }

        //                if (existingAgentByUserId != null)
        //                {
        //                    return Accepted(new Confirmation { Status = "Duplicate", ResponseMsg = "An agent with the same user ID already exists!" });
        //                }

        //                if (existingAgentByEmail != null)
        //                {
        //                    return Accepted(new Confirmation { Status = "Duplicate", ResponseMsg = "An agent with the same Emailid already exists!" });
        //                }

        //                var existingAgents = _context.Agents.Where(opt => opt.IsDeleted == false).ToList();

        //                foreach (var agent in existingAgents)
        //                {
        //                    var theaterNames = agent.TheatreName.Split(',').Select(x => x.Trim()).ToList();
        //                    var newTheaterNames = excelData.TheatreName.Split(',').Select(x => x.Trim()).ToList();

        //                    foreach (var newTheaterName in newTheaterNames)
        //                    {
        //                        foreach (var theaterName in theaterNames)
        //                        {
        //                            if (theaterName.Equals(newTheaterName, StringComparison.OrdinalIgnoreCase))
        //                            {
        //                                if (agent.Agentrole.Equals("Primary", StringComparison.OrdinalIgnoreCase) && excelData.Agentrole.Equals("Primary", StringComparison.OrdinalIgnoreCase))
        //                                {
        //                                    return Accepted(new Confirmation { Status = "Duplicate", ResponseMsg = "A 'Primary' agent with the same TheatreName already exists!" });
        //                                }
        //                                else if (agent.Agentrole.Equals("Backup", StringComparison.OrdinalIgnoreCase) && excelData.Agentrole.Equals("Backup", StringComparison.OrdinalIgnoreCase))
        //                                {
        //                                    return Accepted(new Confirmation { Status = "Duplicate", ResponseMsg = "A 'Backup' agent with the same TheatreName already exists!" });
        //                                }
        //                            }
        //                        }
        //                    }
        //                }

        //                // Create a new record
        //                var stateEntity = _context.States.FirstOrDefault(s => s.StateName == excelData.Statename);
        //                if (stateEntity != null)
        //                {
        //                    excelData.StateId = stateEntity.StateId;
        //                }

        //                _context.Agents.Add(excelData);

        //                // Save the changes to get the AgentId
        //                _context.SaveChanges();

        //                // Create AgentMapping entries
        //                foreach (var theaterName in excelData.TheatreName.Split(',').Select(x => x.Trim()))
        //                {
        //                    AgentMapping agentMapping = new AgentMapping
        //                    {
        //                        AgentId = excelData.AgentId,
        //                        StateId = excelData.StateId,
        //                        AgentName = excelData.AgentName,
        //                        Agentrole = excelData.Agentrole,
        //                        AgentPhoneNumber = excelData.AgentPhoneNumber,
        //                        EmailId = excelData.EmailId,
        //                        TheatreName = theaterName,
        //                        TaskAccepted = false,
        //                        TaskRejected = false,
        //                        NotificationSent = false,
        //                        IsTimeExpired = false, // or set based on your requirement
        //                        CreatedOn = System.DateTime.Now
        //                    };
        //                    _context.AgentMappings.Add(agentMapping);
        //                }
        //            }

        //            _context.SaveChanges();
        //        }

        //        return Ok(new { status = "success", responseMsg = "Data saved successfully" });
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

            var existingAgentByPhoneNumber = _context.Agents.FirstOrDefault(opt => opt.AgentPhoneNumber == AgentCreateDTO.AgentPhoneNumber && opt.IsDeleted == false);
            var existingAgentByUserId = _context.Agents.FirstOrDefault(opt => opt.AgentuserId == AgentCreateDTO.AgentuserId && opt.IsDeleted == false);
            var existingAgentByEmail = _context.Agents.FirstOrDefault(opt => opt.EmailId == AgentCreateDTO.EmailId && opt.IsDeleted == false);

            if (existingAgentByPhoneNumber != null)
            {
                return Accepted(new Confirmation { Status = "AlreadyExist", ResponseMsg = "An agent with the same phone number already exists!" });
            }

            if (existingAgentByUserId != null)
            {
                return Accepted(new Confirmation { Status = "AlreadyExist", ResponseMsg = "An agent with the same user ID already exists!" });
            }
            if (existingAgentByEmail != null)
            {
                return Accepted(new Confirmation { Status = "AlreadyExist", ResponseMsg = "An agent with the same Emailid already exists!" });
            }

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
                            NotificationSent = false,
                            IsTimeExpired = false, // or set based on your requirement
                            CreatedBy = AgentCreateDTO.CreatedBy,
                            CreatedOn = System.DateTime.Now
                        };
                        _context.AgentMappings.Add(agentMapping);
                    }

                    //// _context.SaveChanges();
                    //foreach (var theaterName in AgentCreateDTO.TheatreName.Split(',').Select(x => x.Trim()))
                    //{
                    //    AgentReport agentReport = new AgentReport
                    //    {
                    //        AgentId = insertedAgent.AgentId,
                    //        StateId = AgentCreateDTO.StateId,
                    //        AgentName = AgentCreateDTO.AgentName,
                    //        Agentrole = AgentCreateDTO.Agentrole,
                    //        AgentPhoneNumber = AgentCreateDTO.AgentPhoneNumber,
                    //        EmailId = AgentCreateDTO.EmailId,
                    //        TheatreName = theaterName,
                    //        TaskAccepted = false,
                    //        TaskRejected = false,
                    //        NotificationSent = false,
                    //        CreatedOn = DateTime.Now
                    //    };
                    //    _context.AgentReports.Add(agentReport);
                    //}


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

        ////update
        //[HttpPost]
        //public ActionResult updateAgent(AgentUpdateDTO AgentUpdateDTO)
        //{

        //    var objcheck = _context.Agents.SingleOrDefault(opt => opt.AgentuserId == AgentUpdateDTO.AgentuserId && opt.IsDeleted == false);

        //    var existingAgents = _context.Agents.Where(opt => opt.IsDeleted == false).ToList();


        //    foreach (var agent in existingAgents)
        //    {
        //        if (agent.AgentuserId == AgentUpdateDTO.AgentuserId)
        //        {
        //            continue;
        //        }

        //        var theaterNames = agent.TheatreName.Split(',').Select(x => x.Trim()).ToList();
        //        var newTheaterNames = AgentUpdateDTO.TheatreName.Split(',').Select(x => x.Trim()).ToList();


        //        foreach (var newTheaterName in newTheaterNames)
        //        {
        //            foreach (var theaterName in theaterNames)
        //            {
        //                if (theaterName.Equals(newTheaterName, StringComparison.OrdinalIgnoreCase))
        //                {
        //                    if (agent.Agentrole.Equals("Primary", StringComparison.OrdinalIgnoreCase) && AgentUpdateDTO.Agentrole.Equals("Primary", StringComparison.OrdinalIgnoreCase))
        //                    {
        //                        return Accepted(new Confirmation { Status = "AlreadyExist", ResponseMsg = "A 'Primary' agent with the same TheatreName already exists!" });
        //                    }
        //                    else if (agent.Agentrole.Equals("Backup", StringComparison.OrdinalIgnoreCase) && AgentUpdateDTO.Agentrole.Equals("Backup", StringComparison.OrdinalIgnoreCase))
        //                    {
        //                        return Accepted(new Confirmation { Status = "AlreadyExist", ResponseMsg = "A 'Backup' agent with the same TheatreName already exists!" });
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    try
        //    {
        //        var objAgent = _context.Agents.SingleOrDefault(opt => opt.AgentId == AgentUpdateDTO.AgentId);
        //        objAgent.AgentName = AgentUpdateDTO.AgentName;
        //        objAgent.Agentrole = AgentUpdateDTO.Agentrole;
        //        objAgent.Cityname = AgentUpdateDTO.Cityname;
        //        objAgent.TheatreName = AgentUpdateDTO.TheatreName;
        //        objAgent.AgentPhoneNumber = AgentUpdateDTO.AgentPhoneNumber;
        //        objAgent.Address = AgentUpdateDTO.Address;
        //        objAgent.EmailId = AgentUpdateDTO.EmailId;
        //        objAgent.ProfilePhoto = AgentUpdateDTO.ProfilePhoto;
        //        objAgent.AgentuserId = AgentUpdateDTO.AgentuserId;
        //        objAgent.PassWord = AgentUpdateDTO.PassWord;
        //        //objAgent.PassWord = EncryptPassword(AgentUpdateDTO.PassWord);
        //        objAgent.UpdatedBy = AgentUpdateDTO.UpdatedBy;
        //        objAgent.UpdatedOn = System.DateTime.Now;
        //        var obj = _AgentRepo.Update(objAgent);
        //        return Ok(obj);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        [HttpPost]
        public ActionResult UpdateAgent(AgentUpdateDTO agentUpdateDTO)
        {
            try
            {
                // Retrieve the agent to be updated
                var agent = _context.Agents.SingleOrDefault(opt => opt.AgentId == agentUpdateDTO.AgentId && !opt.IsDeleted);
                if (agent == null)
                {
                    return NotFound(new Confirmation { Status = "Not Found", ResponseMsg = "Agent not found!" });
                }

                // Check for duplicate user id
                var existingAgent = _context.Agents.FirstOrDefault(opt => opt.AgentuserId == agentUpdateDTO.AgentuserId && opt.AgentId != agent.AgentId && !opt.IsDeleted);
                if (existingAgent != null)
                {
                    return Accepted(new Confirmation { Status = "Duplicate", ResponseMsg = "Duplicate User Id..!" });
                }

                // Check for duplicate theater names
                // Check for duplicate theater names
                var existingAgents = _context.Agents.Where(opt => opt.IsDeleted == false).ToList();
                foreach (var existingAgentEntry in existingAgents)
                {
                    if (existingAgentEntry.AgentuserId == agentUpdateDTO.AgentuserId)
                    {
                        continue;
                    }

                    var theaterNames = existingAgentEntry.TheatreName.Split(',').Select(x => x.Trim()).ToList();
                    var newTheaterNames = agentUpdateDTO.TheatreName.Split(',').Select(x => x.Trim()).ToList();

                    foreach (var newTheaterName in newTheaterNames)
                    {
                        foreach (var theaterName in theaterNames)
                        {
                            if (theaterName.Equals(newTheaterName, StringComparison.OrdinalIgnoreCase))
                            {
                                if (existingAgentEntry.Agentrole.Equals("Primary", StringComparison.OrdinalIgnoreCase) && agentUpdateDTO.Agentrole.Equals("Primary", StringComparison.OrdinalIgnoreCase))
                                {
                                    return Accepted(new Confirmation { Status = "AlreadyExist", ResponseMsg = $"A 'Primary' agent with the same TheatreName '{newTheaterName}' already exists!" });
                                }
                                else if (existingAgentEntry.Agentrole.Equals("Backup", StringComparison.OrdinalIgnoreCase) && agentUpdateDTO.Agentrole.Equals("Backup", StringComparison.OrdinalIgnoreCase))
                                {
                                    return Accepted(new Confirmation { Status = "AlreadyExist", ResponseMsg = $"A 'Backup' agent with the same TheatreName '{newTheaterName}' already exists!" });
                                }
                            }
                        }
                    }
                }

                // Update Agent table
                agent.AgentName = agentUpdateDTO.AgentName;
                agent.Agentrole = agentUpdateDTO.Agentrole;
                agent.Cityname = agentUpdateDTO.Cityname;
                agent.TheatreName = agentUpdateDTO.TheatreName;
                agent.AgentPhoneNumber = agentUpdateDTO.AgentPhoneNumber;
                agent.Address = agentUpdateDTO.Address;
                agent.EmailId = agentUpdateDTO.EmailId;
                agent.ProfilePhoto = agentUpdateDTO.ProfilePhoto;
                agent.AgentuserId = agentUpdateDTO.AgentuserId;
                agent.PassWord = agentUpdateDTO.PassWord;
                agent.UpdatedBy = agentUpdateDTO.UpdatedBy;
                agent.UpdatedOn = DateTime.Now;

                // Update AgentMapping table
                var agentMappings = _context.AgentMappings.Where(mapping => mapping.AgentId == agent.AgentId).ToList();
                _context.AgentMappings.RemoveRange(agentMappings);

                foreach (var theaterName in agentUpdateDTO.TheatreName.Split(',').Select(x => x.Trim()))
                {
                    var agentMapping = new AgentMapping
                    {
                        AgentId = agent.AgentId,
                        StateId = agentUpdateDTO.StateId,
                        AgentName = agentUpdateDTO.AgentName,
                        Agentrole = agentUpdateDTO.Agentrole,
                        AgentPhoneNumber = agentUpdateDTO.AgentPhoneNumber,
                        EmailId = agentUpdateDTO.EmailId,
                        TheatreName = theaterName,
                        TaskAccepted = false,
                        TaskRejected = false,
                        NotificationSent = false,
                        IsTimeExpired = false,
                        CreatedBy = (int)agentUpdateDTO.UpdatedBy, // Assuming this should be UpdatedBy
                        CreatedOn = DateTime.Now
                    };
                    _context.AgentMappings.Add(agentMapping);
                }

                _context.SaveChanges();

                return Ok(agent);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //public ActionResult DeleteAgent(int Id, int DeletedBy)
        //{
        //    try
        //    {
        //        var objabout = _context.Agents.SingleOrDefault(opt => opt.AgentId == Id);
        //        objabout.IsDeleted = true;
        //        objabout.UpdatedBy = DeletedBy;
        //        objabout.UpdatedOn = System.DateTime.Now;
        //        _context.SaveChanges();
        //        return Ok(objabout);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        [HttpGet("{Id}/{DeletedBy}")]
        public ActionResult DeleteAgent(int Id, int DeletedBy)
        {
            try
            {
                var agentToDelete = _context.Agents.SingleOrDefault(opt => opt.AgentId == Id);
                if (agentToDelete == null)
                {
                    return NotFound(new Confirmation { Status = "Not Found", ResponseMsg = "Agent not found!" });
                }

                agentToDelete.IsDeleted = true;
                agentToDelete.UpdatedBy = DeletedBy;
                agentToDelete.UpdatedOn = DateTime.Now;

                _context.SaveChanges();
                var agentMappingsToDelete = _context.AgentMappings.Where(mapping => mapping.AgentId == Id).ToList();
                foreach (var agentMapping in agentMappingsToDelete)
                {
                    agentMapping.IsDeleted = true;
                    agentMapping.UpdatedBy = DeletedBy;
                    agentMapping.UpdatedOn = DateTime.Now;
                }

                _context.SaveChanges();

                return Ok(agentToDelete);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //[HttpGet("{Id}/{DeletedBy}")]
        //public IActionResult SetDeleteRequest(int Id, int DeletedBy)
        //{
        //    try
        //    {
        //        // Find the agent to be updated
        //        var agentToUpdate = _context.Agents.SingleOrDefault(u => u.AgentId == Id);
        //        if (agentToUpdate == null)
        //        {
        //            return NotFound(new Confirmation { Status = "Not Found", ResponseMsg = "Agent not found!" });
        //        }

        //        // Update Agent table to set delete request
        //        agentToUpdate.DeleteRequested = true;
        //        agentToUpdate.UpdatedOn = DateTime.Now;
        //        agentToUpdate.UpdatedBy = DeletedBy;
        //        _context.SaveChanges();

        //        // Find and mark related records in AgentMapping table as delete requested
        //        var agentMappingsToUpdate = _context.AgentMappings.Where(mapping => mapping.AgentId == Id).ToList();
        //        foreach (var agentMapping in agentMappingsToUpdate)
        //        {
        //            agentMapping.DeleteRequested = true;
        //            agentMapping.UpdatedBy = DeletedBy;
        //            agentMapping.UpdatedOn = DateTime.Now;
        //        }

        //        // Save changes to AgentMapping table
        //        _context.SaveChanges();

        //        return Ok(agentToUpdate);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}


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
        //                //var mailTo = notification.Mail;
        //                var mailTo = notification.EmailId;
        //                string subject = "Important Notice: Non-Responsive Auto-Generated Email";
        //                string body = "Dear Recipient,<br><br>This auto-generated email serves the sole purpose of maintaining records and tracking information. Kindly refrain from replying to this message, as responses will not be monitored or processed.<br><br>Thank you for your understanding.<br><br>Best regards,<br> Ommr";

        //                await SendNotifications(fcmToken, "Theatre Assigned", "Hello");
        //                await agentService.SendEmail("ommr.ibl@gmail.com", mailTo, subject, body);
        //            }
        //        }

        //        //BackgroundJob.Schedule(() => PrimaryAgentNoResponseBackupAgentAssign(), TimeSpan.FromHours(24));
        //       // BackgroundJob.Schedule(() => PrimaryAgentNoResponseBackupAgentAssign(), TimeSpan.FromMinutes(2));
        //        BackgroundJob.Schedule(() => PrimaryAgentNoResponse(), TimeSpan.FromMinutes(2));

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
                        var theatre = notification.TheatreName;
                        var agentName = notification.AgentName;
                        //string subject = "Important Notice: Non-Responsive Auto-Generated Email";
                        string subject = "URGENT: Immediate Action Required-New Task Assignment";
                        string body = $"Hi  {agentName},<br><br>{theatre} theatre is assigned to you.<br><br>I hope this message grabs your immediate attention.A critical task demands your prompt action.Rush to the mobile app now for detailed instructions-time is of the esscence.<br><br>Complete the assignment within 72 hours of receiving it on the app.Your swift response is crucial for successful execution.<br><br>Act urgently,and thank you for your commitment.<br><br>Best regards,<br>Team OMMR";

                        await SendNotifications(fcmToken, $"{theatre} Assigned", "Hello");
                        await agentService.SendEmail("ommr.ibl@gmail.com", mailTo, subject, body);
                    }
                }

                 // BackgroundJob.Schedule(() => PrimaryAgentNoResponse(), TimeSpan.FromMinutes(30));
                 BackgroundJob.Schedule(() => PrimaryAgentNoResponse(), TimeSpan.FromMinutes(2));
                // BackgroundJob.Schedule(() => PrimaryAgentNoResponse(), TimeSpan.FromMinutes(10));


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
        //public IActionResult Activate(int AgentId)
        //{
        //    try
        //    {
        //        var agent = _context.Agents.FirstOrDefault(u => u.AgentId == AgentId && u.IsDeleted == false);

        //        if (agent == null)
        //        {
        //            return Accepted(new Confirmation { Status = "error", ResponseMsg = "Agent not found for the specified AgentId." });
        //        }

        //        agent.TaskAccepted = true;
        //        _context.SaveChanges();

        //        return Ok(new Confirmation { Status = "success", ResponseMsg = "Task for the agent has been activated successfully." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}


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

        //        if (!agent.NotificationSent)
        //        {
        //            // If NotificationSent is false, return no data.
        //            return Ok(new { data = new List<object>(), recordsTotal = 0, recordsFiltered = 0 });
        //        }

        //        // If TaskAccepted is true, include theater names.
        //        if (agent.TaskAccepted)
        //        {
        //            agent.NotificationSent = true;
        //            _context.SaveChanges();

        //            var theatreNames = agent.TheatreName.Split(',').Select(t => t.Trim()).ToList();

        //            var list = _context.AdScreen
        //                .Where(u => theatreNames.Contains(u.TheatreName) && !u.IsDeleted)
        //                .Select(u => new
        //                {
        //                    u.StateId,
        //                    u.State,
        //                    u.TheatreName,
        //                    //u.Screen,
        //                    AgentId,
        //                    agent.AgentName
        //                })
        //                .Distinct()
        //                .ToList();

        //            int totalRecords = list.Count;
        //            return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //        }
        //        else
        //        {
        //            // If TaskAccepted is false, return no data.
        //            return Ok(new { data = new List<object>(), recordsTotal = 0, recordsFiltered = 0 });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        /// <summary>
        ///After Flutter login API
        /// </summary>
        /// 

        [HttpGet("{AgentId}")]
        public IActionResult PrimaryAgentMovieTheatres(int AgentId)
        {
            try
            {
                var agents = _context.AgentMappings.Where(a => a.AgentId == AgentId && a.IsDeleted == false).ToList();


                if (agents.Any())
                {
                    var theatreNames = agents
                        .Where(z => z.TaskRejected == false && z.IsTimeExpired == false && z.NotificationSent == true && z.IsDeleted == false)
                        .Select(a => new { AgentId, TheatreName = a.TheatreName, StateId = a.StateId, TaskAccepted = a.TaskAccepted })
                        .ToArray();


                    return Ok(new { data = theatreNames, recordsTotal = theatreNames.Length, recordsFiltered = theatreNames.Length });
                }
                else
                {
                    // Handle case when no agents with the given AgentId are found
                    return NotFound($"No agents found with AgentId: {AgentId}");
                }
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //[HttpGet("{AgentId}")]
        //public IActionResult PrimaryAgentMovieTheatres(int AgentId)
        //{
        //    try
        //    {
        //        var agent = _context.AgentMappings.FirstOrDefault(a => a.AgentId == AgentId);

        //        if (agent.NotificationSent == false)
        //        {
        //            return Ok(new string[0]);
        //        }
        //        else
        //        {
        //            var theatreNames = _context.AgentMappings.Where(z => z.AgentId == AgentId && z.TaskRejected == false && z.Agentrole == "Primary" && z.IsTimeExpired == false).Select(a => new { AgentId, TheatreName = a.TheatreName, StateId = a.StateId, TaskAccepted = a.TaskAccepted }).ToArray();
        //            //return Ok(theatreNames);
        //            return Ok(new { data = theatreNames, recordsTotal = theatreNames.Length, recordsFiltered = theatreNames.Length });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        [HttpGet]
        public async Task<IActionResult> PrimaryAgentNoResponse()
        {
            try
            {
                var primaryAgents = _context.AgentMappings.Where(a => a.IsDeleted == false && a.NotificationSent == true && a.TaskAccepted == false && a.TaskRejected == false && a.Agentrole == "Primary").ToList();
                var agentService = new AgentRepository(_context);
                foreach (var mapping in primaryAgents)
                {
                    mapping.IsTimeExpired = true;
                }
                await _context.SaveChangesAsync();

                foreach (var primaryAgent in primaryAgents)
                {
                    var backAgent = _context.AgentMappings
                        .Where(a => a.TheatreName == primaryAgent.TheatreName && a.Agentrole == "Backup")
                        .FirstOrDefault();
                    if (backAgent != null)
                    {
                        var fcm = _context.PushNotifications
                            .Where(w => w.AgentId == backAgent.AgentId)
                            .Select(q => q.FCMToken)
                            .FirstOrDefault();

                        if (fcm != null)
                        {
                            await SendNotifications(fcm, $"{backAgent.TheatreName} assigned", "Hello");
                        }
                        backAgent.NotificationSent = true;
                        backAgent.NotifiedOn = DateTime.Now;
                        await _context.SaveChangesAsync(); // Save changes asynchronously

                        if (backAgent.EmailId != null)
                        {
                            var mailTo = backAgent.EmailId;
                            string subject = "URGENT: Immediate Action Required-New Task Assignment";
                            string body = $"Hi {backAgent.AgentName},<br><br>{backAgent.TheatreName} theatre is assigned to you.<br><br>I hope this message grabs your immediate attention.A critical task demands your prompt action.Rush to the mobile app now for detailed instructions-time is of the essence.<br><br>Complete the assignment within 72 hours of receiving it on the app.Your swift response is crucial for successful execution.<br><br>Act urgently,and thank you for your commitment.<br><br>Best regards,<br>Team OMMR";
                            await agentService.SendEmail("ommr.ibl@gmail.com", mailTo, subject, body);
                        }
                    }

                    // Create an entry in AgentReports for the backup agent
                    var agentReport = new AgentReport
                    {
                        AgentId = backAgent.AgentId,
                        StateId = backAgent.StateId,
                        AgentName = backAgent.AgentName,
                        Agentrole = backAgent.Agentrole,
                        AgentPhoneNumber = backAgent.AgentPhoneNumber,
                        EmailId = backAgent.EmailId,
                        TheatreName = backAgent.TheatreName,
                        NotificationSent = true,
                        TaskRejected = false,
                        TaskRejectedTime = null,
                        TaskAcceptedTime = null,
                        NotifiedOn = DateTime.Now,
                        IsTimeExpired = false,
                        CreatedOn = DateTime.Now
                    };
                    _context.AgentReports.Add(agentReport);
                    await _context.SaveChangesAsync(); // Save changes asynchronously
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }


        /// <summary>
        ///Primary agent reject notification to backup
        /// </summary>
        /// 

        [HttpGet("{AgentId}/{TheaterName}")]
        public async Task<IActionResult> RejectedTheatreNotificationToBackup(int AgentId, string TheaterName)
        {
            try
            {
                var agentService = new AgentRepository(_context);


                var priAgent = _context.AgentMappings.FirstOrDefault(a => a.AgentId == AgentId && a.TheatreName == TheaterName && a.IsDeleted == false);
                priAgent.TaskRejected = true;
                _context.SaveChanges();

                // Update AgentReports table for the latest entry with TaskRejected = true and TaskRejectedTime
                var latestAgentReport = _context.AgentReports
                    .Where(report => report.AgentId == AgentId && report.TheatreName == TheaterName)
                    .OrderByDescending(report => report.NotifiedOn) // Assuming there's a timestamp or unique identifier
                    .FirstOrDefault();

                if (latestAgentReport != null)
                {
                    latestAgentReport.TaskRejected = true;
                    latestAgentReport.TaskRejectedTime = DateTime.Now;
                }

                _context.SaveChanges();

                if (priAgent.Agentrole == "Primary")
                {
                    var backUpAgents = _context.AgentMappings.FirstOrDefault(q => q.TheatreName == TheaterName && q.Agentrole == "Backup" && q.IsDeleted == false);


                    if (backUpAgents != null)
                    {
                        var fcm = _context.PushNotifications.Where(w => w.AgentId == backUpAgents.AgentId).Select(q => q.FCMToken).FirstOrDefault();
                        await SendNotifications(fcm, $"{backUpAgents.TheatreName} assigned", "Hello");
                        backUpAgents.NotifiedOn = DateTime.Now;
                        backUpAgents.NotificationSent = true;
                        _context.SaveChanges();

                        // Create a new AgentReport for the backup agent
                        var newBackupAgentReport = new AgentReport
                        {
                            AgentId = backUpAgents.AgentId,
                            StateId = backUpAgents.StateId,
                            AgentName = backUpAgents.AgentName,
                            Agentrole = backUpAgents.Agentrole,
                            AgentPhoneNumber = backUpAgents.AgentPhoneNumber,
                            EmailId = backUpAgents.EmailId,
                            TheatreName = TheaterName,
                            NotificationSent = true,
                            TaskRejected = false,
                            TaskRejectedTime = null,
                            TaskAcceptedTime = null,
                            NotifiedOn = DateTime.Now,
                            IsTimeExpired = false,
                            CreatedOn = DateTime.Now
                        };

                        // Add the new AgentReport to the context
                        _context.AgentReports.Add(newBackupAgentReport);
                        await _context.SaveChangesAsync(); // Save changes to the database

                     
                        var mailTo = backUpAgents.EmailId;
                        //string subject = "Important Notice: Non-Responsive Auto-Generated Email";
                        //string body = $"Dear {backUpAgents.AgentName},<br><br> {backUpAgents.TheatreName} theatre is assigned to you. <br><br>This auto-generated email serves the sole purpose of maintaining records and tracking information. Kindly refrain from replying to this message, as responses will not be monitored or processed.<br><br>Thank you for your understanding.<br><br>Best regards,<br> Ommr";
                        string subject = "URGENT: Immediate Action Required-New Task Assignment";
                        string body = $"Hi  {backUpAgents.AgentName},<br><br>{backUpAgents.TheatreName} theatre is assigned to you.<br><br>I hope this message grabs your immediate attention.A critical task demands your prompt action.Rush to the mobile app now for detailed instructions-time is of the esscence.<br><br>Complete the assignment within 72 hours of receiving it on the app.Your swift response is crucial for successful execution.<br><br>Act urgently,and thank you for your commitment.<br><br>Best regards,<br>Team OMMR";

                        await agentService.SendEmail("ommr.ibl@gmail.com", mailTo, subject, body);
                    }
                    else
                    {
                        Ok("No Backup Agent is assigned to this Theatre");
                    }

                    //var theatresNames = _context.AgentMappings.Where(z => z.AgentId == AgentId && z.TaskRejected == false && z.Agentrole == "Primary").Select(a => a.TheatreName).ToList();


                    //return Ok(theatresNames);
                    //return Ok(new { });


                    var theatresData = _context.AgentMappings
                     .Where(z => z.AgentId == AgentId && z.TaskRejected == false && z.Agentrole == "Primary")
                     .Select(a => new { TheatreName = a.TheatreName })
                     .ToArray();


                    return Ok(new { data = theatresData, recordsTotal = theatresData.Length, recordsFiltered = theatresData.Length });


                }


                else if (priAgent.Agentrole == "Backup")
                {
                    return Ok(new string[0]);
                }


                return Ok(new string[0]);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //[HttpGet("{AgentId}")]
        //public async Task<IActionResult> PrimaryAgentRejectNotificationToBackup(int AgentId)
        //{
        //    try
        //    {
        //        var agentService = new AgentRepository(_context);
        //        var agent = _context.Agents.FirstOrDefault(u => u.AgentId == AgentId);

        //        if (agent == null)
        //        {
        //            return Accepted(new Confirmation { Status = "error", ResponseMsg = "No Primary Agent Present!." });
        //        }

        //        var uniqueNotifications = new HashSet<string>(); // Using HashSet to keep track of unique notifications
        //        var resultList = new List<object>();

        //        var primaryAgentTheatreNames = agent.TheatreName.Split(',')
        //                                             .Select(t => t.Trim())
        //                                             .ToList();

        //        foreach (var theatreName in primaryAgentTheatreNames)
        //        {
        //            var pushNotifications = _context.PushNotifications
        //                .Where(u => !u.IsDeleted)
        //                .ToList();

        //            var backupAgents = _context.Agents
        //                 .Where(a => !a.IsDeleted && a.Agentrole == "Backup")
        //                 .AsEnumerable()
        //                 .Where(a => a.TheatreName.Split(',').Select(t => t.Trim()).Contains(theatreName, StringComparer.OrdinalIgnoreCase))
        //                 .ToList();

        //            var filteredNotifications = pushNotifications
        //                 .Join(backupAgents,
        //                     p => p.AgentId,
        //                     a => a.AgentId,
        //                     (p, a) => new
        //                     {
        //                         p.AgentId,
        //                         p.DeviceId,
        //                         p.IMEINumber,
        //                         p.FCMToken,
        //                         a.EmailId
        //                     })
        //                 .ToList();

        //            var set = new HashSet<object>(resultList);
                   
        //            foreach (var item in filteredNotifications)
        //            {


        //                var backupAg = _context.Agents.FirstOrDefault(z => z.EmailId == item.EmailId);
        //                backupAg.NotificationSent = true;
        //                _context.SaveChanges();


        //                var notificationKey = $"{item.DeviceId}_{item.IMEINumber}_{item.FCMToken}";
        //                if (!uniqueNotifications.Contains(notificationKey))
        //                {
        //                    uniqueNotifications.Add(notificationKey);
        //                    set.Add(new { data = item });
        //                    await SendNotifications(item.FCMToken, "Theatre Assigned", "Hello");


        //                    var mailTo = item.EmailId;
        //                    string subject = "Important Notice: Non-Responsive Auto-Generated Email";
        //                    string body = "Dear Recipient,\r\n\r\nThis auto-generated email serves the sole purpose of maintaining records and tracking information. Kindly refrain from replying to this message, as responses will not be monitored or processed.\r\n\r\nThank you for your understanding.\r\n\r\nBest regards,\r\n Ommr";


        //                    await agentService.SendEmail("ommr.ibl@gmail.com", mailTo, subject, body);
        //                }
        //            }

        //            resultList = set.ToList();
        //        }

        //        return Ok(resultList);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        [HttpGet]
        public async Task<IActionResult> ReSendNotificationToUnsendPrimaryAgents()
        {
            try
            {
                var agentService = new AgentRepository(_context);

                var resultList = await agentService.RunAgentProcessing2();

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
                        var theatre = notification.TheatreName;
                        var agentName = notification.AgentName;
                        //string subject = "Important Notice: Non-Responsive Auto-Generated Email";
                        //string subject = "Important Notice: Non-Responsive Auto-Generated Email";
                        //string body = $"Dear {agentName},<br><br>{theatre} theatre is assigned to you.<br><br>This auto-generated email serves the sole purpose of maintaining records and tracking information. Kindly refrain from replying to this message, as responses will not be monitored or processed.<br><br>Thank you for your understanding.<br><br>Best regards,<br> Ommr";
                        string subject = "URGENT: Immediate Action Required-New Task Assignment";
                        string body = $"Hi  {agentName},<br><br>{theatre} theatre is assigned to you.<br><br>I hope this message grabs your immediate attention.A critical task demands your prompt action.Rush to the mobile app now for detailed instructions-time is of the esscence.<br><br>Complete the assignment within 72 hours of receiving it on the app.Your swift response is crucial for successful execution.<br><br>Act urgently,and thank you for your commitment.<br><br>Best regards,<br>Team OMMR";

                        await SendNotifications(fcmToken, $"{theatre} Assigned", "Hello");
                        await agentService.SendEmail("ommr.ibl@gmail.com", mailTo, subject, body);
                    }
                }

                //BackgroundJob.Schedule(() => PrimaryAgentNoResponseBackupAgentAssign(), TimeSpan.FromHours(24));
                //BackgroundJob.Schedule(() => PrimaryAgentNoResponseBackupAgentAssign(), TimeSpan.FromMinutes(2));
                BackgroundJob.Schedule(() => PrimaryAgentNoResponse(), TimeSpan.FromMinutes(2));


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

        //[HttpGet]
        //public async Task<IActionResult> PrimaryAgentNoResponseBackupAgentAssign()
        //{
        //    try
        //    {
        //        var agents = _context.Agents.Where(u => u.IsDeleted == false && u.NotificationSent == true && u.TaskAccepted == false && u.Agentrole == "Primary")
        //                        .ToList();

        //        var agentService = new AgentRepository(_context);
        //        var resultList = new List<object>();

        //        // Initialize the HashSet for unique email addresses
        //        var emailSet = new HashSet<string>();

        //        foreach (var agent in agents)
        //        {
        //            agent.IsTimeExpired = true;
        //            agent.UpdatedOn = DateTime.Now;
        //            _context.SaveChanges();

        //            var primaryAgentTheatreNames = agent.TheatreName.Split(',')
        //                                              .Select(t => t.Trim())
        //                                              .ToList();

        //            foreach (var theatreName in primaryAgentTheatreNames)
        //            {
        //                var pushNotifications = _context.PushNotifications
        //                    .Where(u => !u.IsDeleted)
        //                    .ToList();

        //                var backupAgents = _context.Agents
        //                      .Where(u => !u.IsDeleted
        //                          && u.Agentrole == "Backup")
        //                      .AsEnumerable()
        //                      .Where(u => u.TheatreName.Split(',').Select(t => t.Trim()).Contains(theatreName, StringComparer.OrdinalIgnoreCase))
        //                      .ToList();

        //                var filteredNotifications = pushNotifications
        //                      .Join(backupAgents,
        //                          p => p.AgentId,
        //                          a => a.AgentId,
        //                          (p, a) => new
        //                          {
        //                              p.AgentId,
        //                              p.DeviceId,
        //                              p.IMEINumber,
        //                              p.FCMToken,
        //                              a.EmailId,
        //                          })
        //                      .ToList();

        //                foreach (var item in filteredNotifications)
        //                {
        //                    if (emailSet.Add(item.EmailId))
        //                    {
        //                        await SendNotifications(item.FCMToken, "Theatre Assigned", "Hello");
        //                        var backupAg = _context.Agents.FirstOrDefault(z => z.EmailId == item.EmailId);
        //                        backupAg.NotificationSent = true;
        //                        backupAg.NotifiedOn = DateTime.Now;
        //                        _context.SaveChanges();

        //                        var mailTo = item.EmailId;
        //                        string subject = "Important Notice: Non-Responsive Auto-Generated Email";
        //                        string body = "Dear Recipient,\r\n\r\nThis auto-generated email serves the sole purpose of maintaining records and tracking information. Kindly refrain from replying to this message, as responses will not be monitored or processed.\r\n\r\nThank you for your understanding.\r\n\r\nBest regards,\r\n Ommr";

        //                        await agentService.SendEmail("ommr.ibl@gmail.com", mailTo, subject, body);

        //                        // Add the processed data to resultList
        //                        resultList.Add(new { data = item });
        //                    }
        //                }
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
                var agents = _context.AgentMappings.Where(u => u.IsDeleted == false && u.NotificationSent == true && u.TaskAccepted == false && u.Agentrole == "Backup")
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
        //                        u.NotificationSent,
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
                var list = (from u in _context.AgentReports
                            join s in _context.States on u.StateId equals s.StateId
                            where u.CreatedOn.HasValue &&
                           u.CreatedOn.Value.Date >= fromDate.Date &&
                           u.CreatedOn.Value.Date <= toDate.Date

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
                                u.NotificationSent,
                                u.NotifiedOn,
                                u.TaskAccepted,
                                u.TaskAcceptedTime,
                                u.TaskRejected,
                                u.TaskRejectedTime,
                                u.CreatedOn,
                              }).OrderByDescending(t => t.AgentId);

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
        //                        u.NotificationSent,
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
                var list = (from u in _context.AgentReports
                            join s in _context.States on u.StateId equals s.StateId
                            join p in _context.StateUser on u.StateId equals p.StateId
                            where p.IsDeleted == false && p.UserId == UserId &&
                                  u.CreatedOn.HasValue &&
                                  u.CreatedOn.Value.Date >= fromDate.Date &&
                                  u.CreatedOn.Value.Date <= toDate.Date
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
                                u.NotificationSent,
                                u.NotifiedOn,
                                u.TaskAccepted,
                                u.TaskAcceptedTime,
                                u.TaskRejected,
                                u.TaskRejectedTime,
                                p.UserId,
                                u.CreatedOn,
                                p.IsDeleted,
                            }).Where(x => x.IsDeleted == false && x.UserId == UserId).ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }


        [HttpGet("{email}")]
        public IActionResult ForgotPassword(string email)
        {
            var agentService = new AgentRepository(_context);
            var user = _context.Users.FirstOrDefault(z => z.Email == email);

            if (user != null)
            {
                var mailTo = user.Email;
                string subject = "Important Notice: Password Retrieval Request";
                string body = $"Dear {user.FullName},<br><br>This auto-generated email serves the purpose of providing you with your forgotten password.<br><br>Your Old Password is: {user.Password}<br><br>Best regards,<br>Ommr";


                agentService.SendEmail("ommr.ibl@gmail.com", mailTo, subject, body);
            }
            else
            {
                return Ok("This E-mail is not registered");
            }

            return Ok("Your Password is sent to your registered email");
        }

        [HttpPost]
        public IActionResult RefreshBooleans()
        {
            var agents = _context.AgentMappings.Where(a => a.Agentrole == "Primary" || a.Agentrole == "Backup").ToList();
            
            foreach (var agent in agents)
            {
                agent.IsTimeExpired = false;
                agent.TaskAccepted = false;
                agent.TaskRejected = false;
                agent.NotificationSent = false;
                _context.SaveChanges();
            }

            return Ok();
        }

    }
}
