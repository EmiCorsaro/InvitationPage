﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvitationPageModel.DataModels.Interfaces.Person
{
    public interface IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FamilyId { get; set; }
    }
}
