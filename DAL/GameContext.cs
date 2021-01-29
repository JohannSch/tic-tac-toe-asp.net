using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class GameContext : DbContext
    {
        public DbSet<GameResults> GameResults { get; set; }
        public DbSet<GameSteps> GameSteps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-UO4GF3J\SQLEXPRESS;Initial Catalog=T.E.S.T.D.B;persist security info=True;User id=admUser; Password=1234");
            }
        }
    }
}
