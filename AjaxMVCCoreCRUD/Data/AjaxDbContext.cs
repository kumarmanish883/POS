using AjaxMVCCoreCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxMVCCoreCRUD.Data
{
    public class AjaxDbContext:DbContext
    {
        public AjaxDbContext(DbContextOptions<AjaxDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Product> Products { get; set; }
    }
}
