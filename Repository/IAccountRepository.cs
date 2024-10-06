using Microsoft.AspNetCore.Identity;
using MyFirstApi.Model;

namespace MyFirstApi.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel model);
        Task<string> LoginAsync(SignInModel model);
    }
}