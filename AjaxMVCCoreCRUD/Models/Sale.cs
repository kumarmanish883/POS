using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxMVCCoreCRUD.Models
{
    public class Sale
    {
        [Key]
        
        public string SaleId { get; set; }

        [MaxLength(50)]
        public string Sale_Product { get; set; }

        [MaxLength(5)]
        public string Sale_Quantity { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        

    }
}
