namespace lapushki_blazor.ApiRequests.Models
{
    public class Images
    {
        public class UploadImageResponse
        {
            public bool status {  get; set; }
            public string imageUrl { get; set; }
            public string message { get; set; }
        }
    }
}
