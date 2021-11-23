using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace EmptySite.Models.Pages
{
    [ContentType(DisplayName = "Start Page", GUID = "8a404222-0d71-4562-a2ce-dbaa8100eff8")]
    public class StartPage : PageData
    {
        [CultureSpecific]
        [Required(AllowEmptyStrings = false)]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "MainBody",
            Description = "Description for this property.",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual XhtmlString MainBody { get; set; }

        [CultureSpecific]
        [Display(
            Name = "MainContentArea",
            Description = "Description for this property.",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual ContentArea MainContentArea { get; set; }

    }
}
