using BaseApi.Configuration;
using BaseApi.Controllers.Requests;
using BaseApi.Core.Service;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Service
{
    public class EmailService : BaseService, IEmailService
    {
        public EmailService(ProjectConfiguration projectConfiguration) : base(projectConfiguration)
        {
        }

        public async Task SendEmailAsync(EmailRequest emailRequest)
        {
            MimeMessage email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(configuration.EmailConfiguration.Mail);
            email.To.Add(MailboxAddress.Parse(emailRequest.ToEmail));
            email.Subject = emailRequest.Subject;
            BodyBuilder builder = new BodyBuilder();
            if (emailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in emailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = emailRequest.Body;
            email.Body = builder.ToMessageBody();
            using SmtpClient smtp = new SmtpClient();
            smtp.Connect(configuration.EmailConfiguration.Host, configuration.EmailConfiguration.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(configuration.EmailConfiguration.Mail, configuration.EmailConfiguration.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
