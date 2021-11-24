using EmptySite.Models.Pages;
using EPiServer.Core;
using EPiServer.Find.Cms;

namespace EmptySite.Models.ViewModels
{
    public class SearchPageViewModel : PageViewModel<SearchPage>
    {
        public SearchPageViewModel(SearchPage page) : base(page)
        {
        }

        public IContentResult<PageData> SearchResults { get; set; }
    }
}