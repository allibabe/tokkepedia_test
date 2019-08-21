using Firebase.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Tokkepedia.Models;
using Tokkepedia.Services;

namespace Tokkepedia
{
    public class FirebaseUserStore<T> : IUserStore<T>,
                                        IUserPasswordStore<T>
                                        where T : TokketUser
    {
        string result = "";
        public async Task<IdentityResult> CreateAsync(T user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            TokkepediaApiClient apiClient = new TokkepediaApiClient();
            //Firebase Create
            try
            {
                FirebaseAuthLink link = await apiClient.SignUpAsync(user.Email, user.PasswordHash, user.DisplayName, user.Country, user.Birthday, user.UserPhoto);
                user.Id = link.User.LocalId;
                user.IdToken = link.FirebaseToken;
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                string toBeSearched = "Reason: ";
                int ix = err.IndexOf(toBeSearched);

                if (ix != -1)
                {
                    string code = err.Substring(ix + toBeSearched.Length);
                    err = code;
                    result = code;
                }
            }
            
            if (result == "EmailExists")
                result = "";

            return result == ""
                ? IdentityResult.Success
                : IdentityResult.Failed(new IdentityError() { Code = result });
        }

        public async Task<IdentityResult> DeleteAsync(T user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            try
            {
                TokkepediaApiClient apiClient = new TokkepediaApiClient();
                apiClient.User = (TokketUser)(dynamic)user;
                await apiClient.DeleteUserAsync(user.Id);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                string toBeSearched = "Reason: ";
                int ix = err.IndexOf(toBeSearched);

                if (ix != -1)
                {
                    string code = err.Substring(ix + toBeSearched.Length);
                    // do something here
                    err = code;
                    result = code;
                }
            }

            return result == ""
                ? IdentityResult.Success
                : IdentityResult.Failed(new IdentityError() { Code = result });
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public async Task<T> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            T foundUser = null;
            try
            {
                TokkepediaApiClient apiClient = new TokkepediaApiClient();
                var item = await apiClient.GetUserAsync(userId);
                foundUser = (T)(dynamic)item;
            }
            catch
            {

            }

            return foundUser;
        }

        public async Task<T> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (normalizedUserName == null)
            {
                throw new ArgumentNullException(nameof(normalizedUserName));
            }
            T foundUser = null;
            try
            {
                TokkepediaApiClient apiClient = new TokkepediaApiClient();
                foundUser = (T)(dynamic)await apiClient.GetUserAsync(normalizedUserName);
            }
            catch
            {

            }

            return null;

            //return (T)(dynamic)(new FirebaseIdentityUser());
        }

        public Task<string> GetNormalizedUserNameAsync(T user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetPasswordHashAsync(T user, CancellationToken cancellationToken)
        {
            //Passwords will not be retrieved inside the app
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return Task.FromResult("");
        }

        public Task<string> GetUserIdAsync(T user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return Task.FromResult(user.Id);
        }

        public Task<string> GetUserNameAsync(T user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return Task.FromResult(user.UserName);
        }

        public Task<bool> HasPasswordAsync(T user, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        public Task SetNormalizedUserNameAsync(T user, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (normalizedName == null)
            {
                throw new ArgumentNullException(nameof(normalizedName));
            }

            user.NormalizedUserName = normalizedName;

            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(T user, string passwordHash, CancellationToken cancellationToken)
        {
            //Passwords will not be set here, use a different location
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (passwordHash == null)
            {
                throw new ArgumentNullException(nameof(passwordHash));
            }
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(T user, string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (userName == null)
            {
                throw new ArgumentNullException(nameof(userName));
            }

            user.UserName = userName;

            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(T user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            TokkepediaApiClient apiClient = new TokkepediaApiClient();
            apiClient.User = user;
            try
            {
                await apiClient.UpdateUserAsync(user);
            }
            catch (Exception e)
            {
                return IdentityResult.Failed();
            }

            return IdentityResult.Success;
        }
    }
}
