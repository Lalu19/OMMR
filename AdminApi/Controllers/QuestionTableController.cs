using AdminApi.Models.Helper;
using AdminApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AdminApi.Models.App.Location;
using AdminApi.DTO.App.LocationDTO;
using System;
using System.Linq;
using AdminApi.Models.App;
using AdminApi.DTO.App;

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionTableController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly ISqlRepository<QuestionTable> _QuestionRepo;

        public QuestionTableController(IConfiguration config,
                                    AppDbContext context,
                                    ISqlRepository<QuestionTable> QuestionRepo)
        {
            _config = config;
            _context = context;
            _QuestionRepo = QuestionRepo;
        }
        [HttpPost]
        public IActionResult QuestionCreate(QuestionTableDTO questionTableDTO)
        {
            try
            {
                QuestionTable qs = new QuestionTable();
                qs.Questions = questionTableDTO.Questions;
                qs.AdsName = questionTableDTO.AdsName;
                qs.CreatedBy = questionTableDTO.CreatedBy;
                qs.CreatedOn = System.DateTime.Now;
                var obj = _QuestionRepo.Insert(qs);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult GetQuestionList()
        {
            try
            {
                var list = (from u in _context.QuestionTable

                            select new {
                                u.QuestionTableId,
                                u.Questions,
                                u.AdsName,
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

        //single Id
        [HttpGet("{questionTableId}")]
        public ActionResult GetSingleQuestion(int questionTableId)
        {
            try
            {
                var singlequestion = _QuestionRepo.SelectById(questionTableId);
                return Ok(singlequestion);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //update
        [HttpPost]
        public ActionResult UpdateQuestion(UpdateQuestionTableDTO updateQuestionTableDTO)
        {
            try
            {
                var objState = _context.QuestionTable.SingleOrDefault(opt => opt.QuestionTableId == updateQuestionTableDTO.QuestionTableId);
                objState.Questions = updateQuestionTableDTO.Questions;
                objState.AdsName = updateQuestionTableDTO.AdsName;
                objState.UpdatedBy = updateQuestionTableDTO.UpdatedBy;
                objState.UpdatedOn = System.DateTime.Now;
                _context.SaveChanges();
                return Ok(objState);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{Id}/{DeletedBy}")]
        public ActionResult DeleteQuestion(int Id, int DeletedBy)
        {
            try
            {
                var objabout = _context.QuestionTable.SingleOrDefault(opt => opt.QuestionTableId == Id);
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

        [HttpGet("{adsName}")]
        public ActionResult GetQsListFromAdsname(string adsName)
        {
            try
            {
                var list = (from u in _context.QuestionTable

                            select new
                            {
                                u.AdsName,
                                u.Questions,
                                u.QuestionTableId,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.AdsName == adsName).Distinct().ToList();

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
