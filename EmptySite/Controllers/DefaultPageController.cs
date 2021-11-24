using System;
using EmptySite.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace EmptySite.Controllers
{
    [TemplateDescriptor(Inherited = true)]
    public class DefaultPageController : PageController<PageData>
    {

        public IActionResult Index(PageData currentPage)
        {
            var model = CreateModel(currentPage);
            return View($"~/Views/{currentPage.GetOriginalType().Name}/Index.cshtml", model);
        }

        private IPageViewModel<PageData> CreateModel(PageData page)
        {
            var type = typeof(PageViewModel<>).MakeGenericType(page.GetOriginalType());
            return Activator.CreateInstance(type, page) as IPageViewModel<PageData>;
        }
    }
}