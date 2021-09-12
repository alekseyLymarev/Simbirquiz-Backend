using System.ComponentModel.DataAnnotations;

namespace SimbirSquize.Data.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [EmailAddress(ErrorMessage = "Введенные вами данные не являются адресом")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Password { get; set; }
    }
}