using System.ComponentModel.DataAnnotations;

namespace FoodOrderingApp.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        [Required(ErrorMessage = "Numer telefonu jest wymagany")]
        [Phone(ErrorMessage = "Numer telefonu musi być w formacie telefonu")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Numer konta jest wymagany")]
        [RegularExpression(@"^\d{26}$", ErrorMessage = "Numer konta musi składać się z 26 cyfr")]
        public string BankAccountNumber { get; set; } = string.Empty;
        public string Role { get; set; }
    }
}