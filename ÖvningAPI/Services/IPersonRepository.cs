using ÖvningAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ÖvningAPI.Services
{
    public interface IPersonRepository
    {
        Task<Person> GetPerson(int id);
        Task<ICollection<Person>> GetAllPerson();
        Task<ICollection> GetPersonwithAdress(int id);
        Task<ICollection> GetAllPersonsonAdressId(int id);
        Task<IEnumerable<Person>> Search(string name);
        Task<Person> Add(Person personToAdd);
        Task<Person> Update(Person personToUpdate);
        Task<Person> Delete(Person personToDelete);
    }
}
