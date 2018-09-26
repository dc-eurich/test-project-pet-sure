using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Repositories.Interfaces;

namespace Repositories
{
    public class PetRepository : IPetRepository
    {
        public static List<Pet> pets = new List<Pet>();
        public PetRepository()
        {
            pets.Add(new Pet() { Id = 1, Name = "Rocky" });
            pets.Add(new Pet() { Id = 2, Name = "Hansel" });
            pets.Add(new Pet() { Id = 3, Name = "Gretel" });
            pets.Add(new Pet() { Id = 4, Name = "Eevie" });
            pets.Add(new Pet() { Id = 5, Name = "Chewy" });

        }
        public IList<Pet> Get()
        {
            return pets;
        }

        public Pet GetById(int id)
        {
            return pets.Where(p => p.IsClaimed != true).First(p => p.Id == id);
        }

        public Pet Update(Pet pet)
        {
            pets[pets.IndexOf(pet)] = pet;
            return pet;
        }
    }
}
