namespace Allvue.Services.Enums
{
    /// <summary>
    /// Defines the Stock Batch sale strategy list that will be available over time.
    /// </summary>
    public enum StockBatchSaleStrategy
    {
        FIFO = 1, //Implemented
        LIFO = 2, //To be implemented
        AverageCost = 3, //To be implemented
        LowestTaxExposure = 4, //To be implemented
        HighestTaxExposure = 5, //To be implemented
        LotBased = 6 //To be implemented
    }
}
