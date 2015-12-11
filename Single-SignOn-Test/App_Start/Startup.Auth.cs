using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using System.Configuration;
using Single_SignOn_Test.Models;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using System.Configuration;
using System.Globalization;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;
using Single_SignOn_Test.Utility;
using System.Web;

namespace Single_SignOn_Test
{
    public partial class Startup
    {
        private static string clientId = ConfigurationManager.AppSettings["ClientId"];
        private static string appKey = ConfigurationManager.AppSettings["AppKey"];
        private static string aadInstance = ConfigurationManager.AppSettings["AADInstance"];
        private static string tenant = ConfigurationManager.AppSettings["Tenant"];
        private static string postLogoutRedirectUri = ConfigurationManager.AppSettings["PostLogoutRedirectUri"];
     
        public static readonly string Authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);

        // This is the resource ID of the AAD Graph API.  We'll need this to request a token to call the Graph API.
       
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {   

            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseOpenIdConnectAuthentication(  
                new OpenIdConnectAuthenticationOptions
                {
                   ClientId = ConfigurationManager.AppSettings["ClientId"],
                   Authority = string.Format(ConfigurationManager.AppSettings["AADInstance"],ConfigurationManager.AppSettings["Tenant"]),
                   PostLogoutRedirectUri = ConfigurationManager.AppSettings["PostLogoutRedirectUri"],
                  
                });

          
        }
    }
}