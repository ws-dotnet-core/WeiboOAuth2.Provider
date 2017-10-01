using System;
using System.Collections.Generic;
using System.Text;

namespace WeiboOAuth2.Provider.Src {

    /// <summary>
    /// Errors map of oauth 2.0 .
    /// </summary>
    public static class WeiboOAuth2Errors {
        public const string GetErrorMessageFailed = "try get error message from response failed.";
        public const string GetAccessTokenFailed = "get weibo access token failed.";
        public const string GetWeiboUserInfosFailed = "get weibo user infos failed.";
        public const string GetRevokeTokenFailed = "revoke failed. unknown error.";
        public const string DeserializeAccessTokenFailed = "try read weibo access token from response failed.";
        public const string DeserializeWeiboUserInfosFailed = "try read weibo userinfos from response failed.";
        public const string DeserializeRevokeTokenFailed = "try read weibo revoke message from response failed.";
    }

}
