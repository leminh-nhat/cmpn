using System.ComponentModel.DataAnnotations;

namespace tutorgo.Models.ViewModels
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your username")]
        public string Username { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }
    }
}
