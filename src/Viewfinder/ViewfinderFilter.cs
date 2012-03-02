namespace Viewfinder
{
    using System.Web.Mvc;

    public class ViewfinderFilter : IResultFilter {
        public ViewProviderCollection Providers {
            get { return ViewProviders.Providers; }
        }

        public void OnResultExecuting(ResultExecutingContext filterContext) {
            
            var actionName = filterContext.RouteData.Values["action"] as string;

            var viewResult = filterContext.Result as ViewResult;
            if (viewResult == null) return;

            // Ask the runtime to see if anything is registered and we need to use it
            var provider = Providers.GetPathProvider(filterContext);
            if (provider == null) return;

            // Get the name of the view, if nothing is specified, we take the name of the action
            // since this is the same as the value of return View();
            var viewName = (string.IsNullOrEmpty(viewResult.ViewName)) ? actionName : viewResult.ViewName;

            // Ask the collection to get the correct view path from the specified IViewProvider
            var viewInfo = provider.GetViewInfo(filterContext, viewResult);
            if (viewInfo == null) return;
            
            if (!string.IsNullOrEmpty(viewInfo.ViewPath)) {
                viewResult.ViewName = viewInfo.ViewPath + viewName;
            }

            if (!string.IsNullOrEmpty(viewResult.MasterName) && !string.IsNullOrEmpty(viewInfo.MasterPath)) {
                viewResult.MasterName = viewInfo.MasterPath + viewResult.MasterName;
            }
        }

        public void OnResultExecuted(ResultExecutedContext filterContext) {
        }
    }
}