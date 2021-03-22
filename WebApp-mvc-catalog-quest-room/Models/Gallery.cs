using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp_mvc_catalog_quest_room.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<ImageCQR> SetImages { get; set; }
        public Gallery()
        {
            SetImages = new List<ImageCQR>();
        }
    }
}