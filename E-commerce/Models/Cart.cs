using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace E_commerce.Models
{
    [Table("cart")]
    public class Cart
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Cartid { get; set; }
        public int Userid { get; set; }
        public int Pid { get; set; }

    }
}
