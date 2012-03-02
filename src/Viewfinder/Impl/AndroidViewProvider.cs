namespace NerdDinner.ViewProviders
{
    using System.Web.Mvc;
    using NerdDinner.Controllers;
    using NerdDinner.Filters;

    public class AndroidViewProvider : MobileViewProvider
    {
        public override bool CanProvidePath(ControllerContext context)
        {
            return context.IsAndroidRequest();
        }
    }
}
