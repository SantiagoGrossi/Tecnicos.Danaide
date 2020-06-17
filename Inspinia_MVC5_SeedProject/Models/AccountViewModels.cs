using System.ComponentModel.DataAnnotations;
using Inspinia_MVC5_SeedProject.
    Models;
using System.Collections.Generic;
namespace Inspinia_MVC5_SeedProject.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña actual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva contraseña")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar pass")]
        [Compare("NewPassword", ErrorMessage = "Las contraseñas no matchean")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recordar?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar pass")]
        [Compare("Password", ErrorMessage = "Las contraseñas no matchean")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "¿Es soporte?")]
        public bool EsSoporte { get; set; }

        [Display(Name = "Color:")]
        public string Color { get; set; }

        public Roles Roless { get; set; }
        public int RolesId { get; set; }

        public IEnumerable<Roles> RolesEnum { get; set; }
    }
}
