namespace Viewfinder.Providers {
    using System;
    using System.Web.Mvc;

    public static class ControllerContextExt {
        public static bool IsiOSRequest(this ControllerContext context) {
            var isiOS = IsUserAgent(context, "iPhone");
            
            if (!isiOS) {
                isiOS = IsUserAgent(context, "iPad");
            }

            return isiOS;
        }

        public static bool IsAndroidRequest(this ControllerContext context) {
            return IsUserAgent(context, "Android");
        }

        public static bool IsMobileRequest(this ControllerContext context) {
            var mobileRequest = context.IsAndroidRequest();

            if (!mobileRequest) {
                mobileRequest = context.IsiOSRequest();
            }

            return mobileRequest;
        }

        public static bool IsUserAgent(this ControllerContext context, string userAgent) {
            var request = context.HttpContext.Request;
            var userAgentRequeset = request.UserAgent;
            if (string.IsNullOrEmpty(userAgentRequeset)) return false;

            return userAgentRequeset.IndexOf(userAgent, StringComparison.OrdinalIgnoreCase) > 0;
        }
    }
}
