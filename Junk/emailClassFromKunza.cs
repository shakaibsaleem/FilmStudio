using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASendMail; //add EASendMail namespace

namespace test
{
    class EmailHandler
    {
        SmtpMail mail;
        SmtpClient client;
        SmtpServer server;

        public EmailHandler()
        {
            mail = new SmtpMail("whatsthis");
            client = new SmtpClient();
            server = new SmtpServer("smtp.office365.com");
        }

        public void send_email()
        {
            SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();

            // Your email address
            oMail.From = "xx01234@st.habib.edu.pk";

            // Set recipient email address
            oMail.To = "xx01234@st.habib.edu.pk";

            // Set email subject
            oMail.Subject = "test email";

            // Set email body
            oMail.TextBody = "I HOPE YOU GET";

            // If your account is office 365, please change to Office 365 SMTP server
            SmtpServer oServer = new SmtpServer("smtp.office365.com");

            // User authentication should use your
            // email address as the user name.
            oServer.User = "xx01234@st.habib.edu.pk";
            oServer.Password = "";

            // use 587 TLS port
            oServer.Port = 587;

            // detect SSL/TLS connection automatically
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

            oSmtp.SendMail(oServer, oMail);
        }
    }
}
