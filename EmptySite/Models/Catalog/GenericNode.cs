using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;

namespace EmptySite.Models.Catalog
{
    [CatalogContentType(DisplayName = "Generic Node",
        GUID = "b71fb563-5dfc-42fd-86bf-58c80d801e32")]
    public class GenericNode : NodeContent
    {

    }
}
