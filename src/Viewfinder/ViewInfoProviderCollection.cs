namespace Viewfinder {
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Web.Mvc;

    public class ViewInfoProviderCollection : Collection<IViewInfoProvider> {
        public IViewInfoProvider GetPathProvider(ControllerContext context) {
            return this.Where(provider => provider.CanProvidePath(context)).FirstOrDefault();
        }
    }
}
