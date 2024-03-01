using AdminApi.Models.Helper;
using AdminApi.Models.Menu;
using AdminApi.Models.User;
using Microsoft.EntityFrameworkCore;
using AdminApi;
using AdminApi.Models;
using AdminApi.Models.App;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApi.Models.App.Location;
using AdminApi.Models.App.Agent;
using AdminApi.DTO.App;

namespace AdminApi.Models
{
    public class AppDbContext:DbContext
    {     
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<LogHistory> LogHistory { get; set; }
        public virtual DbSet<AppMenu> Menu { get; set; }
        public virtual DbSet<MenuGroup> MenuGroup { get; set; }
        public virtual DbSet<MenuGroupWiseMenuMapping> MenuGroupWiseMenuMapping { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<AgentMapping> AgentMappings { get; set; }
        public virtual DbSet<ScreenList> ScreenList { get; set; }
        public virtual DbSet<HallPass> HallPass { get; set; }
        public virtual DbSet<AdScreen> AdScreen { get; set; }
        public virtual DbSet<AdScreenMapping> AdScreenMapping { get; set; }
        public virtual DbSet<AdScreenFeedbackForm> AdScreenFeedbackForm { get; set; }
        public virtual DbSet<StateUser> StateUser { get; set; }
        //public virtual DbSet<TheatreLocation> TheatreLocation { get; set; }
        public virtual DbSet<PushNotification> PushNotifications { get; set; }
        public virtual DbSet<QuestionTable> QuestionTable { get; set; }
        public virtual DbSet<AnswerTable> AnswerTable { get; set; }
        public virtual DbSet<ClientSearch> ClientSearch { get; set; }
        public virtual DbSet<Options> Options { get; set; }
        public virtual DbSet<UpcomingMovie> UpcomingMovie { get; set; }
        public virtual DbSet<UpComingMovieListforClient> UpComingMovieListforClient { get; set; }
        public virtual DbSet<AgentReport> AgentReports { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   

            modelBuilder.Seed();//use this for Sql server,Mysql,Sqlite and PostgreSql
            //modelBuilder.SeedOracle();//use this only for Oracle
            #region 


            //Website pages start
            modelBuilder.Entity<State>()
            .Property(s => s.CreatedOn)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<State>()
             .Property(s => s.IsDeleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();
            //Website pages end

            //Website pages start
            modelBuilder.Entity<Agent>()
            .Property(s => s.CreatedOn)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Agent>()
             .Property(s => s.IsDeleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();
            //Website pages end

            //Website pages start
            modelBuilder.Entity<AgentMapping>()
            .Property(s => s.CreatedOn)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<AgentMapping>()
             .Property(s => s.IsDeleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();
            //Website pages end

            //Website pages start
            modelBuilder.Entity<ScreenList>()
            .Property(s => s.CreatedOn)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<ScreenList>()
             .Property(s => s.IsDeleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();
            //Website pages end

            //Website pages start
            modelBuilder.Entity<HallPass>()
            .Property(s => s.CreatedOn)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<HallPass>()
             .Property(s => s.IsDeleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();
            //Website pages end

            //Website pages start
            modelBuilder.Entity<AdScreen>()
            .Property(s => s.CreatedOn)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<AdScreen>()
             .Property(s => s.IsDeleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();
            //Website pages end


            //Website pages start
            modelBuilder.Entity<AdScreenMapping>()
            .Property(s => s.CreatedOn)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<AdScreenMapping>()
             .Property(s => s.IsDeleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();
            //Website pages end

            //Website pages start
            modelBuilder.Entity<AdScreenFeedbackForm>()
            .Property(s => s.CreatedOn)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<AdScreenFeedbackForm>()
             .Property(s => s.IsDeleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();
            //Website pages end

            //Website pages start
            modelBuilder.Entity<StateUser>()
            .Property(s => s.CreatedOn)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<StateUser>()
             .Property(s => s.IsDeleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();
            //Website pages end

            //Website pages start
            modelBuilder.Entity<PushNotification>()
            .Property(s => s.CreatedOn)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<PushNotification>()
             .Property(s => s.IsDeleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();
            //Website pages end

            //Website pages start
            modelBuilder.Entity<QuestionTable>()
            .Property(s => s.CreatedOn)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<QuestionTable>()
             .Property(s => s.IsDeleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();
            //Website pages end

            //Website pages start
            modelBuilder.Entity<AnswerTable>()
            .Property(s => s.CreatedOn)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<AnswerTable>()
             .Property(s => s.IsDeleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();
            //Website pages end

            //Website pages start
            modelBuilder.Entity<ClientSearch>()
            .Property(s => s.CreatedOn)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<ClientSearch>()
             .Property(s => s.IsDeleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();
            //Website pages end


            //Website pages start
            modelBuilder.Entity<Options>()
            .Property(s => s.CreatedOn)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Options>()
             .Property(s => s.IsDeleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();
            //Website pages end

            //Website pages start
            modelBuilder.Entity<UpcomingMovie>()
            .Property(s => s.CreatedOn)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<UpcomingMovie>()
             .Property(s => s.IsDeleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();
            //Website pages end

            //Website pages start
            modelBuilder.Entity<UpComingMovieListforClient>()
            .Property(s => s.CreatedOn)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<UpComingMovieListforClient>()
             .Property(s => s.IsDeleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();
            //Website pages end

            #endregion
        }

    }
}
