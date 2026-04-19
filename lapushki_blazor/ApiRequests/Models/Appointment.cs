using static lapushki_blazor.ApiRequests.Models.Doctor;

namespace lapushki_blazor.ApiRequests.Models
{
    public class Appointment
    {
        public class AppointmentModel
        {
            public int id { get; set; }
            public int doctor_id { get; set; }
            public int service_id { get; set; }
            public int pet_id { get; set; }
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
