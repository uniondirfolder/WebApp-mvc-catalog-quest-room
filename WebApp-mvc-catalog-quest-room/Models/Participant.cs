using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_mvc_catalog_quest_room.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool? Sex { get; set; }

        public DateTime RegisterDate { get; set; }

        public int? ImageId { get; set; }
        public ImageCQR Image { get; set; }

        public virtual ICollection<Team> Groups { get; set; }
        public Participant()
        {
            Groups = new List<Team>();
        }
    }
}