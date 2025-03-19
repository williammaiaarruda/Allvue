namespace Allvue.Services.Enums
{
    /// <summary>
    /// Defines the Stock Batch sale strategy list that will be available over time.
    /// </summary>
    public enum StockBatchSaleStrategy
    {
        /// <summary>
        /// Implemented
        /// </summary>
        FIFO = 1,
        /// <summary>
        /// To be implemented
        /// </summary>
        LIFO = 2, 
        AverageCost = 3,
        LowestTaxExposure = 4, 
        HighestTaxExposure = 5,
        LotBased = 6 
    }
}
