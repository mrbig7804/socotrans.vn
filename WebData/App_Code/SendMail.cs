using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Configuration;
using System.Net.Mail;

/// <summary>
/// Summary description for SendMail
/// </summary>
public class SendMail
{
	public SendMail()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void Send(string from, string pass, string to, string subject, string body)
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(from);
        mail.To.Add(to);
        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;

        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
        smtp.Port = 587;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new System.Net.NetworkCredential(from, pass); //Or your Smtp Email ID and Password
        smtp.EnableSsl = true;

        smtp.Send(mail);
    }
}