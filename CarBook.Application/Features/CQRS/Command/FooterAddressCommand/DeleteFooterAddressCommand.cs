using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.FooterAddressCommand
{
    public class DeleteFooterAddressCommand : IRequest
    {
        public int FooterAddressId { get; set; }

        public DeleteFooterAddressCommand(int footerAddressId)
        {
            FooterAddressId = footerAddressId;
        }
    }
}