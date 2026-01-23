using System.ComponentModel.DataAnnotations;
using System.Net;

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
        DateOnly BirthDate,

        //  Address

        [Required]
        string StreetName,

        [Required]
        int StreetNumber,

        [Required]
        string City,

        [Required]
        string Country



    );
    //public class UserRegisterFormDTO
    //{
    //    public string FirstName { get; set; } = null!;
    //    public string LastName { get; set; } = null!;
    //    public string Email { get; set; } = null!;
    //    public string Password { get; set; } = null!;
    //    public DateOnly BirthDate { get; set; }
    //    //public Address? Address { get; set; }
    //}
}
