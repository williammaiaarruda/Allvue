using System.ComponentModel.DataAnnotations;

namespace Allvue.Models
{
    public class StockBatchSale
    {
        /// <summary>
        /// The remaining number of shares after the sale 
        /// </summary>
        [Display(Name = "Remaining shares after sale")]
        public int RemainingStocksAfterSale { get; set; }

        /// <summary>
        /// The cost basis per share of the sold shares
        /// </summary>
        [Display(Name = "Cost basis per sold share")]
        public decimal SoldStocksCostBasis { get; set; }

        /// <summary>
        /// The cost basis per share of the remaining shares after the sale
        /// </summary>
        [Display(Name = "Cost basis per remaining share")]
        public decimal RemainingStocksCostBasis { get; set; }

        /// <summary>
        /// The total profit or loss of the sale
        /// </summary>
        [Display(Name = "Sale Result")]
        public decimal SaleProfitResult { get; set; }
    }
}