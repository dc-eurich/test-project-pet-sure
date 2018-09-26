using Domain.Entities;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IPetManagementService
    {
        IList<Pet> Get();
    }
}
