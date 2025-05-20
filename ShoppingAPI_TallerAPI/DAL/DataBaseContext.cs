using Microsoft.EntityFrameworkCore;
using ShoppingAPI_TallerAPI.DAL.ENTITIES;

namespace ShoppingAPI_TallerAPI.DAL
{
    public class DataBaseContext : DbContext
    {
        // asi nos conectamos a la bd, por medio de este constructor
        public DataBaseContext(DbContextOptions<DataBaseContext> opcions ) : base( opcions)
        {

        }

        //este método es propio de EF CORE y me sirve para configurar unos índises de una tabla en BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique(); //Así creo un Índise del campo Name para la tabla Countries.
        }

        #region DbSets

        public DbSet<Country> Conuntries { get; set; }

        #endregion
    }
}
