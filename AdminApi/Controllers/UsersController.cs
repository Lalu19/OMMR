using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AdminApi.Models;
using AdminApi.Models.Helper;
using AdminApi.Models.User;
using AdminApi.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using static QRCoder.PayloadGenerator;

namespace AdminApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly ISqlRepository<Users> _userRepo;
        private readonly ISqlRepository<UserRole> _userRoleRepo;
        private readonly ISqlRepository<LogHistory> _logHistoryRepo;


        public UsersController(IConfiguration config,
                                AppDbContext context, 
                                ISqlRepository<Users> userRepo,
                                ISqlRepository<UserRole> userRoleRepo,
                                ISqlRepository<LogHistory> logHistoryRepo)
        {
            _config=config;
            _context = context;
            _userRepo = userRepo;
            _userRoleRepo=userRoleRepo;
            _logHistoryRepo=logHistoryRepo;
        }


        ///<summary>
        ///Get Log in Detail
        ///</summary>
        [AllowAnonymous]
        [HttpGet("{username}/{password}")]       
        public ActionResult GetLoginInfo(string username, string password)
        {
            try
            {
                var user= (from u in _context.Users
                join r in _context.UserRole on u.UserRoleId 
                equals r.UserRoleId 
                where u.IsActive.Equals(true) && u.UserName.Equals(username) && u.Password.Equals(password)
                //select new {u.UserId,r.UserRoleId,r.RoleName,u.FullName,u.Mobile,u.Email,u.ImagePath,u.HospitalMasterid}).FirstOrDefault();                                              
                select new {u.UserId,r.UserRoleId,r.RoleName,u.FullName,u.Mobile,u.Email,u.ImagePath,u.StateId,u.StateName,u.Address,u.AdvertiseName}).FirstOrDefault();                                              
                if(user!=null)
                {                   
                    UserInfo userInfo=new UserInfo/*{UserId=user.UserId,UserRoleId=user.UserRoleId,RoleName=user.RoleName,FullName=user.FullName,Mobile=user.Mobile,Email=user.Email,ImagePath=user.ImagePath,HospitalMasterid=user.HospitalMasterid};*/
                    { UserId = user.UserId,UserRoleId = user.UserRoleId,RoleName = user.RoleName,FullName = user.FullName,Mobile = user.Mobile,Email = user.Email,ImagePath = user.ImagePath,StateId = user.StateId,StateName=user.StateName,Address=user.Address,AdvertiseName=user.AdvertiseName};
                    var tokenString=GenerateJwtToken(userInfo);
                    return Ok(new Response{token=tokenString,Obj=userInfo});                                    
                }
               return NoContent();                 
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });             
            }
        }

        ///<summary>
        ///Create Log History after login
        ///</summary>
        //[Authorize(Roles="Admin,User")]
        [HttpPost]       
        public ActionResult CreateLoginHistory(LogHistory model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var obj=_logHistoryRepo.Insert(model);
                    return Ok(obj);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });             
            }
        }

        ///<summary>
        ///Update Login History
        ///</summary>
        //[Authorize(Roles="Admin,User")]
        [HttpGet("{logCode}")]       
        public ActionResult UpdateLoginHistory(string logCode)
        {
            try
            {
                var objLogHistory=_context.LogHistory.SingleOrDefault(opt=>opt.LogCode==logCode);
                objLogHistory.LogOutTime=DateTime.Now;
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });             
            }
        }

        ///<summary>
        ///Get date wise Login summary
        ///</summary>
        [AllowAnonymous]
        [HttpGet("{id}")]      
        public ActionResult GetLogInSummaryByDate(int id)
        {
            try
            {
                var objUser=_context.Users.Where(e=>e.UserId==id).FirstOrDefault();
                if(objUser.UserRoleId==1)
                {
                    var list=_context.LogHistory.GroupBy(e=>e.LogInTime.Date.ToString()).OrderByDescending(e=>e.Key).Take(10)
                    .Select(e => new{ e.Key, Count = e.Count() });
                    var userList=list.Select(s=>new UserLog{Date=s.Key,Count=s.Count});
                    return Ok(userList);
                }   
                else
                {
                    var list=_context.LogHistory.Where(e=>e.UserId==id).GroupBy(e=>e.LogInTime.Date.ToString()).OrderByDescending(e=>e.Key).Take(10)
                    .Select(e => new { e.Key, Count = e.Count() });
                    var userList=list.Select(s=>new UserLog{Date=s.Key,Count=s.Count});
                    return Ok(userList);
                }                                                                      
            }
            catch (Exception ex)
            {              
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get month wise Login summary
        ///</summary>
        [AllowAnonymous] 
        [HttpGet("{id}")]
        public ActionResult GetLogInSummaryByMonth(int id)
        {
            try
            {              
                var objUser=_context.Users.Where(e=>e.UserId==id).FirstOrDefault();
                if(objUser.UserRoleId==1)
                {
                    var list=_context.LogHistory.GroupBy(e=>e.LogInTime.Month)
                        .Select(e => new { e.Key, Count = e.Count() });                       
                    var userList=list.Select(s=>new UserLog{Month=s.Key,Count=s.Count});              
                    return Ok(userList);
                }
                else
                {
                    var list=_context.LogHistory.Where(e=>e.UserId==id).GroupBy(e=>e.LogInTime.Month)
                        .Select(e => new { e.Key, Count = e.Count() });                       
                    var userList=list.Select(s=>new UserLog{Month=s.Key,Count=s.Count});              
                    return Ok(userList);
                }              
            }
            catch (Exception ex)
            {              
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get month wise Login summary
        ///</summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult GetLogInSummaryByYear(int id)
        {
            try
            {     
                var objUser=_context.Users.Where(e=>e.UserId==id).FirstOrDefault();
                if(objUser.UserRoleId==1)
                {
                    var list=_context.LogHistory.GroupBy(e=>e.LogInTime.Year)
                        .Select(e => new { e.Key, Count = e.Count() });                       
                    var userList=list.Select(s=>new UserLog{Year=s.Key,Count=s.Count});             
                    return Ok(userList);
                }
                else
                {
                    var list=_context.LogHistory.Where(e=>e.UserId==id).GroupBy(e=>e.LogInTime.Year)
                        .Select(e => new { e.Key, Count = e.Count() });                       
                    var userList=list.Select(s=>new UserLog{Year=s.Key,Count=s.Count});             
                    return Ok(userList);
                }                     
            }
            catch (Exception ex)
            {              
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get Role wise User Count
        ///</summary>
        //[AllowAnonymous]     
        //[HttpGet] 
        //public ActionResult GetRoleWiseUser()
        //{
        //    try
        //    {              
        //        var list=_context.Users.Join(_context.UserRole,
        //                user=>user.UserRoleId,
        //                role=>role.UserRoleId,
        //                (user,role)=>new
        //                {
        //                    UserId=user.UserId,
        //                    RoleName=role.RoleName
        //                }).GroupBy(e=>e.RoleName)
        //                .Select(e => new { e.Key, Count = e.Count() });

        //        var userList=list.Select(s=>new UserLog{RoleName=s.Key,Count=s.Count});             
        //        return Ok(userList);
        //    }
        //    catch (Exception ex)
        //    {              
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetRoleWiseUser()
        {
            try
            {
                var list = _context.Users
                    .Join(_context.UserRole,
                        user => user.UserRoleId,
                        role => role.UserRoleId,
                        (user, role) => new
                        {
                            UserId = user.UserId,
                            RoleName = role.RoleName,
                            IsActive = user.IsActive
                        })
                    .Where(u => u.IsActive == true) // Adding the condition here
                    .GroupBy(e => e.RoleName)
                    .Select(e => new { e.Key, Count = e.Count() });

                var userList = list.Select(s => new UserLog { RoleName = s.Key, Count = s.Count });
                return Ok(userList);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get Role List
        ///</summary>
        //[Authorize(Roles="Admin,User")]     
        [HttpGet]        
        public ActionResult GetUserRoleList()
        {
            try
            {
                var list=(from r in _context.UserRole join m in _context.MenuGroup on 
                r.MenuGroupId equals m.MenuGroupID 
                select new {r.UserRoleId,r.RoleName,r.RoleDesc,m.MenuGroupName});

                var roleInfoList=list.Select(s=>new RoleInfo{UserRoleId=s.UserRoleId,RoleName=s.RoleName,RoleDesc=s.RoleDesc,MenuGroupName=s.MenuGroupName});

                int totalRecords=roleInfoList.Count();
                return Ok(new {data=roleInfoList, recordsTotal = totalRecords, recordsFiltered = totalRecords});
            }
            catch (Exception ex)
            {              
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get Single Role by ID
        ///</summary>
        [HttpGet("{id}")]       
        //[Authorize(Roles="Admin,User")]
        public ActionResult GetSingleRole(int id)
        {
            try
            {
                var singleRole=_userRoleRepo.SelectById(id);
                return Ok(singleRole);
            }
            catch (Exception ex)
            {              
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Delete Single Role by ID
        ///</summary>
        [HttpGet("{id}")]
        //[Authorize(Roles="Admin,User")]
        public ActionResult DeleteSingleRole(int id)
        {
            try
            {            
                var singleRole=_userRoleRepo.Delete(id);
                return Ok(singleRole);                  
            }
            catch (Exception ex)
            {              
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Create User Role
        ///</summary>
        //[Authorize(Roles="Admin,User")]
        [HttpPost]       
        public ActionResult CreateUserRole(UserRole model)
        {
            try
            {                  
                var objCheck=_context.UserRole.SingleOrDefault(opt=>opt.RoleName==model.RoleName);
                if(objCheck==null)
                {
                    model.DateAdded=DateTime.Now;
                    if(ModelState.IsValid)
                    {
                        var obj=_userRoleRepo.Insert(model);
                        return Ok(obj);
                    }                   
                }
                else if(objCheck!=null)
                {
                    return Accepted(new Confirmation { Status = "duplicate", ResponseMsg = "Duplicate Role name!" });
                }
                return Accepted(new Confirmation { Status = "error", ResponseMsg = "Something unexpected!" });                      
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "unknown", ResponseMsg = ex.Message });             
            }
        }

        ///<summary>
        ///Update User Role
        ///</summary>
        //[Authorize(Roles="Admin,User")]
        [HttpPost]       
        public ActionResult UpdateUserRole(UserRole model)
        {
            try
            {         
                var objUserRole=_context.UserRole.SingleOrDefault(opt=>opt.UserRoleId==model.UserRoleId);
                objUserRole.RoleName=model.RoleName;
                objUserRole.RoleDesc=model.RoleDesc;
                objUserRole.MenuGroupId=model.MenuGroupId;
                objUserRole.LastUpdatedBy=model.LastUpdatedBy;
                objUserRole.LastUpdatedDate=DateTime.Now;
                _context.SaveChanges();
                return Ok(objUserRole);                                       
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });             
            }
        }

        ///<summary>
        ///Get User List
        ///</summary>

        //[Authorize(Roles = "Admin,User")]
        [HttpGet]
        public ActionResult GetUserList()
        {
            try
            {
                var list=(from u in _context.Users 
                join r in _context.UserRole on 
                u.UserRoleId equals r.UserRoleId
                //join p in _context.HospitalMasters on
                //u.HospitalMasterid equals p.HospitalMasterid
                join p in _context.States on u.StateId equals p.StateId
                //join q in _context.AdScreen on u.AdvertiseName equals q.AdvertiseName
                //join c in _context.Citys on u.StateId equals c.CityId
                //join a in _context.Areas on u.StateId equals a.AreaId
                select new {
                    u.UserId,
                    u.UserRoleId,
                    u.FullName,
                    r.RoleName,
                    u.Mobile,
                    u.Email,
                    u.DateOfBirth,
                    u.UserName,
                    u.ImagePath,
                    u.StateId,
                    p.StateName,
                    u.AdvertiseName,
                    //u.CityId,
                    //c.CityName,
                    //u.AreaId,
                    //a.AreaName,
                    u.Address
                    /*u.HospitalMasterid,p.HospitalName*/
                });

                var userInfoList=list.Select(s=>new UserInfo
                {
                    UserId=s.UserId,
                    UserRoleId=s.UserRoleId,
                    RoleName=s.RoleName,
                    FullName=s.FullName,
                    Mobile=s.Mobile,
                    Email=s.Email,
                    DateOfBirth=s.DateOfBirth,
                    UserName=s.UserName,
                    ImagePath=s.ImagePath,
                    StateId = s.StateId,
                    StateName = s.StateName,
                    AdvertiseName = s.AdvertiseName,
                    // CityId = s.CityId,
                    //CityName = s.CityName,
                    // AreaId = s.AreaId,
                    //AreaName = s.AreaName,
                    Address = s.Address
                });

                int totalRecords=userInfoList.Count();
                return Ok(new {data=userInfoList, recordsTotal = totalRecords, recordsFiltered = totalRecords});
            }
            catch (Exception ex)
            {              
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get Single User by ID
        ///</summary>
        [HttpGet("{id}")]
        //[Authorize(Roles="Admin,User")]
        public ActionResult GetSingleUser(int id)
        {
            try
            {
                var singleUser=_userRepo.SelectById(id);
                return Ok(singleUser);
            }
            catch (Exception ex)
            {              
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Delete Single User by ID
        ///</summary>
        [HttpGet("{id}")]
        //[Authorize(Roles="Admin,User")]
        public ActionResult DeleteSingleUser(int id)
        {
            try
            {
                var singleUser=_userRepo.Delete(id);
                return Ok(singleUser);              
            }
            catch (Exception ex)
            {              
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Create User
        ///</summary>
        ///
        ////[Authorize(Roles="Admin,User")]

        [HttpPost]
        public ActionResult CreateUser(Users model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.DateAdded = DateTime.Now;
                    model.IsActive = true;
                    model.IsPasswordChange = false;

                    var obj = _userRepo.Insert(model);
                    return Ok(obj);
                }

                return Accepted(new Confirmation { Status = "error", ResponseMsg = "Invalid Model State" });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        //[HttpPost]
        //public ActionResult CreateUser(Users model)
        //{
        //    var objCheck = _context.Users.SingleOrDefault(opt => opt.AdvertiseName == model.AdvertiseName);
        //    try
        //    {
        //        if (objCheck == null)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                model.DateAdded = DateTime.Now;
        //                model.IsActive = true;
        //                model.IsPasswordChange = false;
        //                var obj = _userRepo.Insert(model);
        //                return Ok(obj);
        //            }
        //        }
        //        else if (objCheck != null)
        //        {
        //            return Accepted(new Confirmation { Status = "duplicate", ResponseMsg = "Duplicate AdvertiseName!" });
        //        }
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = "Something unexpected!" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        ///<summary>
        ///Update User
        ///</summary>
        //[Authorize(Roles="Admin,User")]
        [HttpPost]       
        public ActionResult UpdateUser(Users model)
        {
            try
            {
                var objUser=_context.Users.SingleOrDefault(opt=>opt.UserId==model.UserId);
                objUser.UserRoleId=model.UserRoleId;
                objUser.FullName=model.FullName;
                objUser.Mobile=model.Mobile;
                objUser.Email=model.Email;
                objUser.DateOfBirth=model.DateOfBirth;
                objUser.UserName=model.UserName;
                objUser.Password=model.Password;
                objUser.ImagePath=model.ImagePath;
                objUser.LastUpdatedBy=model.LastUpdatedBy;
                objUser.LastUpdatedDate=DateTime.Now;
                //objUser.HospitalMasterid = model.HospitalMasterid;
                objUser.StateId = model.StateId;
                objUser.StateName = model.StateName;
                objUser.AdvertiseName = model.AdvertiseName;
                //objUser.CityId = model.CityId;
                //objUser.AreaId = model.AreaId;
                objUser.Address = model.Address;

                _context.SaveChanges();
                return Ok(objUser);                   
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });             
            }
        }

        ///<summary>
        ///Update User Profile
        ///</summary>
        //[Authorize(Roles="Admin,User")]
        [HttpPost]       
        public ActionResult UpdateUserProfile(UserInfo model)
        {
            try
            {
                var objUser=_context.Users.SingleOrDefault(opt=>opt.UserId==model.UserId);               
                objUser.FullName=model.FullName;
                objUser.Mobile=model.Mobile;
                objUser.Email=model.Email;
                objUser.DateOfBirth=model.DateOfBirth;
                objUser.ImagePath=model.ImagePath;
                objUser.LastUpdatedBy=model.LastUpdatedBy;
                objUser.LastUpdatedDate=DateTime.Now;
                _context.SaveChanges();
                return Ok(objUser);            
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });             
            }
        }

        ///<summary>
        ///Change User Password
        ///</summary>
        //[Authorize(Roles="Admin,User")]
        [HttpPost]       
        public ActionResult ChangeUserPassword(UserInfo model)
        {
            try
            {
                var objUser=_context.Users.SingleOrDefault(opt=>opt.UserId==model.UserId);
                objUser.Password=model.Password;
                objUser.LastPasswordChangeDate=DateTime.Now;
                objUser.PasswordChangedBy=model.UserId;
                objUser.IsPasswordChange=true;            
                _context.SaveChanges();
                return Ok(objUser);            
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });             
            }
        }

        ///<summary>
        ///Dashboard User Status
        ///</summary>
        //[Authorize(Roles="Admin,User")]     
        [HttpGet]       
        public ActionResult UserStatus()
        {
            try
            {                
                int totalUser=_context.Users.Count();    
                int activeUser=_context.Users.Where(q=>q.IsActive==true).Count();
                int inActiveUser=_context.Users.Where(q=>q.IsActive==false).Count();               
                int adminUser=(from u in _context.Users join ur in _context.UserRole
                              on u.UserRoleId equals ur.UserRoleId where ur.RoleName=="Admin" 
                              select new {ur.RoleName}).Count();
                int superadminUser = (from u in _context.Users 
                                      join ur in _context.UserRole
                                   on u.UserRoleId equals ur.UserRoleId
                                      where ur.RoleName == "Super Admin"
                                      select new { ur.RoleName }).Count();
                int stateUser = (from u in _context.Users
                                      join ur in _context.UserRole
                                   on u.UserRoleId equals ur.UserRoleId
                                      where ur.RoleName == "State User" && u.IsActive == true
                                 select new { ur.RoleName }).Count();
                int clientUser = (from u in _context.Users
                                      join ur in _context.UserRole
                                   on u.UserRoleId equals ur.UserRoleId
                                      where ur.RoleName == "Client User" && u.IsActive == true
                                  select new { ur.RoleName }).Count();

                UserStatus objStatus=new UserStatus{TotalUser=totalUser,ActiveUser=activeUser,InActiveUser=inActiveUser,AdminUser=adminUser, SuperAdminUser = superadminUser, StateUser = stateUser, ClientUser = clientUser };
                return Ok(objStatus);        
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });             
            }
        }

        [HttpGet]
        public ActionResult GetAllUserList()
        {
            try
            {
                var list = (from u in _context.Users
                            join r in _context.UserRole on u.UserRoleId equals r.UserRoleId
                           // join p in _context.States on u.StateId equals p.StateId
                            join a in _context.LogHistory on u.UserId equals a.UserId
                            select new
                            {
                                u.UserId,
                                u.UserRoleId,
                                u.FullName,
                                r.RoleName,
                                u.Mobile,
                                u.Email,
                                u.DateOfBirth,
                                u.UserName,
                                u.ImagePath,
                                //u.StateId,
                                //p.StateName,
                                a.LogId,
                                a.LogDate,
                                a.LogInTime,
                                a.LogOutTime
                            }).OrderByDescending(t => t.UserId);
                int totalRecords = list.Count();
                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        string GenerateJwtToken(UserInfo userInfo)
        {
            var securityKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserId.ToString()),
                new Claim("fullName", userInfo.FullName.ToString()),
                new Claim("role",userInfo.RoleName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(180),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        ////For Client
        //[HttpGet("{userid}")]
        //public ActionResult GetAdsNameByUserId(int userid)
        //{
        //    try
        //    {
        //        var list = (from u in _context.Users
        //                    select new
        //                    {
        //                        u.UserId,
        //                        u.AdvertiseName,


        //                    }).Where(x => x.UserId == userid).ToList();


        //        int totalRecords = list.Count();


        //        return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        [HttpGet("{userid}")]
        public ActionResult GetAdsNameByUserId(int userid)
        {
            try
            {
                var user = _context.Users
                    .Where(u => u.UserId == userid)
                    .FirstOrDefault();

                if (user != null && !string.IsNullOrEmpty(user.AdvertiseName))
                {
                    var ads = user.AdvertiseName.Split(',')
                        .Select(name => new
                        {
                            UserId = user.UserId,
                            AdvertiseName = name.Trim()
                        })
                        .ToList();

                    int totalRecords = ads.Count;

                    return Ok(new { data = ads, recordsTotal = totalRecords, recordsFiltered = totalRecords });
                }
                else
                {
                    return NotFound(); // or return an appropriate response for no data
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }


        [HttpGet("{Id}/{DeletedBy}")]
        public IActionResult SetDeleteRequest(int Id, int DeletedBy)
        {
            try
            {
                var stateAdminToUpdate = _context.Users.FirstOrDefault(u => u.UserId == Id);
                var users = _context.StateUser.Where(u => u.UserId == Id).ToList();



                if (stateAdminToUpdate != null && users.Any())
                {
                    foreach (var user in users)
                    {
                        user.DeleteRequested = true;
                    }
                    stateAdminToUpdate.DeleteRequested = true;
                    stateAdminToUpdate.LastUpdatedDate = System.DateTime.Now;
                    stateAdminToUpdate.LastUpdatedBy = DeletedBy;
                    _context.SaveChanges();
                }
                return Ok(stateAdminToUpdate);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult DeleteStateAdminList()
        {
            try
            {
                var list = (from u in _context.Users
                            join r in _context.UserRole on u.UserRoleId equals r.UserRoleId
                            where u.DeleteRequested == true && u.IsActive == true

                            select new
                            {
                                u.UserId,
                                u.UserRoleId,
                                u.FullName,
                                r.RoleName,
                                u.Mobile,
                                u.Email,
                                u.DateOfBirth,
                                u.UserName,
                                u.ImagePath,
                                u.Address,

                            }).Distinct().ToList();

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
