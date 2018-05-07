using DAL.DomainServices;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Infrastructure.Repository
{
    public class PersonRepository : IPersonRepository
    {
        PersonContext context = new PersonContext();

        public void Add(IPerson p)
        {
            context.Persons.Add(p);
            context.SaveChanges();
        }

        public void Edit(IPerson p)
        {
            context.Entry(p).State = System.Data.Entity.EntityState.Modified;
        }

        public IPerson FindById(int Id)
        {
            var p = (from r in context.Persons where r.Id == Id select r).FirstOrDefault();
            return p;
        }

        public IEnumerable<IPerson> GetPerson()
        {
            return context.Persons;
        }

        public void Remove(string Id)
        {
            IPerson p = context.Persons.Find(Id);
            context.Persons.Remove(p);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
