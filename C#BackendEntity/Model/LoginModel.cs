using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

namespace C_BackendEntity.Model
{
    public class LoginModel
    {
        [JsonIgnore] public int Id { get; set; }

        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
