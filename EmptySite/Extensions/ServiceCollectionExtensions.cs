using EPiServer.Security;
using EPiServer.ServiceLocation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmptySite.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOpenIdConnect(this IServiceCollection services)
        {

            services
              .AddAuthentication(options =>
              {
                  options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                  options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
              }
            )
            .AddCookie()
            .AddOpenIdConnect(
              options =>
              {
                  options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                  options.ClientId = "2ac6f147-2057-4392-bdc0-ccca99c74519";
                  options.Authority = "https://login.microsoftonline.com/21cc0295-83d4-4780-a3c6-92b5f1b244d2/v2.0";
                  // if the azure AD is register for multi-tenant
                  //options.Authority = "https://login.microsoftonline.com/" + "common" + "/v2.0";
                  options.CallbackPath = "/signin-oidc";
                  options.Scope.Add("email");

                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = false,
                      RoleClaimType = ClaimTypes.Role,
                      NameClaimType = ClaimTypes.Email
                  };

                  options.Events.OnAuthenticationFailed = context =>
                  {
                      context.HandleResponse();
                      context.Response.BodyWriter.WriteAsync(Encoding.ASCII.GetBytes(context.Exception.Message));
                      return Task.FromResult(0);
                  };

                  options.Events.OnTokenValidated = (ctx) =>
                  {
                      var redirectUri = new Uri(ctx.Properties.RedirectUri, UriKind.RelativeOrAbsolute);
                      if (redirectUri.IsAbsoluteUri)
                      {
                          ctx.Properties.RedirectUri = redirectUri.PathAndQuery;
                      }
                      //    
                      //Sync user and the roles to EPiServer in the background
                      ServiceLocator.Current.GetInstance<ISynchronizingUserService>().SynchronizeAsync(ctx.Principal.Identity as ClaimsIdentity);
                      return Task.FromResult(0);
                  };
              });

            return services;
        }
    }
}
