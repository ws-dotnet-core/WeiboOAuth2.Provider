using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeiboOAuth2.Provider.Src {

    public class WeiboOAuthV2Provider : IWeiboOAuthV2Provider<WeiboSuccessToken, WeiboUser> {

        protected IWeiboOAuthV2Option options;

        public WeiboOAuthV2Provider(IWeiboOAuthV2Option options) {
            this.options = options;
        }

        public async Task<(WeiboSuccessToken, bool, string)> GetWeiboTokenByCodeAsync(string code, string redirect_url) {
            var oars = $"client_id={options.AppID}&client_secret={options.AppSecret}&grant_type=authorization_code";
            HttpContent hc = new StringContent(oars, Encoding.UTF8, "application/x-www-form-urlencoded");
            using (var client = new HttpClient()) {
                try {
                    var result = await client.PostAsync($"https://api.weibo.com/oauth2/access_token?code={code}&redirect_uri={redirect_url}", hc);
                    var conStr = await result.Content.ReadAsStringAsync();
                    try {
                        var succ_token = JsonConvert.DeserializeObject<WeiboSuccessToken>(conStr);
                        var fail_token = default(WeiboErrorToken);
                        try {
                            fail_token = JsonConvert.DeserializeObject<WeiboErrorToken>(conStr);
                        } catch {
                            return (default(WeiboSuccessToken), false, WeiboOAuth2Errors.GetErrorMessageFailed);
                        }
                        return succ_token == null || succ_token.AccessToken == null ?
                            (default(WeiboSuccessToken), false, fail_token?.ErrorDescription) :
                            (succ_token, true, null);
                    } catch {
                        return (default(WeiboSuccessToken), false, WeiboOAuth2Errors.DeserializeAccessTokenFailed);
                    }
                } catch {
                    return (default(WeiboSuccessToken), false, WeiboOAuth2Errors.GetAccessTokenFailed);
                }
            }
        }

        public async Task<(WeiboUser, bool, string)> GetWeiboUserInfosAsync(string uid, string access_token) {
            using (var client = new HttpClient()) {
                try {
                    var result = await client.GetAsync($"https://api.weibo.com/2/users/show.json?access_token={access_token}&uid={uid}");
                    var conStr = await result.Content.ReadAsStringAsync();
                    try {
                        return (JsonConvert.DeserializeObject<WeiboUser>(conStr), true, conStr);
                    } catch {
                        return (default(WeiboUser), false, WeiboOAuth2Errors.DeserializeWeiboUserInfosFailed);
                    }
                } catch {
                    return (default(WeiboUser), false, WeiboOAuth2Errors.GetWeiboUserInfosFailed);
                }
            }
        }

        public async Task<(RevokeOAuth2Return, bool, string)> RevokeOAuth2Access(string access_token) {
            using (var client = new HttpClient()) {
                try {
                    var result = await client.GetAsync($"https://api.weibo.com/oauth2/revokeoauth2?access_token={access_token}");
                    var conStr = await result.Content.ReadAsStringAsync();
                    try {
                        return (JsonConvert.DeserializeObject<RevokeOAuth2Return>(conStr), true, null);
                    } catch {
                        return (default(RevokeOAuth2Return), false, WeiboOAuth2Errors.DeserializeRevokeTokenFailed);
                    }
                } catch {
                    return (default(RevokeOAuth2Return), false, WeiboOAuth2Errors.GetRevokeTokenFailed);
                }
            }
        }
    }

}
