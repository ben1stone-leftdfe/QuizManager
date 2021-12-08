using QuizManager.Types.Account;
using System.Threading.Tasks;

namespace QuizManager.Web.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<AuthenticationResponse> Login(SignInUserDto userToSignIn);
        Task Logout();
    }
}
