using MimeKit;
using School.Data.Helpers;
using School.Service.Abstract;
using Serilog;

namespace School.Service.Implemintation
{
    public class EmailService : IEmailService
    {

        #region Fields
        private readonly SmtpSettings _smtpSettings;
        #endregion
        #region Constructors
        public EmailService(SmtpSettings smtpSettings)
        {
            this._smtpSettings = smtpSettings;
        }
        #endregion
        #region Handle Functions 
        public async Task<string> SendEmailAsync(string toEmail, string message, string subject)
        {
            try
            {

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync(_smtpSettings.Host, _smtpSettings.Port, _smtpSettings.EnableSsl);
                    client.Authenticate(_smtpSettings.Username, _smtpSettings.Password);

                    var SMS = new MimeMessage();
                    SMS.Body = new TextPart("html")
                    {
                        Text = message
                    };
                    SMS.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
                    SMS.To.Add(MailboxAddress.Parse(toEmail));
                    SMS.Subject = subject;
                    await client.SendAsync(SMS);
                    await client.DisconnectAsync(true);
                }
                return "Success";
            }
            catch (Exception ex)
            {
                Log.Error($"Error In SendEmailAsync: {ex.Message}");
                return "Failed";
            }
        }
        #endregion

    }
}
