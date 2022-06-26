using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using GeorgeVlad.TicketingSystem.Controllers;
using GeorgeVlad.TicketingSystem.Tickets;
using GeorgeVlad.TicketingSystem.Tickets.Dto;

namespace GeorgeVlad.TicketingSystem.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : TicketingSystemControllerBase
    {
        private readonly ITicketAppService _ticketAppService;

        public HomeController(ITicketAppService ticketAppService)
        {
            _ticketAppService = ticketAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> EditTicketModal(int id)
        {
            var model = await _ticketAppService.GetTicketAsync(id);

            return PartialView("_EditModal", ObjectMapper.Map<EditTicketDto>(model));
        }
    }
}
