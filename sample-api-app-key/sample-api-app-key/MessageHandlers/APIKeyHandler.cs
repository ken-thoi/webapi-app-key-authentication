using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace sample_api_app_key.MessageHandlers
{
    public class ApiKeyHandler : DelegatingHandler
    {
        //set a default API key 
        private const string API_KEY = "X-some-key";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool isValidApiKey = false;
            IEnumerable<string> lsHeaders;
            //Validate that the api key exists

            var checkApiKeyExists = request.Headers.TryGetValues("API_KEY", out lsHeaders);

            if (checkApiKeyExists)
            {
                var orDefault = lsHeaders.FirstOrDefault();
                if (orDefault != null && orDefault.Equals(API_KEY))
                {
                    isValidApiKey = true;
                }
            }

            //If the key is not valid, return an http status code.
            if (!isValidApiKey)
                return request.CreateResponse(HttpStatusCode.Forbidden, "Bad API Key");

            //Allow the request to process further down the pipeline
            var response = await base.SendAsync(request, cancellationToken);

            //Return the response back up the chain
            return response;
        }
    }
}