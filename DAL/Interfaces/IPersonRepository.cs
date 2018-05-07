using DAL.Entities;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IPersonRepository
    {
        void Add(IPerson p);
        void Edit(IPerson p);
        void Remove(string Id);
        IEnumerable<IPerson> GetPerson();
        IPerson FindById(int Id);
        void Dispose();
    }
}
