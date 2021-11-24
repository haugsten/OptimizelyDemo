using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EmptySite.Models.Pages
{
    [ContentType(DisplayName = "Article Page", GUID = "f2b26011-bd38-43b7-a206-c8000fec465b")]
    public class ArticlePage : PageData
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

        public int NumberOfCharsInHeading()
        {
            return string.IsNullOrWhiteSpace(Heading) ? 0 : Heading.Length;
        }
    }
}