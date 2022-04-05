using InvitationPageModel.DataModels.Models.User;
using InvitationPageModel.Handlers.Interfaces;
using InvitationPageModel.Responses.Interfaces;
using InvitationPageModel.Responses.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Validation;

namespace InvitationPage.Controllers.UserController
{
    [Controller]
    public class UserController : Controller
    {
        IUserDbHandler UserDbHandler { get; set; }

        public UserController(IUserDbHandler userDbHandler)
        {
            UserDbHandler = userDbHandler;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("/Users")]
        public ActionResult<IResponse<JsonResult>> GetUsers()
        {
            var data = UserDbHandler.GetUsers();
            return Ok(new ResponseData<JsonResult>() { IsSuccess = true, Data = new JsonResult(data) });
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("/User")]
        public ActionResult<IResponse<JsonResult>> GetPersonsByName([FromQuery] User user)
        {
            var data = UserDbHandler.GetUsersWithFilter(user);
            return Ok(new ResponseData<JsonResult>() { IsSuccess = true, Data = new JsonResult(data) });
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("/User")]
        public ActionResult<IResponse<JsonResult>> AddUser([ValidatedNotNull][FromQuery] User user)
        {
            var data = UserDbHandler.GetUsersWithFilter(user);
            return Ok(new ResponseData<JsonResult>() { IsSuccess = true, Data = new JsonResult(data) });
        }
    }
}
