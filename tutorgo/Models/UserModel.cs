using System.ComponentModel.DataAnnotations;

namespace tutorgo.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter your email"),EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password),Required(ErrorMessage = "Please enter your password")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage = "Độ dài tối thiểu 6 kí tự và phải chứa 1 chữ hoa, 1 chữ thường, 1 ký tự đặc biệt và 1 chữ số")]
        public string Password { get; set; }
        [DataType(DataType.Password),Required(ErrorMessage = "Pleasa confirm your password")]
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp")]
        public string PasswordConfirm { get; set; }
    }
}
