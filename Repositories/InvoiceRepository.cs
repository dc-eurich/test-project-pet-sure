﻿using Domain.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public static List<Invoice> invoices = new List<Invoice>();

        public InvoiceRepository()
        {
            invoices.Add(new Invoice() { Id = 1, IsValid = true, PetId = 5, TransactionDate = DateTime.Now.AddDays(-1) });
            invoices.Add(new Invoice() { Id = 2, IsValid = true, PetId = 3, TransactionDate = DateTime.Now.AddDays(-1) });
        }

        public Invoice GetById(int id)
        {
            return invoices.First(i => i.Id == id);
        }
    }
}
