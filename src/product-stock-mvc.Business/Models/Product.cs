namespace product_stock_mvc.Business.Models
{
    public class Product : BaseEntity
    {
        public Guid ProviderId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public long QuantityInStock { get; set; }
        public Provider Provider { get; set; }
    }
}
