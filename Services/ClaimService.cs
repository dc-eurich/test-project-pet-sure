using Domain.Entities;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services
{
    public class ClaimService : IClaimService
    {
        private readonly IPetRepository _petRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IClaimRepository _claimRepository;

        public ClaimService(IPetRepository petRepository, IInvoiceRepository invoiceRepository, IClaimRepository claimRepository)
        {
            _petRepository = petRepository;
            _invoiceRepository = invoiceRepository;
            _claimRepository = claimRepository;
        }
        public bool ProcessClaim(int petId, int invoiceId)
        {
            var pet = _petRepository.GetById(petId);

            if(pet == null)
            {
                throw new InvalidOperationException("Invalid pet for claim!");
            }

            var invoice = _invoiceRepository.GetById(invoiceId);

            if(invoice == null)
            {
                throw new InvalidOperationException("Invalid invoice for claim!");
            }

            _claimRepository.Save(new Claim() { PetId = petId, InvoiceId = invoiceId, TransactionDate = DateTime.Now });

            pet.IsClaimed = true;
            _petRepository.Update(pet);

            return true;
        }

        public IList<Claim> Get()
        {
            return _claimRepository.Get();
        }
    }
}
