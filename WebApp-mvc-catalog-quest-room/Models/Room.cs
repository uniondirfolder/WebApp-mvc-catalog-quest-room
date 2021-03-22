using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_mvc_catalog_quest_room.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Level Fear { get; set; }
        public Level Difficulty { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int Rating { get; set; }//%

        public int TransitTime { get; set; }

        public virtual ICollection<ImageCQR> Images { get; set; }
        public virtual ICollection<Team> Teams { get; set; }

        public Room()
        {
            Images = new List<ImageCQR>();
            Teams = new List<Team>();
        }
    }
}