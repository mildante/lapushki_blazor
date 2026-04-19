using System.Net.Http.Json;
using static lapushki_blazor.ApiRequests.Models.Appointment;
using static lapushki_blazor.ApiRequests.Models.Payments;
using static System.Net.WebRequestMethods;

namespace lapushki_blazor.ApiRequests.Services
{
    public class PaymentsApiService
    {
        private readonly HttpClient _httpClient;
        public PaymentsApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CreatePaymentResponse> CreatePayment(CreatePaymentRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/createPayment", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CreatePaymentResponse>();
        }
        public async Task<string?> CheckPaymentStatus(string paymentId)
        {
            return await _httpClient.GetStringAsync($"/checkPaymentStatus?paymentId={paymentId}");
        }
    }
}
