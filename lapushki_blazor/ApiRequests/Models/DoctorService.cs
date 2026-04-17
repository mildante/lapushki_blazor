using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static lapushki_blazor.ApiRequests.Models.ClinicService;
using static lapushki_blazor.ApiRequests.Models.Doctor;

namespace lapushki_blazor.ApiRequests.Models
{
    public class DoctorService
    {
        public class DoctorServiceModel
        {
            public int id { get; set; }
            public int doctor_id { get; set; }
            public DoctorModel doctor { get; set; }
            public int service_id { get; set; }
            public ClinicServiceModel clinic_service { get; set; }
        }
        public class DoctorServiceListResponse
        {
            public bool status { get; set; }
            public List<DoctorServiceModel> list { get; set; }
        }
    }
}
