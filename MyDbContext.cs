

using Microsoft.EntityFrameworkCore;

namespace AssetSql {
    internal class MyDbContext : DbContext {

        public DbSet<Assets> assets { get; set; }


        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=assets;Integrated Security=True;" +
            "Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
