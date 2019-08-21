using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Tokkepedia.Tools.Helpers;

namespace Tokkepedia.Tools.Extensions
{
    public static class ClaimExtensions
    {
        /// <summary>
        ///     Removes the existing Claims and add the new claim.
        /// </summary>
        public static void AddClaim(this IPrincipal currentPrincipal, string key, string value)
        {
            if (currentPrincipal.Identity is ClaimsIdentity identity)
            {
                var claim = identity.Claims.FirstOrDefault(c => c.Type == key);

                // Remove claim if exists
                if (claim != null) identity.RemoveClaim(claim);

                // Add new claim
                identity.AddClaim(new Claim(key, value));
            }
        }

        /// <summary>
        ///     Get Claim Value by the Current Principal and key provided
        /// </summary>
        /// <param name="currentPrincipal">Current User</param>
        /// <param name="key">Key Provided</param>
        /// <returns>returns the value of specific claim</returns>
        public static string GetClaimValue(this IPrincipal currentPrincipal, string key)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
                return string.Empty;

            var claim = identity.Claims.FirstOrDefault(c => c.Type == key);
            return claim?.Value;
        }

        /// <summary>
        ///     Get the token of the user from the principal/cookie
        /// </summary>
        /// <param name="currentPrincipal">User Principal/Identity</param>
        /// <returns>returns encrypted token</returns>
        public static string GetToken(this IPrincipal currentPrincipal) => (string)GetUserData(currentPrincipal, CookieFilter.Token);

        /// <summary>
        ///     Get the GetStream.io token of the user from the principal/cookie (mainly used for reactions)
        /// </summary>
        /// <param name="currentPrincipal">User Principal/Identity</param>
        /// <returns>returns encrypted token</returns>
        public static string GetStreamToken(this IPrincipal currentPrincipal) => (string)GetUserData(currentPrincipal, CookieFilter.StreamToken);

        /// <summary>
        ///     Get the id of the user in string format from the principal/cookie
        /// </summary>
        /// <param name="currentPrincipal">User Principal/Identity</param>
        /// <returns>returns string UserId</returns>
        public static string GetUserId(this IPrincipal currentPrincipal) => (string)GetUserData(currentPrincipal, CookieFilter.Id);

        /// <summary>
        ///     Get the value of the object with the specific filter
        /// </summary>
        /// <param name="currentPrincipal">User Principal/Identity</param>
        /// <param name="userFilter">User Filter</param>
        /// <returns>returns an object value</returns>
        private static object GetUserData(IPrincipal currentPrincipal, CookieFilter filter)
        {
            switch (filter)
            {
                case CookieFilter.Id:
                    return currentPrincipal.GetClaimValue(ClaimTypes.Name);
                case CookieFilter.Token:
                    return currentPrincipal.GetClaimValue("IdToken");
                case CookieFilter.StreamToken:
                    return currentPrincipal.GetClaimValue("StreamToken");
            }

            return null;
        }
    }
}
