namespace AppWave.ECommerce.Business.DTOs
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public List<InvoiceItemDto> Items { get; set; }
    }

    public class CreateInvoiceDto
    {
        public Guid UserId { get; set; }
        public List<CreateInvoiceItemDto> Items { get; set; }
    }

    public class UpdateInvoiceDto
    {
        public string Status { get; set; }
        public List<CreateInvoiceItemDto> Items { get; set; }
    }

    public class InvoiceItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class CreateInvoiceItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
} 