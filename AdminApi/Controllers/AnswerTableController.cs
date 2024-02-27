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
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnswerTableController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly ISqlRepository<AnswerTable> _AnswerRepo;

        public AnswerTableController(IConfiguration config,
                                    AppDbContext context,
                                    ISqlRepository<AnswerTable> AnswerRepo)
        {
            _config = config;
            _context = context;
            _AnswerRepo = AnswerRepo;
        }

        //[HttpPost]
        //public IActionResult AnswerCreate(AnswerTableDTO answerTableDTO)
        //{
        //    try
        //    {
        //        AnswerTable qs = new AnswerTable();
        //        qs.QuestionTableId = answerTableDTO.QuestionTableId;
        //        qs.Answers = answerTableDTO.Answers;
        //        qs.CreatedBy = answerTableDTO.CreatedBy;
        //        qs.CreatedOn = System.DateTime.Now;
        //        var obj = _AnswerRepo.Insert(qs);
        //        return Ok(obj);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        //[HttpPost]
        //public IActionResult AnswerCreate([FromBody] List<AnswerTableDTO> answerTableDTOs)
        //{
        //    try
        //    {
        //        var responseData = new List<object>();

        //        foreach (var answerTableDTO in answerTableDTOs)
        //        {
        //            AnswerTable qs = new AnswerTable
        //            {
        //                QuestionTableId = answerTableDTO.QuestionTableId,
        //                Answers = answerTableDTO.Answers,
        //                CreatedBy = answerTableDTO.CreatedBy,
        //                CreatedOn = System.DateTime.Now
        //            };

        //            var obj = _AnswerRepo.Insert(qs);

        //            responseData.Add(new
        //            {
        //                QuestionTableId = obj.QuestionTableId,
        //                Answers = obj.Answers,
        //                CreatedBy = obj.CreatedBy
        //            });
        //        }

        //        return Ok(new { data = responseData });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        [HttpPost]
        public IActionResult AnswerCreate(AnswerTableMasterDTO answerTableMasterDTO)
        {
            try
            {
                for (int i = 0; i < answerTableMasterDTO.AnswerTableDTOs.Count; i++)
                {
                    //var objcheck = _context.AnswerTable.SingleOrDefault(opt => opt.QuestionTableId == answerTableMasterDTO.AnswerTableDTOs[i].QuestionTableId && opt.IsDeleted == false);

                    //if (objcheck != null)
                    //{
                    //    return Accepted(new Confirmation { Status = "Duplicate", ResponseMsg = "Duplicate Question..!" });
                    //}

                    AnswerTable ans = new AnswerTable();
                    ans.QuestionTableId = answerTableMasterDTO.AnswerTableDTOs[i].QuestionTableId;
                    ans.OptionId = answerTableMasterDTO.AnswerTableDTOs[i].OptionId;
                    ans.Answers = answerTableMasterDTO.AnswerTableDTOs[i].Answers;
                    ans.StateId = answerTableMasterDTO.AnswerTableDTOs[i].StateId;
                    ans.AgentId = answerTableMasterDTO.AnswerTableDTOs[i].AgentId;
                    ans.AgentName = answerTableMasterDTO.AnswerTableDTOs[i].AgentName;
                    ans.Agentrole = answerTableMasterDTO.AnswerTableDTOs[i].Agentrole;
                    ans.TheatreName = answerTableMasterDTO.AnswerTableDTOs[i].TheatreName;
                    ans.CreatedBy = answerTableMasterDTO.AnswerTableDTOs[i].CreatedBy;
                    _AnswerRepo.Insert(ans);
                }

                return Ok(answerTableMasterDTO);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult GetAnswerList()
        {
            try
            {
                var list = (from u in _context.AnswerTable

                            select new
                            {
                                u.AnswerTableId,
                                u.QuestionTableId,
                                u.OptionId,
                                u.Answers,
                                u.StateId,
                                u.AgentId,
                                u.AgentName,
                                u.Agentrole,
                                u.TheatreName,
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
        public ActionResult GetAnswerListFromQuestion()
        {
            try
            {
                var list = (from u in _context.AnswerTable
                            join p in _context.QuestionTable on u.QuestionTableId equals p.QuestionTableId
                            join q in _context.Options on u.QuestionTableId equals q.QuestionId
                            select new
                            {
                                p.QuestionTableId,
                                p.Questions,
                                u.AnswerTableId,
                                u.OptionId,
                                q.Option,
                                u.AgentName,
                                u.Agentrole,
                                u.TheatreName,
                                u.CreatedOn,
                                u.Answers,
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

        //[HttpGet]
        //public ActionResult GetAnswerListFromQuestion()
        //{
        //    try
        //    {
        //        var list = (from u in _context.AnswerTable
        //                    join p in _context.QuestionTable on u.QuestionTableId equals p.QuestionTableId
        //                    join q in _context.Options on u.QuestionTableId equals q.QuestionId
        //                    join w in _context.AgentMappings on u.AgentId equals w.AgentId
        //                    //join w in _context.AgentMappings on u.AgentId equals w.AgentId

        //                    select new
        //                    {
        //                        p.QuestionTableId,
        //                        p.Questions,
        //                        u.AnswerTableId,
        //                        u.OptionId,
        //                        q.Option,
        //                        u.Answers,
        //                        w.AgentName,
        //                        u.TheatreName,
        //                        w.Agentrole,
        //                        u.CreatedOn,
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

        //single Id

        [HttpGet("{answerTableId}")]
        public ActionResult GetSingleAnswer(int answerTableId)
        {
            try
            {
                var singlequestion = _AnswerRepo.SelectById(answerTableId);
                return Ok(singlequestion);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //update
        [HttpPost]
        public ActionResult UpdateAnswer(UpdateAnswerTableDTO updateAnswerTableDTO)
        {
            try
            {
                var objState = _context.AnswerTable.SingleOrDefault(opt => opt.AnswerTableId == updateAnswerTableDTO.AnswerTableId);
                objState.QuestionTableId = updateAnswerTableDTO.QuestionTableId;
                objState.Answers = updateAnswerTableDTO.Answers;
                objState.StateId = updateAnswerTableDTO.StateId;
                objState.AgentId = updateAnswerTableDTO.AgentId;
                objState.AgentName = updateAnswerTableDTO.AgentName;
                objState.Agentrole = updateAnswerTableDTO.Agentrole;
                objState.TheatreName = updateAnswerTableDTO.TheatreName;
                objState.UpdatedBy = updateAnswerTableDTO.UpdatedBy;
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
        public ActionResult DeleteAnswer(int Id, int DeletedBy)
        {
            try
            {
                var objabout = _context.AnswerTable.SingleOrDefault(opt => opt.AnswerTableId == Id);
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

        [HttpPost]
        public IActionResult DeleteSelectedAnswers([FromBody] int[] idsToDelete, int deletedBy)
        {
            try
            {
                var answersToDelete = _context.AnswerTable.Where(opt => idsToDelete.Contains(opt.AnswerTableId));
                foreach (var answer in answersToDelete)
                {
                    answer.IsDeleted = true;
                    answer.UpdatedBy = deletedBy;
                    answer.UpdatedOn = System.DateTime.Now;
                }
                _context.SaveChanges();
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }
    }
}
