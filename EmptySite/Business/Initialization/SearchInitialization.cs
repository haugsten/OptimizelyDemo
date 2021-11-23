using EmptySite.Models.Pages;
using EPiServer.Core;
using EPiServer.Find.ClientConventions;
using EPiServer.Find.Cms;
using EPiServer.Find.Cms.Conventions;
using EPiServer.Find.Framework;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace EmptySite.Business.Initialization
{
    [InitializableModule]
    public class SearchInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            SearchClient.Instance.Conventions.ForInstancesOf<ArticlePage>()
                .IncludeField(x => x.NumberOfCharsInHeading());

            ContentIndexer.Instance.Conventions.ForInstancesOf<ContentFolder>().ShouldIndex(x => false);
        }
        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}
