using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvitationPageModel.DataModels.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace InvitationPageModel.DataModels
{
    public class MyDbContext : IdentityDbContext<User>
    {
        public record AuthenticateRequest(string UserName, string Password);
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }
    }
}
