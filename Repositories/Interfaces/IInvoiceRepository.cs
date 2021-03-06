﻿using Domain.Entities;

namespace Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        Invoice GetById(int id);
        Invoice Update(Invoice invoice);
    }
}
