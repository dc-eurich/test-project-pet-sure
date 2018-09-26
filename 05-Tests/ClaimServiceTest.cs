using Domain.Entities;
using Moq;
using Repositories;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class ClaimServiceTest
    {
        private IList<Pet> pets = new List<Pet>()
        {
            new Pet() { Id = 1, Name = "Rocky", IsClaimed = false },
            new Pet() { Id = 2, Name = "Hansel", IsClaimed = false },
            new Pet() { Id = 3, Name = "Gretel", IsClaimed = false },
            new Pet() { Id = 4, Name = "Eevie", IsClaimed = false },
            new Pet() { Id = 5, Name = "Chewy", IsClaimed = false },
        };

        private IList<Invoice> invoices = new List<Invoice>()
        {
            new Invoice() { Id = 1, PetId = 1, IsUsed = false, TransactionDate = new DateTime(2018, 09, 25) },
            new Invoice() { Id = 2, PetId = 2, IsUsed = false, TransactionDate = new DateTime(2018, 09, 24) }
        };

        private IList<Claim> claims = new List<Claim>() { };

        [Fact]
        public void TestValidClaimByValidPetIdAndInvoiceId()
        {
            var pet = new Pet() { Id = 1 };
            // Validate if supplied PetId is valid
            var petRepoMock = new Mock<IPetRepository>();
            // Assume that it's valid
            petRepoMock.Setup(pr => pr.GetById(pet.Id)).Returns(pet = pets.First(p => p.Id == pet.Id));
            // Tag pet as claimed
            pet.IsClaimed = true;
            petRepoMock.Setup(pr => pr.Update(pet)).Returns(pets[pets.IndexOf(pet)] = pet);

            var invoice = new Invoice() { Id = 1};
            // Validate if supplied InvoiceId is valid
            var invoiceRepoMock = new Mock<IInvoiceRepository>();
            // Assume that it's valid
            invoiceRepoMock.Setup(ir => ir.GetById(invoice.Id)).Returns(invoice = invoices.First(i => i.Id == invoice.Id));
            // Tag invoice as used for claim
            invoice.IsUsed = true;
            invoiceRepoMock.Setup(ir => ir.Update(invoice)).Returns(invoices[invoices.IndexOf(invoice)] = invoice);

            // Mock successful insert of Claim
            var claimRepoMock = new Mock<IClaimRepository>();
            var claim = new Claim() { Id = 1, InvoiceId = invoice.Id, PetId = pet.Id, TransactionDate = DateTime.Now };
            claimRepoMock.Setup(cr => cr.Save(claim)).Returns(claim);
            claims.Add(claim);

            Assert.NotEmpty(claims);
            Assert.True(petRepoMock.Object.GetById(pet.Id).IsClaimed);
            Assert.True(invoiceRepoMock.Object.GetById(invoice.Id).IsUsed);
        }
    }
}
