using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EmptySite.Models.Blocks
{
    [ContentType(GUID = "5b52ddec-e7db-4089-ab88-e7bc20b505d6")]
    public class EditorialBlock : BlockData
    {
        [Display(GroupName = SystemTabNames.Content)]
        [CultureSpecific]
        public virtual XhtmlString MainBody { get; set; }
    }
}