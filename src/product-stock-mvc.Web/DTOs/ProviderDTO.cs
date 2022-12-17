using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace product_stock_mvc.Web.DTOs
{
    public class ProviderDTO
    {
        [Key]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "The field {0} cannot be empty")]
        [StringLength(225, ErrorMessage = "The length of the field {0} must be {2} to {1} characters", MinimumLength = 3)]
        public string Name { get; set; }


        [Required(ErrorMessage = "The field {0} cannot be empty")]
        [StringLength(14, ErrorMessage = "The length of the field {0} must be {1} characters", MinimumLength = 14)]
        public string Document { get; set; }


        [ScaffoldColumn(false)]
        public DateTime CreatedOn { get; set; }


        [Required(ErrorMessage = "The field {0} cannot be empty")]
        [DisplayName("Type")]
        public int ProviderType { get; set; }


        [Required(ErrorMessage = "The field {0} cannot be empty")]
        [DisplayName("Active?")]
        public bool IsActive { get; set; }


        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
