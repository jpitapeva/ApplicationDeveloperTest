using System.Data.Entity;
using Volvo.Models;

namespace OperasWebsites.Models
{
    public class TruckDB : DbContext
    {
        public TruckDB() : base()
        {
            this.Database.CommandTimeout = 180;
        }

        public DbSet<Truck> Truck { get; set; }
        public DbSet<TruckModel> TruckModel { get; set; }

    }
}
