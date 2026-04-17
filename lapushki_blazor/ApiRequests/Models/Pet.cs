namespace lapushki_blazor.ApiRequests.Models
{
    public class Pet
    {
        public class PetModel
        {
            public int id_pet { get; set; }
            public string name { get; set; }
            public string breed { get; set; }
            public string species { get; set; }
            public string? description { get; set; }
            public string gender { get; set; }
            public DateOnly date_of_birth { get; set; }
            public int user_id { get; set; }
        }

        public class PetListResponse
        {
            public bool status { get; set; }
            public List<PetModel> list { get; set; }
        }
        public class CreatePetResponse
        {
            public bool status { get; set; }
            public string message { get; set; }
        }
        public class UpdatePetResponse
        {
            public bool status { get; set; }
            public string message { get; set; }
        }
        public class DeletePetResponse
        {
            public bool status { get; set; }
            public string message { get; set; }
        }

    }
}
