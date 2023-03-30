using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CrudUsingADO.NetMVC.Models
{
    [Table("tblProduct")]
    public class Product
    {       [Key]
            [ScaffoldColumn(false)]
            public int ProductId { get; set; }

            [Required]
            [Display(Name = "Product Name")]
            [MaxLength(40)]
            [MinLength(2)]
           public string? ProductName { get; set; }

           
            [Required]
            [MaxLength(40)]
             public string? ProductComapny { get; set; }
            
            [Required]
            public double ProductPrice { get; set; }

           
        }
    }

