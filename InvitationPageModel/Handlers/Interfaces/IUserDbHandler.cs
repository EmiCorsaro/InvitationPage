using InvitationPageModel.DataModels.Interfaces.Person;
using InvitationPageModel.DataModels.Models.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvitationPageModel.Handlers.Interfaces
{
    public interface IUserDbHandler
    {
        List<User> GetUsers();
        List<User> GetUsersWithFilter(User user);
        List<Role> getRoles(User user);
        Task<bool> SaveNewUser(User user);
    }
}
