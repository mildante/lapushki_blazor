using static lapushki_blazor.ApiRequests.Models.ClinicService;
using static lapushki_blazor.ApiRequests.Models.Doctor;
using static lapushki_blazor.ApiRequests.Models.Pet;

namespace lapushki_blazor.ApiRequests.Models
{
    public class Appointment
    {
        public class AppointmentModel
        {
            public int id { get; set; }
            public int doctor_id { get; set; }
            public DoctorModel doctor { get; set; }
            public int service_id { get; set; }
            public ClinicServiceModel clinic_service { get; set; }
            public int pet_id { get; set; }
            public PetModel pet { get; set; }
            public DateOnly date { get; set; }
            public TimeOnly time { get; set; }
            public string status { get; set; }
            public string? payment_id { get; set; }
        }

        public class AppointmentListResponse
        {
            public bool status { get; set; }
            public List<AppointmentModel> list { get; set; }
        }
        public class CreateAppointmentResponse
        {
            public bool status { get; set; }
            public string message { get; set; }
            public AppointmentModel newAppointment { get; set; }
        }
        public class UpdateAppointmentResponse
        {
            public bool status { get; set; }
            public string message { get; set; }
        }
        public class DeleteAppointmentResponse
        {
            public bool status { get; set; }
            public string message { get; set; }
        }
    }
}
