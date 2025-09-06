using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.SocialMediaCommand
{
    public class DeleteSocialMediaCommand : IRequest
    {
        public int SocialMediaId { get; set; }

        public DeleteSocialMediaCommand(int socialMediaId)
        {
            SocialMediaId = socialMediaId;
        }
    }
}