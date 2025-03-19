using Allvue.Models;
using Allvue.Services.Enums;

namespace Allvue.Services.Interfaces
{
    public interface IStockBatchService
    {
        void ResetData();
        int GetTotalAvailableStocks();
        void AddStockBatch(StockBatch stockBatch);
        void UpdateStockBatch(StockBatch stockBatch);
        void DeleteStockBatch(int id);
        StockBatch? GetStockBatchById(int id);
        IEnumerable<StockBatch> GetAllStockBatches();
        StockBatchSale CalculateSale(StockBatchSaleStrategy strategy, int quantity, decimal price);
    }
}
