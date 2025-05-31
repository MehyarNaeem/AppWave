using AppWave.ECommerce.Domain.Common;
using System;

namespace AppWave.ECommerce.Domain.Entities
{
    public class InvoiceDetail : BaseEntity
    {
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public Product Product { get; set; }
    }
} 