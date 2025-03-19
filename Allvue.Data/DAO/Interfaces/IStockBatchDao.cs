using Allvue.Models;

namespace Allvue.Data.DAO.Interfaces
{
    public interface IStockBatchDao
    {
        void ResetData();
        void Add(StockBatch stockBatch);
        void Update(StockBatch stockBatch);
        void Delete(int id);
        StockBatch? GetById(int id);
        IEnumerable<StockBatch> GetAll();
    }
}
