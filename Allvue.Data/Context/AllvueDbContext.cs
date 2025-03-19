using Allvue.Models;

namespace Allvue.Data.Context
{
    /// <summary>
    /// Defines the Stock Batch DB Context interface to be used in future to integrated with a Database.
    /// </summary>
    public class AllvueDbContext
    {
        public IList<StockBatch> StockBatches { get; set; } = new List<StockBatch>();
    }
}
