using System.Net;
using System.Net.Mail;

namespace WinLogin_Tracker
{
    public class Gmail
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Gmail(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public void Send(MailMessage msg)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(Username, Password)
            };
            client.Send(msg);
        }
    }
}