using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp_mvc_catalog_quest_room.Models
{
    public class CQRContext:DbContext
    {
        public CQRContext():base("name=CQRContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CQRContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<ImageCQR> imageCQRs { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Team> Teams { get; set; }
  
    }

    
}