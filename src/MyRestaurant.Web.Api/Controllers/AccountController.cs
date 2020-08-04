//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Security.Claims;
//using System.Security.Cryptography;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using MyRestaurant.Services.Interfaces;

//namespace MyRestaurant.Web.Api.Controllers
//{
//    [Authorize]
//    [Route("api/Account")]   
//    public class AccountController : ControllerBase
//    {
//        private const string LocalLoginProvider = "Local";
//        //private ApplicationUserService _userService;
//        private IUserService _userService;

//        public AccountController(IUserService userService, ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
//        {
//            _userService = userService;
//        }

//        public AccountController(ApplicationUserService userService,
//           )
//        {
//            UserService = userService;
//            AccessTokenFormat = accessTokenFormat;
//        }

//        public ApplicationUserService UserService
//        {
//            get
//            {
//                return _userService ?? Request.GetOwinContext().GetUserService<ApplicationUserService>();
//            }
//            private set
//            {
//                _userService = value;
//            }
//        }

//        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

//        // GET api/Account/UserInfo
//        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
//        [Route("UserInfo")]
//        public UserInfoViewModel GetUserInfo()
//        {
//            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

//            return new UserInfoViewModel
//            {
//                Email = User.Identity.GetUserName(),
//                HasRegistered = externalLogin == null,
//                LoginProvider = externalLogin != null ? externalLogin.LoginProvider : null
//            };
//        }

//        // POST api/Account/Logout
//        [Route("Logout")]
//        public IHttpActionResult Logout()
//        {
//            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
//            return Ok();
//        }

//        // GET api/Account/ManageInfo?returnUrl=%2F&generateState=true
//        [Route("ManageInfo")]
//        public async Task<ManageInfoViewModel> GetManageInfo(string returnUrl, bool generateState = false)
//        {
//            IdentityUser user = await UserService.FindByIdAsync(User.Identity.GetUserId());

//            if (user == null)
//            {
//                return null;
//            }

//            List<UserLoginInfoViewModel> logins = new List<UserLoginInfoViewModel>();

//            foreach (IdentityUserLogin linkedAccount in user.Logins)
//            {
//                logins.Add(new UserLoginInfoViewModel
//                {
//                    LoginProvider = linkedAccount.LoginProvider,
//                    ProviderKey = linkedAccount.ProviderKey
//                });
//            }

//            if (user.PasswordHash != null)
//            {
//                logins.Add(new UserLoginInfoViewModel
//                {
//                    LoginProvider = LocalLoginProvider,
//                    ProviderKey = user.UserName,
//                });
//            }

//            return new ManageInfoViewModel
//            {
//                LocalLoginProvider = LocalLoginProvider,
//                Email = user.UserName,
//                Logins = logins,
//                ExternalLoginProviders = GetExternalLogins(returnUrl, generateState)
//            };
//        }

//        // POST api/Account/ChangePassword
//        [Route("ChangePassword")]
//        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            IdentityResult result = await UserService.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword,
//                model.NewPassword);

//            if (!result.Succeeded)
//            {
//                return GetErrorResult(result);
//            }

//            return Ok();
//        }

//        // POST api/Account/SetPassword
//        [Route("SetPassword")]
//        public async Task<IHttpActionResult> SetPassword(SetPasswordBindingModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            IdentityResult result = await UserService.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);

//            if (!result.Succeeded)
//            {
//                return GetErrorResult(result);
//            }

//            return Ok();
//        }

//        // POST api/Account/AddExternalLogin
//        [Route("AddExternalLogin")]
//        public async Task<IHttpActionResult> AddExternalLogin(AddExternalLoginBindingModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

//            AuthenticationTicket ticket = AccessTokenFormat.Unprotect(model.ExternalAccessToken);

//            if (ticket == null || ticket.Identity == null || (ticket.Properties != null
//                && ticket.Properties.ExpiresUtc.HasValue
//                && ticket.Properties.ExpiresUtc.Value < DateTimeOffset.UtcNow))
//            {
//                return BadRequest("External login failure.");
//            }

