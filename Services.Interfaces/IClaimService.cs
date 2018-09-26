using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IClaimService
    {
        bool ProcessClaim(int petId, int invoiceId);
        IList<Claim> Get();
    }
}
