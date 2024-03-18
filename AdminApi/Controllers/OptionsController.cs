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
    public class OptionsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly ISqlRepository<Options> _OptionsTableRepo;

        public OptionsController(IConfiguration config,
                                    AppDbContext context,
                                    ISqlRepository<Options> AnswerRepo)
        {
            _config = config;
            _context = context;
            _OptionsTableRepo = AnswerRepo;
        }



        [HttpPost]
        public IActionResult OptionsCreate(OptionsTableMasterDTO optionsTableMasterDTO)
        {
            try
            {                

                for (int i = 0; i < optionsTableMasterDTO.OptionsTableDTOs.Count; i++)
                {
                    //var objcheck = _context.AnswerTable.SingleOrDefault(opt => opt.QuestionTableId == answerTableMasterDTO.AnswerTableDTOs[i].QuestionTableId && opt.IsDeleted == false);

                    //if (objcheck != null)
                    //{
                    //    return Accepted(new Confirmation { Status = "Duplicate", ResponseMsg = "Duplicate Question..!" });
                    //}

                    Options opt = new Options();
                    opt.QuestionId = optionsTableMasterDTO.OptionsTableDTOs[i].QuestionId;
                    opt.AdsName = optionsTableMasterDTO.OptionsTableDTOs[i].AdsName;
                    opt.Option = optionsTableMasterDTO.OptionsTableDTOs[i].Option;
                    opt.CreatedBy = optionsTableMasterDTO.OptionsTableDTOs[i].CreatedBy;
                    opt.CreatedOn = System.DateTime.Now;
                    _OptionsTableRepo.Insert(opt);
                }

                return Ok(optionsTableMasterDTO);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult GetOptionList()
        {
            try
            {
                var list = (from u in _context.Options
                            join p in _context.QuestionTable on u.QuestionId equals p.QuestionTableId

                            select new
                            {
                                u.OptionsId,
                                u.QuestionId,
                                p.Questions,
                                u.AdsName,
                                u.Option,
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

        /// <summary>
        /// Questions Show in Audience Review
        /// </summary>
        [HttpGet("{AdsName}")]
        public ActionResult GetOptionListFromQuestionbyadsname(string AdsName)
        {
            try
            {
                var questions = (from p in _context.QuestionTable
                                 where p.IsDeleted == false && p.AdsName == AdsName
                                 select new
                                 {
                                     p.QuestionTableId,
                                     p.Questions,
                                     p.AdsName,
                                     p.IsDeleted
                                 }).ToList();


                var options = (from u in _context.Options
                               where u.IsDeleted == false
                               select new
                               {
                                   u.QuestionId,
                                   u.OptionsId,
                                   u.Option,
                                   u.IsDeleted
                               }).ToList();


                var combinedList = questions.Select(q => new
                {
                    QuestionTableId = q.QuestionTableId,
                    Questions = q.Questions,
                    AdsName = q.AdsName,
                    Options = options.Where(o => o.QuestionId == q.QuestionTableId)
                                      .Select(option => new
                                      {
                                          OptionsId = option.OptionsId,
                                          Option = option.Option,
                                          IsDeleted = option.IsDeleted
                                      }).ToList()
                }).ToList();

                int totalRecords = combinedList.Count();

                return Ok(new { data = combinedList, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{QuesId}")]
        public ActionResult GetOptionListFromQsnId(int QuesId)
        {
            try
            {
                var list = (from u in _context.Options
                            where u.QuestionId == QuesId
                            join p in _context.QuestionTable on u.QuestionId equals p.QuestionTableId
                            

                            select new
                            {
                                p.QuestionTableId,
                                p.Questions,
                                p.AdsName,
                                u.OptionsId,
                                u.Option,
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

        [HttpGet("{optionsId}")]
        public ActionResult GetSingleOption(int optionsId)
        {
            try
            {
                var singlequestion = _OptionsTableRepo.SelectById(optionsId);
                return Ok(singlequestion);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult UpdateOption(OptionsTableUpdateDTO optionsTableUpdateDTO)
        {
            try
            {
                var objState = _context.Options.SingleOrDefault(opt => opt.OptionsId == optionsTableUpdateDTO.OptionsId);
                objState.QuestionId = optionsTableUpdateDTO.QuestionId;
                objState.AdsName = optionsTableUpdateDTO.AdsName;
                objState.Option = optionsTableUpdateDTO.Option;
                objState.UpdatedBy = optionsTableUpdateDTO.UpdatedBy;
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
        public ActionResult DeleteOption(int Id, int DeletedBy)
        {
            try
            {
                var objabout = _context.Options.SingleOrDefault(opt => opt.OptionsId == Id);
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
