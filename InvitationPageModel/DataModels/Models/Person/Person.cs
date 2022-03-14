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
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FamilyId { get; set; }

        public Person()
        {
            Random rnd = new Random();
            Id = rnd.Next(1, 10);
            FirstName = "Unknown FirstName";
            LastName = "Unknown LastName";
            FamilyId = rnd.Next(1, 10);
        }

        public Person(string firstName, string lastName)
        {
            Random rnd = new Random();
            Id = rnd.Next(1, 10);
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
