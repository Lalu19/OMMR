using AdminApi.Models.App.Location;
using AdminApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AdminApi.Models.App;
using AdminApi.Models.Helper;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using OfficeOpenXml;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScreenListController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly ISqlRepository<ScreenList> _ScreenListRepo;

        public ScreenListController(IConfiguration config,
                                    AppDbContext context,
                                    ISqlRepository<ScreenList> ScreenListRepo)
        {
            _config = config;
            _context = context;
            _ScreenListRepo = ScreenListRepo;
        }

      //  [HttpPost]
      //  public IActionResult ScreenListCreate(IFormFile file)
      //  {
      //      try
      //      {
      //          if (file == null || file.Length == 0)
      //          {
      //              return BadRequest(new { status = "error", responseMsg = "No file uploaded" });
      //          }
      //          using (var package = new ExcelPackage(file.OpenReadStream()))
      //          {
      //              var worksheet = package.Workbook.Worksheets[0]; // Assuming the data is on the first sheet

      //              // Iterate through rows and save data to the database
      //              for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Start from row 2 (assuming row 1 contains headers)
      //              {
      //                  var excelData = new ScreenList
      //                  {
      //                      Region = worksheet.Cells[row, 1].Value?.ToString(),
      //                      State = worksheet.Cells[row, 2].Value?.ToString(),
      //                      City = worksheet.Cells[row, 3].Value?.ToString(),
      //                      District = worksheet.Cells[row, 4].Value?.ToString(),
      //                      TheatreCode = worksheet.Cells[row, 5].Value?.ToString(),
      //                      TheatreName = worksheet.Cells[row, 6].Value?.ToString(),
      //                      Latitude = worksheet.Cells[row, 7].Value?.ToString(),
      //                      Longitude = worksheet.Cells[row, 8].Value?.ToString(),
      //                      SEC = worksheet.Cells[row, 9].Value?.ToString(),
      //                      Screen = worksheet.Cells[row, 10].Value?.ToString(),
      //                      NoofSeats = worksheet.Cells[row, 11].Value?.ToString(),
      //                      TheatreRating = worksheet.Cells[row, 12].Value?.ToString(),
      //                      Rate = worksheet.Cells[row, 13].Value?.ToString(),
      //                      Media = worksheet.Cells[row, 14].Value?.ToString(),
      //                      //IsActive = true 
      //                  };
						//var existingRecord = _context.ScreenList.FirstOrDefault(s =>
				  //      s.State == excelData.State &&
				  //      s.City == excelData.City &&
				  //      s.TheatreName == excelData.TheatreName &&
				  //      s.Screen == excelData.Screen);

      //                  if (existingRecord != null)
      //                  {
						//	existingRecord.Region = excelData.Region;
						//	existingRecord.State = excelData.State;
						//	existingRecord.City = excelData.City;
						//	existingRecord.District = excelData.District;
						//	existingRecord.TheatreCode = excelData.TheatreCode;
						//	existingRecord.TheatreName = excelData.TheatreName;
						//	existingRecord.Latitude = excelData.Latitude;
						//	existingRecord.Longitude = excelData.Longitude;
						//	existingRecord.SEC = excelData.SEC;
						//	existingRecord.Screen = excelData.Screen;
						//	existingRecord.NoofSeats = excelData.NoofSeats;
						//	existingRecord.TheatreRating = excelData.TheatreRating;
						//	existingRecord.Rate = excelData.Rate;
						//	existingRecord.Media = excelData.Media;
						//	existingRecord.UpdatedBy = excelData.UpdatedBy;
						//	existingRecord.UpdatedOn = System.DateTime.Now;
						//}
      //                  else
      //                  {
      //                      // Create a new record
      //                      var stateEntity = _context.States.FirstOrDefault(s => s.StateName == excelData.State);
      //                      if (stateEntity != null)
      //                      {
      //                          excelData.StateId = stateEntity.StateId;
      //                      }

      //                      _context.ScreenList.Add(excelData);
      //                  }
						
      //              }

      //              _context.SaveChanges();
      //          }

      //          return Ok(new { status = "success", responseMsg = "Data saved successfully" });
      //      }
      //      catch (Exception ex)
      //      {
      //          // Handle exceptions as needed
      //          return StatusCode(500, new { status = "error", responseMsg = "An error occurred" });
      //      }
      //  }

        [HttpPost]
        public IActionResult ScreenListCreate(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest(new { status = "error", responseMsg = "No file uploaded" });
                }
                using (var package = new ExcelPackage(file.OpenReadStream()))
                {
                    var worksheet = package.Workbook.Worksheets[0]; // Assuming the data is on the first sheet
                    // Delete all records from the AdScreen table
                    _context.Database.ExecuteSqlRaw("DELETE FROM ScreenList");

                    // Reset the identity column seed for AdScreenId
                    _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('ScreenList', RESEED, 0)");
                    // Iterate through rows and save data to the database
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Start from row 2 (assuming row 1 contains headers)
                    {
                        var excelData = new ScreenList
                        {
                            Region = worksheet.Cells[row, 1].Value?.ToString(),
                            State = worksheet.Cells[row, 2].Value?.ToString(),
                            City = worksheet.Cells[row, 3].Value?.ToString(),
                            District = worksheet.Cells[row, 4].Value?.ToString(),
                            TheatreCode = worksheet.Cells[row, 5].Value?.ToString(),
                            TheatreName = worksheet.Cells[row, 6].Value?.ToString(),
                            Latitude = worksheet.Cells[row, 7].Value?.ToString(),
                            Longitude = worksheet.Cells[row, 8].Value?.ToString(),
                            SEC = worksheet.Cells[row, 9].Value?.ToString(),
                            Screen = worksheet.Cells[row, 10].Value?.ToString(),
                            NoofSeats = worksheet.Cells[row, 11].Value?.ToString(),
                            TheatreRating = worksheet.Cells[row, 12].Value?.ToString(),
                            Rate = worksheet.Cells[row, 13].Value?.ToString(),
                            Media = worksheet.Cells[row, 14].Value?.ToString(),
                            //IsActive = true 
                        };
                        // Create a new record
                        var stateEntity = _context.States.FirstOrDefault(s => s.StateName == excelData.State);
                        if (stateEntity != null)
                        {
                            excelData.StateId = stateEntity.StateId;
                        }
                        _context.ScreenList.Add(excelData);

                    }

                    _context.SaveChanges();
                }

                return Ok(new { status = "success", responseMsg = "Data saved successfully" });
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                return StatusCode(500, new { status = "error", responseMsg = "An error occurred" });
            }
        }
        //[HttpPost]
        //public IActionResult ToggleActivation(int screenListId, bool isActive)
        //{
        //    try
        //    {
        //        var screen = _context.ScreenList.FirstOrDefault(s => s.ScreenListId == screenListId);
        //        if (screen != null)
        //        {
        //            screen.IsActive = isActive;
        //            _context.SaveChanges();
        //            return Ok(new { status = "success", responseMsg = "Screen activation status updated" });
        //        }
        //        else
        //        {
        //            return NotFound(new { status = "error", responseMsg = "Screen not found" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions as needed
        //        return StatusCode(500, new { status = "error", responseMsg = "An error occurred" });
        //    }
        //}


        [HttpGet]
        public ActionResult GetallList()
        {
            try
            {
                var list = (from u in _context.ScreenList

                            select new
                            {
                                u.Region,
                                u.State,
                                u.City,
                                u.District,
                                u.TheatreCode,
                                u.TheatreName,
                                u.Latitude,
                                u.Longitude,
                                u.SEC,
                                u.Screen,
                                u.NoofSeats,
                                u.TheatreRating,
                                u.Rate,
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

        [HttpGet]
        public ActionResult GetStateList()
        {
            try
            {
                var list = (from u in _context.ScreenList
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
                var list = (from u in _context.ScreenList
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
                var list = (from u in _context.ScreenList

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
        public ActionResult GetSECList()
        {
            try
            {
                var list = (from u in _context.ScreenList

                            select new
                            {
                                u.SEC,
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
        public ActionResult GetTheaterRatingList()
        {
            try
            {
                var list = (from u in _context.ScreenList

                            select new
                            {
                                u.TheatreRating,
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
                var list = (from u in _context.ScreenList

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

        [HttpGet("{State}")]
        public ActionResult GetCityListbystatename(string State)
        {
            try
            {
                var list = (from u in _context.ScreenList

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

        [HttpGet("{Stateid}")]
        public ActionResult GetCityListbystateid(int Stateid)
        {
            try
            {
                var list = (from u in _context.ScreenList
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
                var list = (from u in _context.ScreenList
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

        [HttpGet("{city}")]
        public ActionResult GetTheaterListbycityname(string city)
        {
            try
            {
                var list = (from u in _context.ScreenList

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

        [HttpGet("{Userid}")]
        public ActionResult GetAllListbystateid(int Userid)
        {
            try
            {
                var list = (from u in _context.ScreenList
                                //join a in _context.States on u.StateId equals a.StateId
                            join p in _context.StateUser on u.StateId equals p.StateId

                            select new
                            {
                                p.StateId,
                                u.State,
                                u.City,
                                u.TheatreName,
                                u.Screen,
                                u.NoofSeats,
                                u.TheatreRating,
                                u.Rate,
                                u.Media,
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



        [HttpGet("{city}")]
        public ActionResult GetSecListbycityname(string city)
        {
            try
            {
                var list = (from u in _context.ScreenList

                            select new
                            {
                                u.City,
                                u.SEC,
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

        [HttpGet("{sec}")]
        public ActionResult GetTheaterRatingListbysec(string sec)
        {
            try
            {
                var list = (from u in _context.ScreenList

                            select new
                            {
                                u.SEC,
                                u.TheatreRating,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.SEC == sec).Distinct().ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{theaterRating}")]
        public ActionResult GetMediaListbyTheaterRating(string theaterRating)
        {
            try
            {
                var list = (from u in _context.ScreenList

                            select new
                            {
                                u.TheatreRating,
                                u.Media,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.TheatreRating == theaterRating).Distinct().ToList();

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
                var list = (from u in _context.ScreenList
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

        [HttpGet("{TheaterName}/{Stateid}")]
        public ActionResult GetLocationbyTheaterName(string TheaterName, int Stateid)
        {
            try
            {
                var list = (from u in _context.ScreenList
                            join a in _context.States on u.StateId equals a.StateId

                            select new
                            {
                                a.StateId,
                                u.City,
                                u.TheatreName,
                                u.Latitude,
                                u.Longitude,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.TheatreName == TheaterName && x.StateId == Stateid).Distinct().ToList();


                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //[HttpGet]
        //public ActionResult GetCityList()
        //{
        //    try
        //    {
        //        var list = (from u in _context.ScreenList

        //                    select new
        //                    {
        //                        u.City,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false).Distinct().ToList();

        //        int totalRecords = list.Count();

        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }

        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}
        //[HttpGet]
        //public ActionResult GetAreaList()
        //{
        //    try
        //    {
        //        var list = (from u in _context.ScreenList

        //                    select new
        //                    {
        //                        u.Area,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false).Distinct().ToList();

        //        int totalRecords = list.Count();

        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }

        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        //[HttpGet]
        //public ActionResult GetTheaterList()
        //{
        //    try
        //    {
        //        var list = (from u in _context.ScreenList

        //                    select new
        //                    {
        //                        u.TheaterName,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false).Distinct().ToList();

        //        int totalRecords = list.Count();

        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }

        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        //[HttpGet("{State}")]
        //public ActionResult GetCityListbystatename(string State)
        //{
        //    try
        //    {
        //        var list = (from u in _context.ScreenList

        //                    select new
        //                    {
        //                        u.State,
        //                        u.City,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false && x.State == State).Distinct().ToList();

        //        int totalRecords = list.Count();

        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }

        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        //[HttpGet("{city}")]
        //public ActionResult GetAreaaListbycityname(string city)
        //{
        //    try
        //    {
        //        var list = (from u in _context.ScreenList

        //                    select new
        //                    {
        //                       u.Area,
        //                        u.City,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false && x.City == city).Distinct().ToList();

        //        int totalRecords = list.Count();

        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }

        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        //[HttpGet("{area}")]
        //public ActionResult GetTheaterListbyareaname(string area)
        //{
        //    try
        //    {
        //        var list = (from u in _context.ScreenList

        //                    select new
        //                    {
        //                        u.Area,
        //                        u.TheaterName,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false && x.Area == area).Distinct().ToList();

        //        int totalRecords = list.Count();

        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }

        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        ////state
        //[HttpGet("{Stateid}")]
        //public ActionResult GetCityListbystateid(int Stateid)
        //{
        //    try
        //    {
        //        var list = (from u in _context.ScreenList
        //                    join a in _context.States on u.StateId equals a.StateId

        //                    select new
        //                    {
        //                        a.StateId,
        //                        u.State,
        //                        u.City,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false && x.StateId == Stateid).Distinct().ToList();

        //        int totalRecords = list.Count();

        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }

        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        //[HttpGet("{cityid}")]
        //public ActionResult GetareaListbycityid(int cityid)
        //{
        //    try
        //    {
        //        var list = (from u in _context.ScreenList
        //                    join a in _context.Citys on u.StateId equals a.StateId

        //                    select new
        //                    {
        //                        a.StateId,
        //                        u.State,
        //                        a.CityId,
        //                        a.CityName,
        //                        u.City,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false && x.CityId == cityid).Distinct().ToList();

        //        int totalRecords = list.Count();

        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }

        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        //[HttpGet("{city}/{Stateid}")]
        //public ActionResult GetAreaListbyCityname(string city, int Stateid)
        //{
        //    try
        //    {
        //        var list = (from u in _context.ScreenList
        //                    join a in _context.States on u.StateId equals a.StateId

        //                    select new
        //                    {
        //                        a.StateId,
        //                        u.City,
        //                        u.Area,
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

        //[HttpGet("{area}/{Stateid}")]
        //public ActionResult GetTheaterListbyAreaname(string area, int Stateid)
        //{
        //    try
        //    {
        //        var list = (from u in _context.ScreenList
        //                    join a in _context.States on u.StateId equals a.StateId

        //                    select new
        //                    {
        //                        a.StateId,
        //                        u.Area,
        //                        u.TheaterName,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false && x.Area == area && x.StateId == Stateid).Distinct().ToList();

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
        //        var list = (from u in _context.ScreenList
        //                    join a in _context.States on u.StateId equals a.StateId

        //                    select new
        //                    {
        //                        a.StateId,
        //                        u.TheaterName,
        //                        u.Screen,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false && x.TheaterName == TheaterName && x.StateId == Stateid).Distinct().ToList();

        //        int totalRecords = list.Count();

        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }

        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        ////For Agent create by Admin
        //[HttpGet("{State}")]
        //public ActionResult GetStateIdbystatename(string State)
        //{
        //    try
        //    {
        //        var list = (from u in _context.ScreenList
        //                    join a in _context.States on u.StateId equals a.StateId

        //                    select new
        //                    {
        //                        a.StateId,
        //                        u.State,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false && x.State == State).Distinct().ToList();

        //        int totalRecords = list.Count();

        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }

        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}
    }

}
