using Allvue.Models;
using Allvue.Services.Enums;

namespace Allvue.Services.Interfaces
{
    /// <summary>
    /// Defines the Stock Batch Service interface .
    /// </summary>
    public interface IStockBatchService
    {
        void AddStockBatch(StockBatch stockBatch);
        StockBatchSale CalculateSale(StockBatchSaleStrategy strategy, int quantity, decimal price);
        void DeleteStockBatch(int id);
        IEnumerable<StockBatch> GetAllStockBatches();
        StockBatch? GetStockBatchById(int id);
        int GetTotalAvailableStocks();
        void ResetData();
        void UpdateStockBatch(StockBatch stockBatch);
    }
}
