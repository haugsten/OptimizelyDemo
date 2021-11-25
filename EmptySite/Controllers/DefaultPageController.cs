using System;
using EmptySite.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptimizelySDK;
using OptimizelySDK.Entity;

namespace EmptySite.Controllers
{
    [TemplateDescriptor(Inherited = true)]
    public class DefaultPageController : PageController<PageData>
    {

        public IActionResult Index(PageData currentPage)
        {
            var model = CreateModel(currentPage);
            model.ShowContentArea = IsFeatureEnabled("showcontentarea", HttpContext);
            return View($"~/Views/{currentPage.GetOriginalType().Name}/Index.cshtml", model);
        }

        private IPageViewModel<PageData> CreateModel(PageData page)
        {
            var type = typeof(PageViewModel<>).MakeGenericType(page.GetOriginalType());
            return Activator.CreateInstance(type, page) as IPageViewModel<PageData>;
        }

        private bool IsFeatureEnabled(string name, HttpContext httpContext)
        {
            var optimizely = OptimizelyFactory.NewDefaultInstance("D5KawJ6BffZfAHz7SmR5J");

            var attributes = new UserAttributes
            {
                {"IsBetaUser", httpContext.User.Identity.IsAuthenticated }
            };

            return optimizely.IsFeatureEnabled(name, "", attributes);
        }

    }
}