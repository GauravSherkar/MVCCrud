using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Machine_Test_1.Models
{

    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Enter Category Name")]
        public string CategoryName { get; set; }
        public virtual List<Product> Products { get; set; }      
    }
}