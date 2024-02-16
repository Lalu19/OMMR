using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AdminClient.ViewModels;
using AdminClient.ViewModels.Menu;
using AdminClient.ViewModels.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
//using ZXing;
//using ZXing.QrCode;
using System.Drawing;

namespace AdminClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;
        private string appMenu = "AppMenu", userLogCode = "UserLogCode", tokenTxt = "TokenTxt",
            userId="UserId",imagePath="ImagePath",fullName="FullName",roleName="RoleName",/*hospitalmasterid= "HospitalMasterid",*/ stateId = "StateId", stateName = "StateName";
        

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration /*, IWebHostEnvironment webHostEnviroment*/)
        {
            _logger = logger;
            _configuration = configuration;
            //_webHostEnviroment = webHostEnviroment;
            _apiBaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        }

        [HttpGet]
        public IActionResult Login()
        {         
            return View();
        }

        public IActionResult SignUpForClient()
        {
            return View();
        }

        public IActionResult Forgotpassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                string apiUrl = _apiBaseUrl + "/api/Users/GetLoginInfo/" + username + "/" + password;
                using (HttpClient client = new HttpClient())
                {
                    using (var response = await client.GetAsync(apiUrl))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            var objUser = JsonConvert.DeserializeObject<UserInfoWithToken>(apiResponse);
                            if (objUser != null)
                            {
                                string urlMenu = _apiBaseUrl + "/api/Menu/GetAppMenu/" + objUser.obj.UserRoleId;                             
                                var request = new HttpRequestMessage(HttpMethod.Get, urlMenu);
                                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", objUser.token);

                                using (var responseMenu = await client.SendAsync(request))
                                {
                                    if (responseMenu.StatusCode == HttpStatusCode.OK)
                                    {
                                        string returnMenuString= await responseMenu.Content.ReadAsStringAsync();
                                         var menuList = JsonConvert.DeserializeObject<List<MenuDisplay>>(returnMenuString);                                      
                                        string menuString = listToSidebar(menuList);

                                        var dateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                                        var logCode = objUser.obj.UserId +"-"+ dateTime;

                                        HttpContext.Session.SetString(appMenu, menuString);
                                        HttpContext.Session.SetInt32(userId, objUser.obj.UserId);
                                        HttpContext.Session.SetString(userLogCode, logCode);
                                        HttpContext.Session.SetString(tokenTxt, objUser.token);
                                        HttpContext.Session.SetString(imagePath, objUser.obj.ImagePath==null? "../images/users/male/2.jpg" :            objUser.obj.ImagePath);
                                        HttpContext.Session.SetString(fullName, objUser.obj.FullName);
                                        HttpContext.Session.SetString(roleName, objUser.obj.RoleName);
                                        //HttpContext.Session.SetInt32(hospitalmasterid, objUser.obj.HospitalMasterid);
                                        HttpContext.Session.SetInt32(stateId, objUser.obj.StateId);
                                        string stateNameValue = objUser.obj.StateName ?? ""; // If StateName is null, set it to an empty string
                                        HttpContext.Session.SetString(stateName, stateNameValue);
                                      // HttpContext.Session.SetString(adsname, objUser.obj.AdvertiseName);
                                        CreateLoginHistory(objUser.obj.UserId, logCode, objUser.token);
                                        return RedirectToAction("Index","DashBoard");
                                    }
                                    else if (responseMenu.StatusCode == HttpStatusCode.Forbidden)
                                    {
                                        ViewBag.ErrorMessage = "No Permission!Contact to Admin.";                                       
                                    }
                                    else if (responseMenu.StatusCode == HttpStatusCode.Unauthorized)
                                    {
                                        ViewBag.ErrorMessage = "Token expired!Try Again.";                                       
                                    }                                  
                                }
                            }
                        }
                        else if (response.StatusCode == HttpStatusCode.NoContent)
                        {
                            ViewBag.ErrorMessage = "Incorrect Username/Password ! Please try again.";
                        }                        
                        else
                        {
                            ViewBag.ErrorMessage = "Invalid request!Please try again";
                        }

                    }
                }
            }
            catch(Exception exception)
            {                           
                ViewBag.ErrorMessage = "Something is going wrong!Please try again";
                _logger.LogError(exception.Message);
            }           
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            try
            {              
                string logCode = HttpContext.Session.GetString(userLogCode);                
                string token = HttpContext.Session.GetString(tokenTxt);
                HttpContext.Session.Clear();
                string url = _apiBaseUrl + "/api/Users/UpdateLoginHistory/" + logCode;
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (var client = new HttpClient())
                {
                    using (var response = await client.SendAsync(request))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            return RedirectToAction("Login");
                        }

                    }

                }
            }
            catch (Exception exception)
            {
                HttpContext.Session.Clear();
                _logger.LogError(exception.Message);
            }           
            return View("Login");
        }

        private string listToSidebar(List<MenuDisplay> listOfMenu)
        {
            List<MenuDisplay> parentMenusList = listOfMenu.Where(q => q.ParentID == 0).ToList<MenuDisplay>();
            var sb = new StringBuilder();
            string unorderedList = GenerateSidebar(parentMenusList, listOfMenu, sb);
            unorderedList = "<ul class='side-menu'>" + unorderedList.Substring(22, unorderedList.Length - 22);

            return unorderedList;
        }

        private string GenerateSidebar(List<MenuDisplay> parentMenusList, List<MenuDisplay> listOfMenu, StringBuilder sb)
        {
            sb.Append("<ul class='side-menu'>");

            if (parentMenusList.Count > 0)
            {
                foreach (var parentMenu in parentMenusList)
                {
                    string handler = parentMenu.URL != null ? parentMenu.URL.ToString() : "";
                    string menuText = parentMenu.MenuTitle != null ? parentMenu.MenuTitle.ToString() : "";
                    string iconClass = parentMenu.IconClass != null ? parentMenu.IconClass.ToString() : "";

                    string line = "";
                    if (parentMenu.ParentID.ToString() == "0" && parentMenu.IsSubMenu.ToString() == "1")
                    {
                       // line = String.Format(@"<li class='nav-item 1'><a class='nav-link collapsed text-white p-3 mb-1 sidebar-link' href='#{2}' data-toggle='collapse' data-target='#{2}'><i class='{1} text-light fa-lg mr-3'></i>{0}<i class='fas fa-caret-left fa-lg float-right'></i></a>", menuText, iconClass, parentMenu.MenuID.ToString());

                          
							
                        line = String.Format(@"  <li class='slide'>
							<a class='side-menu__item sidemenu-icon'  data-toggle='slide' href='#{2}'><i class='side-menu__icon fe fe-home'></i><span class='side-menu__label'>{0}</span><i class='angle fa fa-angle-right'></i></a>", menuText, iconClass,parentMenu.MenuID.ToString());
                    }
                    else if (parentMenu.ParentID.ToString() == "0" && parentMenu.IsSubMenu.ToString() == "0")
                    {
                        line = String.Format(@"<li><a class='side-menu__item' href='{0}'><i class='side-menu__icon fe fe-grid'></i><span class='side-menu__label'>{2}</span></a>", handler, iconClass, menuText);
                        
                    }
                    else if (parentMenu.ParentID.ToString() != "0" && parentMenu.IsSubMenu.ToString() == "1")
                    {
                        line = String.Format(@"<li class='nav-item 3'><a class='nav-link collapsed text-white p-3 mb-1 sidebar-link' href='#{1}' data-toggle='collapse' data-target='#{1}'><i class='far fa-dot-circle text-light fa-lg mr-3'></i>{0}<i class='fas fa-caret-left fa-lg float-right'></i></a>", menuText, parentMenu.MenuID.ToString());
                    }
                    else
                    {                      
                        line = String.Format(@"<li><a class='slide-item' href='{0}'>{1}</a>", handler, menuText);

                            
                    }
                    sb.Append(line);

                    string pid = parentMenu.MenuID.ToString();
                    string parentId = parentMenu.ParentID.ToString();

                    List<MenuDisplay> subMenu = listOfMenu.Where(q => q.ParentID.ToString() == pid).ToList<MenuDisplay>();
                    if (subMenu.Count > 0)
                    {
                        var subMenuBuilder = new StringBuilder();
                        string childMenu = "<ul class='slide-menu''>";
                        sb.Append(childMenu);
                        sb.Append(GenerateSidebar(subMenu, listOfMenu, subMenuBuilder));
                        sb.Append("</ul>");
                    }
                    sb.Append("</li>");
                }
            }

            sb.Append("</ul>");
            
            return sb.ToString();
        }
        //[HttpPost]
        //public IActionResult index( IFormCollection formCollection)
        //{
        //    var writer = new QRCodeWriter();
        //    var resultBit = writer.encode(formCollection["QRCodeString"], BarcodeFormat.QR_CODE, 200, 200);
        //    var matrix = resultBit;
        //    int scale = 2;
        //    Bitmap result = new Bitmap(matrix.Width * scale, matrix.Height * scale);
        //    for (int k = 0; k < matrix.Height; k++)
        //    {
        //        for(int l = 0; l < matrix.Width; l++)
        //        {
        //            Color pixel = matrix[k, l] ? Color.Black : Color.White;
        //            for(int m = 0; m < scale; m++)
        //                for(int n = 0; n < scale; n++)
        //                    result.SetPixel(k * scale + m, l * scale + n, pixel);
        //        }
        //    }
        //    string webRootPath = _webHostEnviroment.WebRootPath;
        //    result.Save(webRootPath + "\\images\\QrcodeNew.png");
        //    ViewBag.URL = "\\images\\QrcodeNew.png";
        //    return View();
        //}

        private async void CreateLoginHistory(int userId, string logCode, string token)
        {
            var logHistory = new LogHistory
            {
                LogCode = logCode,
                LogDate = DateTime.Now,
                UserId = userId,
                LogInTime = DateTime.Now
            };

            string stringData = JsonConvert.SerializeObject(logHistory);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            string url = _apiBaseUrl + "/api/Users/CreateLoginHistory/";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Content = contentData;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    _logger.LogError("History not generated!Check please.");
                }               
            }
        }
    }
}
