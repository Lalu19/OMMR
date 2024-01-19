using AdminApi.Models.App.Agent;
using AdminApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AdminApi.Models.App;
using AdminApi.DTO.App;
using AdminApi.Models.Helper;
using System;
using System.Linq;


namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PushNotificationController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly ISqlRepository<PushNotification> _PushNotificationRepo;
        public PushNotificationController(IConfiguration config,
                                AppDbContext context,
                                ISqlRepository<PushNotification> PushNotificationRepo)

        {
            _config = config;
            _context = context;
            _PushNotificationRepo = PushNotificationRepo;
        }


        //[HttpPost]
        //public IActionResult CreatePushNotificationInfo(PushNotificationDTO pushNotificationDTO)
        //{
        //    try
        //    {
        //        PushNotification pushNotification = new PushNotification();

        //        pushNotification.DeviceId = pushNotificationDTO.DeviceId;
        //        pushNotification.AgentId = pushNotificationDTO.AgentId;
        //        pushNotification.IMEINumber = pushNotificationDTO.IMEINumber;
        //        pushNotification.FCMToken = pushNotificationDTO.FCMToken;
        //        pushNotification.CreatedBy = pushNotificationDTO.CreatedBy;
        //        pushNotification.CreatedOn = System.DateTime.Now;

        //        var obj = _PushNotificationRepo.Insert(pushNotification);
        //        return Ok(obj);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        [HttpPost]
        public IActionResult CreatePushNotificationInfo(PushNotificationDTO pushNotificationDTO)
        {
            try
            {
                // Check if a record with the same AgentId already exists
                PushNotification existingPushNotification = _context.PushNotifications.FirstOrDefault(x => x.AgentId == pushNotificationDTO.AgentId);

                if (existingPushNotification != null)
                {
                    
                    existingPushNotification.DeviceId = pushNotificationDTO.DeviceId;
                    existingPushNotification.IMEINumber = pushNotificationDTO.IMEINumber;
                    existingPushNotification.FCMToken = pushNotificationDTO.FCMToken;
                    existingPushNotification.CreatedBy = pushNotificationDTO.CreatedBy;
                    existingPushNotification.CreatedOn = System.DateTime.Now;

                    _PushNotificationRepo.Update(existingPushNotification);
                    return Ok(existingPushNotification);
                }
                else
                {
                    
                    PushNotification pushNotification = new PushNotification
                    {
                        DeviceId = pushNotificationDTO.DeviceId,
                        AgentId = pushNotificationDTO.AgentId,
                        IMEINumber = pushNotificationDTO.IMEINumber,
                        FCMToken = pushNotificationDTO.FCMToken,
                        CreatedBy = pushNotificationDTO.CreatedBy,
                        CreatedOn = System.DateTime.Now
                    };

                    var obj = _PushNotificationRepo.Insert(pushNotification);
                    return Ok(obj);
                }
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }





        [HttpGet]
        public IActionResult GetPushNotificationList()
        {
            try
            {
                var list = (from u in _context.PushNotifications

                            select new
                            {
                                u.PushNotificationId,
                                u.DeviceId,
                                u.AgentId,
                                u.FCMToken,
                                u.IMEINumber,
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

        [HttpGet("{PushNotificationId}")]
        public IActionResult GetPushNotificationByAgentId(int PushNotificationId)
        {
            try
            {
                var list = (from u in _context.PushNotifications
                            where u.PushNotificationId == PushNotificationId && u.IsDeleted == false

                            select new
                            {
                                u.PushNotificationId,
                                //u.DeviceId,
                                u.AgentId,
                                u.FCMToken,
                                //u.IMEINumber,
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

        [HttpPost]
        public ActionResult UpdatePushNotificationInfo(UpdatePushNotificationDTO updatepushNotificationDTO)
        {
            try
            {
                var obj = _context.PushNotifications.SingleOrDefault(opt => opt.PushNotificationId == updatepushNotificationDTO.PushNotificationId);
                
                obj.DeviceId = updatepushNotificationDTO.DeviceId;
                obj.AgentId = updatepushNotificationDTO.AgentId;
                obj.FCMToken = updatepushNotificationDTO.FCMToken;
                obj.IMEINumber = updatepushNotificationDTO.IMEINumber;
                obj.UpdatedBy = updatepushNotificationDTO.UpdatedBy;
                obj.UpdatedOn = System.DateTime.Now;
                _context.SaveChanges();
                return Ok(obj);

            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{Id}/{DeletedBy}")]
        public ActionResult DeletePushNotificationInfo(int Id, int DeletedBy)
        {
            try
            {
                var objabout = _context.PushNotifications.SingleOrDefault(opt => opt.PushNotificationId == Id);
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
