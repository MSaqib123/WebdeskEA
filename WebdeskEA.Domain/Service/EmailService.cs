using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Options;
using Proj.Models.ViewModel;
using Proj.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Proj.DataAccess.Service
{
    public class EmailService : IEmailService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly string templatePath = @"Template/EmailTemplate/";
        private readonly SMTPEmail _SmptConfig;
        public EmailService(IWebHostEnvironment hostingEnvironment, IOptions<SMTPEmail> SmptConfig)
        {
            _hostingEnvironment = hostingEnvironment;
            _SmptConfig = SmptConfig.Value;
        }

        //________ Private Methods _________
        #region Private_ Method 
        private async Task SendEmail(UserEmailVM userEmail)
        {
            try
            {
                MailMessage email = new MailMessage
                {
                    Subject = userEmail.Subject,
                    Body = userEmail.Body,
                    From = new MailAddress(_SmptConfig.SenderAddress, _SmptConfig.SenderDisplayName),
                    IsBodyHtml = _SmptConfig.IsBodyHTML
                };
                foreach (var toEmail in userEmail.ToEmail)
                {
                    email.To.Add(toEmail);
                }
                NetworkCredential networkCredential = new NetworkCredential(_SmptConfig.UserName, _SmptConfig.Password);
                SmtpClient smtpClient = new SmtpClient
                {
                    Host = _SmptConfig.Host,
                    Port = _SmptConfig.Port,
                    EnableSsl = _SmptConfig.EnableSSL,
                    UseDefaultCredentials = _SmptConfig.UseDefaultCredentials,// Do not use default credentials
                    Credentials = networkCredential
                };
                email.BodyEncoding = Encoding.Default;
                await smtpClient.SendMailAsync(email);
            }
            catch (SmtpException ex)
            {
                // Handle the SmtpException, log the details, and/or throw the exception
                Console.WriteLine($"SMTP Exception: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string GetEmailBody(string templateName)
        {
            //var body = File.ReadAllText(string.Format(templatePath, templateName));
            //return body;
            string templateFullPath = Path.Combine(
                _hostingEnvironment.WebRootPath, templatePath);
            string templateFilePath = Path.Combine(templateFullPath, templateName + ".html");

            if (File.Exists(templateFilePath))
            {
                return File.ReadAllText(templateFilePath);
            }
            else
            {
                // Handle the case where the template file does not exist
                return null; // or throw an exception, log a warning, etc.
            }
        }
        
        private string UpdatePlaceholder(string text , List<KeyValuePair<string,string>> keyValuePair)
        {
            if (!string.IsNullOrEmpty(text) && keyValuePair != null)
            {
                foreach (var placeholder in keyValuePair)
                {
                    if (text.Contains(placeholder.Key))
                    {
                        text = text.Replace(placeholder.Key,placeholder.Value);
                    }
                }
            }
            return text;
        }
        #endregion

        //________ Interface IMplementation _________
        public async Task SendTestEmail(UserEmailVM vm)
        {
            vm.Subject = "Pakistan";
            vm.Body = UpdatePlaceholder(GetEmailBody("VerifyEmail"),vm.Placeholders);

            // Check if vm.Body is not null or empty before sending the email
            if (!string.IsNullOrEmpty(vm.Body))
            {
                await SendEmail(vm);
            }
            else
            {
                // Handle the case where the email body is not available
                // You may want to log a warning or throw an exception
                // Log.Warning("Email body is null or empty");
                // OR
                // throw new InvalidOperationException("Email body is null or empty");
            }
        }

    }
}
