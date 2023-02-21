using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDUsingEF.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [ScaffoldColumn(false)]
        public int CId { get; set; }
        [Required]
        public string? CName { get; set; }
    }
}
