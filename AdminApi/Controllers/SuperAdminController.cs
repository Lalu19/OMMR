using AdminApi.Models.App;
using AdminApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AdminApi.Models.Helper;
using System;
using System.Linq;
using AdminApi.Models.User;
using NPOI.SS.Formula.Functions;

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SuperAdminController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly ISqlRepository<Users> _userRepo;
        public SuperAdminController(IConfiguration config,
                                AppDbContext context,
                                ISqlRepository<Users> userRepo)

        {
            _config = config;
            _context = context;
            _userRepo = userRepo;

        }


        [HttpGet("{id}/{DeletedBy}")]
        public IActionResult DeleteStateAdmin(int id, int DeletedBy)
        {
            try
            {
                var obj = _context.Users.FirstOrDefault(opt => opt.UserId == id);
                var obj1 = _context.StateUser.Where(opt => opt.UserId == id).ToList();

                if (obj != null && obj1 != null)
                {
                    foreach (var user in obj1)
                    {
                        user.IsDeleted = true;
                    }
                    //obj1.IsDeleted = true;
                    obj.IsActive = false;
                    obj.LastUpdatedBy = DeletedBy;
                    obj.LastUpdatedDate = System.DateTime.Now;
                    _context.SaveChanges();
                }
                   
                return Ok(obj);

            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{id}/{DeletedBy}")]
        public IActionResult DeleteStateAdminReject(int id, int DeletedBy)
        {
            try
            {
                var obj = _context.Users.FirstOrDefault(opt => opt.UserId == id);
                var obj1 = _context.StateUser.Where(opt => opt.UserId == id).ToList();

                if(obj != null && obj1 != null)
                {
                    foreach (var user in obj1)
                    {
                        user.DeleteRequested = false;
                    }
                   // obj1.DeleteRequested = false;
                    obj.DeleteRequested = false;
                    obj.LastUpdatedBy = DeletedBy;
                    obj.LastUpdatedDate = System.DateTime.Now;
                    obj.SuperAdminDeletionResponse = "SuperAdmin has rejected your State Agent deletion request";
                    _context.SaveChanges();
                }

                return Ok(obj);

            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }




    }



}
