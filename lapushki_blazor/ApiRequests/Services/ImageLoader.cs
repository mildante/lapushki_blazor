using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using static lapushki_blazor.ApiRequests.Models.Images;

namespace lapushki_blazor.ApiRequests.Services
{
    public class ImageLoader
    {
        private readonly HttpClient _httpClient;
        public ImageLoader(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string?> UploadImage(IBrowserFile file)
        {
            using var content = new MultipartFormDataContent();

            var streamContent = new StreamContent(file.OpenReadStream(maxAllowedSize: long.MaxValue));
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            content.Add(streamContent, "file", file.Name);

            var response = await _httpClient.PostAsync("/uploadImage", content);

            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<UploadImageResponse>();

            return result?.imageUrl;
        }
    }
}
