using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using QuizManager.Types.Account;
using QuizManager.Web.Interfaces;
using QuizManager.Web.Provider;
using System.Threading.Tasks;

namespace QuizManager.Web.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpService _httpService;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationService(HttpService httpService, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            _httpService = httpService;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }

        public async Task<string> Login(SignInUserDto userToSignIn)
        {
            var authResponse = await _httpService.HttpPostAsync<string>("account/signin", userToSignIn);

            if (authResponse != null)
            {
                await _localStorage.SetItemAsync("authToken", authResponse);

                ((AppAuthenticationStateProvider)_authStateProvider).NotifyUserAuthentication(userToSignIn.EmailAddress);
            }

            return authResponse;
        }
    }
}
