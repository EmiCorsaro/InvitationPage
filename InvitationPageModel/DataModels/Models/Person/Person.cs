using InvitationPageModel.DataModels.Interfaces.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvitationPageModel.DataModels.Person
{
    public class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FamilyId { get; set; }

        public Person()
        {
            FirstName = "UnknownFirtsName";
            LastName = "UnknownLastName";
            FamilyId = -1;
        }

        public Person(string firstName, string lastName, int familyId)
        {
            FirstName = firstName;
            LastName = lastName;
            FamilyId = familyId;
        }
    }
}
