using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Repository
{
    internal class RocketWebservice
    {
        private readonly Uri baseAddress;

        public RocketWebservice(Uri baseAddress)
        {
            this.baseAddress = baseAddress;
        }

        public Rocket GetRocket(string rocketId)
        {
            var uriBuilder = new UriBuilder(baseAddress);
            uriBuilder.Path += rocketId;
            var webRequestResponse = WebRequest.Create(uriBuilder.Uri).GetResponse();
            using (JsonReader jsonReader = new JsonTextReader(new StreamReader(webRequestResponse.GetResponseStream())))
            {
                return new JsonSerializer().Deserialize<Rocket>(jsonReader);
            }
        }
    }
}
