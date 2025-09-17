using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.AuthCommand
{
    /// <summary>
    /// Command for revoking refresh token (logout)
    /// </summary>
    public class RevokeTokenCommand : IRequest<RevokeTokenCommandResult>
    {
        public string RefreshToken { get; set; }
        public string? IpAddress { get; set; }
    }

    /// <summary>
    /// Result for revoke token command
    /// </summary>
    public class RevokeTokenCommandResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
