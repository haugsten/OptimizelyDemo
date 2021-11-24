using EmptySite.Models.Catalog;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace EmptySite.Controllers
{
    public class GenericProductController : ContentController<GenericProduct>
    {

        public ActionResult Index(GenericProduct currentContent)
        {
            return View(currentContent);
        }
    }
}