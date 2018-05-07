using System.Data.Entity;
using System.Configuration;
using DAL.Interfaces;

namespace DAL.DomainServices
{
    public class PersonContext : DbContext
    {
        public PersonContext()
        {
            this.Database.Connection.ConnectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public DbSet<IPerson> Persons { get; set; }
    }
}
