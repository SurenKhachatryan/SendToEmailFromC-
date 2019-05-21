using MailKit.Net.Smtp;
using MimeKit;

namespace SendToEmailFromCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var smtp = "smtp.mail.ru";
            var port = 587;

            var from = "oleg.tabakov@mail.ru";     //отправитель
            var fromName = "Олег Табаков";         //отправитель

            var to = "evgeniy.onegin@gmail.com";   //получатель
            var toName = "Евгений Онегин";         //получатель

            var subject = "Тема";
            var body = "ваше сообщение.........";

            var userName = "oleg.tabakov@mail.ru"; //логин от Email-а отправителя
            var password = "oleg1234";             //и пороль
            
            
            var mail = new MimeMessage();
            mail.From.Add(new MailboxAddress(fromName, from));
            mail.To.Add(new MailboxAddress(toName, to));
            mail.Subject = subject;
            mail.Body = new TextPart() { Text = body };

            using (var client = new SmtpClient())
            {
                client.Connect(smtp, port);
                client.Authenticate(userName, password);
                client.Send(mail);
                client.Disconnect(true);
            }
        }
    }
}
