using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Pid { get; set; }
        [Required(ErrorMessage ="product name not found")]
        public string? Pname { get; set; }
        [Required(ErrorMessage ="product price not found")]
        public int? Price { get; set; }
        public int? Catid { get; set; }



    }
}
