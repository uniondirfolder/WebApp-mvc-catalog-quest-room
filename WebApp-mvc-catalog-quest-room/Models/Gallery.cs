using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp_mvc_catalog_quest_room.Models
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("Id")]
        public  ICollection<ImageCQR> Images { get; set; }
        public Gallery()
        {
            Images = new List<ImageCQR>();
        }
    }
}