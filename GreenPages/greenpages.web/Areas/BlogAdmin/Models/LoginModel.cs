using System.ComponentModel.DataAnnotations;

namespace GreenPages.Web.Areas.BlogAdmin.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}