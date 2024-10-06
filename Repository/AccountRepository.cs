using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MyFirstApi.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyFirstApi.Repository;

public class AccountRepository(UserManager<ApplicationUser> _userManager,SignInManager<ApplicationUser> _signInManager, IConfiguration _configuration) : IAccountRepository
{
    public async Task<IdentityResult> SignUpAsync(SignUpModel model)
    {
        var user = new ApplicationUser 
        { 
            FirstName = model.FirstName,
            LastName = model.LastName,
            UserName = model.Email, 
            Email = model.Email
        };
     return   await _userManager.CreateAsync(user,model.Password);
    }
    public async Task<string> LoginAsync(SignInModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Email,model.Password,false,false);
        if (!result.Succeeded)
        {
            return null;
        }
        var authClaims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name,model.Email),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
        };
        var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddDays(1),
            claims: authClaims,
            signingCredentials:  new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
            );
        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}
