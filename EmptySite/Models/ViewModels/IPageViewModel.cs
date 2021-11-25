using EPiServer.Core;

namespace EmptySite.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : PageData
    {
        T CurrentPage { get; }
        bool ShowContentArea { get; set; }
    }
}