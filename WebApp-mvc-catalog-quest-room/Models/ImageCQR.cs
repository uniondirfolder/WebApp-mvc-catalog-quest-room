using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp_mvc_catalog_quest_room.Models
{
    public class ImageCQR
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string ExternalLink { get; set; }
        [MaxLength(250)]
        public string InternalPath { get; set; }
        public byte[] DataBase { get; set; }
    }
}