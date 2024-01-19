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

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UpComingMovieListforClientController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly ISqlRepository<UpComingMovieListforClient> _UpComingMovieListforClientRepo;

        public UpComingMovieListforClientController(IConfiguration config,
                                    AppDbContext context,
                                    ISqlRepository<UpComingMovieListforClient> UpComingMovieListforClientRepo)
        {
            _config = config;
            _context = context;
            _UpComingMovieListforClientRepo = UpComingMovieListforClientRepo;
        }

        [HttpPost]
        public IActionResult UpComingMovieListCreate(IFormFile file)
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

                    // Iterate through rows and save data to the database
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Start from row 2 (assuming row 1 contains headers)
                    {
                        var excelData = new UpComingMovieListforClient
                        {
                            MovieName = worksheet.Cells[row, 1].Value?.ToString(),
                            ReleaseDate = worksheet.Cells[row, 2].Value?.ToString(),
                            StarCast = worksheet.Cells[row, 3].Value?.ToString(),
                            Director = worksheet.Cells[row, 4].Value?.ToString(),
                            Producer = worksheet.Cells[row, 5].Value?.ToString(), 
                        };
                        _context.UpComingMovieListforClient.Add(excelData);
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

        [HttpGet]
        public ActionResult GetallList()
        {
            try
            {
                var list = (from u in _context.UpComingMovieListforClient

                            select new
                            {
                                u.UpComingMovieListforClientId,
                                u.MovieName,
                                u.ReleaseDate,
                                u.StarCast,
                                u.Director,
                                u.Producer,
                               
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

    }
}
