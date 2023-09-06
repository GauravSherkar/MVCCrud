using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Machine_Test_1.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }    

        [Required(ErrorMessage = "Enter Product Name")]
        [StringLength(20)]
        public string ProductName { get; set; }
        [Display(Name = "Category")]
        public virtual int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}