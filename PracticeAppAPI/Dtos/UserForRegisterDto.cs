using System.ComponentModel.DataAnnotations;

namespace PracticeAppAPI.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "password should between 4-10 charactors")]
        public string Password { get; set; }
    }
}