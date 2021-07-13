namespace SendEmail.Models
{
    public class EmailSettings
    {
        private readonly string Host = "Smtp.live.com"; // esse host é especifico para hotmail
        private readonly int Port = 587; // a porta parece padrão em todos os hosts
        private readonly string UsernameEmail = "exemple@email.com"; // email que vai enviar os emails
        private readonly string UsernamePassword = "******"; // senha do email
        public string GetHost()
        {
            return Host;
        }
        public int GetPort()
        {
            return Port;
        }
        public string GetUsernameEmail()
        {
            return UsernameEmail;
        }
        public string GetUsernamePassword()
        {
            return UsernamePassword;
        }
    }
}
