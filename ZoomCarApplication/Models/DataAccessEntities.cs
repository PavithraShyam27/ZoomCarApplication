using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ZoomCarApplication.Models
{
    public class DataAccessEntities : DbContext
    {
        public DataAccessEntities()
            : base("name=DBEntities")
        {

        }

        public DbSet<CarDetails> CarDetails { get; set; }
        //public DbSet<UserDetails> UserDetails { get; set; }
    }
}