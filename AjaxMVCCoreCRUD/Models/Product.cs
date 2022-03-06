﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxMVCCoreCRUD.Models
{
    public class Product
    {

      
        [Key]
        [MaxLength(6)]
        public string Code { get; set; }

        [MaxLength(75)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [MaxLength(15)]
        public string Category { get; set; }

        [Range(5,1000)]
        public float Cost { get; set; }

        [Range(5, 3000)]
        public float Price { get; set; }

        [MaxLength(500)]
        public string ImageUrl { get; set; }

    }
}
