using MediatR;
using School.Core.Bases;
using School.Core.Features.Email.Commands.Models;
using School.Service.Abstract;

namespace School.Core.Features.Email.Commands.Hundllers
{
    public class EmailCommandHandller : ResponseHandler,
        IRequestHandler<SendEmailCommand, Response<string>>
    {
        #region Fields
        private readonly IEmailService _emailService;

        #endregion
        #region Constructors
        public EmailCommandHandller(IEmailService emailService)
        {
            this._emailService = emailService;
        }
        #endregion
        #region Handle Functions

        #endregion


        public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var response = await _emailService.SendEmailAsync(request.Email, request.Message, "");
            if (response == "Success")
                return Success<string>("Email send Successfully");
            else
                return BadRequest<string>("failed to send Email");
        }
    }
}