using System.Web;
using System.Web.Mvc;
using Recruitment.Filters;

namespace Recruitment
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LocalizationAttribute("en"), 0);
        }
    }
}
