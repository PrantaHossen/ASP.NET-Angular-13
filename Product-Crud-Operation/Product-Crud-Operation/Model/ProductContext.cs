using Microsoft.EntityFrameworkCore;

namespace Product_Crud_Operation.Model
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        public DbSet<Product> ProductTable { get; set; }
    }
}