//            ExternalLoginData externalData = ExternalLoginData.FromIdentity(ticket.Identity);

//            if (externalData == null)
//            {
//                return BadRequest("The external login is already associated with an account.");
//            }

//            IdentityResult result = await UserService.AddLoginAsync(User.Identity.GetUserId(),
//                new UserLoginInfo(externalData.LoginProvider, externalData.ProviderKey));

//            if (!result.Succeeded)
//            {
//                return GetErrorResult(result);
//            }

//            return Ok();
//        }

//        // POST api/Account/RemoveLogin
//        [Route("RemoveLogin")]
//        public async Task<IHttpActionResult> RemoveLogin(RemoveLoginBindingModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            IdentityResult result;

//            if (model.LoginProvider == LocalLoginProvider)
//            {
//                result = await UserService.RemovePasswordAsync(User.Identity.GetUserId());
//            }
//            else
//            {
//                result = await UserService.RemoveLoginAsync(User.Identity.GetUserId(),
//                    new UserLoginInfo(model.LoginProvider, model.ProviderKey));
//            }

//            if (!result.Succeeded)
//            {
//                return GetErrorResult(result);
//            }

//            return Ok();
//        }

//        // GET api/Account/ExternalLogin
//        [OverrideAuthentication]
//        [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
//        [AllowAnonymous]
//        [Route("ExternalLogin", Name = "ExternalLogin")]
//        public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
//        {
//            if (error != null)
//            {
//                return Redirect(Url.Content("~/") + "#error=" + Uri.EscapeDataString(error));
//            }

//            if (!User.Identity.IsAuthenticated)
//            {
//                return new ChallengeResult(provider, this);
//            }

//            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

//            if (externalLogin == null)
//            {
//                return InternalServerError();
//            }

//            if (externalLogin.LoginProvider != provider)
//            {
//                Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
//                return new ChallengeResult(provider, this);
//            }

//            ApplicationUser user = await UserService.FindAsync(new UserLoginInfo(externalLogin.LoginProvider,
//                externalLogin.ProviderKey));

//            bool hasRegistered = user != null;

//            if (hasRegistered)
//            {
//                Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

//                ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(UserService,
//                   OAuthDefaults.AuthenticationType);
//                ClaimsIdentity cookieIdentity = await user.GenerateUserIdentityAsync(UserService,
//                    CookieAuthenticationDefaults.AuthenticationType);

//                AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user);
//                Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);
//            }
//            else
//            {
//                IEnumerable<Claim> claims = externalLogin.GetClaims();
//                ClaimsIdentity identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
//                Authentication.SignIn(identity);
//            }

//            return Ok();
//        }

//        // GET api/Account/ExternalLogins?returnUrl=%2F&generateState=true
//        [AllowAnonymous]
//        [Route("ExternalLogins")]
//        public IEnumerable<ExternalLoginViewModel> GetExternalLogins(string returnUrl, bool generateState = false)
//        {
//            IEnumerable<AuthenticationDescription> descriptions = Authentication.GetExternalAuthenticationTypes();
//            List<ExternalLoginViewModel> logins = new List<ExternalLoginViewModel>();

//            string state;

//            if (generateState)
//            {
//                const int strengthInBits = 256;
//                state = RandomOAuthStateGenerator.Generate(strengthInBits);
//            }
//            else
//            {
//                state = null;
//            }

//            foreach (AuthenticationDescription description in descriptions)
//            {
//                ExternalLoginViewModel login = new ExternalLoginViewModel
//                {
//                    Name = description.Caption,
//                    Url = Url.Route("ExternalLogin", new
//                    {
//                        provider = description.AuthenticationType,
//                        response_type = "token",
//                        client_id = Startup.PublicClientId,
//                        redirect_uri = new Uri(Request.RequestUri, returnUrl).AbsoluteUri,
//                        state = state
//                    }),
//                    State = state
//                };
//                logins.Add(login);
//            }

