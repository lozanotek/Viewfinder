namespace Viewfinder {
    using System.Web.Mvc;

    public class IOSViewProvider : IViewPathProvider {
        public bool CanProvidePath(ControllerContext context) {
            return context.IsiOSRequest();
        }

        public ViewInfo GetViewInfo(ControllerContext controllerContext, ViewResult result) {
            return new ViewInfo {
                ViewPath = "Mobile/iOS/",
                MasterPath = "Mobile/iOS/"
            };
        }
    }
}
