using QuizManager.Types.Account;
using System.Threading.Tasks;

namespace QuizManager.Web.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<string> Login(SignInUserDto userToSignIn);
    }
}
