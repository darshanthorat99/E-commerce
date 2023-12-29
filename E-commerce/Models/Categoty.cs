using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    [Table("categoty")]
    public class Categoty
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Catid { get; set; }

        public string? Catname { get; set; }
    }
}
