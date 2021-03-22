using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_mvc_catalog_quest_room.Models
{
    public class Room
    {
        public string Description { get; set; }
        public Level Fear { get; set; }
        public Level Diffikulty { get; set; }
    }
}