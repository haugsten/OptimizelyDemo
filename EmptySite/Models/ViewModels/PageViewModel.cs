using EPiServer.Core;

namespace EmptySite.Models.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : PageData
    {
        public T CurrentPage { get; set; }

        public PageViewModel(T page)
        {
            CurrentPage = page;
        }

        public bool ShowContentArea { get; set; }
    }
}