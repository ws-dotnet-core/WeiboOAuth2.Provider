using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeiboOAuth2.Provider {

    /// <summary>
    /// Options interface to make sure providing the app-id and app-secret. For IoC.
    /// </summary>
    public interface IWeiboOAuthV2Option {

        /// <summary>
        /// your app id
        /// </summary>
        string AppID { get; }

        /// <summary>
        /// your app secret
        /// </summary>
        string AppSecret { get; }
    }

    /// <summary>
    /// The contract of provider base.
    /// </summary>
    /// <typeparam name="TToken"></typeparam>
    /// <typeparam name="TWeiboUser"></typeparam>
    public interface IWeiboOAuthV2Provider<TToken, TWeiboUser> {

        /// <summary>
        /// Try to fetch access token with code and redirect_url.
        /// </summary>
        /// <param name="code">code returns from weibo.</param>
        /// <param name="redirect_url">url you want ro redirect to.</param>
        /// <returns>token, succeed or not, error if have</returns>
        Task<(TToken, bool, string)> GetWeiboTokenByCodeAsync(string code, string redirect_url);

        /// <summary>
        /// Try to get the details of weibo user with the access_token and uid.
        /// </summary>
        /// <param name="uid">uid of weibo user.</param>
        /// <param name="access_token">access token from provider.</param>
        /// <returns>weibo user, succeed or not, error if have</returns>
        Task<(TWeiboUser, bool, string)> GetWeiboUserInfosAsync(string uid, string access_token);

        /// <summary>
        /// Try to delete the authentication with access_token.
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns>action result, succeed or not, error if have</returns>
        Task<(RevokeOAuth2Return, bool, string)> RevokeOAuth2Access(string access_token);
    }

}
