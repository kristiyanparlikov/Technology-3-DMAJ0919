using Microsoft.Owin; /* Added*/
using Microsoft.Owin.Security; /* Added*/
using Microsoft.Owin.Security.Cookies; /* Added*/
using Microsoft.Owin.Security.OpenIdConnect; /* Added*/
using Owin; /* Added*/
using System;
using System.Collections.Generic;
using System.Configuration; /* Added*/
using System.Globalization; /* Added*/
using System.Linq;
using System.Threading.Tasks; /* Added*/
using System.Web;

[assembly: OwinStartup(typeof(SingleSignOnWIthAzureAD.App_Start.Startup))]
namespace SingleSignOnWIthAzureAD.App_Start
{
    public class Startup
    {
        private static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        private static string aadInstance = ConfigurationManager.AppSettings["ida:AAdInstance"];
        private static string tenant = ConfigurationManager.AppSettings["ida:Tenant"];
        private static string postLogoutRedirectUri = ConfigurationManager.AppSettings["ida:PostLogoutRedirectUri"];

        // Get globalized string for the authority
        // Will result in values from the Web.config file: https://login.microsoftonline.com/indsætDitDomainHer.onmicrosoft.com
        string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);

        public void Configuration(IAppBuilder app)
        {
            DoAuthentication(app);
        }

        public void DoAuthentication(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = clientId,
                    Authority = authority,
                    PostLogoutRedirectUri = postLogoutRedirectUri,
                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        AuthenticationFailed = context =>
                        {
                            context.HandleResponse();
                            context.Response.Redirect("/Error/message=" + context.Exception.Message);
                            return Task.FromResult(0);
                        }
                    }
                }
                );
        }
    }
}
