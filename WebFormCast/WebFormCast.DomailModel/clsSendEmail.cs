using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System;
using System.Configuration;
namespace WebFormCast.ACLG
{
    public class clsSendEmail
    {
        public string SMTP_Server;
        public string UserName;
        public string Password;
        public string FromName;
        public string SendTo;
        public string Subject;
        public string Body;
        public string ErrMessage;
        public string ReplyTo;
        public string BCc;
        MailMessage emailMsg;
        SmtpClient smtpClient;
        

        public clsSendEmail()
        {
            SMTP_Server =   System.Configuration.ConfigurationSettings.AppSettings.Get("SMTPServer");
            UserName = "";
            Password = "";
            FromName = System.Configuration.ConfigurationSettings.AppSettings.Get("FromEmail");
            //SendTo = System.Configuration.ConfigurationManager.AppSettings.Get("ErrorReportingEmail");
            Subject = "";
            Body = "";
            ErrMessage = "";
            ReplyTo = FromName;
        }

        public bool Send()
        {
            try
            {
                smtpClient = DoInitSMTP();
                smtpClient.Send(emailMsg);
                
                return true;
            }
            catch (Exception ex)
            {
                throw new System.Exception("Unable to send the email. " + ex.Message);
            }
        }

        private SmtpClient DoInitSMTP()
        {
            string smtpServer = System.Configuration.ConfigurationSettings.AppSettings.Get("SMTPServer");

            char[] delimeter ={ ',' };
            string[] ToEmailIDs = null;
            
            ErrMessage = "";
            //string smtpServer = System.Configuration.ConfigurationManager.AppSettings.Get("SMTPServer");
            //emailMsg = new MailMessage(FromName, SendTo, Subject, Body);
            MailMessage msg = GetMessage();
            
            emailMsg = msg;
            
            //if (SendTo != null)
            //{
            //    ToEmailIDs = SendTo.Split(delimeter);
            //    for (int count = 0; count < ToEmailIDs.Length; count++)
            //    {
            //        if (ToEmailIDs[count].Trim() != "")
            //            emailMsg.To.Add(ToEmailIDs[count].Trim());
            //    }
            //}

            //emailMsg.ReplyTo = new System.Net.Mail.MailAddress(ReplyTo, null);
            //emailMsg.IsBodyHtml = true;

            if (smtpServer == "")
            {
                smtpServer = System.Configuration.ConfigurationSettings.AppSettings.Get("SMTPServer");//"127.0.0.1";
            }
            return new SmtpClient(smtpServer);
        }

        protected virtual MailMessage GetMessage()
        {
            MailMessage msg = new MailMessage();
            msg.Body = Body;
            msg.Subject = Subject;
            msg.IsBodyHtml = true;
            FromName = System.Configuration.ConfigurationSettings.AppSettings.Get("FromEmail");
            msg.From = new MailAddress(FromName, "");

            if (!string.IsNullOrEmpty(ReplyTo))
                msg.ReplyTo = new MailAddress(ReplyTo);

            // *** Send all the different recipients
            this.SendRecipients(msg.To, SendTo);
            this.SendRecipients(msg.Bcc , BCc);

            return msg;

        }

        public void SendRecipients(MailAddressCollection address, string recipients)
        {
            if (recipients == null || recipients.Length == 0)
                return;

            string[] recips = recipients.Split(',', ';');

            for (int x = 0; x < recips.Length; x++)
            {
                address.Add(new MailAddress(recips[x]));
            }
        }
    }
}
