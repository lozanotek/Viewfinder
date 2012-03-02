namespace Viewfinder
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Web.Mvc;

    public class ViewProviderCollection : Collection<IViewPathProvider> {
        public IViewPathProvider GetPathProvider(ControllerContext context) {
            return this.Where(provider => provider.CanProvidePath(context)).FirstOrDefault();
        }
    }
}
