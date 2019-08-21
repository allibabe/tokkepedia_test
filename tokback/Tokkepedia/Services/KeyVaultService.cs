using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tokkepedia.Services
{
    public static class KeyVaultService
    {   
        static HttpClient _httpClient = new HttpClient();
        public static async Task<string> GetSecretAsync(string secretName, string secretVersion)
        {
            var vault_url = "https://tokket.vault.azure.net/";

            var client = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(GetAccessTokenAsync), _httpClient);
            var secret = await client.GetSecretAsync(vault_url, secretName, secretVersion);

            return secret.Value;
        }

        private static async Task<string> GetAccessTokenAsync(string authority, string resource, string scope)
        {
            var appCredentials = new ClientCredential("5acd3e9f-5120-4c47-9296-42119ad49717", "4_6W68uoEv5.@4%}(dC_GuB4O^bS)(^m+n9XRq=SQ90I9pp3XpG%fU&YEZdc");
            var context = new AuthenticationContext(authority, TokenCache.DefaultShared);

            var result = await context.AcquireTokenAsync(resource, appCredentials);

            return result.AccessToken;
        }

    }
}
