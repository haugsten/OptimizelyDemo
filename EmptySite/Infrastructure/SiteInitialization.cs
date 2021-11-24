using EPiServer;
using EPiServer.Commerce.Routing;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAbstraction.Migration;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using Mediachase.Commerce.Catalog;

namespace EmptySite.Infrastructure
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Commerce.Initialization.InitializationModule))]
    public class SiteInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            CatalogRouteHelper.MapDefaultHierarchialRouter(false);


            var contentSecurityRepository = ServiceLocator.Current.GetInstance<IContentSecurityRepository>();
            var referenceConverter = ServiceLocator.Current.GetInstance<ReferenceConverter>();
            if (ServiceLocator.Current.GetInstance<IContentLoader>().TryGet(referenceConverter.GetRootLink(), out IContent content))
            {
                var securableContent = (IContentSecurable)content;
                var defaultAccessControlList = (IContentSecurityDescriptor)securableContent.GetContentSecurityDescriptor().CreateWritableClone();
                defaultAccessControlList.AddEntry(new AccessControlEntry("CommerceAdmins", AccessLevel.FullAccess, SecurityEntityType.Role));
                defaultAccessControlList.AddEntry(new AccessControlEntry(EveryoneRole.RoleName, AccessLevel.Read, SecurityEntityType.Role));

                contentSecurityRepository.Save(content.ContentLink, defaultAccessControlList, SecuritySaveType.Replace);
            }
        }

        public void Preload(string[] parameters) { }

        public void Uninitialize(InitializationEngine context)
        {

        }
    }


    public class CustomMigrationStep : MigrationStep
    {
        public override void AddChanges()
        {
            var name = "test";
        }
    }
}
