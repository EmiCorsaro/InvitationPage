using InvitationPageModel.Responses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvitationPageModel.Responses.Models
{
    public class ResponseError<T> : IResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T? Error { get; set; }
    }
}
