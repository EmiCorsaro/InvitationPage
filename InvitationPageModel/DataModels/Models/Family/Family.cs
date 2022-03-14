using InvitationPageModel.DataModels.Interfaces.Family;
using InvitationPageModel.DataModels.Interfaces.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvitationPageModel.DataModels.Models.Family
{
    public class Family : IFamily
    {
        public int Id { get; set; }
        public int IdPersonRefer { get; set; }
        public Guid familyHash { get; set; }
        public List<IPerson> persons { get; set; }
        public Family(IPerson person)
        {
            Random rnd = new Random();
            persons = new List<IPerson>();
            Id = rnd.Next(1, 10);
            IdPersonRefer = person.Id;
            familyHash = Guid.NewGuid();
            person.FamilyId = Id;
            persons.Add(person);
   
        }

        public void AddMember(IPerson person)
        {
            persons.Add(person);
            person.FamilyId = this.Id;
        }
    }
}
