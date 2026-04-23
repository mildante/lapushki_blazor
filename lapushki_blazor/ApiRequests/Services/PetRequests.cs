using System.Net.Http.Json;
using static lapushki_blazor.ApiRequests.Models.Pet;
using static lapushki_blazor.ApiRequests.Models.User;

namespace lapushki_blazor.ApiRequests.Services
{
    public class PetRequests
    {
        private readonly HttpClient _httpClient;
        public PetRequests(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<PetListResponse> GetAllPets()
        {
            return await _httpClient.GetFromJsonAsync<PetListResponse>("/getAllPets");
        }
        public async Task<PetListResponse> GetAllPetsByUser(int user_id)
        {
            return await _httpClient.GetFromJsonAsync<PetListResponse>($"/getAllPetsByUser?user_id={user_id}");
        }
        public async Task<CreatePetResponse> AddPet(PetModel petModel)
        {
            var response = await _httpClient.PostAsJsonAsync("/addPet", petModel);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CreatePetResponse>();
        }
        public async Task<UpdatePetResponse> UpdatePet(PetModel petModel)
        {
            var response = await _httpClient.PutAsJsonAsync("/updatePet", petModel);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UpdatePetResponse>();
        }
        public async Task<DeletePetResponse> DeletePet(int pet_id)
        {
            var response = await _httpClient.DeleteAsync($"/deletePet?pet_id={pet_id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<DeletePetResponse>();
        }
    }
}
