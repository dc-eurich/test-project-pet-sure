using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Claim
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int InvoiceId { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
