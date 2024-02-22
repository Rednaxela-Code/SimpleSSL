using RestSharp;
using SimpleSSL;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        // Init
        X509Certificate2Collection X509Collection = new X509Certificate2Collection();

        Settings settings = new Settings();

        Console.WriteLine("Please type the base URL:");
        string URL = Console.ReadLine();
        Console.WriteLine($"BaseURL is now set to {URL}");

        settings.SettingMaker();

        RestClientOptions restClientOptions = new RestClientOptions() { BaseUrl = new Uri(URL) };
        Requester requester = new Requester();

        // Certificate
        X509Collection.Import(settings.CertificatePath, settings.Password, X509KeyStorageFlags.PersistKeySet);

        foreach (X509Certificate2 x in X509Collection)
        {
            restClientOptions.ClientCertificates = new X509CertificateCollection() { x };
        }

        RestClient restClient = new RestClient(restClientOptions);

        // Request
        requester.RestGET(settings, restClient);
    }
}