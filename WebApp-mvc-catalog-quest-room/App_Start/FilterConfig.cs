using System.Web;
using System.Web.Mvc;

namespace WebApp_mvc_catalog_quest_room
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
