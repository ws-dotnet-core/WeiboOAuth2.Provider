using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeiboOAuth2.Provider.Src {

    /// <summary>
    /// Options interface to make sure providing the app-id and app-secret. For IoC.
    /// </summary>
    public interface IWeiboOAuthV2Option {
        string AppID { get; }
        string AppSecret { get; }
    }

    /// <summary>
    /// The contract of provider base.
    /// </summary>
    /// <typeparam name="TToken"></typeparam>
    /// <typeparam name="TWeiboUser"></typeparam>
    public interface IWeiboOAuthV2Provider<TToken, TWeiboUser> {
        Task<(TToken, bool, string)> GetWeiboTokenByCodeAsync(string code, string redirect_url);
        Task<(TWeiboUser, bool, string)> GetWeiboUserInfosAsync(string uid, string access_token);
        Task<(RevokeOAuth2Return, bool, string)> RevokeOAuth2Access(string access_token);
    }

}
