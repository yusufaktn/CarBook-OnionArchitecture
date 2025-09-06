using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.AboutCommand
{
    public class DeleteAboutCommand:IRequest
    {
        public int AboutId { get; set; }

        public DeleteAboutCommand(int aboutId)
        {
            AboutId = aboutId;
        }
    }
}
