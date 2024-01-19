using System;
using AdminApi.Models.Menu;
using AdminApi.Models.User;
using Microsoft.EntityFrameworkCore;

namespace AdminApi.Models.Helper
{
    public static class ModelBuilderExtensionOracle
    {
        public static void SeedOracle(this ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<MenuGroup>(b=>
            {               
                b.HasKey(e=>e.MenuGroupID);                        
                b.HasData(new MenuGroup
                        {
                            MenuGroupID=-1,
                            MenuGroupName="Super Admin Group",
                            IsActive=true,
                            DateAdded=DateTime.Now,
                            IsMigrationData=true,
                            AddedBy=-1  
                        },
                        new MenuGroup
                        {
                            MenuGroupID=-2,
                            MenuGroupName="User Group",
                            IsActive=true,
                            DateAdded=DateTime.Now,
                            IsMigrationData=true,
                            AddedBy=-1 
                        });
            });
            modelBuilder.Entity<UserRole>(b=>
            {
                b.HasKey(e=>e.UserRoleId);          
                b.HasData(
                    new UserRole
                    {
                        UserRoleId=-1,
                        RoleName="Admin",
                        MenuGroupId=-1,
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1 
                    },
                    new UserRole
                    {
                        UserRoleId=-2,
                        RoleName="User",
                        MenuGroupId=-2,
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1 
                    });          
            });

            modelBuilder.Entity<Users>(b=>{
                b.HasKey(e=>e.UserId);                             
                b.HasData(
                    new Users
                    {
                        UserId=-1,
                        UserRoleId=-1,
                        FullName="John Doe",
                        UserName="admin@2020",
                        Password="admin@2020",
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        AddedBy=-1,
                        IsMigrationData=true,
                        IsPasswordChange=false
                    },
                    new Users
                    {
                        UserId=-2,
                        UserRoleId=-2,
                        FullName="Helen Smith",
                        UserName="user@2020",
                        Password="user@2020",
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        AddedBy=-1,
                        IsMigrationData=true,
                        IsPasswordChange=false
                    });
            });

            modelBuilder.Entity<AppMenu>(b=>{
                b.HasKey(e=>e.MenuID);              
                b.HasData(
                    new AppMenu
                    {
                        MenuID=-1,
                        ParentID=0,
                        MenuTitle="Dashboard",
                        URL="/DashBoard/Index",
                        IsSubMenu=0,
                        SortOrder=1,
                        IconClass="fas fa-home",
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1             
                    },
                    new AppMenu
                    {
                        MenuID=-2,
                        ParentID=0,
                        MenuTitle="Menu",
                        URL="",
                        IsSubMenu=1,
                        SortOrder=2,
                        IconClass="fas fa-ellipsis-v",
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1              
                    },
                    new AppMenu
                    {
                        MenuID=-3,
                        ParentID=-2,
                        MenuTitle="Menu List",
                        URL="/Menu/MenuList",
                        IsSubMenu=0,
                        SortOrder=0,
                        IconClass="",
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1                
                    },
                    new AppMenu
                    {
                        MenuID=-4,
                        ParentID=-2,
                        MenuTitle="Menu Group List",
                        URL="/Menu/MenuGroupList",
                        IsSubMenu=0,
                        SortOrder=0,
                        IconClass="",
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1             
                    },
                    new AppMenu
                    {
                        MenuID=-5,
                        ParentID=0,
                        MenuTitle="User",
                        URL="",
                        IsSubMenu=1,
                        SortOrder=3,
                        IconClass="fas fa-user",
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1              
                    },
                    new AppMenu
                    {
                        MenuID=-6,
                        ParentID=-5,
                        MenuTitle="User List",
                        URL="/User/UserList",
                        IsSubMenu=0,
                        SortOrder=0,
                        IconClass="",
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1              
                    },
                    new AppMenu
                    {
                        MenuID=-7,
                        ParentID=-5,
                        MenuTitle="Role List",
                        URL="/User/RoleList",
                        IsSubMenu=0,
                        SortOrder=0,
                        IconClass="",
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1              
                    },
                    new AppMenu
                    {
                        MenuID=-8,
                        ParentID=-5,
                        MenuTitle="Profile",
                        URL="/User/UserProfile",
                        IsSubMenu=0,
                        SortOrder=0,
                        IconClass="",
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1                
                    },
                    new AppMenu
                    {
                        MenuID=-9,
                        ParentID=0,
                        MenuTitle="Settings",
                        URL="",
                        IsSubMenu=1,
                        SortOrder=4,
                        IconClass="fas fa-wrench",
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1               
                    },
                    new AppMenu
                    {
                        MenuID=-10,
                        ParentID=-9,
                        MenuTitle="Change Password",
                        URL="/User/ChangePassword",
                        IsSubMenu=0,
                        SortOrder=0,
                        IconClass="",
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1              
                    });
            });


            modelBuilder.Entity<MenuGroupWiseMenuMapping>(b=>{
                b.HasKey(e=>e.MenuGroupWiseMenuMappingId);                  
                b.HasData(
                    new MenuGroupWiseMenuMapping
                    {
                        MenuGroupWiseMenuMappingId=-1,
                        MenuGroupId=-1,
                        MenuId=-1,                  
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1              
                    },
                    new MenuGroupWiseMenuMapping
                    {
                        MenuGroupWiseMenuMappingId=-2,
                        MenuGroupId=-1,
                        MenuId=-3,                  
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1               
                    },
                    new MenuGroupWiseMenuMapping
                    {
                        MenuGroupWiseMenuMappingId=-3,
                        MenuGroupId=-1,
                        MenuId=-4,                  
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1               
                    },
                    new MenuGroupWiseMenuMapping
                    {
                        MenuGroupWiseMenuMappingId=-4,
                        MenuGroupId=-1,
                        MenuId=-6,                  
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1                 
                    },
                    new MenuGroupWiseMenuMapping
                    {
                        MenuGroupWiseMenuMappingId=-5,
                        MenuGroupId=-1,
                        MenuId=-7,                  
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1              
                    },
                    new MenuGroupWiseMenuMapping
                    {
                        MenuGroupWiseMenuMappingId=-6,
                        MenuGroupId=-1,
                        MenuId=-8,                  
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1                  
                    },
                    new MenuGroupWiseMenuMapping
                    {
                        MenuGroupWiseMenuMappingId=-7,
                        MenuGroupId=-1,
                        MenuId=-10,                  
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1                 
                    },
                    new MenuGroupWiseMenuMapping
                    {
                        MenuGroupWiseMenuMappingId=-8,
                        MenuGroupId=-2,
                        MenuId=-1,                  
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1               
                    },
                    new MenuGroupWiseMenuMapping
                    {
                        MenuGroupWiseMenuMappingId=-9,
                        MenuGroupId=-2,
                        MenuId=-8,                  
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1                  
                    },
                    new MenuGroupWiseMenuMapping
                    {
                        MenuGroupWiseMenuMappingId=-10,
                        MenuGroupId=-2,
                        MenuId=-10,                  
                        IsActive=true,
                        DateAdded=DateTime.Now,
                        IsMigrationData=true,
                        AddedBy=-1                
                    });
            });
            modelBuilder.Entity<LogHistory>().HasKey(b=>b.LogId);                    
        }
    }
}