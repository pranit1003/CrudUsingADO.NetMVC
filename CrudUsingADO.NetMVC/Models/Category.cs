using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudUsingADO.NetMVC.Models
{
    [Table("tblCategory")]
    public class Category
    {
        [Key]
        [ScaffoldColumn(false)]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        [MaxLength(40)]
        [MinLength(2)]
        public string? CategoryName { get; set; }

    }
}
