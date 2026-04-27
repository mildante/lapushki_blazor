using System.Data;
using static lapushki_blazor.ApiRequests.Models.User;

namespace lapushki_blazor.ApiRequests.Models
{
    public class UserService
    {
        public UserModel? CurrentUser { get; set; }

        public bool IsAuthorized => CurrentUser != null;
        public bool isAdmin => CurrentUser?.role_id == 1;
        public bool isDoctor => CurrentUser?.role_id == 2;
        public Action OnAuthStateChanged { get; set; }

        public void Noitify()
        {
            OnAuthStateChanged?.Invoke();
        }


    }
    public class User
    {
        public class AuthModel
        {
            public string email { get; set; }
            public string password { get; set; }
        }

        public class UserModel
        {
            public int id_user { get; set; }
            public string name { get; set; }
            public string? surname { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string password { get; set; }
            public string gender { get; set; }
            public string? avatar { get; set; }
            public DateOnly date_of_birth { get; set; }
            public int role_id { get; set; }
            public Role role { get; set; }

        }
        public class AuthorizeResponse
        {
            public bool status { get; set; }
            public string token { get; set; }
            public UserModel user { get; set; }
            public string message { get; set; }

        }

        public class UserListResponse
        {
            public bool status { get; set; }
            public List<UserModel> list { get; set; }
        }

        public class NewUserResponse
        {
            public bool status { get; set; }
            public string message { get; set; }
        }

        public class DeleteUserResponse
        {
            public bool status { get; set; }
            public string message { get; set; }
        }

        public class UpdateUserResponse
        {
            public bool status { get; set; }
            public string message { get; set; }
        }
    }
}
