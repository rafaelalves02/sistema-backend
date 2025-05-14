using System.Net;
using System.Net.Mail;

namespace csharp2.common
{
    public class EmailSender
    {
        public void EnviarEmail(string assunto, string corpo, string emailDeDestino)
        {
            //dispara email
            var fromEmail = "";
            var fromPassword = "";
            var fromHost = "smtp.gmail.com";
            var fromPort = 587;

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(fromEmail);
            mail.To.Add(new MailAddress(emailDeDestino));
            mail.Subject = assunto;
            mail.Body = corpo;

            using (SmtpClient smtp = new SmtpClient(fromHost, fromPort))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(mail);
            }
        }
    }
}
