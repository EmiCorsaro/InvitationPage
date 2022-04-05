using InvitationPageModel.DataModels;
using InvitationPageModel.DataModels.Models.User;
using InvitationPageModel.Handlers.Interfaces;
using InvitationPageModel.Handlers.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace InvitationPageModel
{
	public static class ModelConfiguration
	{
		public static void AddInvitationModel(this IServiceCollection services)
		{
			services.AddScoped<IUserDbHandler, UserDbHandler>();
		}

		public static void setDBContext(this IServiceCollection services)
        {
			services.AddDbContext<MyDbContext>()
					.AddIdentityCore<User>()
					.AddEntityFrameworkStores<MyDbContext>(); ;
		}
	}
}
