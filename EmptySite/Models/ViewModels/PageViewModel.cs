using EmptySite.Models.Pages;
using EPiServer.Core;
using EPiServer.Find.Cms;

namespace EmptySite.Models.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : PageData
    {
        public T CurrentPage { get; set; }

        public PageViewModel(T page)
        {
            CurrentPage = page;
        }
    }

    public class SearchPageViewModel : PageViewModel<SearchPage>
    {
        public SearchPageViewModel(SearchPage page) : base(page)
        {
        }

        public IContentResult<PageData> SearchResults { get; set; }
    }

}