using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using product_stock_mvc.Web.DTOs;

namespace product_stock_mvc.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<product_stock_mvc.Web.DTOs.ProductDTO> ProductDTO { get; set; }
    }
}