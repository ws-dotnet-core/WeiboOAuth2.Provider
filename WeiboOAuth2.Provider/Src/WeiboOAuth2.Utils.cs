using System;
using System.Collections.Generic;
using System.Text;

namespace WeiboOAuth2.Provider {

    /// <summary>
    /// Errors map of oauth 2.0 .
    /// </summary>
    public static class WeiboOAuth2Errors {

        /// <summary>
        /// Error : try get error message from response failed.
        /// </summary>
        public const string GetErrorMessageFailed = "try get error message from response failed.";

        /// <summary>
        /// Error : get weibo access token failed.
        /// </summary>
        public const string GetAccessTokenFailed = "get weibo access token failed.";

        /// <summary>
        /// Error : get weibo user infos failed.
        /// </summary>
        public const string GetWeiboUserInfosFailed = "get weibo user infos failed.";

        /// <summary>
        /// Error : revoke failed. unknown error.
        /// </summary>
        public const string GetRevokeTokenFailed = "revoke failed. unknown error.";

        /// <summary>
        /// Error : try read weibo access token from response failed.
        /// </summary>
        public const string DeserializeAccessTokenFailed = "try read weibo access token from response failed.";

        /// <summary>
        /// Error : try read weibo userinfos from response failed.
        /// </summary>
        public const string DeserializeWeiboUserInfosFailed = "try read weibo userinfos from response failed.";

        /// <summary>
        /// Error : try read weibo revoke message from response failed.
        /// </summary>
        public const string DeserializeRevokeTokenFailed = "try read weibo revoke message from response failed.";
    }

}