//            return logins;
//        }

//        // POST api/Account/Register
//        [AllowAnonymous]
//        [Route("Register")]
//        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            ResponseModel<UserDto> response = new ResponseModel<UserDto>();
//            var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };
//            try
//            {                
//                IdentityResult result = await UserService.CreateAsync(user, model.Password);
//                if (result.Succeeded)
//                {
//                    await UserService.AddToRoleAsync(user.Id, model.Role);
//                    response = _userManaager.SaveUser(new Model.Dto.UserDto
//                    {
//                        FirstName = model.FirstName,
//                        LastName = model.LastName,
//                        EmailAddress = model.Email,
//                        ProfileImage = string.Empty,
//                        UserId = user.Id
//                    });
//                    response = MessageHelper<UserDto>.GetResponse(response);
//                }
//                if (!result.Succeeded)
//                {
//                    return GetErrorResult(result);
//                }
//            }
//            catch(Exception ex)
//            {
//                response.ErrorCode = "500";
//                await UserService.DeleteAsync(user);
//                response = MessageHelper<UserDto>.GetResponse(response);

//            }
//            return Ok(response);
//        }
//        #region Helpers

//        private IAuthenticationService Authentication
//        {
//            get { return Request.GetOwinContext().Authentication; }
//        }


//        private IHttpActionResult GetErrorResult(IdentityResult result)
//        {
//            if (result == null)
//            {
//                return InternalServerError();
//            }

//            if (!result.Succeeded)
//            {
//                if (result.Errors != null)
//                {
//                    foreach (string error in result.Errors)
//                    {
//                        ModelState.AddModelError("", error);
//                    }
//                }
//                if (ModelState.IsValid)
//                {
//                    // No ModelState errors are available to send, so just return an empty BadRequest.
//                    return BadRequest();
//                }
//                return BadRequest(ModelState);
//            }

//            return null;
//        }



//        private static class RandomOAuthStateGenerator
//        {
//            private static RandomNumberGenerator _random = new RNGCryptoServiceProvider();

//            public static string Generate(int strengthInBits)
//            {
//                const int bitsPerByte = 8;

//                if (strengthInBits % bitsPerByte != 0)
//                {
//                    throw new ArgumentException("strengthInBits must be evenly divisible by 8.", "strengthInBits");
//                }

//                int strengthInBytes = strengthInBits / bitsPerByte;

//                byte[] data = new byte[strengthInBytes];
//                _random.GetBytes(data);
//                return HttpServerUtility.UrlTokenEncode(data);
//            }
//        }


//        [OverrideAuthentication]
//        [AllowAnonymous]
//        [Route("RegisterExternalToken")]
//        public async Task<IHttpActionResult> RegisterExternalToken(RegisterExternalTokenBindingModel model)
//        {

//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            ResponseModel<JObject> response = new ResponseModel<JObject>();
//            JObject token;
//            try
//            {
//                //validate token
//                ExternalLoginData externalLogin = await ExternalLoginData.FromToken(model.Provider, model.Token);

//                if (externalLogin == null)
//                {
//                    return InternalServerError();
//                }

//                if (externalLogin.LoginProvider != model.Provider)
//                {
//                    Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
//                    return InternalServerError();
//                }
//                //if we reached this point then token is valid
//                ApplicationUser user = await UserService.FindByEmailAsync(model.Email);

//                bool hasRegistered = user != null;
//                IdentityResult result;

//                if (!hasRegistered)
//                {
//                    user = new ApplicationUser() { UserName = externalLogin.UserName, Email = externalLogin.UserName };

