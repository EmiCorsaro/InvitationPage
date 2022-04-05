using InvitationPageModel.DataModels.Interfaces.Family;
using InvitationPageModel.DataModels.Interfaces.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvitationPageModel.DataModels.Models.Family
{
    public class Family : IFamily
    {
        [Key]
        public int Id { get; set; }
        public int IdPersonRefer { get; set; }
        public Guid familyHash { get; set; }
    }
}
