namespace Viewfinder
{
    using System.Web.Mvc;

    public class ViewfinderFilter : IResultFilter {
        public ViewInfoProviderCollection ViewInfoProviders {
            get { return Viewfinder.ViewInfoProviders.Providers; }
        }

        public void OnResultExecuting(ResultExecutingContext filterContext) {
            
            var actionName = filterContext.RouteData.Values["action"] as string;

            var viewResult = filterContext.Result as ViewResult;
            if (viewResult == null) return;

            // Ask the runtime to see if anything is registered and we need to use it
            var provider = ViewInfoProviders.GetPathProvider(filterContext);
            if (provider == null) return;

            // Get the name of the view, if nothing is specified, we take the name of the action
            // since this is the same as the value of return View();
            var viewName = (string.IsNullOrEmpty(viewResult.ViewName)) ? actionName : viewResult.ViewName;

            // Ask the collection to get the correct view path from the specified IViewProvider
            var viewInfo = provider.GetViewInfo(filterContext, viewResult);
            if (viewInfo == null) return;

            string newView = viewInfo.ViewPath + viewName;
            var foundView = ViewEngines.Engines.FindView(filterContext, newView, viewResult.MasterName);
            if (foundView == null || foundView.SearchedLocations != null) return;

            viewResult.ViewName = newView;
        }

        public void OnResultExecuted(ResultExecutedContext filterContext) {
        }
    }
}