//                    result = await UserService.CreateAsync(user);
//                    if (!result.Succeeded)
//                    {
//                        return GetErrorResult(result);
//                    }
//                    UserLoginInfo login = new UserLoginInfo(externalLogin.LoginProvider, externalLogin.ProviderKey);
//                    result = await UserService.AddLoginAsync(user.Id, login);
//                    if (!result.Succeeded)
//                    {
//                        return GetErrorResult(result);
//                    }
//                    await UserService.AddToRoleAsync(user.Id, model.Role ?? CommonConstants.User);
//                    _userManaager.SaveUser(new Model.Dto.UserDto
//                    {
//                        FirstName = model.DisplayName.Split(' ')[0],
//                        LastName = model.DisplayName.Split(' ').Length > 1 ? model.DisplayName.Split(' ')[1] : string.Empty,
//                        EmailAddress = model.Email,
//                        ProfileImage = model.ProfileImage,
//                        UserId = user.Id
//                    });
//                }
//                else
//                {
//                    if (!UserService.IsInRole(user.Id, model.Role ?? CommonConstants.User))
//                    {
//                        await UserService.AddToRoleAsync(user.Id, model.Role ?? CommonConstants.User);
//                    }
//                }

//                //authenticate
//                var identity = await UserService.CreateIdentityAsync(user, OAuthDefaults.AuthenticationType);
//                IEnumerable<Claim> claims = externalLogin.GetClaims();
//                identity.AddClaims(claims);
//                //Authentication.SignIn(identity);

//                ClaimsIdentity oAuthIdentity = new ClaimsIdentity(Startup.OAuthOptions.AuthenticationType);

//                oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
//                oAuthIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));

//                AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties());

//                DateTime currentUtc = DateTime.UtcNow;
//                ticket.Properties.IssuedUtc = currentUtc;
//                ticket.Properties.ExpiresUtc = currentUtc.Add(Startup.OAuthOptions.AccessTokenExpireTimeSpan);

//                string accessToken = Startup.OAuthOptions.AccessTokenFormat.Protect(ticket);
//                Request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

//                ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(UserService,
//                      CookieAuthenticationDefaults.AuthenticationType);
//                Authentication.SignIn(cookiesIdentity);

//                response.SuccessCode = "101";
//                response = MessageHelper<JObject>.GetResponse(response);
//                // Create the response building a JSON object that mimics exactly the one issued by the default /Token endpoint
//                token = new JObject(
//                new JProperty("username", user.UserName),
//                new JProperty("userid", user.Id),
//                new JProperty("access_token", accessToken),
//                new JProperty("token_type", "bearer"),
//                new JProperty("expires_in", Startup.OAuthOptions.AccessTokenExpireTimeSpan.TotalSeconds.ToString()),
//                new JProperty("issued", currentUtc.ToString("ddd, dd MMM yyyy HH':'mm':'ss 'GMT'")),
//                new JProperty("name", model.DisplayName),
//                new JProperty("profileimage", model.ProfileImage),
//                new JProperty("role", model.Role),
//                new JProperty("provider", model.Provider),

//                new JProperty("expires", currentUtc.Add(Startup.OAuthOptions.AccessTokenExpireTimeSpan).ToString("ddd, dd MMM yyyy HH:mm:ss 'GMT'"))
//                );
//                response.ResponseObject = token;
//            }
//            catch (Exception ex)
//            {
//                return InternalServerError(ex);
//            }

//            return Ok(response);
//        }
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && _userService != null)
//            {
//                _userService.Dispose();
//                _userService = null;
//            }

//            base.Dispose(disposing);
//        }
//        private class ExternalLoginData
//        {
//            public string LoginProvider { get; set; }
//            public string ProviderKey { get; set; }
//            public string UserName { get; set; }

//            public IList<Claim> GetClaims()
//            {
//                IList<Claim> claims = new List<Claim>();
//                claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

//                if (UserName != null)
//                {
//                    claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
//                }

//                return claims;
//            }

//            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
//            {
//                if (identity == null)
//                {
//                    return null;
//                }

//                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

//                if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
//                    || String.IsNullOrEmpty(providerKeyClaim.Value))
//                {
//                    return null;
//                }

