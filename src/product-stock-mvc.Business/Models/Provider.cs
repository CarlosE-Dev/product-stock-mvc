using product_stock_mvc.Business.Models.Enums;

namespace product_stock_mvc.Business.Models
{
    public class Provider : BaseEntity
    {
        public string Document { get; set; }
        public ProviderType ProviderType { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
