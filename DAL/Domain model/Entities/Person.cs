using DAL.Interfaces;

namespace DAL.Entities
{
    class Person : IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
    }
}
