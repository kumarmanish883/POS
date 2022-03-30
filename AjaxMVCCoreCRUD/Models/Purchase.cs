using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxMVCCoreCRUD.Models
{
    public class Purchase
    {
        [Key]
        public int Purchase_Id { get; set; }
        public string PurchaseProduct { get; set; }
        public string PurchaseQuantity { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
