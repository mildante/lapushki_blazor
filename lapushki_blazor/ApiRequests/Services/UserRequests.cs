using lapushki_blazor.ApiRequests.Models;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using static lapushki_blazor.ApiRequests.Models.User;

namespace lapushki_blazor.ApiRequests.Services
{
    public class UserRequests
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly UserService _userService;
        public UserRequests(HttpClient httpClient, ILocalStorageService localStorage, UserService userService)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _userService = userService;
        }

        public async Task<AuthorizeResponse> GetAuthorizeUser(AuthModel authUser)
        {
            var response = await _httpClient.PostAsJsonAsync("/authorize", authUser);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<AuthorizeResponse>();

            if (result != null && result.status && !string.IsNullOrEmpty(result.token))
            {
                _localStorage.SetItem("token", result.token);

                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", result.token);

                if (result.user != null)
                    _userService.CurrentUser = result.user;
            }

            return result;
        }

        public async Task<bool> LoadUserFromToken()
        {
            var token = _localStorage.GetItem<string>("token");

            if (string.IsNullOrEmpty(token))
                return false;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync("/authUserByToken");

            if (!response.IsSuccessStatusCode)
            {
                await Logout();
                return false;
            }

            var result = await response.Content.ReadFromJsonAsync<AuthorizeResponse>();

            if (result == null || !result.status || result.user == null)
            {
                await Logout();
                return false;
            }

            _userService.CurrentUser = result.user;
            _userService.Noitify();
            return true;

        }

        public async Task Logout()
        {
            _localStorage.RemoveItem("token");
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _userService.CurrentUser = null;
            _userService.Noitify();
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
            var response = await _httpClient.DeleteAsync($"/deleteUser?user_id={user_id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<DeleteUserResponse>();
        }

    }
}
