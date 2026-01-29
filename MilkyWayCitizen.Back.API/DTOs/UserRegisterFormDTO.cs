using System.ComponentModel.DataAnnotations;

namespace MilkyWayCitizen.Back.API.DTOs
{
    public record UserRegisterFormDTO
    (
        [Required]
        [MinLength(3), MaxLength(32)]
        string UserName,

        [Required]
        [MaxLength(60)]
        string FirstName,

        [Required]
        [MaxLength(60)]
        string LastName,

        [Required]
        [EmailAddress]
        string Email,

        [Required]
        string Password,

        [Required]
        DateOnly BirthDate
    );

}
