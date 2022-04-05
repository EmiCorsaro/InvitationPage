using InvitationPageModel.DataModels.Interfaces.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvitationPageModel.DataModels.Models.Person
{
    public class Person : IPerson
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FamilyId { get; set; }

        public Person(string firstName, string lastName)
        {
            Random rnd = new Random();
            Id = rnd.Next(1, 10);
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
