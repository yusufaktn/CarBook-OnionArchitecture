using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.FeatureCommand
{
    public class DeleteFeatureCommand : IRequest
    {
        public int FeatureId { get; set; }

        public DeleteFeatureCommand(int featureId)
        {
            FeatureId = featureId;
        }
    }
}