using InvitationPageModel.DataModels.Interfaces.Family;
using InvitationPageModel.DataModels.Models.Family;
using InvitationPageModel.DataModels.Person;
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
        public ActionResult<IResponse<JsonResult>> GetPersons()
        {
            
            List<Person> persons = new List<Person>();
            Person personRefered = new Person() { FirstName = "Tini", LastName = "Hernandez"};
            Family family = new Family(personRefered);
            family.AddMember(new Person() { FirstName = "Lucas", LastName = "Hernandez" });
            family.AddMember(new Person() { FirstName = "Gustavo", LastName = "Hernandez" });


            return Ok(new ResponseData<JsonResult>() { IsSuccess = true, Data = new JsonResult(family) });
        }
    }
}
