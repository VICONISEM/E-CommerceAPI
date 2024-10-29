using System.ComponentModel.DataAnnotations;

namespace Store.Service.Services.Basket.DTO
{
    public class BasketItemDto
    {
        [Required]
        [Range(0, int.MaxValue)]    
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(0.1,double.MaxValue,ErrorMessage ="Price must be Greater than zero")]
        public decimal Price { get; set; }

        [Required]
        [Range(1,10, ErrorMessage = "Quantity must be Greater than zero")]
        public int Quantity { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string BrandName { get; set; }

        [Required]
        public string TypeName { get; set; }


    }
}