
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PhoneBook.Application.Configuration;
using PhoneBook.Application.Contracts;
using PhoneBook.Application.Features.UserAccount.Query.Login;
using PhoneBook.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PhoneBook.Persistence.Repositories
{
    public class UserAccountRepository : BaseRepository<SeUser>, IUserAccountRepository
    {
        private readonly UserManager<SeUser> _userManager;
        private readonly JWT _jwt;

        public UserAccountRepository(PhoneBookDbContext dbContext, UserManager<SeUser> userManager , IOptions<JWT> jwt) : base(dbContext)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
        }
        public async Task<string> CreateJwtToken(SeUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;
        }

        public async Task<LoginOutput> LoginAsync(LoginInput loginInput)
        {
            LoginOutput loginOutput = new LoginOutput();
            var user = await _userManager.FindByEmailAsync(loginInput.Email);
            if (user == null || user.Password.CompareTo(loginInput.Password) !=0 )
            {
                loginOutput.Message = "  Email or Password is not correct";
            }
            else
            {
                loginOutput.UserName = user.UserName;
                loginOutput.UserId = user.Id;
                loginOutput.Email=user.Email;
                loginOutput.Token = await CreateJwtToken(user);
            }
            return loginOutput;
        }
    }
}
