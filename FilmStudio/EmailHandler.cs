using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASendMail; //add EASendMail namespace, requires install
// for help, see https://www.emailarchitect.net/easendmail/ex/c/6.aspx

namespace FilmStudio
{
    class EmailHandler
    {
        SmtpMail mail;
        SmtpClient client;
        SmtpServer server;

        public string Passkey { get; set; }
        public string User { get; set; }

        public EmailHandler()
        {
            mail = new SmtpMail("TryIt");
            client = new SmtpClient();
            server = new SmtpServer("smtp.office365.com");

            server.User = "";
            server.Password = "";
            server.Port = 587;
            server.ConnectType = SmtpConnectType.ConnectSSLAuto;

            mail.From = "ms01036@st.habib.edu.pk";
            mail.To = "kr03917@st.habib.edu.pk";
            mail.Subject = "Ignore this email";
            mail.TextBody = "Testing 1 2 3";
        }

        public EmailHandler(string user, string pass, string sender, string recipient, string subject, string body)
        {
            mail = new SmtpMail("Email");
            client = new SmtpClient();
            server = new SmtpServer("smtp.office365.com");

            server.User = user;
            server.Password = pass;
            Passkey = pass;
            User = user;
            server.Port = 587;
            server.ConnectType = SmtpConnectType.ConnectSSLAuto;

            mail.From = sender;
            mail.To = recipient;
            mail.Subject = subject;
            mail.TextBody = body;
        }

        public bool Send()
        {
            server.Password = Passkey;
            server.User = User;
            try
            {
                client.SendMail(server, mail);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Send(string recipient, string subject, string body)
        {
            mail.To = recipient;
            mail.Subject = subject;
            mail.TextBody = body;
            server.Password = Passkey;
            server.User = User;

            try
            {
                client.SendMail(server, mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
