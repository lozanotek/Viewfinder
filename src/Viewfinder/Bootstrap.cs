namespace Viewfinder {
    using System.Web.Mvc;

    public static class Bootstrap {
        public static void RegisterGlobalFilter() {
            GlobalFilters.Filters.Add(new ViewfinderFilter());
        }
    }
}