using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerServiceApp.Models
{
    [Table("Login")]
    public class Login
    {
        [Key]
        public int ID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
