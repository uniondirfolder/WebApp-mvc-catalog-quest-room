using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp_mvc_catalog_quest_room.Models
{
    public class CQRContext:DbContext
    {
        public CQRContext():base("CQRContext")
        {

        }
        private DbSet<Room> _rooms;
        public DbSet<Room> Rooms { get => _rooms; set => _rooms = value; }
    }

    
}