namespace Viewfinder {
    using Viewfinder.Providers;

    public static class ViewInfoProviders {
        private static readonly ViewInfoProviderCollection PathInfoProviders = new ViewInfoProviderCollection();

        static ViewInfoProviders() {
            // Register these view path providers
            PathInfoProviders.Add(new IOSViewProvider());
            PathInfoProviders.Add(new AndroidViewProvider());
        }

        public static ViewInfoProviderCollection Providers {
            get { return PathInfoProviders; }
        }
    }
}
