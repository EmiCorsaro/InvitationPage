using InvitationPageModel.DataModels.Models.User;
using InvitationPageModel.Handlers.Interfaces;
using InvitationPageModel.Responses.Interfaces;
using InvitationPageModel.Responses.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static InvitationPageModel.DataModels.MyDbContext;

namespace InvitationPage.Controllers.Auth
{
    public class AuthController : Controller
    {
        private IConfiguration ConfigManager { get; set; }
        private IUserDbHandler UserDbHandler { get; set; }
        private UserManager<User> UserManager { get; set; }

        public AuthController(UserManager<User> userManager, IUserDbHandler userDbHandler, IConfiguration configManager)
        {
            UserDbHandler = userDbHandler;
            UserManager = userManager;
            ConfigManager = configManager;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("Auth/Token")]
        public async Task<IResult> GetUsers([FromBody]AuthenticateRequest request)
        {
            var user = await UserManager.FindByNameAsync(request.UserName);

            if (user is null || !await UserManager.CheckPasswordAsync(user, request.Password))
            {
                return Results.Forbid();
            }

            var roles = UserDbHandler.getRoles(user);

            // Generamos un token según los claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}")
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigManager.GetValue<String>("Jwt:Key")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: ConfigManager.GetValue<String>("Jwt:Issuer"),
                audience: ConfigManager.GetValue<String>("Jwt:Audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return Results.Ok(new
            {
                AccessToken = jwt
            });
        }
    }
}
