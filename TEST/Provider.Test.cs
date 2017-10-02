using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeiboOAuth2.Provider;

namespace TEST {

    class TestFailureOptions : IWeiboOAuthV2Option {
        public string AppID => "aaa";
        public string AppSecret => "bbb";
    }

    class TestSucceedOptions : IWeiboOAuthV2Option {
        public string AppID => "185930524";
        public string AppSecret => "389e2d039b372cf2763c4842ea1c46d1";
    }

    [TestClass]
    public class WeiboOAuthV2Provider_TEST {

        [TestMethod]
        public async Task GetWeiboTokenByCodeAsync_TESTAsync() {

            var provider = new WeiboOAuthV2Provider(new TestFailureOptions());
            var (token, succeed, error) = await provider.GetWeiboTokenByCodeAsync("ccc", "ddd");

            Assert.AreEqual(false, succeed);
            Assert.AreEqual("invalid_client", error);
            Assert.AreEqual(token.AccessToken, null);

            var provider2 = new WeiboOAuthV2Provider(new TestSucceedOptions());
            var (token2, succeed2, error2) = await provider2.GetWeiboTokenByCodeAsync("ccc", "ddd");

            Assert.AreEqual(false, succeed2);
            Assert.AreEqual("redirect_uri_mismatch", error2);
            Assert.AreEqual(null, token2.AccessToken);
            Assert.AreEqual(21322, token2.ErrorCode);
            Assert.AreEqual("/oauth2/access_token", token2.ErrorUri);
            Assert.AreEqual("redirect_uri_mismatch", token2.Error);

        }

    }
}
