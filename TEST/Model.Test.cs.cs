using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using WeiboOAuth2.Provider;

namespace TEST {
    [TestClass]
    public class WeiboOAuthV2Model_TEST {

        [TestMethod]
        public void DeserializeError_TEST() {

            var json = "{'error':'aaaa','error_code':20000, 'request':'bbbbbb', 'error_uri':'cccccc', 'error_description':'dddddd'}";
            var jstruct = JsonConvert.DeserializeObject<ErrorBase>(json);

            Assert.AreEqual("aaaa", jstruct.Error, string.Format("Expected for '{0}': true; Actual: {1}", "aaaa", jstruct.Error));
            Assert.AreEqual(20000, jstruct.ErrorCode, string.Format("Expected for '{0}': true; Actual: {1}", 20000, jstruct.ErrorCode));
            Assert.AreEqual("bbbbbb", jstruct.Request, string.Format("Expected for '{0}': true; Actual: {1}", "bbbbbb", jstruct.Request));
            Assert.AreEqual("cccccc", jstruct.ErrorUri, string.Format("Expected for '{0}': true; Actual: {1}", "cccccc", jstruct.ErrorUri));
            Assert.AreEqual("dddddd", jstruct.ErrorDescription, string.Format("Expected for '{0}': true; Actual: {1}", "dddddd", jstruct.ErrorDescription));
        }

        [TestMethod]
        public void SerializeError_TEST() {

            var jstruct = new ErrorBase { Error = "fuck", ErrorCode = 20000, ErrorDescription = "sb", ErrorUri = "hh", Request = "2333" };
            var json = JsonConvert.SerializeObject(jstruct);
            var result = "{\"error\":\"fuck\",\"error_code\":20000,\"request\":\"2333\",\"error_uri\":\"hh\",\"error_description\":\"sb\"}";

            Assert.AreEqual(result, json, string.Format("Expected for '{0}': true; Actual: {1}", result, json));

            var jstruct2 = new ErrorBase { Error = "fuck", ErrorCode = 20000, Request = "2333"};
            var json2 = JsonConvert.SerializeObject(jstruct2);
            var result2 = "{\"error\":\"fuck\",\"error_code\":20000,\"request\":\"2333\"}";

            Assert.AreEqual(result2, json2, string.Format("Expected for '{0}': true; Actual: {1}", result2, json2));
        }

        [TestMethod]
        public void DeserializeToken_TEST() {

            var json = "{'access_token':'aaaa','remind_in':'####', 'expires_in':20000, 'uid':'cccccc', 'isRealName':true}";
            var jstruct = JsonConvert.DeserializeObject<WeiboSuccessToken>(json);

            Assert.AreEqual("aaaa", jstruct.AccessToken, string.Format("Expected for '{0}': true; Actual: {1}", "aaaa", jstruct.AccessToken));
            Assert.AreEqual(20000, jstruct.ExpiresIn, string.Format("Expected for '{0}': true; Actual: {1}", 20000, jstruct.ExpiresIn));
            Assert.AreEqual("####", jstruct.RemindIn, string.Format("Expected for '{0}': true; Actual: {1}", "####", jstruct.RemindIn));
            Assert.AreEqual("cccccc", jstruct.Uid, string.Format("Expected for '{0}': true; Actual: {1}", "cccccc", jstruct.Uid));
            Assert.AreEqual(true, jstruct.IsRealName, string.Format("Expected for '{0}': true; Actual: {1}", true, jstruct.IsRealName));
            Assert.IsNull(jstruct.Error);
            Assert.IsNull(jstruct.ErrorCode);
            Assert.IsNull(jstruct.Request);
            Assert.IsNull(jstruct.ErrorUri);
            Assert.IsNull(jstruct.ErrorDescription);
        }

        [TestMethod]
        public void SerializeToken_TEST() {

            var jstruct = new WeiboSuccessToken { Error = "fuck", ErrorCode = 20000, ErrorDescription = "sb", ErrorUri = "hh", Request = "2333" };
            var json = JsonConvert.SerializeObject(jstruct);
            var result = "{\"error\":\"fuck\",\"error_code\":20000,\"request\":\"2333\",\"error_uri\":\"hh\",\"error_description\":\"sb\"}";

            Assert.AreEqual(result, json, string.Format("Expected for '{0}': true; Actual: {1}", result, json));

            var jstruct2 = new WeiboSuccessToken { AccessToken="token", RemindIn = "aaa", ExpiresIn = 5000, Uid = "bbb", IsRealName = true };
            var json2 = JsonConvert.SerializeObject(jstruct2);
            var result2 = "{\"access_token\":\"token\",\"remind_in\":\"aaa\",\"expires_in\":5000,\"uid\":\"bbb\",\"isRealName\":true}";

             Assert.AreEqual(result2, json2, string.Format("Expected for '{0}': true; Actual: {1}", result2, json2));
        }

        [TestMethod]
        public void DeserializeRevokeOAuth2Return_TEST() {

            var json = "{'result':'true'}";
            var jstruct = JsonConvert.DeserializeObject<RevokeOAuth2Return>(json);

            Assert.AreEqual("true", jstruct.ReturnStr, string.Format("Expected for '{0}': true; Actual: {1}", "true", jstruct.ReturnStr));
            Assert.AreEqual(true, jstruct.Return, string.Format("Expected for '{0}': true; Actual: {1}", true, jstruct.Return));
            Assert.IsNull(jstruct.Error);
            Assert.IsNull(jstruct.ErrorCode);
            Assert.IsNull(jstruct.Request);
            Assert.IsNull(jstruct.ErrorUri);
            Assert.IsNull(jstruct.ErrorDescription);

            var json2 = "{'error':'aaaa','error_code':20000, 'request':'bbbbbb', 'error_uri':'cccccc', 'error_description':'dddddd'}";
            var jstruct2 = JsonConvert.DeserializeObject<RevokeOAuth2Return>(json2);

            Assert.AreEqual("false", jstruct2.ReturnStr, string.Format("Expected for '{0}': true; Actual: {1}", "false", jstruct.ReturnStr));
            Assert.AreEqual(false, jstruct2.Return, string.Format("Expected for '{0}': true; Actual: {1}", false, jstruct.Return));
            Assert.AreEqual("aaaa", jstruct2.Error, string.Format("Expected for '{0}': true; Actual: {1}", "aaaa", jstruct.Error));
            Assert.AreEqual(20000, jstruct2.ErrorCode, string.Format("Expected for '{0}': true; Actual: {1}", 20000, jstruct.ErrorCode));
            Assert.AreEqual("bbbbbb", jstruct2.Request, string.Format("Expected for '{0}': true; Actual: {1}", "bbbbbb", jstruct.Request));
            Assert.AreEqual("cccccc", jstruct2.ErrorUri, string.Format("Expected for '{0}': true; Actual: {1}", "cccccc", jstruct.ErrorUri));
            Assert.AreEqual("dddddd", jstruct2.ErrorDescription, string.Format("Expected for '{0}': true; Actual: {1}", "dddddd", jstruct.ErrorDescription));

        }

    }
}
