using System;

namespace Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public int PetId { get; set; }
        public bool IsUsed { get; set; } //Flag to check if invoice is still valid. Will be set to false when invoice has already been used to claim.
    }
}
