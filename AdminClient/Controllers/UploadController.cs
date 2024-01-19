using System;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AdminClient.Controllers
{
    public class UploadController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger<UploadController> _logger;

        public UploadController(IWebHostEnvironment hostingEnvironment,
                              ILogger<UploadController> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }
        [HttpPost]
        public string ImgUpload(IFormFile file)
        {
            try
            {
                string filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                filename = EnsureCorrectFilename(filename);
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
                file.CopyTo(new FileStream(imagePath, FileMode.Create));
                return "/images/" + uniqueFileName;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                return "";
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
