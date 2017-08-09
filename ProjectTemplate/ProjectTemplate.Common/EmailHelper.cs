using System.Net;
using System.Net.Mail;
using System.Text;

namespace ProjectTemplate.Common
{
    public class EmailHelper
    {
        public SmtpClient SmtpClient;

        private string _from;

        public EmailHelper(string name, string password) : this(name, password, 25)
        {

        }

        public EmailHelper(string name, string password, int port)
        {
            SmtpClient = new SmtpClient();
            string host = name.Substring(name.IndexOf("@") + 1);
            SmtpClient.Host = $"smtp.{host}";
            SmtpClient.Credentials = new NetworkCredential(name, password);

            SmtpClient.Port = port;

            _from = name;
        }

        public EmailHelper(string name, string password, EmailType type) : this(name, password)
        {
            switch (type)
            {
                case EmailType.Gmail:
                    SmtpClient.Port = 587;
                    SmtpClient.EnableSsl = true;
                    break;
            }
        }

        public void Send(string title, string content, bool isHtml, params string[] toMails)
        {
            if (toMails == null)
            {
                return;
            }

            MailMessage myMail = new MailMessage();

            myMail.From = new MailAddress(_from);
            foreach (string mail in toMails)
            {
                myMail.To.Add(mail);
            }

            myMail.Subject = title;
            myMail.SubjectEncoding = Encoding.UTF8;

            myMail.Body = content;
            myMail.BodyEncoding = Encoding.UTF8;
            myMail.IsBodyHtml = isHtml;

            SmtpClient.Send(myMail);
        }

        public void Send(string title, string content, params string[] toMails)
        {
            Send(title, content, false, toMails);
        }
    }

    public enum EmailType
    {
        Gmail
    }
}