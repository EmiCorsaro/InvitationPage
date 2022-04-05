using InvitationPageModel;
using InvitationPageModel.DataModels;
using InvitationPageModel.DataModels.Models.User;
using InvitationPageModel.Handlers.Interfaces;
using InvitationPageModel.Handlers.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static InvitationPageModel.DataModels.MyDbContext;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddHttpContextAccessor()
    .AddAuthorization()
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// Add services to the container.
builder.Services.setDBContext();
builder.Services.AddInvitationModel();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.MapPost("/token", async (AuthenticateRequest request, UserManager<User> userManager, IUserDbHandler userDbHandler) =>
{
    // Verificamos credenciales con Identity
    var user = await userManager.FindByNameAsync(request.UserName);

    if (user is null || !await userManager.CheckPasswordAsync(user, request.Password))
    {
        return Results.Forbid();
    }

    var roles = userDbHandler.getRoles(user);

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

    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
    var tokenDescriptor = new JwtSecurityToken(
        issuer: builder.Configuration["Jwt:Issuer"],
        audience: builder.Configuration["Jwt:Audience"],
        claims: claims,
        expires: DateTime.Now.AddMinutes(60),
        signingCredentials: credentials);

    var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

    return Results.Ok(new
    {
        AccessToken = jwt
    });
});

//async Task SeedData()
//{
//    var scopeFactory = app!.Services.GetRequiredService<IServiceScopeFactory>();
//    using var scope = scopeFactory.CreateScope();

//    var context = scope.ServiceProvider.GetRequiredService<MyDbContext>();
//    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
//    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

//    context.Database.EnsureCreated();

//    if (!userManager.Users.Any())
//    {
//        logger.LogInformation("Creando usuario de prueba");

//        var newUser = new User
//        {
//            Email = "emii.corsaro@gmail.com",
//            FirstName = "Emiliano",
//            LastName = "Corsaro",
//            UserName = "ecorsaro"
//        };

//        await userManager.CreateAsync(newUser, "P@ss.W0rd");
//        await roleManager.CreateAsync(new Role
//        {
//            Name = "Admin"
//        });

//        await userManager.AddToRoleAsync(newUser, "Admin");
//    }
//}

//await SeedData();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.MapSwagger();
app.UseSwaggerUI();

app.Run();

