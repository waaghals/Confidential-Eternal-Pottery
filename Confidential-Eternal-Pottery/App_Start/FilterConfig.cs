using System.Web;
using System.Web.Mvc;

namespace Confidential_Eternal_Pottery
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}