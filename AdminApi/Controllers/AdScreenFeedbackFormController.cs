using AdminApi.Models.Helper;
using AdminApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AdminApi.Models.App.Location;
using AdminApi.DTO.App.LocationDTO;
using System;
using System.Linq;
using AdminApi.DTO.App;
using AdminApi.Models.App;
using AdminApi.Models.User;

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdScreenFeedbackFormController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly ISqlRepository<AdScreenFeedbackForm> _AdScreenFeedbackFormRepo;

        public AdScreenFeedbackFormController(IConfiguration config,
                                    AppDbContext context,
                                    ISqlRepository<AdScreenFeedbackForm> AdScreenFeedbackFormRepo)
        {
            _config = config;
            _context = context;
            _AdScreenFeedbackFormRepo = AdScreenFeedbackFormRepo;
        }

        [HttpPost]
        public IActionResult AdScreenFeedbackFormCreate(AdScreenFeedbackFormDTO adScreenFeedbackFormDTO)
        {
            var objCheck = _context.AdScreenFeedbackForm.SingleOrDefault(opt => opt.AdScreenId == adScreenFeedbackFormDTO.AdScreenId && opt.IsDeleted == false);
            try
            {
              if(objCheck == null) {

                AdScreenFeedbackForm aa = new AdScreenFeedbackForm();
                aa.StateId = adScreenFeedbackFormDTO.StateId;
                aa.AgentId = adScreenFeedbackFormDTO.AgentId;
               aa.AdScreenId = adScreenFeedbackFormDTO.AdScreenId;
                // aa.AdsDuration = adScreenFeedbackFormDTO.AdsDuration;
                aa.AdsVariantStatusOk = adScreenFeedbackFormDTO.AdsVariantStatusOk;
                aa.AdsVariantStatusNotOk = adScreenFeedbackFormDTO.AdsVariantStatusNotOk;
                aa.AdsVariantStatusRemark = adScreenFeedbackFormDTO.AdsVariantStatusRemark;
                aa.AdsDurationStatusOk = adScreenFeedbackFormDTO.AdsDurationStatusOk;
                aa.AdsDurationStatusNotOk = adScreenFeedbackFormDTO.AdsDurationStatusNotOk;
                aa.AdsDurationStatusRemark = adScreenFeedbackFormDTO.AdsDurationStatusRemark;
               // aa.AdsPlayTime = adScreenFeedbackFormDTO.AdsPlayTime;
                aa.AdsPlayTimeStatusOk = adScreenFeedbackFormDTO.AdsPlayTimeStatusOk;
                aa.AdsPlayTimeStatusNotOk = adScreenFeedbackFormDTO.AdsPlayTimeStatusNotOk;
                aa.AdsPlayTimeStatusRemark = adScreenFeedbackFormDTO.AdsPlayTimeStatusRemark;
               // aa.AdsSequence = adScreenFeedbackFormDTO.AdsSequence;
                aa.AdsSequenceStatusOk = adScreenFeedbackFormDTO.AdsSequenceStatusOk;
                aa.AdsSequenceStatusNotOk = adScreenFeedbackFormDTO.AdsSequenceStatusNotOk;
                aa.AdsSequenceStatusRemark = adScreenFeedbackFormDTO.AdsSequenceStatusRemark;
                aa.Occupancy = adScreenFeedbackFormDTO.Occupancy;
               // aa.Language = adScreenFeedbackFormDTO.Language;
                aa.LanguageStatusOk = adScreenFeedbackFormDTO.LanguageStatusOk;
                aa.LanguageStatusNotOk = adScreenFeedbackFormDTO.LanguageStatusNotOk;
                aa.LanguageStatusRemark = adScreenFeedbackFormDTO.LanguageStatusRemark;
                aa.TheaterInspectionStatusforMale = adScreenFeedbackFormDTO.TheaterInspectionStatusforMale;
                aa.TheaterInspectionStatusforFemale = adScreenFeedbackFormDTO.TheaterInspectionStatusforFemale;
                aa.TheaterInspectionforMale = adScreenFeedbackFormDTO.TheaterInspectionforMale;
                aa.TheaterInspectionforFemale = adScreenFeedbackFormDTO.TheaterInspectionforFemale;
                aa.AgentSelfie = adScreenFeedbackFormDTO.AgentSelfie;
                aa.FeedbackStatus = "Verified";
                aa.CreatedBy = adScreenFeedbackFormDTO.CreatedBy;
                aa.CreatedOn = System.DateTime.Now;
                var obj = _AdScreenFeedbackFormRepo.Insert(aa);
                return Ok(obj);
              }
                else if (objCheck != null)
                {
                    return Accepted(new Confirmation { Status = "Duplicate", ResponseMsg = "Already Registered..!" });
                }
                return Accepted(new Confirmation { Status = "Error", ResponseMsg = "Something unexpected!" });
            }

            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }                     

        [HttpGet]
        public ActionResult GetVerifiedFeedbackFormList()
        {
            try
            {
                var list = (from u in _context.AdScreenFeedbackForm
                            join s in _context.States on u.StateId equals s.StateId
                            join p in _context.Agents on u.AgentId equals p.AgentId

                            select new
                            {
                                u.AdScreenFeedbackFormId,
                                u.AdScreenId,
                                u.AgentId,
                                p.AgentName,
                                u.StateId,
                                s.StateName,
                                // u.AdsDuration,
                                u.AdsVariantStatusOk,
                                u.AdsVariantStatusNotOk,
                                u.AdsVariantStatusRemark,
                                u.AdsDurationStatusOk,
                                u.AdsDurationStatusNotOk,
                                u.AdsDurationStatusRemark,
                                // u.AdsPlayTime,
                                u.AdsPlayTimeStatusOk,
                                u.AdsPlayTimeStatusNotOk,
                                u.AdsPlayTimeStatusRemark,
                                // u.AdsSequence,
                                u.AdsSequenceStatusOk,
                                u.AdsSequenceStatusNotOk,
                                u.AdsSequenceStatusRemark,
                                u.Occupancy,
                                // u.Language,
                                u.LanguageStatusOk,
                                u.LanguageStatusNotOk,
                                u.LanguageStatusRemark,
                                u.TheaterInspectionStatusforMale,
                                u.TheaterInspectionStatusforFemale,
                                u.TheaterInspectionforMale,
                                u.TheaterInspectionforFemale,
                                u.AgentSelfie,
                                u.FeedbackStatus,
                                u.CreatedBy,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.FeedbackStatus == "Verified").ToList();


                int totalRecords = list.Count();


                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult GetAdScreenFeedbackFormList()
        {
            try
            {
                var list = (from u in _context.AdScreenFeedbackForm
                            join s in _context.States on u.StateId equals s.StateId
                            join p in _context.Agents on u.AgentId equals p.AgentId
                            join q in _context.AdScreen on u.AdScreenId equals q.AdScreenId
                            join l in _context.ScreenList on q.TheatreName equals l.TheatreName

                            select new
                            {
                               u.AdScreenFeedbackFormId,
                               u.AdScreenId,
                               u.AgentId,
                               p.AgentName,
                               u.StateId,
                               s.StateName,
                               q.TheatreName,
                               q.Screen,
                               l.TheatreCode,
                               q.AdsName,
                                // u.AdsDuration,
                                u.AdsVariantStatusOk,
                                u.AdsVariantStatusNotOk,
                                u.AdsVariantStatusRemark,
                                u.AdsDurationStatusOk,
                               u.AdsDurationStatusNotOk,
                               u.AdsDurationStatusRemark,
                              // u.AdsPlayTime,
                               u.AdsPlayTimeStatusOk,
                               u.AdsPlayTimeStatusNotOk,
                               u.AdsPlayTimeStatusRemark,
                              // u.AdsSequence,
                               u.AdsSequenceStatusOk,
                               u.AdsSequenceStatusNotOk,
                               u.AdsSequenceStatusRemark,
                               u.Occupancy,
                              // u.Language,
                               u.LanguageStatusOk,
                               u.LanguageStatusNotOk,
                               u.LanguageStatusRemark,
                               u.TheaterInspectionStatusforMale,
                               u.TheaterInspectionStatusforFemale,
                               u.TheaterInspectionforMale,
                               u.TheaterInspectionforFemale,
                               u.AgentSelfie,
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

        [HttpGet("{AdScreenId}")]
        public ActionResult GetAdScreenFeedbackFormListByAdScreenId(int AdScreenId)
        {
            try
            {
                var list = (from u in _context.AdScreenFeedbackForm
                            join s in _context.States on u.StateId equals s.StateId
                            join p in _context.Agents on u.AgentId equals p.AgentId
                            join y in _context.AdScreen on u.AdScreenId equals y.AdScreenId

                            select new
                            {
                                u.AdScreenFeedbackFormId,
                                y.AdScreenId,
                                u.AgentId,
                                p.AgentName,
                                s.StateId,
                                s.StateName,
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
                                u.AgentSelfie,
                                u.CreatedBy,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.AdScreenId == AdScreenId).ToList();

                int totalRecords = list.Count();


                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{UserId}")]
        public ActionResult GetAdScreenFeedbackFormListByUserId(int UserId)
        {
            try
            {
                var list = (from u in _context.AdScreenFeedbackForm
                            join s in _context.States on u.StateId equals s.StateId
                            join p in _context.Agents on u.AgentId equals p.AgentId
                            join q in _context.StateUser on u.StateId equals q.StateId
                            join c in _context.AdScreen on u.AdScreenId equals c.AdScreenId
                            join l in _context.ScreenList on c.TheatreName equals l.TheatreName

                            select new
                            {
                                u.AdScreenFeedbackFormId,
                               // u.AdScreenId,
                                u.AgentId,
                                p.AgentName,
                                s.StateId,
                                s.StateName,
                                c.TheatreName,
                                c.Screen,
                                l.TheatreCode,
                                c.AdsName,
                                // u.AdsDuration,
                                u.AdsVariantStatusOk,
                                u.AdsVariantStatusNotOk,
                                u.AdsVariantStatusRemark,
                                u.AdsDurationStatusOk,
                                u.AdsDurationStatusNotOk,
                                u.AdsDurationStatusRemark,
                              //  u.AdsPlayTime,
                                u.AdsPlayTimeStatusOk,
                                u.AdsPlayTimeStatusNotOk,
                                u.AdsPlayTimeStatusRemark,
                              //  u.AdsSequence,
                                u.AdsSequenceStatusOk,
                                u.AdsSequenceStatusNotOk,
                                u.AdsSequenceStatusRemark,
                                u.Occupancy,
                              //  u.Language,
                                u.LanguageStatusOk,
                                u.LanguageStatusNotOk,
                                u.LanguageStatusRemark,
                                u.TheaterInspectionStatusforMale,
                                u.TheaterInspectionStatusforFemale,
                                u.TheaterInspectionforMale,
                                u.TheaterInspectionforFemale,
                                u.AgentSelfie,
                                q.UserId,
                                u.CreatedBy,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.UserId == UserId).ToList();

                int totalRecords = list.Count();


                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //[HttpGet("{StateId}")]
        //public ActionResult GetAdScreenFeedbackFormListByAgentId(int StateId)
        //{
        //    try
        //    {
        //        var list = (from u in _context.AdScreenFeedbackForm
        //                    join s in _context.States on u.StateId equals s.StateId
        //                    join p in _context.Agents on u.AgentId equals p.AgentId
        //                    //join a in _context.AdScreen on u.StateId equals a.StateId

        //                    select new
        //                    {
        //                        u.AdScreenFeedbackFormId,
        //                        // u.AdScreenId,
        //                        u.AgentId,
        //                        p.AgentName,
        //                        u.StateId,
        //                        s.StateName,
        //                        //a.AdvertiseName,
        //                        //a.AdvertiseVideoLink,
        //                        //a.AdsDuration,
        //                        u.AdsDurationStatusOk,
        //                        u.AdsDurationStatusNotOk,
        //                        u.AdsDurationStatusRemark,
        //                        //a.AdsPlaytime,
        //                        u.AdsPlayTimeStatusOk,
        //                        u.AdsPlayTimeStatusNotOk,
        //                        u.AdsPlayTimeStatusRemark,
        //                       // a.AdsSequence,
        //                        u.AdsSequenceStatusOk,
        //                        u.AdsSequenceStatusNotOk,
        //                        u.AdsSequenceStatusRemark,
        //                        u.Occupancy,
        //                       // a.AdsLanguage,
        //                        u.LanguageStatusOk,
        //                        u.LanguageStatusNotOk,
        //                        u.LanguageStatusRemark,
        //                        u.TheaterInspectionStatusforMale,
        //                        u.TheaterInspectionStatusforFemale,
        //                        u.TheaterInspectionforMale,
        //                        u.TheaterInspectionforFemale,
        //                        u.CreatedBy,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false && x.StateId == StateId).ToList();

        //        int totalRecords = list.Count();


        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

       
        //single Id


        [HttpGet("{adScreenFeedbackFormId}")]
        public ActionResult GetSingleFeedbackForm(int adScreenFeedbackFormId)
        {
            try
            {
                var singleState = _AdScreenFeedbackFormRepo.SelectById(adScreenFeedbackFormId);
                return Ok(singleState);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //update
        [HttpPost]
        public ActionResult UpdateAdScreenFeedbackForm(UpdateAdScreenFeedbackFormDTO updateAdScreenFeedbackFormDTO)
        {
            try
            {
                var objState = _context.AdScreenFeedbackForm.SingleOrDefault(opt => opt.AdScreenFeedbackFormId == updateAdScreenFeedbackFormDTO.AdScreenFeedbackFormId);
                objState.StateId = updateAdScreenFeedbackFormDTO.StateId;
                objState.AgentId = updateAdScreenFeedbackFormDTO.AgentId;
                objState.AdScreenId = updateAdScreenFeedbackFormDTO.AdScreenId;
                // objState.AdsDuration = updateAdScreenFeedbackFormDTO.AdsDuration;
                objState.AdsVariantStatusOk = updateAdScreenFeedbackFormDTO.AdsVariantStatusOk;
                objState.AdsVariantStatusNotOk = updateAdScreenFeedbackFormDTO.AdsVariantStatusNotOk;
                objState.AdsVariantStatusRemark = updateAdScreenFeedbackFormDTO.AdsVariantStatusRemark;
                objState.AdsDurationStatusOk = updateAdScreenFeedbackFormDTO.AdsDurationStatusOk;
                objState.AdsDurationStatusNotOk = updateAdScreenFeedbackFormDTO.AdsDurationStatusNotOk;
                objState.AdsDurationStatusRemark = updateAdScreenFeedbackFormDTO.AdsDurationStatusRemark;
              //  objState.AdsPlayTime = updateAdScreenFeedbackFormDTO.AdsPlayTime;
                objState.AdsPlayTimeStatusOk = updateAdScreenFeedbackFormDTO.AdsPlayTimeStatusOk;
                objState.AdsPlayTimeStatusNotOk = updateAdScreenFeedbackFormDTO.AdsPlayTimeStatusNotOk;
                objState.AdsPlayTimeStatusRemark = updateAdScreenFeedbackFormDTO.AdsPlayTimeStatusRemark;
             //   objState.AdsSequence = updateAdScreenFeedbackFormDTO.AdsSequence;
                objState.AdsSequenceStatusOk = updateAdScreenFeedbackFormDTO.AdsSequenceStatusOk;
                objState.AdsSequenceStatusNotOk = updateAdScreenFeedbackFormDTO.AdsSequenceStatusNotOk;
                objState.AdsSequenceStatusRemark = updateAdScreenFeedbackFormDTO.AdsSequenceStatusRemark;
                objState.Occupancy = updateAdScreenFeedbackFormDTO.Occupancy;
              //  objState.Language = updateAdScreenFeedbackFormDTO.Language;
                objState.LanguageStatusOk = updateAdScreenFeedbackFormDTO.LanguageStatusOk;
                objState.LanguageStatusNotOk = updateAdScreenFeedbackFormDTO.LanguageStatusNotOk;
                objState.LanguageStatusRemark = updateAdScreenFeedbackFormDTO.LanguageStatusRemark;
                objState.TheaterInspectionStatusforMale = updateAdScreenFeedbackFormDTO.TheaterInspectionStatusforMale;
                objState.TheaterInspectionStatusforFemale = updateAdScreenFeedbackFormDTO.TheaterInspectionStatusforFemale;
                objState.TheaterInspectionforMale = updateAdScreenFeedbackFormDTO.TheaterInspectionforMale;
                objState.TheaterInspectionforFemale = updateAdScreenFeedbackFormDTO.TheaterInspectionforFemale;
                objState.AgentSelfie = updateAdScreenFeedbackFormDTO.AgentSelfie;
                objState.UpdatedBy = updateAdScreenFeedbackFormDTO.UpdatedBy;
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
        public ActionResult DeleteFeedbackForm(int Id, int DeletedBy)
        {
            try
            {
                var objabout = _context.AdScreenFeedbackForm.SingleOrDefault(opt => opt.AdScreenFeedbackFormId == Id);
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


        [HttpGet]
        public ActionResult GetFeedbackFormList()
        {
            try
            {
                var list = (from u in _context.AdScreenFeedbackForm
                            //join s in _context.States on u.StateId equals s.StateId
                            join p in _context.Agents on u.AgentId equals p.AgentId
                            join q in _context.AdScreen on p.TheatreName equals q.TheatreName

                            select new
                            {
                                u.AdScreenFeedbackFormId,
                                u.AgentId,
                                p.AgentName,
                                //u.StateId,
                                //s.StateName,
                                q.AdsDuration,
                                u.AdsVariantStatusOk,
                                u.AdsVariantStatusNotOk,
                                u.AdsVariantStatusRemark,
                                u.AdsDurationStatusOk,
                                u.AdsDurationStatusNotOk,
                                u.AdsDurationStatusRemark,
                                 q.AdsPlaytime,
                                u.AdsPlayTimeStatusOk,
                                u.AdsPlayTimeStatusNotOk,
                                u.AdsPlayTimeStatusRemark,
                                 q.AdsSequence,
                                u.AdsSequenceStatusOk,
                                u.AdsSequenceStatusNotOk,
                                u.AdsSequenceStatusRemark,
                                u.Occupancy,
                                 q.AdsLanguage,
                                u.LanguageStatusOk,
                                u.LanguageStatusNotOk,
                                u.LanguageStatusRemark,
                                u.TheaterInspectionStatusforMale,
                                u.TheaterInspectionStatusforFemale,
                                u.TheaterInspectionforMale,
                                u.TheaterInspectionforFemale,
                                u.AgentSelfie,
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

        //[HttpGet("{agentId}")]
        //public ActionResult GetTheatreListByAgent(int agentId)
        //{
        //    try
        //    {
        //        var list = (from u in _context.AdScreenFeedbackForm
        //                    join a in _context.Agents on u.AgentId equals a.AgentId
                           

        //                    select new
        //                    {
        //                        u.StateId,
        //                        u.AgentId,
        //                        a.AgentName,
        //                        a.Cityname,
        //                        a.TheatreName,
        //                        u.IsDeleted
        //                    }).Where(x => x.IsDeleted == false && x.AgentId == agentId).Distinct().ToList();

        //        int totalRecords = list.Count();

        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }

        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        [HttpGet("{fromDate}/{toDate}/{agentId}")]
        public ActionResult GetTheatreListByAgent(DateTime fromDate, DateTime toDate, int agentId)
        {
            try
            {
                var list = (from u in _context.AdScreenFeedbackForm
                            join m in _context.Agents on u.AgentId equals m.AgentId
                           
                            where u.IsDeleted == false && u.CreatedOn.Date >= fromDate.Date && u.CreatedOn.Date <= toDate.Date
                            select new
                            {
                                u.AdScreenFeedbackFormId,
                                u.StateId,
                                u.AgentId,
                                m.AgentName,
                                m.Cityname,
                                m.TheatreName,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false && x.AgentId == agentId).OrderByDescending(t => t.AdScreenFeedbackFormId);

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
