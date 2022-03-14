using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvitationPageModel.Responses.Interfaces
{
    public interface IResponse<T>
    {
        public bool IsSuccess { get; set; }
    }
}
