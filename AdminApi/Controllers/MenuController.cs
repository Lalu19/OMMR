using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using AdminApi.Models;
using AdminApi.Models.Menu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using AdminApi.Models.Helper;
using AdminApi.ViewModels.Menu;

namespace AdminApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MenuController:ControllerBase
    {     
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;

        public MenuController(AppDbContext context, 
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo)
        {         
            _context = context;
            _config=config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo=menuGroupWiseMenuMappingRepo;
        } 

        ///<summary>
        ///Generate App Menu.
        ///</summary>
      //  [Authorize(Roles="Admin,User")]
        [HttpGet("{roleId}")]
        public ActionResult GetAppMenu(int roleId)
        {
            try
            {

                var assignMenus=(from mm in _context.MenuGroupWiseMenuMapping join m in _context.Menu
                on mm.MenuId equals m.MenuID 
                where mm.MenuGroupId.Equals((from ur in _context.UserRole where ur.UserRoleId==roleId select new{ur.MenuGroupId}).FirstOrDefault().MenuGroupId) 
                && m.IsActive.Equals(true)
                select new{m.MenuID, m.ParentID, m.MenuTitle, m.URL, m.IsSubMenu,
                m.SortOrder, m.IconClass});

                var parentMenus=from a in assignMenus join m in _context.Menu
                on a.ParentID equals m.MenuID
                select new{m.MenuID, m.ParentID, m.MenuTitle, m.URL, m.IsSubMenu,
                m.SortOrder, m.IconClass};

                var menuList=assignMenus.Union(parentMenus).ToList().OrderBy(q=>q.SortOrder);                          
                return Ok(menuList);                                 
            }
            catch(Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });                     
            }           
        }

        ///<summary>
        ///Menu Access List by Menu Group ID.
        ///</summary>
       // [Authorize(Roles="Admin,User")]
        [HttpGet("{menuGroupId}")]
        public string GetMenuAccessList(int menuGroupId)
        {
            try
            {
                var childMenus=(from m in _context.Menu 
                select new{m.MenuID, m.ParentID, m.MenuTitle, m.URL, m.IsSubMenu,
                m.SortOrder, m.IconClass});

                var parentMenus=(from a in childMenus join m in _context.Menu
                on a.ParentID equals m.MenuID
                select new{m.MenuID, m.ParentID, m.MenuTitle, m.URL, m.IsSubMenu,
                m.SortOrder, m.IconClass});

                var list=childMenus.Union(parentMenus).ToList().OrderBy(q=>q.SortOrder);  

                List<MenuDisplay> menuList=list.Select(s=>new MenuDisplay{MenuID=s.MenuID,ParentID=s.ParentID,
                    MenuTitle=s.MenuTitle,URL=s.URL,IsSubMenu=s.IsSubMenu,
                    SortOrder=s.SortOrder,IconClass=s.IconClass}).ToList();   
                
                var assignedMenuList=(from m in _context.MenuGroupWiseMenuMapping
                where m.MenuGroupId.Equals(menuGroupId) 
                select new{m.MenuGroupId,m.MenuId}).ToList();

                List<MenuGroupWiseMenuMapping> assignedMenuListCast=assignedMenuList.Select(s=>new MenuGroupWiseMenuMapping{
                    MenuGroupId=s.MenuGroupId,MenuId=s.MenuId
                }).ToList();

                return listToMenuAccess(menuList,assignedMenuListCast);                             
            }
            catch(Exception ex)
            {
                return ex.Message;                                   
            }           
        }

        private string listToMenuAccess(List<MenuDisplay> listOfMenu,List<MenuGroupWiseMenuMapping> assignedMenuList)
        {
            List<MenuDisplay> parentMenusList = listOfMenu.Where(q => q.ParentID == 0).ToList<MenuDisplay>();
            var sb = new StringBuilder();
            string unorderedList = GenerateMenu(parentMenusList, listOfMenu, sb, assignedMenuList);
            return unorderedList;
        }

        private string GenerateMenu(List<MenuDisplay> parentMenusList, List<MenuDisplay> listOfMenu, StringBuilder sb,List<MenuGroupWiseMenuMapping> assignedMenuList)
        {
            sb.Append("<ul class='list-group list-group-flush'>");

            if (parentMenusList.Count > 0)
            {
                foreach (var parentMenu in parentMenusList)
                {
                    string handler = parentMenu.URL != null ? parentMenu.URL.ToString() : "";
                    string menuText = parentMenu.MenuTitle != null ? parentMenu.MenuTitle.ToString() : "";
                    string iconClass = parentMenu.IconClass != null ? parentMenu.IconClass.ToString() : "";

                    string line = "";
                    string chkVal="";
                    var chkMenuId=assignedMenuList.Where(q=>q.MenuId==parentMenu.MenuID).FirstOrDefault();
                    if(chkMenuId!=null)
                    {
                        chkVal="checked";
                    }
                    if (parentMenu.ParentID.ToString() == "0" && parentMenu.IsSubMenu.ToString() == "1")
                    {
                        line = String.Format(@"<li class='list-group-item list-group-item-light'> {0} ", menuText);
                    }                  
                    else
                    {                      
                        line = String.Format(@"<li class='list-group-item list-group-item-light'> {0} <input type='checkbox' id='{2}' onclick='menuManipulate(this)' {1}>", menuText,chkVal,parentMenu.MenuID);
                    }
                    sb.Append(line);

                    string pid = parentMenu.MenuID.ToString();
                    string parentId = parentMenu.ParentID.ToString();

                    List<MenuDisplay> subMenu = listOfMenu.Where(q => q.ParentID.ToString() == pid).ToList<MenuDisplay>();
                    if (subMenu.Count > 0)
                    {
                        var subMenuBuilder = new StringBuilder();
                        sb.Append(GenerateMenu(subMenu, listOfMenu, subMenuBuilder,assignedMenuList));
                    }
                    sb.Append("</li>");
                }
            }

            sb.Append("</ul>");
            
            return sb.ToString();
        }

        ///<summary>
        ///Assign App Menu
        ///</summary>
        [HttpPost]
       // [Authorize(Roles="Admin,User")]
        public ActionResult MenuAssign(MenuOperation model)
        {
            try
            { 
                var objCheck=_context.MenuGroupWiseMenuMapping.SingleOrDefault(opt=>opt.MenuGroupId==model.MenuGroupId&&opt.MenuId==model.MenuId);             
                if(model.Operation=="insert")
                {                   
                    if(objCheck==null)
                    {
                        var objAssign=new MenuGroupWiseMenuMapping{MenuGroupId=model.MenuGroupId,
                        MenuId=model.MenuId,IsActive=true,DateAdded=DateTime.Now,AddedBy=model.AddedBy};

                        var obj=_menuGroupWiseMenuMappingRepo.Insert(objAssign);
                        return Ok(obj);
                    }
                }
                else if(model.Operation=="delete")
                {                                     
                    if(objCheck!=null)
                    {
                        var obj=_menuGroupWiseMenuMappingRepo.Delete(objCheck.MenuGroupWiseMenuMappingId);                   
                        return Ok(objCheck);
                    }
                }
                return Accepted(new Confirmation { Status = "error", ResponseMsg = "Something unexpected!" });               
            }
            catch(Exception ex)
            {
                return Accepted(new Confirmation { Status = "unknown", ResponseMsg = ex.Message });  
            }
            
        }

        ///<summary>
        ///Get App Menu List
        ///</summary>
        [HttpGet]
       // [Authorize(Roles="Admin,User")]
        public ActionResult GetMenuList()
        {
            try
            {
                var menuList=(from m in _context.Menu orderby m.ParentID 
                select new{m.MenuID,m.MenuTitle,m.URL,m.IsSubMenu,m.SortOrder,m.IconClass,m.ParentID,
                ParentMenuName=(from mm in _context.Menu where mm.MenuID.Equals(m.ParentID) select mm.MenuTitle).FirstOrDefault()});

                int totalRecords=menuList.Count();
                return Ok(new {data=menuList, recordsTotal = totalRecords, recordsFiltered = totalRecords});           
            }
            catch (Exception ex)
            {              
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get App Parent Menu List
        ///</summary>
        [HttpGet]
      //  [Authorize(Roles="Admin,User")]
        public ActionResult GetParentMenuList()
        {
            try
            {
                var parentMenuList=_context.Menu.Where(q=>q.ParentID==0&&q.IsSubMenu==1);
                return Ok(parentMenuList);           
            }
            catch (Exception ex)
            {              
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get Single Menu by ID
        ///</summary>
        [HttpGet("{id}")]
        //[Authorize(Roles="Admin,User")]
        public ActionResult GetSingleMenu(int id)
        {
            try
            {
                var singleMenu=_menuRepo.SelectById(id);
                return Ok(singleMenu);
            }
            catch (Exception ex)
            {              
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Delete Single Menu by ID
        ///</summary>
        [HttpGet("{id}")]
      //  [Authorize(Roles="Admin,User")]
        public ActionResult DeleteSingleMenu(int id)
        {
            try
            {
                var singleMenu=_menuRepo.Delete(id);
                return Ok(singleMenu);       
            }
            catch (Exception ex)
            {              
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Create App Menu
        ///</summary>
      //  [Authorize(Roles="Admin,User")]
        [HttpPost]       
        public ActionResult CreateMenu(AppMenu model)
        {
            try
            {
                var objCheck=_context.Menu.Where(opt=>opt.MenuTitle==model.MenuTitle||
                (opt.SortOrder==model.SortOrder&&model.ParentID==0&&opt.SortOrder>0)||
                (model.ParentID==0&&model.SortOrder<=0)).FirstOrDefault();

                if(objCheck==null)
                {                  
                    model.DateAdded=DateTime.Now;
                    model.IsActive=true;
                    var obj=_menuRepo.Insert(model);
                    return Ok(obj);                   
                }
                else if(objCheck.SortOrder==model.SortOrder)
                {
                    return Accepted(new Confirmation { Status = "duplicate", ResponseMsg = "Duplicate Order No.!" });
                }
                else if(model.SortOrder<=0)
                {
                    return Accepted(new Confirmation { Status = "duplicate", ResponseMsg = "Order No. must greater than 0!" });
                }
                else if(objCheck.MenuTitle==model.MenuTitle)
                {
                    return Accepted(new Confirmation { Status = "duplicate", ResponseMsg = "Duplicate Menu Title!" });
                }
                return Accepted(new Confirmation { Status = "error", ResponseMsg = "Something unexpected!" });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });             
            }
        }

        ///<summary>
        ///Update App Menu
        ///</summary>
       // [Authorize(Roles="Admin,User")]
        [HttpPost]       
        public ActionResult UpdateMenu(AppMenu model)
        {
            try
            {
                var objMenu=_context.Menu.SingleOrDefault(opt=>opt.MenuID==model.MenuID);
                objMenu.ParentID=model.ParentID; 
                objMenu.MenuTitle=model.MenuTitle;
                objMenu.URL=model.URL;
                objMenu.IsSubMenu=model.IsSubMenu;
                objMenu.SortOrder=model.SortOrder;
                objMenu.IconClass=model.IconClass;              
                objMenu.LastUpdatedBy=model.LastUpdatedBy;
                objMenu.LastUpdatedDate=DateTime.Now;
                _context.SaveChanges();
                return Ok(objMenu);                       
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });             
            }
        }

        ///<summary>
        ///Get Menu Group List
        ///</summary>
        [HttpGet]
       // [Authorize(Roles="Admin,User")]
        public ActionResult GetMenuGroupList()
        {
            try
            {
                var list=_context.MenuGroup;
                var menuGroupList=list.Select(s=>new MenuGroup{MenuGroupID=s.MenuGroupID,MenuGroupName=s.MenuGroupName});
                int totalRecords=menuGroupList.Count();
                return Ok(new {data=menuGroupList, recordsTotal = totalRecords, recordsFiltered = totalRecords});
            }
            catch (Exception ex)
            {              
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get Single Menu Group by ID
        ///</summary>
        [HttpGet("{id}")]
       // [Authorize(Roles="Admin,User")]
        public ActionResult GetSingleMenuGroup(int id)
        {
            try
            {
                var singleMenuGrp=_menuGroupRepo.SelectById(id);
                return Ok(singleMenuGrp);
            }
            catch (Exception ex)
            {              
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Delete Single Menu Group by ID
        ///</summary>
        [HttpGet("{id}")]
       // [Authorize(Roles="Admin,User")]
        public ActionResult DeleteSingleMenuGroup(int id)
        {
            try
            {
                var singleMenuGrp=_menuGroupRepo.Delete(id);
                return Ok(singleMenuGrp);              
            }
            catch (Exception ex)
            {              
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Create Menu Group
        ///</summary>
      //  [Authorize(Roles="Admin,User")]
        [HttpPost]       
        public ActionResult CreateMenuGroup(MenuGroup model)
        {
            try
            {
                var objCheck=_context.MenuGroup.SingleOrDefault(opt=>opt.MenuGroupName==model.MenuGroupName);
                if(objCheck==null)
                {
                    model.DateAdded=DateTime.Now;
                    var obj=_menuGroupRepo.Insert(model);
                    return Ok(obj);         
                }
                else if(objCheck!=null)
                {
                    return Accepted(new Confirmation { Status = "duplicate", ResponseMsg = "Duplicate Menu Group name!" });
                }
                return Accepted(new Confirmation { Status = "error", ResponseMsg = "Something unexpected!" });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });             
            }
        }

        ///<summary>
        ///Update Menu Group
        ///</summary>
      //  [Authorize(Roles="Admin,User")]
        [HttpPost]       
        public ActionResult UpdateMenuGroup(MenuGroup model)
        {
            try
            {
                var objMenuGroup=_context.MenuGroup.SingleOrDefault(opt=>opt.MenuGroupID==model.MenuGroupID);
                objMenuGroup.MenuGroupName=model.MenuGroupName;          
                objMenuGroup.LastUpdatedBy=model.LastUpdatedBy;
                objMenuGroup.LastUpdatedDate=DateTime.Now;
                _context.SaveChanges();
                return Ok(objMenuGroup);                      
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });             
            }
        }

        ///<summary>
        ///Get Menu Group wise Menu Mapping List
        ///</summary>
        [HttpGet]
      //  [Authorize(Roles="Admin,User")]
        public ActionResult GetMenuGroupWiseMenuMappingList()
        {
            try
            {
                var list=_context.MenuGroupWiseMenuMapping;
                return Ok(list);
            }
            catch (Exception ex)
            {              
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }
    }
}
