using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.BannerCommand
{
    public class DeleteBannerCommand:IRequest
    {
        public int BannerId { get; set; }

        public DeleteBannerCommand(int bannerId)
        {
            BannerId = bannerId;
        }
    }
}