#region

using System;
using System.Threading.Tasks;
using System.Web.WebPages;
using Microsoft.Azure.ActiveDirectory.GraphClient;

#endregion

namespace Single_SignOn_Test.Utility
{
    internal class AuthenticationHelper
    {
        public static string token;

        /// <summary>
        ///     Async task to acquire token for Application.
        /// </summary>
        /// <returns>Async Token for application.</returns>
        public static async Task<string> AcquireTokenAsync()
        {
            if (token == null || token.IsEmpty())
            {
                throw new Exception("Authorization Required.");
            }
            return token;
        }

        /// <summary>
        ///     Get Active Directory Client for Application.
        /// </summary>
        /// <returns>ActiveDirectoryClient for Application.</returns>
        public static ActiveDirectoryClient GetActiveDirectoryClient()
        {
            Uri baseServiceUri = new Uri(Const.ResourceUrl);
            ActiveDirectoryClient activeDirectoryClient =
                new ActiveDirectoryClient(new Uri(baseServiceUri, Const.TenantId),
                    async () => await AcquireTokenAsync());
            return activeDirectoryClient;
        }
  
    }
}