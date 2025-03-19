using System.ComponentModel.DataAnnotations;

namespace Allvue.Models
{
    /// <summary>
    /// Defines the Stock Batch model containing all relevant information related to the shares.
    /// </summary>
    public class StockBatch
    {
        /// <summary>
        /// The acquisition date of the Stock Batch.
        /// </summary>
        [Display(Name = "Acquisition Date")]
        public DateTime AcquisitionDate { get; set; }
        /// <summary>
        /// The id of the Stock Batch.
        /// </summary>
        [Display(Name = "ID")]
        public int Id { get; set; }

        /// <summary>
        /// The initial quantity acquired in the Stock Batch.
        /// </summary>
        [Display(Name = "Initial Quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// The remaining quantity of the Stock Batch available to sell.
        /// </summary>
        [Display(Name = "Remaining Quantity")]
        public int RemainingQuantity { get; set; }

        /// <summary>
        /// The unit price of the Stock Batch.
        /// </summary>
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
    }
}
