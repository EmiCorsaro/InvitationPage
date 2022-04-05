using InvitationPageModel.DataModels;
using InvitationPageModel.DataModels.Interfaces.Person;
using InvitationPageModel.DataModels.Models.User;
using InvitationPageModel.Handlers.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvitationPageModel.Handlers.Services
{
    public class UserDbHandler : IUserDbHandler
    {
        MyDbContext DbContext;
        UserManager<User> UserManager;
        public UserDbHandler(MyDbContext dbContext, UserManager<User> userManager)
        {
            DbContext = dbContext;
            UserManager = userManager;
        }

        public List<Role> getRoles(User user)
        {
            return DbContext.Roles.Where(p => p.Id == user.RoleId.ToString()).ToList();
        }

        public List<User> GetUsers()
        {
            return DbContext.Users.ToList();
        }

        public List<User> GetUsersWithFilter(User user)
        {
            if(String.IsNullOrEmpty(user.UserName) && String.IsNullOrEmpty(user.FirstName) ||
                String.IsNullOrEmpty(user.LastName) &&
                String.IsNullOrEmpty(user.Email))
            {
                return new List<User>();
            }
            return DbContext.Users.Where(u => u.UserName == user.UserName ||
                                              u.FirstName == user.FirstName ||
                                              u.LastName == user.LastName ||
                                              u.Email == user.Email).ToList();    
        }

        public async Task<bool> SaveNewUser(User user)
        {
            IdentityResult response = await UserManager.CreateAsync(user).ConfigureAwait(false);
            return response.Succeeded;
        }
    }
}
