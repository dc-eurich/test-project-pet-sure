using Domain.Entities;
using System.Collections.Generic;

namespace Repositories.Interfaces
{
    public interface IClaimRepository
    {
        IList<Claim> Get();
        Claim Save(Claim claim);
    }
}
