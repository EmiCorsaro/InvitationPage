using InvitationPageModel.DataModels.Interfaces.Family;
using InvitationPageModel.DataModels.Models.Family;
using InvitationPageModel.DataModels.Models.Person;
using InvitationPageModel.Handlers.Interfaces;
using InvitationPageModel.Responses.Interfaces;
using InvitationPageModel.Responses.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvitationPage_backend.Controllers
{
    [Controller]
    public class PersonController : Controller
    {
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("/Persons")]
        public ActionResult<IResponse<JsonResult>> GetPersons(IUserDbHandler userDbHandler)
        {
            var data = userDbHandler.GetUsers();
            return Ok(new ResponseData<JsonResult>() { IsSuccess = true, Data = new JsonResult(data) });
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("/Person")]
        public ActionResult<IResponse<JsonResult>> GetPersonsByName([FromQuery] Person person)
        {

            Family family = new Family();

            return Ok(new ResponseData<JsonResult>() { IsSuccess = true, Data = new JsonResult(family) });
        }
    }
}
