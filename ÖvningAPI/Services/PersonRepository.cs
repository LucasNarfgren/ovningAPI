using Microsoft.EntityFrameworkCore;
using ÖvningAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ÖvningAPI.Services
{
    public class PersonRepository : IPersonRepository
    {
        private ÖvningAPIDbContext Context;

        public PersonRepository(ÖvningAPIDbContext context)
        {
            Context = context;
        }

        // ADD
        public async Task<Person> Add(Person personToAdd)
        {
            var person = await Context.Persons.AddAsync(personToAdd);
            await Context.SaveChangesAsync();
            return person.Entity;
        }

        // DELETE
        public async Task<Person> Delete(Person personToDelete)
        {
            var person = Context.Persons.FirstOrDefault(p => p.PersonId == personToDelete.PersonId);
            if (person != null)
            {
                Context.Persons.Remove(person);
                await Context.SaveChangesAsync();
            }
            return null;
        }

        // GETS ALL PERSONS
        public async Task<ICollection<Person>> GetAllPerson()
        {
            return await Context.Persons.ToListAsync();
        }

        // GETS ALL PERSONS LINKED TO AN ADRESS ID
        public async Task<ICollection> GetAllPersonsonAdressId(int id)
        {
            var list = (from per in Context.Persons
                        join adr in Context.Adresses
                        on per.AdressId equals adr.AdressId
                        where per.AdressId == id
                        select new
                        {
                            Person = per.FirstName + " " + per.LastName,
                            Adress = adr.GatuNamn

                        }).ToListAsync();

            return await list;
        }

        // GET SINGLE PERSON
        public async Task<Person> GetPerson(int id)
        {
            return await Context.Persons.FirstOrDefaultAsync(p => p.PersonId == id);
        }
        // GETS PERSONS WITH THEIR ADRESS AND SKILL
        public async Task<ICollection> GetPersonwithAdress(int id)
        {
            var list = (from per in Context.Persons
                        where per.PersonId == id
                        join adr in Context.Adresses
                        on per.AdressId equals adr.AdressId
                        join ski in Context.Skills
                        on per.SkillId equals ski.SkillId
                        select new 
                        { 
                            Fullname = per.FirstName + " " + per.LastName,
                            GatuNamn =  adr.GatuNamn,
                            kommun = adr.Kommun,
                            postkod = adr.PostCode,
                            Skill = ski.SkillName

                        }).ToListAsync();

            return await list;
        }
        // SEARCH FUNCTIONS THAT LOOKING ON FIRSTNAME
        public async Task<IEnumerable<Person>> Search(string name)
        {
            IQueryable<Person> query = Context.Persons;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.FirstName.Contains(name));
            }
            return await query.ToListAsync();

        }
        // UPDATES A PERSON
        public async Task<Person> Update(Person personToUpdate)
        {
            var result = await Context.Persons.FirstOrDefaultAsync(p => p.PersonId == personToUpdate.PersonId);
            if (result != null)
            {
                result.FirstName = personToUpdate.FirstName;
                result.LastName = personToUpdate.LastName;
                result.Password = personToUpdate.Password;
                result.ConfirmPassword = personToUpdate.ConfirmPassword;
                result.AdressId = personToUpdate.AdressId;
                result.SkillId = personToUpdate.SkillId;

                await Context.SaveChangesAsync();
            }

            return result;

        }
    }
}
