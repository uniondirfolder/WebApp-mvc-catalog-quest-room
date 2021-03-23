using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp_mvc_catalog_quest_room.Models
{
    public class RoomFilter
    {
       
        public bool IsFilterSetFear { get; set; }
        public bool IsFilterSetDifficulty { get; set; }
        public bool IsFilterSetAge { get; set; }
        public bool IsFilterSetCountGamers { get; set; }
        public bool IsFilterSetRating { get; set; }
        public bool IsFilterSetTransitTime { get; set; }

        public Level Fear { get; set; }
        public Level Difficulty { get; set; }
        public int Age { get; set; }
        public SizeGroup CountGamers { get; set; }
        public int Rating { get; set; }//%
        public int TransitTime { get; set; }


        public List<Room> GetResultFiltering(CQRContext db) 
        {
            List<Room> list = null;
            if (db != null) 
            {
                list = db.Rooms.Where(x=>x.Id>0).ToList();

                if (list != null && list.Count > 1) 
                {
                    if (IsFilterSetFear)
                    {
                        list = list.Where(x => x.Fear == Fear).ToList();
                    }

                    if (IsFilterSetDifficulty)
                    {
                        list = list.Where(x => x.Difficulty == Difficulty).ToList();
                    }

                    if (IsFilterSetAge)
                    {
                        list = list.Where(x => x.MaxAge >= Age && x.MinAge <= Age).ToList();
                    }

                    if (IsFilterSetRating)
                    {
                        list = list.Where(x => x.Rating == Rating).ToList();
                    }

                    if (IsFilterSetTransitTime)
                    {
                        list = list.Where(x => x.TransitTime == TransitTime).ToList();
                    }

                    if (IsFilterSetCountGamers)
                    {
                        var teams = db.Teams.Where(x => x.SizeGroup == CountGamers).ToList();

                        for (int i = 0; i < teams.Count; i++)
                        {
                            for (int j = 0; j < list.Count; j++)
                            {
                                if (list[j].Teams.Contains(teams[i])) { break; }
                                else { list.RemoveAt(j); break; }
                            }
                        }
                    }

                    
                }
            }

            if (list == null) { list = new List<Room>(); }

            return list;
        }

    }
}

/*На главную страницу, где отображается список квест-комнат,
добавить форму с возможностью фильтрации списка по сложности,
количеству игроков, уровню страха*/