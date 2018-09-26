using Domain.Entities;
using System.Collections.Generic;

namespace Repositories.Interfaces
{
    public interface IPetRepository
    {
        IList<Pet> Get();
        Pet GetById(int id);
        Pet Update(Pet pet);
    }
}
