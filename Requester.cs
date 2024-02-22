using RestSharp;
using System.Net;

namespace SimpleSSL
{
    public class Requester : Settings
    {
        public void RestGET(Settings settings, RestClient onsApi)
        {
            bool runRequests = true;
            int idResource = 1;
            while (runRequests == true)
            {
            string resourceCall = string.Format(settings.BaseURL.ToString(), idResource.ToString());
                RestRequest restRequest = new RestRequest()
                {
                    Method = Method.Get,
                    RequestFormat = DataFormat.Json,
                    Resource = resourceCall,
                };
                restRequest.AddHeader("Accept", "application/xml"); // Nodig?
                RestResponse restResponse = onsApi.Execute(restRequest);

                Console.WriteLine(resourceCall);

                if (restResponse.StatusCode != HttpStatusCode.OK)
                {
                    Console.WriteLine(string.Format("API foutcode ({0} - {1}).", (int)restResponse.StatusCode, restResponse.StatusDescription));
                    idResource++;
                }
                else
                {
                    Console.WriteLine("Succes!");
                    idResource++;
                }
                Console.WriteLine(restResponse.Content);
            }
        }

        public void RestPOST(Settings settings, RestClient onsApi)
        {

        }
    }
}
