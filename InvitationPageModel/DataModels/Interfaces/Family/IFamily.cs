using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvitationPageModel.DataModels.Interfaces.Family
{
    public interface IFamily
    {
        public int Id { get; set; }
        public int IdPersonRefer { get; set; }
        public Guid familyHash { get; set; }
    }
}
