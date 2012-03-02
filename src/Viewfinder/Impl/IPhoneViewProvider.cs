namespace NerdDinner.ViewProviders {
    using System.Web.Mvc;
    using NerdDinner.Controllers;
    using NerdDinner.Filters;

    public class IPhoneViewProvider : IViewPathProvider
    {
        public bool CanProvidePath(ControllerContext context)
        {
            return context.IsiPhoneRequest();
        }

        public string GetViewPath(ControllerContext controllerContext, ViewResult result)
        {
            return "Mobile/iPhone/";
        }
    }
}