using System.Net.Http.Json;
using static lapushki_blazor.ApiRequests.Models.Appointment;
using static lapushki_blazor.ApiRequests.Models.ClinicService;
using static lapushki_blazor.ApiRequests.Models.Doctor;
using static lapushki_blazor.ApiRequests.Models.User;

namespace lapushki_blazor.ApiRequests.Services
{
    public class AppointmentRequests
    {
        private readonly HttpClient _httpClient;
        public AppointmentRequests(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<DoctorListResponse> GetAllDoctors()
        {
            return await _httpClient.GetFromJsonAsync<DoctorListResponse>("/getAllDoctors");
        }
        public async Task<ClinicServiceListResponse> GetAllCLinicServices()
        {
            return await _httpClient.GetFromJsonAsync<ClinicServiceListResponse>("/getAllServices");
        }
        public async Task<AppointmentListResponse> GetAllAppointments()
        {
            return await _httpClient.GetFromJsonAsync<AppointmentListResponse>("/getAllAppointments");
        }
        public async Task<AppointmentListResponse> GetAllAppointmentsByUser(int user_id)
        {
            return await _httpClient.GetFromJsonAsync<AppointmentListResponse>($"/getAllAppointmentsByUser?user_id={user_id}");
        }
        public async Task<AppointmentListResponse> GetAllAppointmentsByDoctor(int doctor_id)
        {
            return await _httpClient.GetFromJsonAsync<AppointmentListResponse>($"/getAllAppointmentsByDoctor?doctor_id={doctor_id}");
        }
        public async Task<CreateAppointmentResponse> AddAppointment(AppointmentModel appointmentModel)
        {
            var response = await _httpClient.PostAsJsonAsync("/addAppointment", appointmentModel);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CreateAppointmentResponse>();
        }
        public async Task<UpdateAppointmentResponse> UpdateAppointment(AppointmentModel appointmentModel)
        {
            var response = await _httpClient.PutAsJsonAsync("/updateAppointment", appointmentModel);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UpdateAppointmentResponse>();
        }
        public async Task<DeleteAppointmentResponse> DeleteAppointment(int appointment_id)
        {
            var response = await _httpClient.DeleteAsync($"/deleteAppointment?appointmentId={appointment_id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<DeleteAppointmentResponse>();
        }
        public async Task<CreateDoctorResponse> CreateDoctor(CreateDoctorRequest doctorModel)
        {
            var response = await _httpClient.PostAsJsonAsync("/addDoctor", doctorModel);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CreateDoctorResponse>();
        }
        public async Task<UpdateDoctorResponse> UpdateDoctor(DoctorModel doctorModel)
        {
            var response = await _httpClient.PutAsJsonAsync("/updateDoctor", doctorModel);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UpdateDoctorResponse>();
        }
        public async Task<DeleteDoctorResponse> DeleteDoctor(int doctor_id)
        {
            var response = await _httpClient.DeleteAsync($"/deleteDoctor?doctor_id={doctor_id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<DeleteDoctorResponse>();
        }
    }
}
