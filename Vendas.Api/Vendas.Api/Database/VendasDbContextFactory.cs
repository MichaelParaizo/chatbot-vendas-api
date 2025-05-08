using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Vendas.Api.Database
{
    public class ProjectContextFactory : IDesignTimeDbContextFactory<VendasDbContext>

    {

        public VendasDbContext CreateDbContext(string[] args)

        {

            var optionsBuilder = new DbContextOptionsBuilder<VendasDbContext>();

            optionsBuilder.UseSqlServer("Server=DESKTOP-DHEH2N;Database=VendasDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new VendasDbContext(optionsBuilder.Options);

        }

    }

}
