using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp_mvc_catalog_quest_room.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(3000)]
        public string Description { get; set; }
        public Level Fear { get; set; }
        public Level Difficulty { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int Rating { get; set; }//%

        public int TransitTime { get; set; }

        [ForeignKey("Id")]
        public ICollection<ImageCQR> Images { get; set; }
        [ForeignKey("Id")]
        public ICollection<Team> Teams { get; set; }

        public Room()
        {
            Images = new List<ImageCQR>();
            Teams = new List<Team>();
        }
    }
}