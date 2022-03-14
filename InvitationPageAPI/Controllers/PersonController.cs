using InvitationPageModel.DataModels.Person;
using InvitationPageModel.Responses.Interfaces;
using InvitationPageModel.Responses.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvitationPage_backend.Controllers
{
    [Controller]
    public class PersonController : Controller
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("/Persons")]
        public ActionResult<IResponse<Person>> GetPersons()
        {
            return Ok(new ResponseData<Person>() { IsSuccess = true, Data = new Person() { FirstName="Tini", LastName="Hernandez", FamilyId=1 } });
        }
    }
}
