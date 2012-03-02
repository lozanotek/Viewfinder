namespace Viewfinder.Providers {
    using System.Web.Mvc;

    public class AndroidViewProvider : IViewInfoProvider {
        public bool CanProvidePath(ControllerContext context) {
            return context.IsAndroidRequest();
        }

        public ViewInfo GetViewInfo(ControllerContext controllerContext, ViewResult result) {
            return new ViewInfo {
                ViewPath = "Mobile/Android/"
            };
        }
    }
}
