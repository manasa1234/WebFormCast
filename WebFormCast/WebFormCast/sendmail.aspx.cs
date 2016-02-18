using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Net.Mail;
using WebFormCast.ACLG;
public partial class sendmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        clsSendEmail mail = new clsSendEmail();
        mail.SendTo = TextBox1.Text;
        mail.Subject = TextBox2.Text;
        mail.Body = TextBox3.Text; 
        mail.Send();
        Response.Write("Mail has been sent :" + DateTime.Now.ToString());
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        MailMessage message = new MailMessage();

        message.From = new MailAddress("support@webformcast.com");
        message.To.Add(new MailAddress("raw00001@yahoo.com"));
        message.To.Add(new MailAddress("meet_shivaji1@yahoo.com"));
        message.To.Add(new MailAddress("meet_shivaji@yahoo.com"));
        message.To.Add(new MailAddress("meet_shivaji@hotmail.com"));

        //message.To.Add(new MailAddress("recipient3@foo.bar.com"));

        message.ReplyTo = new MailAddress("support@webformcast.com");
        //message.Headers.Add("Return-Path", "<support@webformcast.com>");
        message.Headers.Add("MIME-Version", "1.0");
        //message.Headers.Add("Content-Type", "multipart/alternative;");
        
  

        

        //message.CC.Add(new MailAddress("carboncopy@foo.bar.com"));

        message.Subject = "Welcome to ACLG Client Management System";

        message.Body = "This is the content";

        SmtpClient client = new SmtpClient();
        
        client.Send(message);

    }
}
