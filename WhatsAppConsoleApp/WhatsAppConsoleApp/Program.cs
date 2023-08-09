using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        await SendPostRequestAsync("50255106008");
    }

    static async Task SendPostRequestAsync(string toNumber)
    {
        using HttpClient httpClient = new HttpClient();

        // Set the base URL
        string baseUrl = "https://graph.facebook.com/v17.0/100393526496435/messages";

        // Set the authorization header
        string accessToken = "";
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

        // Create the request body data
        var requestData = new
        {
            messaging_product = "whatsapp",
            to = toNumber,
            type = "template",
            template = new
            {
                name = "hello_world",
                language = new { code = "en_US" }
            }
        };

        // Serialize the request data to JSON
        string requestDataJson = JsonSerializer.Serialize(requestData);

        // Create the HTTP request content
        var content = new StringContent(requestDataJson, Encoding.UTF8, "application/json");

        // Set the content type header in the HttpContent object
        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

        // Send the POST request
        HttpResponseMessage response = await httpClient.PostAsync(baseUrl, content);

        // Read and display the response
        string responseContent = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Response:");
        Console.WriteLine(responseContent);
    }
}