using System.Data.Entity;

namespace ProgPOE
{
    public class FarmCentralDBContextcs : DbContext
    {
        public FarmCentralDBContextcs(): base(Properties.Resources.connectionString) 
        { 
        }


        //public DbSet<Farmer> Farmers { get; set; }
    }
}