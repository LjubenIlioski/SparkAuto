using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SparkAuto.Email
{
    public class EmailSender : IEmailSender
    {

        public EmailOptions Options { get; set; }

        public EmailSender(IOptions<EmailOptions> emailOptions)
        {
            Options = emailOptions.Value;
        }



        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("admin@spark.com", "Spark Auto"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };

            msg.AddTo(new EmailAddress(email));

            try
            {
                return client.SendEmailAsync(msg);
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}