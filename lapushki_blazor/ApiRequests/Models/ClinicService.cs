using System.ComponentModel.DataAnnotations;

namespace lapushki_blazor.ApiRequests.Models
{
    public class ClinicService
    {
        public class ClinicServiceModel
        {
            public int id_service { get; set; }
            public string name { get; set; }
            public double price { get; set; }
            public int duration { get; set; }
        }
        public class ClinicServiceListResponse
        {
            public bool status {  get; set; }
            public List<ClinicServiceModel> list { get; set; }
        }
    }
}
