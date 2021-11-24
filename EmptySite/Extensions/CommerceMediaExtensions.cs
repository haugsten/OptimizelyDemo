using System.Collections.Generic;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web;

namespace EmptySite.Extensions
{
    public static class CommerceMediaExtensions
    {

        public static ContentReference AssetImageUrl(this EntryContentBase entry)
        {
            if (entry != null)
            {
                if (entry.CommerceMediaCollection != null)
                {
                    foreach (var commerceMedia in entry.CommerceMediaCollection)
                    {
                       
                            return commerceMedia.AssetLink;
                    }

                }
            }
            return ContentReference.EmptyReference;
        }
    }
}