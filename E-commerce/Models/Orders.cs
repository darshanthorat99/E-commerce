using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace E_commerce.Models
{
    [Table("orders")]
    public class Orders
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Oid { get; set; }
        public int Pid { get; set; }

        public int Userid { get; set; }
        public int Quantity { get; set; }



    }
}
