using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DisplayProbeResults.EntityModels;

namespace DisplayProbeResults.Utils
{
    public class ProbeDbContext : DbContext
    {
        public ProbeDbContext(string connectionString) : base(connectionString)
        {
            base.Configuration.LazyLoadingEnabled = false;
        }

        //public ProbeDbContext(IMachineIdentity appUser) : this(Config.Exigo(appUser.CompanyID))
        //{

        //}

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}