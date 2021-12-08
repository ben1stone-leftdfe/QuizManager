using Microsoft.AspNetCore.Components;
using QuizManager.Types.Account;
using QuizManager.Web.Interfaces;
using QuizManager.Web.Models.Account;
using System.Threading.Tasks;

namespace QuizManager.Web.Pages
{
    public partial class Login
    {
        private UserSignInModel UserSignInModel = new UserSignInModel();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        public async Task ExecuteLogin()
        {
            var signInDto = new SignInUserDto
            {
                EmailAddress = UserSignInModel.EmailAddress,
                Password = UserSignInModel.Password
            };

            var response = await AuthenticationService.Login(signInDto);

            if (response != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