//                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
//                {
//                    return null;
//                }

//                return new ExternalLoginData
//                {
//                    LoginProvider = providerKeyClaim.Issuer,
//                    ProviderKey = providerKeyClaim.Value,
//                    UserName = identity.FindFirstValue(ClaimTypes.Name)
//                };
//            }

//            public static async Task<ExternalLoginData> FromToken(string provider, string accessToken)
//            {

//                string verifyTokenEndPoint = "", verifyAppEndpoint = "";
//                HttpClient client = new HttpClient();

//                if (provider == "Facebook")
//                {
//                    verifyTokenEndPoint = string.Format(CommonConstants.FBTokenVerificationUrl, accessToken);
//                    verifyAppEndpoint = string.Format(CommonConstants.FBTokenVerificationUrl, accessToken);
//                }
//                else if (provider == "Google")
//                {
//                    // not implemented yet
//                    // return null;
//                    verifyTokenEndPoint = string.Format(CommonConstants.GTokenVerificationUrl, accessToken);
//                    verifyAppEndpoint = string.Format(CommonConstants.GTokenVerificationUrl, accessToken);

//                }
//                else if (provider == "Twitter")
//                {
//                    verifyTokenEndPoint = string.Format(CommonConstants.TTokenVerificationUrl);
//                    // don't need verifyAppEndPoint as our twitter app automatically gets verified. The token will be invalid if it was issues by some other spoofing app.
//                    //add authorization headers here...
//                    //client.DefaultRequestHeaders.Add("Authorization", string.Format("your authorizations here&access_Token={0}&other stuff", accessToken));
//                    return null; // remove return on implementation.
//                }
//                else
//                {
//                    return null;
//                }

//                Uri uri = new Uri(verifyTokenEndPoint);
//                HttpResponseMessage response = await client.GetAsync(uri);
//                ClaimsIdentity identity = null;

//                if (response.IsSuccessStatusCode)
//                {
//                    string content = await response.Content.ReadAsStringAsync();
//                    dynamic iObj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);


//                    identity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);

//                    if (provider == "Facebook")
//                    {
//                        uri = new Uri(verifyAppEndpoint);
//                        response = await client.GetAsync(uri);
//                        content = await response.Content.ReadAsStringAsync();
//                        dynamic appObj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);
//                        if (appObj["id"] != Startup.facebookAuthOptions.AppId)
//                        {
//                            return null;
//                        }

//                        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, iObj["id"].ToString(), ClaimValueTypes.String, "Facebook", "Facebook"));

//                    }
//                    else if (provider == "Google")
//                    {
//                        uri = new Uri(verifyAppEndpoint);
//                        response = await client.GetAsync(uri);
//                        content = await response.Content.ReadAsStringAsync();
//                        dynamic appObj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);
//                        if (appObj["issued_to"] != Startup.googleAuthOptions.ClientId)
//                        {
//                            return null;
//                        }

//                        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, iObj["issued_to"].ToString(), ClaimValueTypes.String, "Google", "Google"));
//                        identity.AddClaim(new Claim(ClaimTypes.Name, iObj["email"].ToString(), ClaimValueTypes.String, "Google", "Google"));
//                    }
//                    else if (provider == "Twitter")
//                    {
//                        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, iObj["issued_to"].ToString(), ClaimValueTypes.String, "Twitter", "Twitter"));
//                    }
//                }

//                if (identity == null)
//                {
//                    return null;
//                }

//                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

//                if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer) || String.IsNullOrEmpty(providerKeyClaim.Value))
//                {
//                    return null;
//                }

//                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
//                {
//                    return null;
//                }
//                return new ExternalLoginData
//                {
//                    LoginProvider = providerKeyClaim.Issuer,
//                    ProviderKey = providerKeyClaim.Value,
//                    UserName = identity.FindFirstValue(ClaimTypes.Name)

//                };
//            }
//        }
//        #endregion
//    }
//}
