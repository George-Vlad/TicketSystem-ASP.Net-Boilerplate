using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using GeorgeVlad.TicketingSystem.Controllers;

namespace GeorgeVlad.TicketingSystem.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : TicketingSystemControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
