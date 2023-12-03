using System.ComponentModel.DataAnnotations;

namespace Letter.Business.Dtos.Post.Users
{
    public class RegisterUserDto
    {
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required]
        
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Şifrələr eyni deyil")]
        public string ConfirmPassword { get; set; }
    }
}
