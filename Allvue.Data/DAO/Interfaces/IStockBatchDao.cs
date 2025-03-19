using Allvue.Models;

namespace Allvue.Data.DAO.Interfaces
{
    /// <summary>
    /// Defines the Dao Stock Batch interface .
    /// </summary>
    public interface IStockBatchDao
    {
        void Add(StockBatch stockBatch);
        void Delete(int id);
        StockBatch? GetById(int id);
        IEnumerable<StockBatch> GetAll();
        void ResetData();
        void Update(StockBatch stockBatch);
    }
}
