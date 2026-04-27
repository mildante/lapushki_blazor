using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static lapushki_blazor.ApiRequests.Models.User;

namespace lapushki_blazor.ApiRequests.Models
{
    public class Doctor
    {
        public class DoctorModel
        {
            public int id_doctor { get; set; }
            public string specialization { get; set; }
            public TimeOnly work_start { get; set; }
            public TimeOnly work_end { get; set; }
            public int duration_slot { get; set; }
            public bool is_active { get; set; }
            public int id_user { get; set; }
            public UserModel user { get; set; }
        }
        public class DoctorListResponse
        {
            public bool status { get; set; }
            public List<DoctorModel> list { get; set; }
        }

        public class CreateDoctorResponse
        {
            public bool status { get; set; }
        }
        public class UpdateDoctorResponse
        {
            public bool status { get; set; }
            public string message { get; set; }

        }
        public class DeleteDoctorResponse
        {
            public bool status { get; set; }
            public string message { get; set; }

        }

        public class CreateDoctorRequest
        {
            public string specialization { get; set; }
            public TimeOnly work_start { get; set; }
            public TimeOnly work_end { get; set; }
            public int duration_slot { get; set; }
            public string name { get; set; }
            public string surname { get; set; }
            public string gender { get; set; }
            public string phone { get; set; }
            public string email { get; set; }
            public DateOnly date_of_birth { get; set; }
            public bool is_active { get; set; }
        }

    }
}
