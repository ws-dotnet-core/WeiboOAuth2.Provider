# WeiboOAuth2.Provider
![](logo.png)
Weibo OAuth 2.0 provider for .net core 2.0

github : https://github.com/ws-dotnet-core/WeiboOAuth2.Provider

nuget(current version) : https://www.nuget.org/packages/WeiboOAuth2.Provider/1.0.0

## UPDATE

2017.10.02 : change the main namespace to "WeiboOAuth2.Provider", not "WeiboOAuth2.Provider.Src" .

## Weibo OAuth 2.0

  ```code
[T]: Implemented
[F]: Not implemented

OAuth2（Guider）VERSION 1.0.0
[T]Request authorization:	oauth2/authorize	
[T]Get authorization:	oauth2/access_token	
[F]Authorization Query:	oauth2/get_token_info	
[F]Replace authorization:	oauth2/get_oauth2_token	
[T]Authorization Recycle:	oauth2/revokeoauth2	
Other interfaces:	
    [F]account/rate_limit_status	Gets the current authorized user API Access frequency limit
    [F]account/get_uid	        To obtain a user's UID after authorization
    [F]account/profile/email	        Get user's contact mailbox after authorization
    [T]https://api.weibo.com/2/users/show.json      get user infos
  ```

Package Manager
```Package Manager
PM > Install-Package WeiboOAuth2.Provider -Version 1.0.0
```

.NET CLI
```.NET CLI
> dotnet add package WeiboOAuth2.Provider --version 1.0.0
```

 ## Dependencies : 

### .NETStandard 2.0
```
Newtonsoft.Json (>= 10.0.3)
```

## How to use:

### 1. Create options for WeiboOAuth2.0 and inject it into container
```CSharp
    public class WeiboOAuthV2Option : IWeiboOAuthV2Option {
        public string AppID => "your app id";
        public string AppSecret => "your app secret";
    }

    // ...... then inject it.

    services.AddScoped<IWeiboOAuthV2Option, WeiboOAuthV2Option>();

```

### 2. Then create your service 
```CSharp
    // new interface for web service provider
    public interface IWeiboOAuthService<TUser> : IWeiboOAuthV2Provider<WeiboSuccessToken, WeiboUser> {
        // add your code here.
    }

    public class WeiboOAuthService : WeiboOAuthV2Provider, IWeiboOAuthService<User> {

        private YourDBContext db;

        public WeiboOAuthService(YourDBContext db, IWeiboOAuthV2Option options) : base(options) {
            this.options = options;
            this.db = db;
        }

    }

    // then inject it

    services.AddScoped<IWeiboOAuthService<User>, WeiboOAuthService>();
```

### 3. Use in controller
```CSharp
public class IdentityController : Controller {

        private YourDBContext db;
        private IWeiboOAuthService<User> weibo;

        public IdentityController(YourDBContext db, IWeiboOAuthService<User> WEOBO_SRV) {
            this.db = db;
            this.weibo = WEOBO_SRV;
        }
```

### 4. Request authorization (frontend)
```Typescript
// example in typescript
public get WeiboAuth() {
    // my regex tools : ws-regex (npm)
    const href = Regex.Create(/htt.+\/\/.+?\//).Matches(window.location.href)[0];
    return `${this.server.WeiboOAuthHost}/authorize?client_id=${this.server.WeiboClientID}&response_type=code&redirect_uri=${href}`;
  }
```

### 5. Get authorization
```CSharp
 var (result, succeed, error) = await this.weibo.GetWeiboTokenByCodeAsync(code, redirect_url);
```

### 6. Get userinfos
```CSharp
var (infos, succeed02, error02) = await this.weibo.GetWeiboUserInfosAsync(result.Uid, result.AccessToken);
```

### 7. Authorization Recycle
```CSharp
var (result, succeed, error) = await this.weibo.RevokeOAuth2Access(access_token);
```
