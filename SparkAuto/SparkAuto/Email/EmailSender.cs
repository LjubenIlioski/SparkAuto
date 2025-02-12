﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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



        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "test@gmail.com",  // replace with valid value
                    Password = "AS"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                var message = new MailMessage();
                message.To.Add(email);
                message.Subject = subject;
                message.Body = htmlMessage;
                message.IsBodyHtml = true;
                message.From = new MailAddress("test@gmail.com");
                await smtp.SendMailAsync(message);
            }




            //SendGrid Logic not working

            //var apiKey = "SG";
            //var client = new SendGridClient(apiKey);
            //var from = new EmailAddress("hotmail.com", "Ljuben");
            //var sub = subject;
            //var to = new EmailAddress(email, "Example User");
            //var plainTextContent = htmlMessage;
            //var htmlContent = htmlMessage;
            //var msg = MailHelper.CreateSingleEmail(from, to, sub, plainTextContent, htmlContent);
            //var response = await client.SendEmailAsync(msg);



            //SendGrid Logic not working

            //var apiKey = "SG";
            //var client = new SendGridClient(apiKey);
            //    var msg = new SendGridMessage()
            //    {
            //        From = new EmailAddress("@hotmail.com", "Ljuben"),
            //        Subject = subject,
            //        PlainTextContent = htmlMessage,
            //        HtmlContent = htmlMessage,

            //    };

            //    msg.AddTo(new EmailAddress(email));

            //    try
            //    {
            //        return client.SendEmailAsync(msg);
            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //    return null;
        }
    }
}
