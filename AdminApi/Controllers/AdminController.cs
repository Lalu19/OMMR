using AdminApi.Models.App;
using AdminApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AdminApi.Models.App.Agent;
using AdminApi.Models.Helper;
using System;
using System.Linq;

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly ISqlRepository<Agent> _AgentRepo;
        public AdminController(IConfiguration config,
                                AppDbContext context,
                                ISqlRepository<Agent> AgentRepo)

        {
            _config = config;
            _context = context;
            _AgentRepo = AgentRepo;

        }


        [HttpGet("{id}/{DeletedBy}")]
        public IActionResult DeleteAgent(int id ,int DeletedBy)
        {
            try
            {
                var obj =  _context.Agents.SingleOrDefault(opt => opt.AgentId == id);

                obj.IsDeleted = true;
                obj.UpdatedBy = DeletedBy;
                obj.UpdatedOn = System.DateTime.Now;
                _context.SaveChanges();
                return Ok(obj);

            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{id}/{DeletedBy}")]
        public IActionResult DeleteAgentReject(int id, int DeletedBy)
        {
            try
            {
                var obj = _context.Agents.SingleOrDefault(opt => opt.AgentId == id);

                obj.DeleteRequested= false;
               // obj.IsDeleted = true;
                obj.UpdatedBy = DeletedBy;
                obj.UpdatedOn = System.DateTime.Now;
                obj.AdminDeletionResponse = "Admin has rejected your Agent deletion request";
               // obj.AdminDeletionResponse = "<span style='color: red;'>Admin has rejected your Agent deletion request</span>";
                _context.SaveChanges();
                return Ok(obj);

            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }




    }

    

}
