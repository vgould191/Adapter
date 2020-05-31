using System;
using System.Collections.Generic;

namespace AdapterExample
{   
    /**
     * Purpose is to make data from other sources
     * compatible with Advisor
     * */
    class StockDataAdapter : IStockData
    {
        private readonly StockDataHTML _stockDataHTML;

        // Adapter could manage different data sources
        public StockDataAdapter(StockDataHTML stockDataHTML)
        {
            this._stockDataHTML = stockDataHTML;
        }

        // this method just returns a fake array for demo purposes
        public StockPrice[] GetStockData(string symbol)
        {
            // Make a call to class to get data and fix it to meet 
            // contract for Advisor
            var data = _stockDataHTML.GetSomeData(symbol);
            List<StockPrice> stockPrices = new List<StockPrice>();
            Random ran = new Random();
            bool test = true;

            // Manually creating fake StockPrice array for demo
            for (int i = 0; i < 14; i++)
            {
                StockPrice stockPrice = new StockPrice();
                stockPrice.Date = 1549377000;
                stockPrice.High = 16.510000228881836;
                stockPrice.Low = 16.010000228881836;
                stockPrice.Close = 16.139999389648438;
                stockPrice.Volume = 4150300;
                // just to add random variety to results
                var n = ran.NextDouble();
                double randomAdjClose;
                if (test)
                {
                    test = false;
                    randomAdjClose = 16.139999389648438 - (16 * n);
                }
                else
                {
                    test = true;
                    randomAdjClose = 16.139999389648438 + (16 * n);
                }
                stockPrice.AdjClose = randomAdjClose;
                stockPrices.Add(stockPrice);
            }
            StockPrice[] returnPrices = stockPrices.ToArray();
            return returnPrices;
        }
    }
}
