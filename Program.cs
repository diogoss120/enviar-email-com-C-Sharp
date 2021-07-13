using SendEmail.Services;
using System;
using System.Threading.Tasks;

namespace SendEmail
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            EmailSender email = new EmailSender();
            string destinatario = "exemple@email.com";
            string titulo = "título do email";
            string corpo = "corpo do email";
            try
            {
                Console.WriteLine("Enviando email...");
                await email.SendEmailAsync(destinatario, titulo, corpo);
                Console.WriteLine("Email enviado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }
    }
}
