using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext:DbContext
    {
        public DataContext (DbContextOptions options): base(options){

        }
      
     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Addd the Postgres Extension for UUID generation
      
            // define configurations
         
        }  
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       /// optionsBuilder.UseNpgsql("Server=localhost; Port=5432 ; User Id=admin; Password=secret");
    //    optionsBuilder.UseNpgsql(" Server=localhost; Port=5432; User Id=admin; Password=secret; Database=auctions");
    }



        public DbSet <Product> Products {get;set;}
        public DbSet <Seller> Sellers {get;set;}
        public DbSet <Bid> Bids {get;set;}
        
        
    }
}