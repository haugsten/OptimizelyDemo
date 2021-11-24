using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EmptySite.Models.Pages
{
    [ContentType(DisplayName = "Search Page", GUID = "1b5eeb8d-dc0f-436f-a37e-2fe433921711")]
    public class SearchPage : PageData
    {
        [CultureSpecific]
        [Required(AllowEmptyStrings = false)]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Heading { get; set; }
    }
}