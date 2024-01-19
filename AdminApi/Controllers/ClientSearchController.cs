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
using Microsoft.Extensions.Logging;
using AdminApi.Models.User;

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientSearchController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly ILogger<ClientSearchController> _logger; // Inject a logger
        private readonly ISqlRepository<ClientSearch> _ClientSearchRepo;

        public ClientSearchController(IConfiguration config,
                                    AppDbContext context,
                                    ISqlRepository<ClientSearch> ClientSearchRepo)
        {
            _config = config;
            _context = context;
            _ClientSearchRepo = ClientSearchRepo;
        }

        [HttpPost("SaveDataToDatabase")]
        public IActionResult SaveDataToDatabase([FromBody] List<ClientSearch> data)
        {
            try
            {
                if (data == null || data.Count == 0)
                {
                    return BadRequest("No data provided.");
                }

                // Validate data here (e.g., check for required fields)

                // Save data to the database
                foreach (var item in data)
                {
                    var stateEntity = _context.States.FirstOrDefault(s => s.StateName == item.State);

                    if (stateEntity != null)
                    {
                        item.StateId = stateEntity.StateId;
                    }
                    else
                    {
                        // Handle the case where StateName doesn't exist in the States table
                        return BadRequest($"State not found for: {item.State}");
                    }

                    // Save the item using your data access logic
                    _context.ClientSearch.Add(item);
                }

                // Commit changes to the database
                _context.SaveChanges();

                return Ok("Data saved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving data to the database.");
                return BadRequest("Error saving data to the database: " + ex.Message);
            }
        }

       
        [HttpGet]
        public ActionResult GetallClientSearchListforClient(int ClientId)
        {
            try
            {
                var list = (from u in _context.ClientSearch.Where(x => x.CreatedBy == ClientId)
                            

                            select new
                            {
                                
                                u.Region,
                                u.State,
                                u.City,
                                u.District,
                                u.TheatreCode,
                                u.TheatreName,
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
        public ActionResult GetallClientSearchList()
        {
            try
            {
                var list = (from u in _context.ClientSearch
                            join a in _context.Users on u.CreatedBy equals a.UserId

                            select new
                            {
                                a.FullName,
                                a.UserName,
                                a.UserId,
                                u.Region,
                                u.State,
                                u.City,
                                u.District,
                                u.TheatreCode,
                                u.TheatreName,
                                u.SEC,
                                u.Screen,
                                u.NoofSeats,
                                u.TheatreRating,
                                u.Rate,
                                u.Media,
                                a.IsActive
                            }).Where(x => x.IsActive == true).ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{userid}")]
        public ActionResult GetallClientSearchListforadmin(int userid)
        {
            try
            {
                var list = (from u in _context.ClientSearch
                            join a in _context.Users on u.CreatedBy equals a.UserId

                            select new
                            {
                                a.FullName,
                                a.UserName,
                                a.UserId,
                                u.Region,
                                u.State,
                                u.City,
                                u.District,
                                u.TheatreCode,
                                u.TheatreName,
                                u.SEC,
                                u.Screen,
                                u.NoofSeats,
                                u.TheatreRating,
                                u.Rate,
                                u.Media,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.UserId == userid).ToList();

                int totalRecords = list.Count();

                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

    }
}
