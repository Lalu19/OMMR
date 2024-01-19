using AdminApi.Models.App.Agent;
using AdminApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AdminApi.Models.App;
using AdminApi.DTO.App.AgentDTO;
using AdminApi.Models.Helper;
using System.Linq;
using System;
using AdminApi.DTO.App;

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UpcomingMovieController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly ISqlRepository<UpcomingMovie> _UpcomingMovieRepo;
        public UpcomingMovieController(IConfiguration config,
                                AppDbContext context,
                                ISqlRepository<UpcomingMovie> UpcomingMovieRepo)

        {
            _config = config;
            _context = context;
            _UpcomingMovieRepo = UpcomingMovieRepo;

        }

        [HttpPost]
        public IActionResult UpcomingMovieCreate(UpcomingMovieDTO upcomingMovieDTO)
        {
           // var objcheck = _context.UpcomingMovie.SingleOrDefault(opt => opt.AdsName == hallPassDTO.AdsName && opt.IsDeleted == false);
            try
            {
                //if (objcheck == null)
                //{
                    UpcomingMovie hp = new UpcomingMovie();
                    hp.MoviePoster = upcomingMovieDTO.MoviePoster;
                    hp.TeaserLink = upcomingMovieDTO.TeaserLink;
                    hp.CreatedBy = upcomingMovieDTO.CreatedBy;
                    hp.CreatedOn = System.DateTime.Now;
                    var obj = _UpcomingMovieRepo.Insert(hp);
                    return Ok(obj);
                //}
                //else if (objcheck != null)
                //{
                //    return Accepted(new Confirmation { Status = "Duplicate", ResponseMsg = "Duplicate Ads Name..!" });
                //}
                //return Accepted(new Confirmation { Status = "Error", ResponseMsg = "Something unexpected!" });

            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }

        }

        [HttpGet]
        public ActionResult GetUpcomingMovieList()
        {
            try
            {
                var list = (from u in _context.UpcomingMovie

                            select new
                            {
                                u.UpcomingMovieId,
                                u.MoviePoster,
                                u.TeaserLink,
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

        [HttpGet("{upcomingMovieId}")]
        public ActionResult GetSingleMovie(int upcomingMovieId)
        {
            try
            {
                var singleMovie = _UpcomingMovieRepo.SelectById(upcomingMovieId);
                return Ok(singleMovie);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //update
        [HttpPost]
        public ActionResult UpdateMovie(UpdateUpcomingMovieDTO updateUpcomingMovieDTO)
        {
            try
            {
                var objMovie = _context.UpcomingMovie.SingleOrDefault(opt => opt.UpcomingMovieId == updateUpcomingMovieDTO.UpcomingMovieId);
                objMovie.MoviePoster = updateUpcomingMovieDTO.MoviePoster;
                objMovie.TeaserLink = updateUpcomingMovieDTO.TeaserLink;
                objMovie.UpdatedBy = updateUpcomingMovieDTO.UpdatedBy;
                objMovie.UpdatedOn = System.DateTime.Now;
                _context.SaveChanges();
                return Ok(objMovie);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{Id}/{DeletedBy}")]
        public ActionResult DeleteMovie(int Id, int DeletedBy)
        {
            try
            {
                var objabout = _context.UpcomingMovie.SingleOrDefault(opt => opt.UpcomingMovieId == Id);
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

    }
}
