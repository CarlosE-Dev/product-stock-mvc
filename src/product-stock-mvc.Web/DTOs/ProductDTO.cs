using product_stock_mvc.Web.Extensions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace product_stock_mvc.Web.DTOs
{
    public class ProductDTO
    {
        [Key]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "The field {0} cannot be empty")]
        [StringLength(500, ErrorMessage = "The length of the field {0} must be {2} to {1} characters", MinimumLength = 3)]
        public string Name { get; set; }


        [ScaffoldColumn(false)]
        public DateTime CreatedOn { get; set; }


        [Required(ErrorMessage = "The field {0} cannot be empty")]
        [DisplayName("Active?")]
        public bool IsActive { get; set; }


        [Required(ErrorMessage = "The field {0} cannot be empty")]
        [StringLength(500, ErrorMessage = "The length of the field {0} must be {2} to {1} characters", MinimumLength = 20)]
        public string Description { get; set; }

        [DisplayName("Image")]
        public IFormFile ImageUpload { get; set; }


        public string Image { get; set; }


        [Required(ErrorMessage = "The field {0} cannot be empty")]
        [Currency]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "The field {0} cannot be empty")]
        [DisplayName("In stock")]
        public long QuantityInStock { get; set; }


        public ProviderDTO Provider { get; set; }



        [Required(ErrorMessage = "The field {0} cannot be empty")]
        [DisplayName("Provider")]
        public Guid ProviderId { get; set; }


        public IEnumerable<ProviderDTO> Providers { get; set; }
    }
}
