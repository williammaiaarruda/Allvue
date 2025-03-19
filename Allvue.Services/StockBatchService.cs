using Allvue.Models;
using Allvue.Data.DAO.Interfaces;
using Allvue.Services.Enums;
using Allvue.Services.Interfaces;

namespace Allvue.Services
{
    public class StockBatchService : IStockBatchService
    {
        private readonly IStockBatchDao _stockBatchDao;

        public StockBatchService(IStockBatchDao stockBatchDao)
        {
            _stockBatchDao = stockBatchDao;
        }

        /// <summary>
        /// Resets the stock batch list to its default state.
        /// This method is only for mock/testing purposes to facilitate development.
        /// </summary>
        public void ResetData()
        {
            _stockBatchDao.ResetData();
        }

        public int GetTotalAvailableStocks()
        {
            return _stockBatchDao.GetAll()
                .Sum(batch => batch.RemainingQuantity);
        }

        public void AddStockBatch(StockBatch stockBatch)
        {
            _stockBatchDao.Add(stockBatch);
        }

        public void UpdateStockBatch(StockBatch stockBatch)
        {
            _stockBatchDao.Update(stockBatch);
        }

        public void DeleteStockBatch(int id)
        {
            _stockBatchDao.Delete(id);
        }

        public StockBatch? GetStockBatchById(int id)
        {
            return _stockBatchDao.GetById(id);
        }

        public IEnumerable<StockBatch> GetAllStockBatches()
        {
            return _stockBatchDao.GetAll();
        }

        public StockBatchSale CalculateSale(StockBatchSaleStrategy strategy, int quantity, decimal price)
        {
            switch (strategy)
            {
                case StockBatchSaleStrategy.FIFO:
                    return CalculateSaleFIFO(quantity, price);
                    break;
                case StockBatchSaleStrategy.LIFO:
                    throw new NotImplementedException("LIFO strategy not implemented");
                default:
                    return CalculateSaleFIFO(quantity, price);
                    break;
            }
        }

        public StockBatchSale CalculateSaleFIFO(int quantity, decimal price)
        {
            var stockBatches = _stockBatchDao.GetAll()
                .OrderBy(sb => sb.AcquisitionDate)
                .ToList();

            int remainingQuantity = quantity;
            decimal totalCost = 0;
            int totalSoldStocks = 0;
            decimal totalProfit = 0;
            decimal remainingStocksCostBasis = 0;

            List<StockBatch> updatedBatches = new List<StockBatch>();

            foreach (var batch in stockBatches)
            {
                if (remainingQuantity <= 0)
                    break;

                if (batch.RemainingQuantity > 0)
                {
                    int sellQuantity = Math.Min(batch.RemainingQuantity, remainingQuantity);
                    decimal costBasis = batch.UnitPrice;

                    totalCost += sellQuantity * costBasis;
                    totalSoldStocks += sellQuantity;
                    totalProfit += sellQuantity * (price - costBasis);

                    batch.RemainingQuantity -= sellQuantity;
                    remainingQuantity -= sellQuantity;
                }

                updatedBatches.Add(batch);
            }

            foreach (var batch in updatedBatches)
            {
                _stockBatchDao.Update(batch);
            }

            var remainingStocks = stockBatches.Where(sb => sb.RemainingQuantity > 0).ToList();
            if (remainingStocks.Any())
            {
                remainingStocksCostBasis = remainingStocks.Average(sb => sb.UnitPrice);
            }

            return new StockBatchSale
            {
                RemainingStocksAfterSale = stockBatches.Sum(sb => sb.RemainingQuantity),
                SoldStocksCostBasis = totalCost / (totalSoldStocks == 0 ? 1 : totalSoldStocks),
                RemainingStocksCostBasis = remainingStocksCostBasis,
                SaleProfitResult = totalProfit
            };
        }
    }
}
