using Domain.Entities;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services
{
    public class PetManagementService : IPetManagementService
    {
        private readonly IPetRepository _petRepository;
        public PetManagementService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public IList<Pet> Get()
        {
            return _petRepository.Get();
        }
    }
}
