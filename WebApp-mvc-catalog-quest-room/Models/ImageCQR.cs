using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_mvc_catalog_quest_room.Models
{
    public class ImageCQR
    {
        public int Id { get; set; }
        public string ExternalLink { get; set; }
        public string InternalPath { get; set; }
        public byte[] DataBase { get; set; }
    }
}