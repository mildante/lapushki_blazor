using System.Net.Http.Json;
using System.Text.Json;
using static lapushki_blazor.ApiRequests.Models.User;

namespace lapushki_blazor.ApiRequests.Services
{
    public class UserRequests
    {
        private readonly HttpClient _httpClient;
        public UserRequests(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AuthorizeResponse> GetAuthorizeUser(AuthModel authUser)
        {
            var response = await _httpClient.PostAsJsonAsync("/authorize", authUser);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<AuthorizeResponse>();
        }
        public async Task<UserListResponse> GetAllUser()
        {
            return await _httpClient.GetFromJsonAsync<UserListResponse>("/getAllUser");
        }
        public async Task<NewUserResponse> CreateNewUser(UserModel newUser)
        {
            var response = await _httpClient.PostAsJsonAsync("/registration", newUser);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<NewUserResponse>();
        }
        public async Task<UpdateUserResponse> UpdateUser(UserModel userModel)
        {
            var response = await _httpClient.PutAsJsonAsync("/updateUser", userModel);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UpdateUserResponse>();
        }
        public async Task<DeleteUserResponse> DeleteUser(int user_id)
        {
            var response = await _httpClient.DeleteAsync($"/deleteUser/{user_id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<DeleteUserResponse>();
        }

    }
}
