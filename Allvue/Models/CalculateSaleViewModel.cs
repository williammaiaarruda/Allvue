using Allvue.Services.Enums;
using System.ComponentModel.DataAnnotations;

namespace Allvue.Models
{
    public class CalculateSaleViewModel
    {
        [Required(ErrorMessage = "Please select a sale strategy.")]
        [Display(Name = "Sale Strategy")]
        public StockBatchSaleStrategy? Strategy { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        [Display(Name = "Price per Unit")]
        public decimal Price { get; set; }
    }
}
