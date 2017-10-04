using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeiboOAuth2.Provider;
using Xunit;

namespace XTEST {

    class TestFailureOptions : IWeiboOAuthV2Option {
        public string AppID => "aaa";
        public string AppSecret => "bbb";
    }

    class TestSucceedOptions : IWeiboOAuthV2Option {
        public string AppID => "185930524";
        public string AppSecret => "389e2d039b372cf2763c4842ea1c46d1";
    }

    public class WeiboOAuthV2Provider_TEST {

        [Fact]
        public async Task GetWeiboTokenByCodeAsync_TESTAsync() {

            var provider = new WeiboOAuthV2Provider(new TestFailureOptions());
            var (token, succeed, error) = await provider.GetWeiboTokenByCodeAsync("ccc", "ddd");

            Assert.Equal(false, succeed);
            Assert.Equal("invalid_client", error);
            Assert.Equal(token.AccessToken, null);

            var provider2 = new WeiboOAuthV2Provider(new TestSucceedOptions());
            var (token2, succeed2, error2) = await provider2.GetWeiboTokenByCodeAsync("ccc", "ddd");

            Assert.Equal(false, succeed2);
            Assert.Equal("redirect_uri_mismatch", error2);
            Assert.Equal(null, token2.AccessToken);
            Assert.Equal(21322, token2.ErrorCode);
            Assert.Equal("/oauth2/access_token", token2.ErrorUri);
            Assert.Equal("redirect_uri_mismatch", token2.Error);

        }

    }

}
