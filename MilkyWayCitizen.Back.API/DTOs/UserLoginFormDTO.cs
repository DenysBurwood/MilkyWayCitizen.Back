using System.ComponentModel.DataAnnotations;

namespace MilkyWayCitizen.Back.API.DTOs
{
    public record UserLoginFormDTO
    (
        [Required]
        string UserName,

        [Required]
        string Password
    );
}
