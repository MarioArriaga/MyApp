using System.Data.Entity;
using System.Configuration;
using DAL.Entities;

namespace DAL.DomainServices
{
    public class PersonContext : DbContext
    {
        public PersonContext()
        {
            this.Database.Connection.ConnectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public DbSet<Person> Persons { get; set; }
    }
}
