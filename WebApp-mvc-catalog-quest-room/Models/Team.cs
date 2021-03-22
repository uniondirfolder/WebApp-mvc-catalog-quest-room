using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_mvc_catalog_quest_room.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }

        public int? ImageId { get; set; }
        public ImageCQR Image { get; set; }

        public virtual ICollection<Participant> Gamers { get; set; }

        public Team()
        {
            Gamers = new List<Participant>();
            CreateDate = DateTime.Now;
        }
    }
}