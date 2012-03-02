namespace Viewfinder {
    using System;

    [Serializable]
    public class ViewInfo {
        public string Prefix { get; set; }
        public string ViewPath { get; set; }
        public string MasterPath { get; set; }
    }
}