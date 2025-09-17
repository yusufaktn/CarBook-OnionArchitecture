using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.AuthCommand
{
    /// <summary>
    /// Command for refreshing access token
    /// </summary>
    public class RefreshTokenCommand : IRequest<RefreshTokenCommandResult>
    {
        public string RefreshToken { get; set; }
        public string? IpAddress { get; set; }
    }

    /// <summary>
    /// Result for refresh token command
    /// </summary>
    public class RefreshTokenCommandResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
