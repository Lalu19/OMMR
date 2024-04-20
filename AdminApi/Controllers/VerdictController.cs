using AdminApi.Models.App;
using AdminApi.Models;
using Microsoft.AspNetCore.Mvc;
using AdminApi.DTO.App;
using AdminApi.Models.Helper;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;


namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VerdictController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly ISqlRepository<Verdict> _VerdictRepo;

        public VerdictController(IConfiguration config,
                                    AppDbContext context,
                                    ISqlRepository<Verdict> VerdictRepo)
        {
            _config = config;
            _context = context;
            _VerdictRepo = VerdictRepo;
        }

        [HttpPost]
        public IActionResult VerdictCreate(VerdictDTO verdictDTO)
        {
            var objcheck = _context.Verdicts.SingleOrDefault(opt => opt.VerdictName == verdictDTO.VerdictName && opt.IsDeleted == false);
            try
            {
                if (objcheck == null)
                {
                    Verdict vd = new Verdict();
                    vd.VerdictName = verdictDTO.VerdictName;
                    vd.VerdictValue = verdictDTO.VerdictValue;
                    vd.ColorCode = verdictDTO.ColorCode;
                    vd.CreatedBy = verdictDTO.CreatedBy;
                    vd.CreatedOn = System.DateTime.Now;
                    var obj = _VerdictRepo.Insert(vd);
                    return Ok(obj);
                }
                else if (objcheck != null)
                {
                    return Accepted(new Confirmation { Status = "Duplicate", ResponseMsg = "Duplicate VerdictName..!" });
                }
                return Accepted(new Confirmation { Status = "Error", ResponseMsg = "Something unexpected!" });

            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult GetVerdictList()
        {
            try
            {
                var list = (from u in _context.Verdicts

                            select new
                            {
                                u.VerdictId,
                                u.VerdictName,
                                u.VerdictValue,
                                u.ColorCode,
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
        public ActionResult UpdateVerdict(UpdateVerdictDTO updateVerdictDTO)
        {
            try
            {
                var objVerdict = _context.Verdicts.SingleOrDefault(opt => opt.VerdictId == updateVerdictDTO.VerdictId);

                var existingVerdict = _context.Verdicts.SingleOrDefault(opt => opt.VerdictName == updateVerdictDTO.VerdictName && opt.VerdictId != updateVerdictDTO.VerdictId && opt.IsDeleted == false);

                if (existingVerdict != null)
                {
                    return Accepted(new Confirmation { Status = "Duplicate", ResponseMsg = "Duplicate VerdictName..!" });
                }

                objVerdict.VerdictName = updateVerdictDTO.VerdictName;
                objVerdict.VerdictValue = updateVerdictDTO.VerdictValue;
                objVerdict.ColorCode = updateVerdictDTO.ColorCode;

                objVerdict.UpdatedBy = updateVerdictDTO.UpdatedBy;
                objVerdict.UpdatedOn = System.DateTime.Now;
                _context.SaveChanges();
                return Ok(objVerdict);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

  
        [HttpGet("{verdictId}")]
        public ActionResult GetSingleVerdict(int verdictId)
        {
            try
            {
                var singleVerdict = _VerdictRepo.SelectById(verdictId);
                return Ok(singleVerdict);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{Id}/{DeletedBy}")]
        public ActionResult DeleteVerdict(int Id, int DeletedBy)
        {
            try
            {
                var objabout = _context.Verdicts.SingleOrDefault(opt => opt.VerdictId == Id);
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
