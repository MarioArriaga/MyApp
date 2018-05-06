using DAL.Entities;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IPersonRepository
    {
        void Add(Person p);
        void Edit(Person p);
        void Remove(string Id);
        IEnumerable<Person> GetPerson();
        Person FindById(int Id);
        void Dispose();
    }
}
