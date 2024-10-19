using System;
using System.Net;
using RestSharp;
using NLog;
using Xunit;

namespace ApiTestProject.Methods
{
    public class ApiMethods
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        private readonly RestClient _client;

        public ApiMethods()
        {
            try
            {
                LogManager.Setup().LoadConfigurationFromFile("NLog.config");
                Logger.Info("NLog configuration loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading NLog configuration: {ex.Message}");
            }

            _client = new RestClient("https://jsonplaceholder.typicode.com");
        }

        // Helper method to send a request, log the response, and assert the expected status code
        public void SendRequestAndAssertStatusCode(RestRequest request, HttpStatusCode expectedStatusCode, string requestDescription)
        {
            Logger.Info($"Starting request: {requestDescription}");
            Logger.Debug($"Sending {request.Method} request to {request.Resource}");

            var response = _client.Execute(request);

            Logger.Debug($"Response: {response.StatusCode}, Content: {response.Content}");
            Logger.Info($"Finished request: {requestDescription}");

            // Perform assertion and log the result
            Assert.Equal(expectedStatusCode, response.StatusCode);
            Logger.Info($"Asserted that status code {response.StatusCode} matches expected {expectedStatusCode}");
        }
    }
}
