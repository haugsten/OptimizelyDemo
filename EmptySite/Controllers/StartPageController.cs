using EmptySite.Models.Pages;
using EmptySite.Models.ViewModels;
using EPiServer.Core;
using EPiServer.Find;
using EPiServer.Find.Cms;
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

    public class SearchPageController : PageController<SearchPage>
    {
        private readonly IClient _searchClient;

        public SearchPageController(IClient searchClient)
        {
            _searchClient = searchClient;
        }

        public IActionResult Index(SearchPage currentPage, string query)
        {
            var searchResults = _searchClient.Search<PageData>()
                .For(query)
                .FilterForVisitor()
                .GetContentResult();

            var model = new SearchPageViewModel(currentPage);
            model.SearchResults = searchResults;

            return View(model);
        }
    }
}
