using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using SendEmail.Models;

namespace SendEmail.Services
{
    public class EmailSender
    {
        private readonly EmailSettings emailSettings = new EmailSettings();

        public Task SendEmailAsync(string mail, string subject, string message)
        {
            Execute(mail, subject, message).Wait();
            return Task.FromResult(0);
        }

        public async Task Execute(string emailDestinatario, string assunto, string mensagem)
        {
            // As instâncias da classe MailMessage são usadas para construir 
            // mensagens de e-mail que são transmitidas para um servidor SMTP 
            // para entrega usando a classe SmtpClient
            MailMessage mail = new MailMessage()
            {
                // esse segundo parâmetro é o que vai aparecer como 'Nome' da pessoa que está enviando o email
                // ele é diferente do título do email
                From = new MailAddress(emailSettings.GetUsernameEmail(), "Desenvolvimento de sistemas")
            };

            // Representa o endereço do destinatário de email
            mail.To.Add(new MailAddress(emailDestinatario));

            // envia uma cópia do email para outra pessoa
            mail.CC.Add(new MailAddress("exemple@email.com"));

            // título do email
            mail.Subject = "Diogo Desenvolvedor - " + assunto;

            // mensagem de email
            mail.Body = mensagem;

            // outras configurações
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            string[] arquivos = Directory.GetFiles("./");
            // envia arquivos no corpo do email, basta informar o caminho do arquivo, nesse caso: './messageTest.txt'
            mail.Attachments.Add(new Attachment(arquivos.First()));

            // usa o endereço do host (Smtp.live.com) e a porta 587
            using (SmtpClient smtp = new SmtpClient(emailSettings.GetHost(), emailSettings.GetPort()))
            {
                // usa o email e a senha do usuário para enviar email  
                smtp.Credentials = new NetworkCredential(emailSettings.GetUsernameEmail(), emailSettings.GetUsernamePassword());
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}
