using System.ComponentModel.DataAnnotations;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace EmptySite.Models.Catalog
{
    [CatalogContentType(
        GUID = "2b0372b6-5648-4d1c-a2f9-03647a783a43",
        MetaClassName = "GenericProduct",
        DisplayName = "Generic Product",
        Description = "")]
    public class GenericProduct : ProductContent
    {

        [CultureSpecific]
        [Display(Name = "Title",
            Description = "Title text",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Title { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        [Display(Name = "Introduction",
            Description = "Introduction text",
            Order = 20)]
        public virtual string Introduction { get; set; }

        [CultureSpecific]
        [Display(Name = "Description",
            Description = "Description text",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual XhtmlString Mainbody { get; set; }


        [Display(Name = "SEO Information", GroupName = "Metadata", Order = 100)]
        public override SeoInformation SeoInformation { get; set; }
    }
}