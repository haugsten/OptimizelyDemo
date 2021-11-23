using System;
using EmptySite.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
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
    public interface IPageViewModel<out T> where T : PageData
    {
        T CurrentPage { get; }
    }

    public class PageViewModel<T> : IPageViewModel<T> where T : PageData
    {
        public T CurrentPage { get; set; }

        public PageViewModel(T page)
        {
            CurrentPage = page;
        }
    }
    
}
