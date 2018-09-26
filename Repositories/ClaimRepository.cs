using Domain.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public class ClaimRepository : IClaimRepository
    {
        public static List<Claim> claims = new List<Claim>();
        public Claim Save(Claim claim)
        {
            claims.Add(claim);

            return claim;
        }

        public IList<Claim> Get()
        {
            return claims;
        }
    }
}
