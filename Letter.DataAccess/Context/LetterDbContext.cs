using Letter.Business.Dtos.Get.Main;
using Letter.DataAccess.Configurations;
using Letter.DataAccess.Entities.Chat;
using Letter.DataAccess.Entities.Libraries;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using F = Letter.DataAccess.Entities.Main;

namespace Letter.DataAccess.Context
{
    public class LetterDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public LetterDbContext(DbContextOptions options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}


        //#region Main
        ////public DbSet<Blog> Blogs { get; set; }
        ////public DbSet<About> Abouts { get; set; }
        //public DbSet<AboutCompany> Abouts { get; set; }
        ////public DbSet<GoStudyFront> GoStudyFronts { get; set; }
        ////public DbSet<GoStudyFile> GoStudyFiles { get; set; }
        ////public DbSet<BlogCategory> BlogCategories { get; set; }
        ////public DbSet<MainAbout> PersonalAbouts { get; set; }


        //public DbSet<Contact> Contacts { get; set; }
        //public DbSet<Icon> Icons { get; set; }
        //public DbSet<TimeType> TimeTypes { get; set; }
        //public DbSet<F.File> Files { get; set; }
        //public DbSet<HomeFile> HomeFiles { get; set; }
        
        ////public DbSet<BlogFile> BlogFiles { get; set; }
        //public DbSet<Home> Homes { get; set; }
        //public DbSet<Place> Places { get; set; }
        //public DbSet<PlaceFile> PlaceFiles { get; set; }
        //public DbSet<Status> Statuses { get; set; }
        //public DbSet<City> Cities { get; set; }
        //public DbSet<HomeType> HomeTypes { get; set; }
       
        //#endregion
        //#region Chat
        ////public DbSet<Message> Messages { get; set; }
        ////public DbSet<MessageThread> MessageThreads { get; set; }
        ////public DbSet<ThreadMember> ThreadMembers { get; set; }
        //#endregion

        //#region Library
        //public DbSet<ThreadMemberRole> ZThreadMemberRoles { get; set; }
        //#endregion

    }
}
