/**----------------------------------------------------------------------------
 Copyright © 2020 Vincent Gould

Permission is hereby granted, free of charge, to any person obtaining a copy of this 
software and associated documentation files (the “Software”), to deal in the Software 
without restriction, including without limitation the rights to use, copy, modify, 
merge, publish, distribute, sublicense, and/or sell copies of the Software, and to 
permit persons to whom the Software is furnished to do so, subject to the following 
conditions:

The above copyright notice and this permission notice shall be included in all copies or 
substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR 
OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
DEALINGS IN THE SOFTWARE.
 -----------------------------------------------------------------------------*/

using System;

namespace AdapterExample
{
    class Program
    {
        /**
         * Purspose is to demo the Adapter design pattern
         * The target is the StockData interface 
         * the Adaptee is StockDataHTML which provides useful information
         * but is incompatible with client.
         * The Adapter is StockDataAdapter
         * */
        static void Main(string[] args)
        {
            // this is the stock symbol client wants to analyze
            string symbol = "CAT";
            // create an advisor to offer advice
            Advisor advisor = new Advisor();

            /**
             * the first data source is compatible with client
             * */
            IStockData stockData1 = new StockDataJSON();
            // gets the data in an array compatible with Advisor
            StockPrice[] prices1 =  stockData1.GetStockData(symbol);
            Console.WriteLine("The Advisor offers the following recommendation for {0}: {1} from StockDataJSON", symbol, advisor.OfferAdvice(prices1));

            /*
             * the second data source is incompatible with Advisor
             * and needs to use the adapter
             * */
            StockDataHTML stockDataHTML = new StockDataHTML();
            IStockData stockData2 = new StockDataAdapter(stockDataHTML);
            StockPrice[] prices2 =  stockData2.GetStockData(symbol);
            Console.WriteLine("The Advisor offers the following recommendation for {0}: {1} from StockDataHTML", symbol, advisor.OfferAdvice(prices2));
        }
    }
}
