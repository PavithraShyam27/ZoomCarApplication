using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoomCarDataAccess
{
    public partial class CarDetailsDBEntities : DbContext
    {
        public CarDetailsDBEntities()
            : base("name=CarDetailsDBEntities")
        {
            
        }

        public DbSet<CarDetails> CarDetails { get; set; }

    }
}
