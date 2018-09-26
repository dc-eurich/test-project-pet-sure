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
            // Validate if pet exists or is available for claim
            var pet = _petRepository.GetById(petId);

            if(pet != null)
            {
                pet.IsClaimed = true;
                _petRepository.Update(pet);
            }
            else
            {
                throw new InvalidOperationException("Invalid pet for claim!");
            }

            // Validate if invoice exists or is still available to be used for claim
            var invoice = _invoiceRepository.GetById(invoiceId);

            if(invoice != null)
            {
                invoice.IsUsed = false;
                _invoiceRepository.Update(invoice);
            }
            else
            {
                throw new InvalidOperationException("Invalid invoice for claim!");
            }

            _claimRepository.Save(new Claim() { PetId = pet.Id, InvoiceId = invoiceId, TransactionDate = DateTime.Now });

            return true;
        }

        public IList<Claim> Get()
        {
            return _claimRepository.Get();
        }
    }
}
