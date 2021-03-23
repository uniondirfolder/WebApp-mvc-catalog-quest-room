using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp_mvc_catalog_quest_room.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }

        public int? ImageId { get; set; }
        public ImageCQR Image { get; set; }
        public SizeGroup SizeGroup { get; set;}

        [ForeignKey("Id")]
        public ICollection<Participant> Participants { get; set; }

        public Team()
        {
            Participants = new List<Participant>();
            CreateDate = DateTime.Now;
        }
    }
}