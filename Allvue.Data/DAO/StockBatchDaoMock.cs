using Allvue.Data.DAO.Interfaces;
using Allvue.Models;

namespace Allvue.Data.DAO
{
    /// <summary>
    /// Provides stock batch mock data operations.
    /// </summary>
    public class StockBatchDaoMock : IStockBatchDao
    {
        /// <summary>
        /// Initializes the stock batch list with a sample of stock shares acquired at first.
        /// This method is only for development purposes, in the future a database will be integrated .
        /// </summary>
        private static List<StockBatch> _stockBatches = new()
        {
            new StockBatch { Id = 1, Quantity = 100, RemainingQuantity = 100, UnitPrice = 20, AcquisitionDate = new DateTime(2025, 01, 01)},
            new StockBatch { Id = 2, Quantity = 150, RemainingQuantity = 150, UnitPrice = 30, AcquisitionDate = new DateTime(2025, 02, 01)},
            new StockBatch { Id = 3, Quantity = 120, RemainingQuantity = 120, UnitPrice = 10, AcquisitionDate = new DateTime(2025, 03, 01)}
        };

        /// <summary>
        /// Adds a stock batch to the stocks list.
        /// </summary>
        public void Add(StockBatch stockBatch)
        {
            stockBatch.Id = _stockBatches.Any() ? _stockBatches.Max(s => s.Id) + 1 : 1;
            _stockBatches.Add(stockBatch);
        }

        /// <summary>
        /// Deletes a stock batch from the stocks list.
        /// </summary>
        public void Delete(int id)
        {
            var stockBatch = _stockBatches.FirstOrDefault(s => s.Id == id);
            if (stockBatch != null)
            {
                _stockBatches.Remove(stockBatch);
            }
        }

        /// <summary>
        /// Gets a stock batch from the stocks list using its Id.
        /// </summary>
        public StockBatch? GetById(int id)
        {
            return _stockBatches.FirstOrDefault(s => s.Id == id);
        }

        /// <summary>
        /// Gets all stock batches from the stocks list.
        /// </summary>
        public IEnumerable<StockBatch> GetAll()
        {
            return _stockBatches;
        }

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

        /// <summary>
        /// Updates a stock batch in the stocks list.
        /// </summary>
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
    }
}
