using System.ComponentModel.DataAnnotations;

namespace FoodOrderingApp.DTOs.User
{
    public class AppUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string BankAccountNumber { get; set; } 
        public string Role { get; set; }
    }
}
