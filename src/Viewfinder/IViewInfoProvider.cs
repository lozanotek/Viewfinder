namespace Viewfinder {
    using System.Web.Mvc;

    public interface IViewInfoProvider {
        bool CanProvidePath(ControllerContext context);
        ViewInfo GetViewInfo(ControllerContext controllerContext, ViewResult result);
    }
}
