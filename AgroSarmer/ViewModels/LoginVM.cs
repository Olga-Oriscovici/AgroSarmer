using System.ComponentModel.DataAnnotations;

namespace AgroSarmer.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="UserName is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage ="Password is requireg")]
        public string? Password { get; set; }
        [Display(Name ="Rememeber me")]
        public bool RememberMe { get; set; }
    }
}
