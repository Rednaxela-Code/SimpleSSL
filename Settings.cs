namespace SimpleSSL
{
    public class Settings
    {
        private Uri _baseURL;
        private string _certificatePath;
        private string _password;

        public Uri BaseURL { get => _baseURL; set => _baseURL = value; }
        public string CertificatePath { get => _certificatePath; set => _certificatePath = value; }
        public string Password { get => _password; set => _password = value; } //

        public Settings SettingMaker()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("Type CertificatePath:");
                _certificatePath = Console.ReadLine();
                Console.WriteLine($"CertificatePath is {CertificatePath}");

                Console.WriteLine("Type Password:");
                _password = Console.ReadLine();
                Console.WriteLine($"Password is {Password}");

                done = true;
            }
            return this;
        }

        public Settings SettingEditor()
        {
            Console.WriteLine("What you wanna edit?");
            Console.WriteLine("CertificatePath (1), Password (2)");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Type new CertificatePath:");
                    _certificatePath = Console.ReadLine();
                    Console.WriteLine($"CertificatePath is changed to {CertificatePath}");
                    break;
                case "2":
                    Console.WriteLine("Type new Password:");
                    _password = Console.ReadLine();
                    Console.WriteLine($"Password is changed to {Password}");
                    break;
            }
            return this;
        }
    }
}
