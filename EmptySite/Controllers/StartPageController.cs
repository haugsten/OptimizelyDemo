using EmptySite.Models.Pages;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace EmptySite.Controllers
{
    public class StartPageController : PageController<StartPage>
    {

        public IActionResult Index(StartPage currentPage)
        {
            return View(currentPage);
        }
    }
}
