using ECommerceAPI.Domain.Common;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWave.ECommerce.Domain.Entities
{
    public class InvoiceItem:BaseEntity
    {
        public Guid InvoiceId { get; set; }

        public Invoice Invoice { get; set; } = null!;
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
