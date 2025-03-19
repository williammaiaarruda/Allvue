using System.ComponentModel.DataAnnotations;

namespace Allvue.Models
{
    public class StockBatch
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        
        [Display(Name = "Initial Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Remaining Quantity")]
        public int RemainingQuantity { get; set; }

        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Acquisition Date")]
        public DateTime AcquisitionDate { get; set; }
    }
}
