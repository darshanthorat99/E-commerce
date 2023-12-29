using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    [Table("users")]
    public class Users
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Userid { get; set; }
        [Required(ErrorMessage ="EMAIL NOT FOUND")]
        public string? Emailid { get; set; }
        [Required(ErrorMessage ="PASSWORD NOT FOUND")]
        public  string? Password { get; set; }

        public int Roleid { get; set; }
    }   
}
