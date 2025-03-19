using Allvue.Services.Enums;
using System.ComponentModel.DataAnnotations;

namespace Allvue.Models
{
    /// <summary>
    /// Defines the Calculate Sale model containing all relevant information related to a sale.
    /// </summary>
    public class CalculateSaleViewModel
    {
        /// <summary>
        /// The Stock Batch sale price.
        /// </summary>
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        [Display(Name = "Price per Unit")]
        public decimal Price { get; set; }

        /// <summary>
        /// The Stock Batch sale quantity.
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// The Stock Batch sale strategy.
        /// </summary>
        [Required(ErrorMessage = "Please select a sale strategy.")]
        [Display(Name = "Sale Strategy")]
        public StockBatchSaleStrategy? Strategy { get; set; }

    }
}
