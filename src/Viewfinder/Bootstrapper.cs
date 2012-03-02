namespace Viewfinder {
    using System.Web.Mvc;

    public static class Bootstrapper {
        public static void ClearProviders() {
            ViewInfoProviders.Providers.Clear();
        }

        public static void AddProvider<TProvider>() where TProvider : IViewInfoProvider, new() {
            AddProvider(new TProvider());
        }

        public static void AddProvider<TProvider>(TProvider provider) where TProvider: IViewInfoProvider{
            if(provider == null) return;
            ViewInfoProviders.Providers.Add(provider);
        }

        public static void RegisterGlobalFilter() {
            GlobalFilters.Filters.Add(new ViewfinderFilter());
        }
    }
}
