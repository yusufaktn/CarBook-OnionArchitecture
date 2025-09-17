using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.AuthCommand
{
    /// <summary>
    /// Command for user registration
    /// </summary>
    public class RegisterCommand : IRequest<RegisterCommandResult>
    {
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// Result for register command
    /// </summary>
    public class RegisterCommandResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public int? UserId { get; set; }
    }
}
