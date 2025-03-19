using Allvue.Data.DAO.Interfaces;
using Allvue.Models;

namespace Allvue.Data.DAO
{
    public class StockBatchDaoMock : IStockBatchDao
    {
        private static List<StockBatch> _stockBatches = new()
        {
            new StockBatch { Id = 1, Quantity = 100, RemainingQuantity = 100, UnitPrice = 20, AcquisitionDate = new DateTime(2025, 01, 01)},
            new StockBatch { Id = 2, Quantity = 150, RemainingQuantity = 150, UnitPrice = 30, AcquisitionDate = new DateTime(2025, 02, 01)},
            new StockBatch { Id = 3, Quantity = 120, RemainingQuantity = 120, UnitPrice = 10, AcquisitionDate = new DateTime(2025, 03, 01)}
        };

        /// <summary>
        /// Resets the stock batch list to its default state.
        /// This method is only for mock/testing purposes to facilitate development.
        /// </summary>
        public void ResetData()
        {
            _stockBatches = new()
            {
                new StockBatch { Id = 1, Quantity = 100, RemainingQuantity = 100, UnitPrice = 20, AcquisitionDate = new DateTime(2025, 01, 01)},
                new StockBatch { Id = 2, Quantity = 150, RemainingQuantity = 150, UnitPrice = 30, AcquisitionDate = new DateTime(2025, 02, 01)},
                new StockBatch { Id = 3, Quantity = 120, RemainingQuantity = 120, UnitPrice = 10, AcquisitionDate = new DateTime(2025, 03, 01)}
            };
        }

        public void Add(StockBatch stockBatch)
        {
            stockBatch.Id = _stockBatches.Any() ? _stockBatches.Max(s => s.Id) + 1 : 1;
            _stockBatches.Add(stockBatch);
        }

        public void Update(StockBatch stockBatch)
        {
            var existing = _stockBatches.FirstOrDefault(s => s.Id == stockBatch.Id);
            if (existing != null)
            {
                existing.Quantity = stockBatch.Quantity;
                existing.UnitPrice = stockBatch.UnitPrice;
                existing.AcquisitionDate = stockBatch.AcquisitionDate;
            }
        }

        public void Delete(int id)
        {
            var stockBatch = _stockBatches.FirstOrDefault(s => s.Id == id);
            if (stockBatch != null)
            {
                _stockBatches.Remove(stockBatch);
            }
        }

        public StockBatch? GetById(int id)
        {
            return _stockBatches.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<StockBatch> GetAll()
        {
            return _stockBatches;
        }
    }
}
