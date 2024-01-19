using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AdminClient.DTO;
using AdminClient.Model.AgentFeedbackForm;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace AdminClient.Controllers
{
    public class AgentFeedbackFormController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IAgentFeedbackForm _agentFeedbackForm;
        public AgentFeedbackFormController(IWebHostEnvironment hostingEnvironment,
                                            IAgentFeedbackForm agentFeedbackForm)
        {
            _hostingEnvironment = hostingEnvironment;
            _agentFeedbackForm = agentFeedbackForm;
        }

        [HttpPost]
        public IActionResult AgentFeedbackFormCreate(AgentFeedbackFormDTO agentFeedbackFormDTO)
        {
            if (agentFeedbackFormDTO.file != null)
            {
                string filename = ContentDispositionHeaderValue.Parse(agentFeedbackFormDTO.file.ContentDisposition).FileName.Trim('"');
                filename = EnsureCorrectFilename(filename);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
                agentFeedbackFormDTO.file.CopyTo(new FileStream(imagePath, FileMode.Create));
                string photopath = "/images/" + uniqueFileName;
                AgentFeedbackFormNewDTO ag = new AgentFeedbackFormNewDTO();
                ag.StateId = agentFeedbackFormDTO.StateId;
                ag.AgentId = agentFeedbackFormDTO.AgentId;
                ag.AdScreenId = agentFeedbackFormDTO.AdScreenId;
                ag.AdsVariantStatusOk = agentFeedbackFormDTO.AdsVariantStatusOk;
                ag.AdsVariantStatusNotOk = agentFeedbackFormDTO.AdsVariantStatusNotOk;
                ag.AdsVariantStatusRemark = agentFeedbackFormDTO.AdsVariantStatusRemark;
                ag.AdsDurationStatusOk = agentFeedbackFormDTO.AdsDurationStatusOk;
                ag.AdsDurationStatusNotOk = agentFeedbackFormDTO.AdsDurationStatusNotOk;
                ag.AdsDurationStatusRemark = agentFeedbackFormDTO.AdsDurationStatusRemark;
                ag.AdsPlayTimeStatusOk = agentFeedbackFormDTO.AdsPlayTimeStatusOk;
                ag.AdsPlayTimeStatusNotOk = agentFeedbackFormDTO.AdsPlayTimeStatusNotOk;
                ag.AdsPlayTimeStatusRemark = agentFeedbackFormDTO.AdsPlayTimeStatusRemark;
                ag.AdsSequenceStatusOk = agentFeedbackFormDTO.AdsSequenceStatusOk;
                ag.AdsSequenceStatusNotOk = agentFeedbackFormDTO.AdsSequenceStatusNotOk;
                ag.AdsSequenceStatusRemark = agentFeedbackFormDTO.AdsSequenceStatusRemark;
                ag.Occupancy = agentFeedbackFormDTO.Occupancy;
                ag.LanguageStatusOk = agentFeedbackFormDTO.LanguageStatusOk;
                ag.LanguageStatusNotOk = agentFeedbackFormDTO.LanguageStatusNotOk;
                ag.LanguageStatusRemark = agentFeedbackFormDTO.LanguageStatusRemark;
                ag.TheaterInspectionStatusforMale = agentFeedbackFormDTO.TheaterInspectionStatusforMale;
                ag.TheaterInspectionStatusforFemale = agentFeedbackFormDTO.TheaterInspectionStatusforFemale;
                ag.TheaterInspectionforMale = agentFeedbackFormDTO.TheaterInspectionforMale;
                ag.TheaterInspectionforFemale = agentFeedbackFormDTO.TheaterInspectionforFemale;
                ag.AgentSelfie = photopath;
                ag.CreatedBy = agentFeedbackFormDTO.CreatedBy;

                var a = _agentFeedbackForm.AgentFeedbackFormCreate(ag);

                return Ok(a);
            }
            else
            {
                AgentFeedbackFormNewDTO ag = new AgentFeedbackFormNewDTO();
                ag.StateId = agentFeedbackFormDTO.StateId;
                ag.AgentId = agentFeedbackFormDTO.AgentId;
                ag.AdScreenId = agentFeedbackFormDTO.AdScreenId;
                ag.AdsVariantStatusOk = agentFeedbackFormDTO.AdsVariantStatusOk;
                ag.AdsVariantStatusNotOk = agentFeedbackFormDTO.AdsVariantStatusNotOk;
                ag.AdsVariantStatusRemark = agentFeedbackFormDTO.AdsVariantStatusRemark;
                ag.AdsDurationStatusOk = agentFeedbackFormDTO.AdsDurationStatusOk;
                ag.AdsDurationStatusNotOk = agentFeedbackFormDTO.AdsDurationStatusNotOk;
                ag.AdsDurationStatusRemark = agentFeedbackFormDTO.AdsDurationStatusRemark;
                ag.AdsPlayTimeStatusOk = agentFeedbackFormDTO.AdsPlayTimeStatusOk;
                ag.AdsPlayTimeStatusNotOk = agentFeedbackFormDTO.AdsPlayTimeStatusNotOk;
                ag.AdsPlayTimeStatusRemark = agentFeedbackFormDTO.AdsPlayTimeStatusRemark;
                ag.AdsSequenceStatusOk = agentFeedbackFormDTO.AdsSequenceStatusOk;
                ag.AdsSequenceStatusNotOk = agentFeedbackFormDTO.AdsSequenceStatusNotOk;
                ag.AdsSequenceStatusRemark = agentFeedbackFormDTO.AdsSequenceStatusRemark;
                ag.Occupancy = agentFeedbackFormDTO.Occupancy;
                ag.LanguageStatusOk = agentFeedbackFormDTO.LanguageStatusOk;
                ag.LanguageStatusNotOk = agentFeedbackFormDTO.LanguageStatusNotOk;
                ag.LanguageStatusRemark = agentFeedbackFormDTO.LanguageStatusRemark;
                ag.TheaterInspectionStatusforMale = agentFeedbackFormDTO.TheaterInspectionStatusforMale;
                ag.TheaterInspectionStatusforFemale = agentFeedbackFormDTO.TheaterInspectionStatusforFemale;
                ag.TheaterInspectionforMale = agentFeedbackFormDTO.TheaterInspectionforMale;
                ag.TheaterInspectionforFemale = agentFeedbackFormDTO.TheaterInspectionforFemale;
                //ag.AgentSelfie = photopath;
                ag.CreatedBy = agentFeedbackFormDTO.CreatedBy;

                var a = _agentFeedbackForm.AgentFeedbackFormCreate(ag);

                return Ok(a);
            }

        }

        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return filename;
        }
    }
}
