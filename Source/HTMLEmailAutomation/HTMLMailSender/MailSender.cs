using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace HTMLEmailAutomation.HTMLMailSender
{
    internal class MailSender : IMailSender
    {
        void IMailSender.Send(string mailer, string mailerPassword, string exchange, Dictionary<string, string> reciepent, string mail,string mailSubject)
        {
            ExchangeService service = new ExchangeService();
            //service.Url("shekhark@orioninc.com");

            try
            {
                SmtpClient sMail = new SmtpClient(exchange);
                sMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                sMail.Credentials = new NetworkCredential(mailer, mailerPassword);

                MailMessage message = new MailMessage();
                message.From = new MailAddress(mailer);
                message.Body=mail;
                message.Subject = mailSubject;
                foreach (var item in reciepent)
                {
                    string X = item.Value;
                    switch (X)
                    {
                        case "Bcc":
                            message.Bcc.Add(item.Key);
                            continue;
                        case "Cc":
                            message.CC.Add(item.Key);
                            continue;
                        case "To":
                            message.To.Add(item.Key);
                            continue;
                        default:
                            continue;
                    }                    
                }



                message.IsBodyHtml = true;

                sMail.EnableSsl = true;
                sMail.Send(message);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
