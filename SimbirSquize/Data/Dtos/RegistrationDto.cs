using System.ComponentModel.DataAnnotations;

namespace SimbirSquize.Data.Dtos
{
    public class RegistrationDto
    {
        [Required(ErrorMessage = "Данное поле обязательно для сохранения")]
        [EmailAddress(ErrorMessage = "Введенные данные не являются адресом электронной почты")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Поле является обязательным для сохранения")]
        [MinLength(4, ErrorMessage = "Минимальная длинна пароля 4 символа")]
        public string Password { get; set; }
        
        public string PasswordRepeat { get; set; }
    }
}