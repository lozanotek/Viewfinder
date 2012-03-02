namespace Viewfinder {
    using System.Web.Mvc;

    public interface IViewPathProvider {
        bool CanProvidePath(ControllerContext context);
        ViewInfo GetViewInfo(ControllerContext controllerContext, ViewResult result);
    }
}
