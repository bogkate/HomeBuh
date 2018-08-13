namespace HomeBuhDb
{
    using System.Data.Entity;
    using HomeBuhDb;

    public class Storage : DbContext
    {
        public Storage(string connectionString)
            : base(connectionString)
        {
        }

        public Storage() : base("Storage")
        {

        }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
