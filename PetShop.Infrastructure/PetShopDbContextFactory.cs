using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PetShop.Infrastructure
{
    internal class PetShopDbContextFactory : IDesignTimeDbContextFactory<PetShopDbContext>
    {
        public PetShopDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PetShopDbContext>();
            optionsBuilder.UseOracle("User Id=seu_usuario;Password=sua_senha;Data Source=oracle.fiap.com.br:1521/ORCL");

            return new PetShopDbContext(optionsBuilder.Options);
        }
    }
}
