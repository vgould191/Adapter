
using System;

namespace AdapterExample
{
    /**
     * This is a sample class with a single method
     * it takes and array of stock prices
     * and recommends if the stock should be purchased
     * */
    class Advisor
    {
        public string OfferAdvice(StockPrice[] stockPrices)
        {
            double indicator = 0.00;

            for(int i = 1; i< stockPrices.Length; i++)
            {
                indicator += stockPrices[i].AdjClose - stockPrices[i - 1].AdjClose;
            }
            
            if(indicator>0)
            {
                return "Buy";
            }
            else
            {
                return "Do not buy";
            }
        }
    }
}
