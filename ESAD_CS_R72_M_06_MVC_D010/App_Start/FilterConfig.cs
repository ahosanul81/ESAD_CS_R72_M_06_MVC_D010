using System.Web;
using System.Web.Mvc;

namespace ESAD_CS_R72_M_06_MVC_D010
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
