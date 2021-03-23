using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp_mvc_catalog_quest_room.Models
{
    public class Participant
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public int Age { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }
        [MaxLength(30)]
        public string Phone { get; set; }
        [MaxLength(30)]
        public string Email { get; set; }
        public bool? Sex { get; set; }

        public DateTime RegisterDate { get; set; }

        public int? ImageId { get; set; }
        public ImageCQR Image { get; set; }

        [ForeignKey("Id")]
        public ICollection<Team> Groups { get; set; }
        public Participant()
        {
            Groups = new List<Team>();
        }
    }
}