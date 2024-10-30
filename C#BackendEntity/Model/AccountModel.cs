using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

namespace C_BackendEntity.Model
{
    public class AccountModel
    {
        [JsonIgnore] public int Id { get; set; }

        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }

    public class LoginModel 
    {
        [JsonIgnore] public int Id { get; set; }

        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
