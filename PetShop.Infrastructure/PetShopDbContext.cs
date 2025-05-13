using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Estruturas;
using System.Collections.Generic;

namespace PetShop.Infrastructure
{
    public class PetShopDbContext : DbContext
    {
        public PetShopDbContext(DbContextOptions<PetShopDbContext> options) : base(options) { }

        public DbSet<Animal> Animais { get; set; }
    }
}
