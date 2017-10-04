using Newtonsoft.Json;
using System;
using WeiboOAuth2.Provider;
using Xunit;

namespace XTEST {
    public class WeiboOAuthV2Model_TEST {

        [Fact]
        public void DeserializeError_TEST() {

            var json = "{'error':'aaaa','error_code':20000, 'request':'bbbbbb', 'error_uri':'cccccc', 'error_description':'dddddd'}";
            var jstruct = JsonConvert.DeserializeObject<ErrorBase>(json);

            Assert.Equal("aaaa", jstruct.Error);
            Assert.Equal(20000, jstruct.ErrorCode);
            Assert.Equal("bbbbbb", jstruct.Request);
            Assert.Equal("cccccc", jstruct.ErrorUri);
            Assert.Equal("dddddd", jstruct.ErrorDescription);
        }

        [Fact]
        public void SerializeError_TEST() {

            var jstruct = new ErrorBase { Error = "fuck", ErrorCode = 20000, ErrorDescription = "sb", ErrorUri = "hh", Request = "2333" };
            var json = JsonConvert.SerializeObject(jstruct);
            var result = "{\"error\":\"fuck\",\"error_code\":20000,\"request\":\"2333\",\"error_uri\":\"hh\",\"error_description\":\"sb\"}";

            Assert.Equal(result, json);

            var jstruct2 = new ErrorBase { Error = "fuck", ErrorCode = 20000, Request = "2333" };
            var json2 = JsonConvert.SerializeObject(jstruct2);
            var result2 = "{\"error\":\"fuck\",\"error_code\":20000,\"request\":\"2333\"}";

            Assert.Equal(result2, json2);
        }

        [Fact]
        public void DeserializeToken_TEST() {

            var json = "{'access_token':'aaaa','remind_in':'####', 'expires_in':20000, 'uid':'cccccc', 'isRealName':true}";
            var jstruct = JsonConvert.DeserializeObject<WeiboSuccessToken>(json);

            Assert.Equal("aaaa", jstruct.AccessToken);
            Assert.Equal(20000, jstruct.ExpiresIn);
            Assert.Equal("####", jstruct.RemindIn);
            Assert.Equal("cccccc", jstruct.Uid);
            Assert.Equal(true, jstruct.IsRealName);
            Assert.Null(jstruct.Error);
            Assert.Null(jstruct.ErrorCode);
            Assert.Null(jstruct.Request);
            Assert.Null(jstruct.ErrorUri);
            Assert.Null(jstruct.ErrorDescription);

            var json2 = "{'error':'aaaa','error_code':20000, 'request':'bbbbbb', 'error_uri':'cccccc', 'error_description':'dddddd'}";
            var jstruct2 = JsonConvert.DeserializeObject<WeiboSuccessToken>(json2);

            Assert.Equal("aaaa", jstruct2.Error);
            Assert.Equal(20000, jstruct2.ErrorCode);
            Assert.Equal("bbbbbb", jstruct2.Request);
            Assert.Equal("cccccc", jstruct2.ErrorUri);
            Assert.Equal("dddddd", jstruct2.ErrorDescription);
        }

        [Fact]
        public void SerializeToken_TEST() {

            var jstruct = new WeiboSuccessToken { Error = "fuck", ErrorCode = 20000, ErrorDescription = "sb", ErrorUri = "hh", Request = "2333" };
            var json = JsonConvert.SerializeObject(jstruct);
            var result = "{\"error\":\"fuck\",\"error_code\":20000,\"request\":\"2333\",\"error_uri\":\"hh\",\"error_description\":\"sb\"}";

            Assert.Equal(result, json);

            var jstruct2 = new WeiboSuccessToken { AccessToken = "token", RemindIn = "aaa", ExpiresIn = 5000, Uid = "bbb", IsRealName = true };
            var json2 = JsonConvert.SerializeObject(jstruct2);
            var result2 = "{\"access_token\":\"token\",\"remind_in\":\"aaa\",\"expires_in\":5000,\"uid\":\"bbb\",\"isRealName\":true}";

            Assert.Equal(result2, json2);
        }

        [Fact]
        public void DeserializeRevokeOAuth2Return_TEST() {

            var json = "{'result':'true'}";
            var jstruct = JsonConvert.DeserializeObject<RevokeOAuth2Return>(json);

            Assert.Equal("true", jstruct.ReturnStr);
            Assert.Equal(true, jstruct.Return);
            Assert.Null(jstruct.Error);
            Assert.Null(jstruct.ErrorCode);
            Assert.Null(jstruct.Request);
            Assert.Null(jstruct.ErrorUri);
            Assert.Null(jstruct.ErrorDescription);

            var json2 = "{'error':'aaaa','error_code':20000, 'request':'bbbbbb', 'error_uri':'cccccc', 'error_description':'dddddd'}";
            var jstruct2 = JsonConvert.DeserializeObject<RevokeOAuth2Return>(json2);

            Assert.Equal("false", jstruct2.ReturnStr);
            Assert.Equal(false, jstruct2.Return);
            Assert.Equal("aaaa", jstruct2.Error);
            Assert.Equal(20000, jstruct2.ErrorCode);
            Assert.Equal("bbbbbb", jstruct2.Request);
            Assert.Equal("cccccc", jstruct2.ErrorUri);
            Assert.Equal("dddddd", jstruct2.ErrorDescription);

        }

    }
}
