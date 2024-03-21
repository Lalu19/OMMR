using AdminApi.Models.App;
using AdminApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Linq;
using System;
using AdminApi.Models.Helper;
using AdminApi.Models.App.Location;
using AdminApi.ViewModels.User;
using System.Collections.Generic;
using AdminApi.Models.User;
using AdminApi.DTO.App.AgentDTO;
using Microsoft.EntityFrameworkCore;

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdScreenController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly ISqlRepository<AdScreen> _AdScreenRepo;

        public AdScreenController(IConfiguration config,
                                    AppDbContext context,
                                    ISqlRepository<AdScreen> AdScreenRepo)
        {
            _config = config;
            _context = context;
            _AdScreenRepo = AdScreenRepo;
        }

        //[HttpPost]
        //public IActionResult AdScreenCreate(IFormFile file)
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
        //                var excelData = new AdScreen
        //                {
        //                    State = worksheet.Cells[row, 1].Value?.ToString(),
        //                    City = worksheet.Cells[row, 2].Value?.ToString(),
        //                    TheatreName = worksheet.Cells[row, 3].Value?.ToString(),
        //                    //Latitude = worksheet.Cells[row, 4].Value?.ToString(),
        //                    //Longitude = worksheet.Cells[row, 5].Value?.ToString(),
        //                    Screen = worksheet.Cells[row, 4].Value?.ToString(),
        //                    AdsName = worksheet.Cells[row, 5].Value?.ToString(),
        //                    AdsLanguage = worksheet.Cells[row, 6].Value?.ToString(),
        //                    AdsSequence = worksheet.Cells[row, 7].Value?.ToString(),
        //                    AdsDuration = worksheet.Cells[row, 8].Value?.ToString(),
        //                    AdsPlaytime = worksheet.Cells[row, 9].Value?.ToString(),
        //                    AdsYoutubeLink = worksheet.Cells[row, 10].Value?.ToString(),
        //                };

        //                var existingRecord = _context.AdScreen.FirstOrDefault(a =>
        //                    a.State == excelData.State &&
        //                    a.City == excelData.City &&
        //                    a.TheatreName == excelData.TheatreName &&
        //                    a.Screen == excelData.Screen);

        //                if (existingRecord != null)
        //                {
        //                    // Update the existing record
        //                    existingRecord.State = excelData.State;
        //                    existingRecord.City = excelData.City;
        //                    existingRecord.TheatreName = excelData.TheatreName;
        //                    //existingRecord.Latitude = excelData.Latitude;
        //                    //existingRecord.Longitude = excelData.Longitude;
        //                    existingRecord.Screen = excelData.Screen;
        //                    existingRecord.AdsName = excelData.AdsName;
        //                    existingRecord.AdsLanguage = excelData.AdsLanguage;
        //                    existingRecord.AdsSequence = excelData.AdsSequence;
        //                    existingRecord.AdsDuration = excelData.AdsDuration;
        //                    existingRecord.AdsPlaytime = excelData.AdsPlaytime;
        //                    existingRecord.AdsYoutubeLink = excelData.AdsYoutubeLink;
        //                    existingRecord.UpdatedBy = excelData.UpdatedBy;
        //                    existingRecord.UpdatedOn = System.DateTime.Now;
        //                }
        //                else
        //                {
        //                    // Create a new record
        //                    var stateEntity = _context.States.FirstOrDefault(s => s.StateName == excelData.State);
        //                    if (stateEntity != null)
        //                    {
        //                        excelData.StateId = stateEntity.StateId;
        //                    }

        //                    _context.AdScreen.Add(excelData);
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


        /////Delete the previous data code

        //[HttpPost]
        //public IActionResult AdScreenCreate(IFormFile file)
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

        //            // Delete all records from the AdScreen table
        //            _context.Database.ExecuteSqlRaw("DELETE FROM AdScreen");

        //            //// Reset the identity column seed for AdScreenId
        //            //_context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('AdScreen', RESEED, 0)");

        //            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
        //            {
        //                var excelData = new AdScreen
        //                {
        //                    State = worksheet.Cells[row, 1].Value?.ToString(),
        //                    City = worksheet.Cells[row, 2].Value?.ToString(),
        //                    TheatreName = worksheet.Cells[row, 3].Value?.ToString(),
        //                    //Latitude = worksheet.Cells[row, 4].Value?.ToString(),
        //                    //Longitude = worksheet.Cells[row, 5].Value?.ToString(),
        //                    Screen = worksheet.Cells[row, 4].Value?.ToString(),
        //                    AdsName = worksheet.Cells[row, 5].Value?.ToString(),
        //                    AdsLanguage = worksheet.Cells[row, 6].Value?.ToString(),
        //                    AdsSequence = worksheet.Cells[row, 7].Value?.ToString(),
        //                    AdsDuration = worksheet.Cells[row, 8].Value?.ToString(),
        //                    AdsPlaytime = worksheet.Cells[row, 9].Value?.ToString(),
        //                    AdsYoutubeLink = worksheet.Cells[row, 10].Value?.ToString(),
        //                };

        //                // Create a new record
        //                var stateEntity = _context.States.FirstOrDefault(s => s.StateName == excelData.State);
        //                if (stateEntity != null)
        //                {
        //                    excelData.StateId = stateEntity.StateId;
        //                }

        //                _context.AdScreen.Add(excelData);
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
        public IActionResult AdScreenCreate(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest(new { status = "error", responseMsg = "No file uploaded" });
                }

                using (var package = new ExcelPackage(file.OpenReadStream()))
                {
                    var worksheet = package.Workbook.Worksheets[0];

                    // Delete all records from the AdScreen table
                    _context.Database.ExecuteSqlRaw("DELETE FROM AdScreen");

                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        var excelData = new AdScreen
                        {
                            State = worksheet.Cells[row, 1].Value?.ToString(),
                            City = worksheet.Cells[row, 2].Value?.ToString(),
                            TheatreName = worksheet.Cells[row, 3].Value?.ToString(),
                            Screen = worksheet.Cells[row, 4].Value?.ToString(),
                            AdsName = worksheet.Cells[row, 5].Value?.ToString(),
                            AdsLanguage = worksheet.Cells[row, 6].Value?.ToString(),
                            AdsSequence = worksheet.Cells[row, 7].Value?.ToString(),
                            AdsDuration = worksheet.Cells[row, 8].Value?.ToString(),
                            AdsPlaytime = worksheet.Cells[row, 9].Value?.ToString(),
                            AdsYoutubeLink = worksheet.Cells[row, 10].Value?.ToString(),
                            Media = worksheet.Cells[row, 11].Value?.ToString(),
                        };

                        // Create a new record
                        var stateEntity = _context.States.FirstOrDefault(s => s.StateName == excelData.State);
                        if (stateEntity != null)
                        {
                            excelData.StateId = stateEntity.StateId;
                        }

                        _context.AdScreen.Add(excelData);

                        // Save the changes to get the AdScreenId
                        _context.SaveChanges();

                        // Create corresponding AdScreenMapping entry
                        var adScreenMapping = new AdScreenMapping
                        {
                            AdScreenId = excelData.AdScreenId, // Use the newly generated AdScreenId
                            StateId = excelData.StateId,
                            State = excelData.State,
                            City = excelData.City, 
                            TheatreName = excelData.TheatreName, 
                            Screen = excelData.Screen, 
                            AdsName = excelData.AdsName, 
                            AdsLanguage = excelData.AdsLanguage, 
                            AdsSequence = excelData.AdsSequence, 
                            AdsDuration = excelData.AdsDuration, 
                            AdsPlaytime = excelData.AdsPlaytime, 
                            AdsYoutubeLink = excelData.AdsYoutubeLink, 
                                                              
                        };

                        _context.AdScreenMapping.Add(adScreenMapping);
                    }

                    _context.SaveChanges();
                }

                return Ok(new { status = "success", responseMsg = "Data saved successfully" });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }



        [HttpGet]
        public ActionResult GetallList()
        {
            try
            {
                var list = (from u in _context.AdScreen

                            select new
                            {
                                u.AdScreenId,
                                u.State,
                                u.City,
                                u.TheatreName,
                                u.Screen,
                                u.AdsName,
                                u.AdsYoutubeLink,
                                u.AdsLanguage,
                                u.AdsSequence,
                                u.AdsDuration,
                                u.AdsPlaytime,
                                u.Media,
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

        [HttpGet("{Userid}")]
        public ActionResult GetAllListbystateid(int Userid)
        {
            try
            {
                var list = (from u in _context.AdScreen
                            //join a in _context.States on u.StateId equals a.StateId
                            join p in _context.StateUser on u.StateId equals p.StateId

                            select new
                            {
                                p.StateId,
                                u.State,
                                u.City,
                                u.TheatreName,
                                u.Screen,
                                u.AdsName,
                                u.AdsYoutubeLink,
                                u.AdsLanguage,
                                u.AdsSequence,
                                u.AdsDuration,
                                u.AdsPlaytime,
                                p.UserId,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.UserId == Userid).Distinct().ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult GetStateList()
        {
            try
            {
                var list = (from u in _context.AdScreen
                            join a in _context.States on u.State equals a.StateName

                            select new
                            {
                                a.StateId,
                                u.State,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false).Distinct().ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{Userid}")]
        public ActionResult GetStateListbyuserid(int Userid)
        {
            try
            {
                var list = (from u in _context.AdScreen
                                //join a in _context.States on u.StateId equals a.StateId
                            join p in _context.StateUser on u.StateId equals p.StateId

                            select new
                            {
                                p.StateId,
                                p.UserId,
                                u.State,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.UserId == Userid).Distinct().ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }


        [HttpGet]
        public ActionResult GetCityList()
        {
            try
            {
                var list = (from u in _context.AdScreen

                            select new
                            {
                                u.City,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false).Distinct().ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult GetTheaterList()
        {
            try
            {
                var list = (from u in _context.AdScreen

                            select new
                            {
                                u.TheatreName,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false).Distinct().ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult GetTheaterListinarrayformat()
        {
            try
            {
                var list = (from u in _context.AdScreen
                            select new
                            {
                                u.TheatreName,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false).Distinct().ToList();

                int totalRecords = list.Count();

                // Create an array of theater names with each name in its array
                var theaterNamesArray = list.Select(item => new[] { item.TheatreName }).ToArray();

                return Ok(new { data = theaterNamesArray, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{State}")]
        public ActionResult GetCityListbystatename(string State)
        {
            try
            {
                var list = (from u in _context.AdScreen

                            select new
                            {
                                u.State,
                                u.City,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.State == State).Distinct().ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{city}")]
        public ActionResult GetTheaterListbycityname(string city)
        {
            try
            {
                var list = (from u in _context.AdScreen

                            select new
                            {
                                u.City,
                                u.TheatreName,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.City == city).Distinct().ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //state
        [HttpGet("{Userid}")]
        public ActionResult GetCityListbyuserid(int Userid)
        {
            try
            {
                var list = (from u in _context.AdScreen
                            //join a in _context.States on u.StateId equals a.StateId
                            join p in _context.StateUser on u.StateId equals p.StateId

                            select new
                            {
                                u.StateId,
                                p.UserId,
                                u.State,
                                u.City,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.UserId == Userid).Distinct().ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{Stateid}")]
        public ActionResult GetCityListbystateid(int Stateid)
        {
            try
            {
                var list = (from u in _context.AdScreen
                            join a in _context.States on u.StateId equals a.StateId

                            select new
                            {
                                a.StateId,
                                u.State,
                                u.City,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.StateId == Stateid).Distinct().ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{city}/{Stateid}")]
        public ActionResult GetTheaterListbycityname(string city, int Stateid)
        {
            try
            {
                var list = (from u in _context.AdScreen
                            join a in _context.States on u.StateId equals a.StateId

                            select new
                            {
                                a.StateId,
                                u.City,
                                u.TheatreName,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.City == city && x.StateId == Stateid).Distinct().ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //[HttpGet("{Stateid}/{city}")]
        //public ActionResult GetTheaterListbyagentid(int Stateid, string city)
        //{
        //    try
        //    {
        //        var list = (from u in _context.AdScreen
        //                    join a in _context.States on u.StateId equals a.StateId
        //                    join p in _context.Agents on u.City equals p.Cityname

        //                    select new
        //                    {
        //                        a.StateId,
        //                        u.City,
        //                        p.AgentId,
        //                        p.AgentName,
        //                        p.TheatreName,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false && x.City == city && x.StateId == Stateid).Distinct().ToList();

        //        int totalRecords = list.Count();

        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }

        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

      
        //[HttpGet("{Stateid}/{city}/{TheaterName}")]
        //public ActionResult GetScreenListbyagentid(int Stateid,string city, string TheaterName)
        //{
        //    try
        //    {
        //        var list = (from u in _context.AdScreen
        //                    join a in _context.States on u.StateId equals a.StateId
        //                    join p in _context.Agents on u.City equals p.Cityname

        //                    select new
        //                    {
        //                        a.StateId,
        //                        u.City,
        //                        p.TheatreName,
        //                        u.Screen,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false && x.StateId == Stateid && x.City == city && x.TheatreName == TheaterName).Distinct().ToList();

        //        int totalRecords = list.Count();

        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }

        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}


        //[HttpGet("{StateId}")]
        //public ActionResult GetCityListByAgent(int StateId)
        //{
        //    try
        //    {
        //        var list = (from u in _context.AdScreen
        //                    join a in _context.Agents on u.City equals a.Cityname
        //                    join p in _context.States on u.StateId equals p.StateId
        //                    join h in _context.HallPass on u.City equals h.Cityname
                            

        //                    select new
        //                    {
        //                        a.AgentId,
        //                        a.AgentName,
        //                        p.StateId,
        //                        u.State,
        //                        u.City,
        //                        a.TheatreName,
        //                        u.Screen,
        //                        u.AdsName,
        //                        u.AdsYoutubeLink,
        //                        u.AdsLanguage,
        //                        u.AdsSequence,
        //                        u.AdsDuration,
        //                        u.AdsPlaytime,
        //                        h.HallPassImg,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false && x.StateId == StateId).Distinct().ToList();

        //        int totalRecords = list.Count();

        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }

        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}


        [HttpGet("{agentId}")]
        public ActionResult GetAdListByAgent(int agentId)
        {
            try
            {
                var list = (from u in _context.AdScreen
                            join a in _context.Agents on u.City equals a.Cityname
                           // join p in _context.States on u.StateId equals p.StateId
                            //join h in _context.HallPass on u.City equals h.Cityname


                            select new
                            {
                                a.AgentId,
                                a.AgentName,
                                //p.StateId,
                                //u.State,
                                u.City,
                                a.TheatreName,
                                u.Screen,
                                u.AdsName,
                                u.AdsYoutubeLink,
                                u.AdsLanguage,
                                u.AdsSequence,
                                u.AdsDuration,
                                u.AdsPlaytime,
                               // h.HallPassImg,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.AgentId == agentId).Distinct().ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //Reports
        //[HttpGet]
        //public ActionResult GetActiveScreenList()
        //{
        //    try
        //    {
        //        var list = (from u in _context.AdScreen

        //                    select new
        //                    {
        //                        u.State,
        //                        u.City,
        //                        u.Area,
        //                        u.TheaterName,
        //                        u.Screen,
        //                        u.IsActive,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false && x.IsActive == "Active").Distinct().ToList();

        //        int totalRecords = list.Count();

        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }

        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        [HttpGet]
        public ActionResult GetAdvertiseList()
        {
            try
            {
                var list = (from u in _context.AdScreen

                            select new
                            {
                                u.AdsName,
                                u.AdsYoutubeLink,
                                u.AdsLanguage,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false).Distinct().ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult GetMediaList()
        {
            try
            {
                var list = (from u in _context.AdScreen

                            select new
                            {
                                u.Media,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false).Distinct().ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult GetAllUserrList()
        {
            try
            {
                var list = (from u in _context.Users
                            join r in _context.UserRole on
                            u.UserRoleId equals r.UserRoleId
                            //join p in _context.States on u.StateId equals p.StateId
                         
                            select new
                            {
                                u.UserId,
                                u.UserRoleId,
                                u.FullName,
                                r.RoleName,
                                u.Mobile,
                                u.Email,
                                u.DateOfBirth,
                                u.UserName,
                                u.Password,
                                u.ImagePath,
                                //u.StateId,
                                //p.StateName,
                                u.Address

                            });

                var userInfoList = list.Select(s => new UserInfo
                {
                    UserId = s.UserId,
                    UserRoleId = s.UserRoleId,
                    RoleName = s.RoleName,
                    FullName = s.FullName,
                    Mobile = s.Mobile,
                    Email = s.Email,
                    DateOfBirth = s.DateOfBirth,
                    UserName = s.UserName,
                    Password = s.Password,
                    ImagePath = s.ImagePath,
                    //StateId = s.StateId,
                    //StateName = s.StateName,
                  
                    Address = s.Address
                });

                int totalRecords = userInfoList.Count();
                return Ok(new { data = userInfoList, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult GetAdminList()
        {
            try
            {
                var list = (from u in _context.Users
                            join r in _context.UserRole on u.UserRoleId equals r.UserRoleId
                            where u.UserRoleId == 2 // Filter data where UserRoleId is equal to 2
                            select new
                            {
                                u.UserId,
                                u.UserRoleId,
                                u.FullName,
                                r.RoleName,
                                u.Mobile,
                                u.Email,
                                u.DateOfBirth,
                                u.UserName,
                                u.Password,
                                u.ImagePath,
                                u.Address
                            });

                var userInfoList = list.Select(s => new UserInfo
                {
                    UserId = s.UserId,
                    UserRoleId = s.UserRoleId,
                    RoleName = s.RoleName,
                    FullName = s.FullName,
                    Mobile = s.Mobile,
                    Email = s.Email,
                    DateOfBirth = s.DateOfBirth,
                    UserName = s.UserName,
                    Password = s.Password,
                    ImagePath = s.ImagePath,
                    Address = s.Address
                });

                int totalRecords = userInfoList.Count();
                return Ok(new { data = userInfoList, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult GetStateUserList()
        {
            try
            {
                var list = (from u in _context.Users
                            join r in _context.UserRole on u.UserRoleId equals r.UserRoleId
                            where u.UserRoleId == 3 && u.DeleteRequested == false

                            select new
                            {
                                u.UserId,
                                u.UserRoleId,
                                u.FullName,
                                r.RoleName,
                                u.Mobile,
                                u.Email,
                                u.DateOfBirth,
                                u.UserName,
                                u.Password,
                                u.ImagePath,
                                u.Address,
                                u.DeleteRequested,
                                u.SuperAdminDeletionResponse,

                            });

                var userInfoList = list.Select(s => new UserInfo
                {
                    UserId = s.UserId,
                    UserRoleId = s.UserRoleId,
                    RoleName = s.RoleName,
                    FullName = s.FullName,
                    Mobile = s.Mobile,
                    Email = s.Email,
                    DateOfBirth = s.DateOfBirth,
                    UserName = s.UserName,
                    Password = s.Password,
                    ImagePath = s.ImagePath,
                    Address = s.Address,
                    DeleteRequested = s.DeleteRequested,
                    SuperAdminDeletionResponse = s.SuperAdminDeletionResponse
                });

                int totalRecords = userInfoList.Count();
                return Ok(new { data = userInfoList, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //Code for Mobile Agent

        [HttpGet]
        public ActionResult GetClientList()
        {
            try
            {
                var list = (from u in _context.Users
                            join r in _context.UserRole on u.UserRoleId equals r.UserRoleId
                            where u.UserRoleId == 4 // Filter data where UserRoleId is equal to 4
                            select new
                            {
                                u.UserId,
                                u.UserRoleId,
                                u.FullName,
                                r.RoleName,
                                u.Mobile,
                                u.Email,
                                u.DateOfBirth,
                                u.UserName,
                                u.Password,
                                u.ImagePath,
                                u.Address,
                                u.AdvertiseName,
                                u.TotalVerificationCount,
                                u.IsActive
                            }).Where(x=> x.IsActive == true);

                var userInfoList = list.Select(s => new UserInfo
                {
                    UserId = s.UserId,
                    UserRoleId = s.UserRoleId,
                    RoleName = s.RoleName,
                    FullName = s.FullName,
                    Mobile = s.Mobile,
                    Email = s.Email,
                    DateOfBirth = s.DateOfBirth,
                    UserName = s.UserName,
                    Password = s.Password,
                    ImagePath = s.ImagePath,
                    Address = s.Address,
                    AdvertiseName = s.AdvertiseName,
                    TotalVerificationCount = s.TotalVerificationCount
                });

                int totalRecords = userInfoList.Count();
                return Ok(new { data = userInfoList, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }


        //[HttpGet("{TheaterName}/{Stateid}")]
        //public ActionResult GetScreenListbyTheaterName(string TheaterName, int Stateid)
        //{
        //    try
        //    {
        //        var list = (from u in _context.AdScreen
        //                    join a in _context.States on u.StateId equals a.StateId
        //                    //join h in _context.HallPass on u.TheatreName equals h.TheatreName

        //                    select new
        //                    {
        //                        u.AdScreenId,
        //                        a.StateId,
        //                        u.TheatreName,
        //                        u.Latitude,
        //                        u.Longitude,
        //                        u.Screen,
        //                        u.AdsPlaytime,
        //                        u.AdsName,
        //                        u.AdsYoutubeLink,
        //                        u.AdsSequence,
        //                        u.AdsDuration,
        //                        u.AdsLanguage,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false && x.TheatreName == TheaterName && x.StateId == Stateid).Distinct().ToList();


        //        int totalRecords = list.Count();

        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }

        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}


        //[HttpGet("{TheaterName}/{Stateid}")]
        //public ActionResult GetScreenListbyTheaterName(string TheaterName, int Stateid)
        //{
        //    try
        //    {
        //        var result = new List<object>();

        //        var allHallPassRecords = _context.HallPass.Where(h => !h.IsDeleted).ToList();

        //        foreach (var hallPassRecord in allHallPassRecords)
        //        {
        //            var theaterNames = hallPassRecord.TheatreName.Split(',').Select(name => name.Trim()); // Split and trim theater names

        //            if (theaterNames.Contains(TheaterName))
        //            {
        //                var records = (from u in _context.AdScreen
        //                               join a in _context.States on u.StateId equals a.StateId
        //                               where u.TheatreName.Trim() == TheaterName && a.StateId == Stateid
        //                               select new
        //                               {
        //                                   u.AdScreenId,
        //                                   a.StateId,
        //                                   u.TheatreName,
        //                                   u.Latitude,
        //                                   u.Longitude,
        //                                   u.Screen,
        //                                   u.AdsPlaytime,
        //                                   u.AdsName,
        //                                   u.AdsYoutubeLink,
        //                                   u.AdsSequence,
        //                                   u.AdsDuration,
        //                                   u.AdsLanguage,
        //                                   HallPassImg = hallPassRecord.HallPassImg
        //                               }).ToList();

        //                result.AddRange(records);
        //            }
        //        }

        //        int totalRecords = result.Count;

        //        return Ok(new { data = result, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}


        //[HttpGet("{TheaterName}/{Stateid}")]
        //public ActionResult GetScreenListbyTheaterName(string TheaterName, int Stateid)
        //{
        //    try
        //    {
        //        var feedbackAdScreenIds = _context.AdScreenFeedbackForm
        //            .Where(feedback => feedback.IsDeleted == false)
        //            .Select(feedback => feedback.AdScreenId)
        //            .Distinct()
        //            .ToList();

        //        var list = (from u in _context.AdScreen
        //                    join a in _context.States on u.StateId equals a.StateId
        //                    where u.IsDeleted == false && u.TheatreName == TheaterName && u.StateId == Stateid
        //                          && !feedbackAdScreenIds.Contains(u.AdScreenId) // Filter out AdScreenIds with feedback
        //                    select new
        //                    {
        //                        u.AdScreenId,
        //                        a.StateId,
        //                        u.TheatreName,
        //                        u.Screen,
        //                        u.AdsPlaytime,
        //                        u.AdsName,
        //                        u.AdsYoutubeLink,
        //                        u.AdsSequence,
        //                        u.AdsDuration,
        //                        u.AdsLanguage,
        //                        u.IsDeleted
        //                    }).Distinct().ToList();

        //        int totalRecords = list.Count();

        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}


        /// <summary>
        /// After Clicking Accept Btn in TheaterName
        /// </summary>

        //[HttpGet("{TheaterName}/{Stateid}/{AgentId}")]
        //public ActionResult GetScreenListbyTheaterName(string TheaterName, int Stateid, int AgentId)
        //{
        //    try
        //    {
        //        var feedbackAdScreenIds = _context.AdScreenFeedbackForm
        //            .Where(feedback => feedback.IsDeleted == false)
        //            .Select(feedback => feedback.AdScreenId)
        //            .Distinct()
        //            .ToList();

        //        var adsList = _context.AdScreen
        //            .Where(u => u.IsDeleted == false && u.TheatreName == TheaterName && u.StateId == Stateid
        //                        && !feedbackAdScreenIds.Contains(u.AdScreenId))
        //            .ToList();

        //        var groupedAds = adsList
        //            .GroupBy(u => new { u.StateId, u.TheatreName, u.Screen, u.AdsPlaytime })
        //            .Select(group => new
        //            {
        //                StateId = group.Key.StateId,
        //                TheatreName = group.Key.TheatreName,
        //                Screen = group.Key.Screen,
        //                AdsPlaytime = group.Key.AdsPlaytime,
        //                AdsNames = group.Select(u => u.AdsName).ToArray(),
        //                /* AdsPlaytime = group.Select(u => u.AdsPlaytime).FirstOrDefault(),*/
        //                AdScreenId = group.Select(u => u.AdScreenId).ToArray(),
        //                AdsYoutubeLink = group.Select(u => u.AdsYoutubeLink).ToArray(),
        //                AdsSequence = group.Select(u => u.AdsSequence).ToArray(),
        //                AdsDuration = group.Select(u => u.AdsDuration).ToArray(),
        //                AdsLanguage = group.Select(u => u.AdsLanguage).ToArray(),
        //                IsDeleted = group.Select(u => u.IsDeleted).FirstOrDefault(),
        //            })
        //            .ToList();

        //        int totalRecords = groupedAds.Count();
        //        // Update AgentMapping table
        //        var agentMappingsToUpdate = _context.AgentMappings
        //            .Where(mapping => mapping.StateId == Stateid && mapping.AgentId == AgentId && mapping.TheatreName == TheaterName)
        //            .ToList();

        //        foreach (var mapping in agentMappingsToUpdate)
        //        {
        //            mapping.TaskAccepted = true; // Set TaskAccepted to true in AgentMappings table

        //            // Check conditions in AgentReport table
        //            var agentReportRecord = _context.AgentReports.FirstOrDefault(
        //                ar => ar.StateId == Stateid
        //                && ar.AgentId == AgentId
        //                && ar.TheatreName == TheaterName
        //                && ar.NotificationSent);
        //            // && DateTime.UtcNow.Subtract((DateTime)ar.NotifiedOn).TotalHours <= 24);

        //            if (agentReportRecord != null)
        //            {
        //                agentReportRecord.TaskAccepted = true; // Set TaskAccepted to true in AgentReport table
        //            }
        //            else
        //            {
        //                // No record meeting conditions or NotifiedOn time exceeded 24 hours
        //                agentReportRecord.TaskAccepted = false;
        //            }
        //        }

        //        //_context.SaveChanges();


        //        _context.SaveChanges();
        //        return Ok(new { data = groupedAds, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}


        [HttpGet("{TheaterName}/{Stateid}/{AgentId}")]
        public ActionResult GetScreenListbyTheaterName(string TheaterName, int Stateid, int AgentId)
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

                int totalRecords = groupedAds.Count();

                // Update AgentMapping table
                var agentMappingsToUpdate = _context.AgentMappings
                    .Where(mapping => mapping.StateId == Stateid && mapping.AgentId == AgentId && mapping.TheatreName == TheaterName)
                    .ToList();

                foreach (var mapping in agentMappingsToUpdate)
                {
                    mapping.TaskAccepted = true; // Set TaskAccepted to true
                }

                // Update AgentReports table
                var agentReportsToUpdate = _context.AgentReports
                    .Where(report => report.StateId == Stateid && report.AgentId == AgentId && report.TheatreName == TheaterName)
                    .OrderByDescending(report => report.NotifiedOn) // Order by Timestamp to get the latest entry
                    .FirstOrDefault(); // Get the latest entry

                if (agentReportsToUpdate != null)
                {
                    agentReportsToUpdate.TaskAccepted = true; // Set TaskAccepted to true
                    agentReportsToUpdate.TaskAcceptedTime = DateTime.Now;
                }

                _context.SaveChanges();
                return Ok(new { data = groupedAds, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }


        [HttpGet("{TheaterName}/{Stateid}")]
        public ActionResult GetScreenListbyTheaterName(string TheaterName, int Stateid)
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
                        /* AdsPlaytime = group.Select(u => u.AdsPlaytime).FirstOrDefault(),*/
                        AdScreenId = group.Select(u => u.AdScreenId).ToArray(),
                        AdsYoutubeLink = group.Select(u => u.AdsYoutubeLink).ToArray(),
                        AdsSequence = group.Select(u => u.AdsSequence).ToArray(),
                        AdsDuration = group.Select(u => u.AdsDuration).ToArray(),
                        AdsLanguage = group.Select(u => u.AdsLanguage).ToArray(),
                        IsDeleted = group.Select(u => u.IsDeleted).FirstOrDefault(),
                    })
                    .ToList();

                int totalRecords = groupedAds.Count();

                return Ok(new { data = groupedAds, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{TheaterName}/{Stateid}/{Screen}/{AdsPlaytime}")]
        public ActionResult GetAdsListbyScreenNo(int Stateid,string TheaterName, string Screen, string AdsPlaytime)
        {
            try
            {
                var feedbackAdScreenIds = _context.AdScreenFeedbackForm
                   .Where(feedback => feedback.IsDeleted == false)
                   .Select(feedback => feedback.AdScreenId)
                   .Distinct()
                   .ToList();
                var list = (from u in _context.AdScreen
                            join a in _context.States on u.StateId equals a.StateId
                            where u.IsDeleted == false && u.StateId == Stateid && u.TheatreName == TheaterName && u.Screen == Screen && u.AdsPlaytime == AdsPlaytime
                                  && !feedbackAdScreenIds.Contains(u.AdScreenId) // Filter out AdScreenIds with feedback

                            select new
                            {
                                u.AdScreenId,
                                a.StateId,
                                u.TheatreName,
                                u.Screen,
                                u.AdsPlaytime,
                                u.AdsName,
                                u.AdsYoutubeLink,
                                u.AdsSequence,
                                u.AdsDuration,
                                u.AdsLanguage,
                                u.Media,
                                u.IsDeleted
                            }).Distinct().ToList();


                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{agentid}")]
        public ActionResult TheatreListByAgentId(int agentid)
        {
            try
            {
                var list = (from u in _context.AdScreen
                            join a in _context.Agents on u.City equals a.Cityname
                            join p in _context.States on u.StateId equals p.StateId

                            select new
                            {
                                u.StateId,
                                p.StateName,
                                a.AgentId,
                                a.AgentName,
                                a.TheatreName,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.AgentId == agentid).Distinct().ToList();

                var theaters = new List<object>();

                foreach (var item in list)
                {
                    var theaterNames = item.TheatreName.Split(',').Select(name => name.Trim());

                    foreach (var theaterName in theaterNames)
                    {
                        theaters.Add(new
                        {
                            StateId = item.StateId,
                            StateName = item.StateName,
                            AgentId = item.AgentId,
                            AgentName = item.AgentName,
                            TheatreName = theaterName,
                            IsDeleted = item.IsDeleted
                        });
                    }
                }

                int totalRecords = theaters.Count;

                return Ok(new { data = theaters, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{adsName}/{media}")]
        public ActionResult GetHallpassByAdsname(string adsName, string media)
        {
            try
            {
                var list = (from u in _context.AdScreen
                            join a in _context.HallPass on u.AdsName equals a.AdsName

                            select new
                            {
                                u.AdsName,
                                a.Media,
                                a.HallPassImg,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.AdsName == adsName && x.Media == media).ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }


        ////For Client
        //[HttpGet("{adsName}")]
        //public ActionResult GetClientAdsFeedbackListbyAdsName(string adsName)
        //{
        //    try
        //    {
        //        // Split the comma-separated string into an array of ads names
        //        var adsNameArray = adsName.Split(',');

        //        var list = (from s in _context.AdScreen
        //                    join u in _context.AdScreenFeedbackForm on s.AdScreenId equals u.AdScreenId
        //                    join p in _context.Agents on u.AgentId equals p.AgentId
        //                    join q in _context.States on s.StateId equals q.StateId

        //                    where adsNameArray.Contains(s.AdsName)
        //                    select new
        //                    {
        //                        u.AdScreenFeedbackFormId,
        //                        u.AdScreenId,
        //                        u.AgentId,
        //                        p.AgentName,
        //                        u.StateId,
        //                        q.StateName,
        //                        s.AdsName,
        //                        s.City,
        //                        s.TheatreName,
        //                        //s.Latitude,
        //                        //s.Longitude,
        //                        s.Screen,
        //                        s.AdsLanguage,
        //                        s.AdsSequence,
        //                        s.AdsDuration,
        //                        s.AdsPlaytime,
        //                        s.AdsYoutubeLink,
        //                        u.AdsVariantStatusOk,
        //                        u.AdsVariantStatusNotOk,
        //                        u.AdsVariantStatusRemark,
        //                        u.AdsDurationStatusOk,
        //                        u.AdsDurationStatusNotOk,
        //                        u.AdsDurationStatusRemark,
        //                        u.AdsPlayTimeStatusOk,
        //                        u.AdsPlayTimeStatusNotOk,
        //                        u.AdsPlayTimeStatusRemark,
        //                        u.AdsSequenceStatusOk,
        //                        u.AdsSequenceStatusNotOk,
        //                        u.AdsSequenceStatusRemark,
        //                        u.Occupancy,
        //                        u.LanguageStatusOk,
        //                        u.LanguageStatusNotOk,
        //                        u.LanguageStatusRemark,
        //                        u.TheaterInspectionStatusforMale,
        //                        u.TheaterInspectionStatusforFemale,
        //                        u.TheaterInspectionforMale,
        //                        u.TheaterInspectionforFemale,
        //                        u.CreatedBy,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false).ToList();


        //        //int totalRecords = list.Count();
        //        //return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });

        //        int totalFeedbackCount = list.Count(); // This is the total count based on your existing logic

        //        return Ok(new { data = list, totalFeedbackCount, recordsTotal = totalFeedbackCount, recordsFiltered = totalFeedbackCount });

        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        //[HttpGet("{adsName}")]

        [HttpGet]
        public ActionResult GetClientAdsFeedbackListbyAdsNames([FromQuery] string adsNames)
        {
            try
            {
                // Split the comma-separated string into an array of ads names
                var adsNameArray = adsNames.Split(',');

                var list = (from s in _context.AdScreenMapping
                            join u in _context.AdScreenFeedbackForm on s.AdScreenId equals u.AdScreenId
                            join p in _context.Agents on u.AgentId equals p.AgentId
                            join q in _context.States on s.StateId equals q.StateId

                            where adsNameArray.Contains(s.AdsName)
                            select new
                            {
                                u.AdScreenFeedbackFormId,
                                u.AdScreenId,
                                u.AgentId,
                                p.AgentName,
                                u.StateId,
                                q.StateName,
                                s.AdsName,
                                s.City,
                                s.TheatreName,
                                s.Screen,
                                s.AdsLanguage,
                                s.AdsSequence,
                                s.AdsDuration,
                                s.AdsPlaytime,
                                s.AdsYoutubeLink,
                                u.AdsVariantStatusOk,
                                u.AdsVariantStatusNotOk,
                                u.AdsVariantStatusRemark,
                                u.AdsDurationStatusOk,
                                u.AdsDurationStatusNotOk,
                                u.AdsDurationStatusRemark,
                                u.AdsPlayTimeStatusOk,
                                u.AdsPlayTimeStatusNotOk,
                                u.AdsPlayTimeStatusRemark,
                                u.AdsSequenceStatusOk,
                                u.AdsSequenceStatusNotOk,
                                u.AdsSequenceStatusRemark,
                                u.Occupancy,
                                u.LanguageStatusOk,
                                u.LanguageStatusNotOk,
                                u.LanguageStatusRemark,
                                u.TheaterInspectionStatusforMale,
                                u.TheaterInspectionStatusforFemale,
                                u.TheaterInspectionforMale,
                                u.TheaterInspectionforFemale,
                                u.CreatedBy,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false).ToList();

                int totalFeedbackCount = list.Count();

                return Ok(new { data = list, totalFeedbackCount, recordsTotal = totalFeedbackCount, recordsFiltered = totalFeedbackCount });

            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

    }
}
