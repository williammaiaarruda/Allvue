using Allvue.Models;

namespace Allvue.Data.Context
{
    public class AllvueDbContext
    {
        public IList<StockBatch> StockBatches { get; set; } = new List<StockBatch>();
    }
}
