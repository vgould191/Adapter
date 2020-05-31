using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;

namespace AdapterExample
{
    /**
     * This class actually calls a data source to return real data
     * */
    class StockDataJSON : IStockData
    {
        /**
         * create a free account and subscribe to Yahoo Finance API to get a key
         * https://rapidapi.com/
         * Register for free account
         * Subscribe to Yahoo Finance feed
         * */
        private const string _API_Key = "";
        public StockPrice[] GetStockData(string symbol)
        {
            // this could be expanded to allow user to request custom date range
            Int64[] dates = GetDates();

            // gets response from API call
            IRestResponse response = GetResponse(dates[0], dates[1], symbol);

            // extracts just the price data from API call
            JToken jToken = GetToken(response, "prices");

            // Converts JToken to necessary array
            StockPrice[] stockPrices = GetStockPrices(jToken);

            return stockPrices;
        }

        // send the JToken and the desired object to create
        private StockPrice[] GetStockPrices(JToken jToken)
        {
            List<StockPrice> stockPrices = new List<StockPrice>();
            foreach (JToken j in jToken)
            {
                StockPrice stockPrice = j.ToObject<StockPrice>();
                stockPrices.Add(stockPrice);
            }
            return stockPrices.ToArray();
        }

        // this method is used to get an object or array of objects from the response
        private JToken GetToken(IRestResponse response, string tokenValue)
        {
            JObject jObject = JObject.Parse(response.Content);
            JToken tokPrices = jObject.GetValue("prices");
            return tokPrices;
        }

        private IRestResponse GetResponse(Int64 startDate, Int64 endDate, string symbol)
        {
            // using open source RestSharp to make Json Rest API call
            IRestResponse response = null;
            var client = new RestClient(String.Format("https://apidojo-yahoo-finance-v1.p.rapidapi.com/" +
                "stock/v2/get-historical-data?frequency=1d&filter=history&period1={0}&period2={1}&symbol" +
                "={2}", startDate, endDate, symbol));
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "apidojo-yahoo-finance-v1.p.rapidapi.com");

            request.AddHeader("x-rapidapi-key", _API_Key);
            try
            {
                response = client.Execute(request);
            }
            catch (Exception e)
            {
                Console.WriteLine("There has been an error processing the data from RapidAPI. \n " +
                    "First check that you have a valid API Key which is available for free from rapidapi.com \n" +
                    "{0}\n{1}", e.GetType(), e.Message);
            }
            return response;
        }

        // Returns start and end dates for API call date range.
        // Todo: allow user to provide start and end dates
        private Int64[] GetDates()
        {
            Int64[] dates = new Int64[2];

            // get historical prices for last 14 days
            DateTimeOffset dtoEnd = new DateTimeOffset(DateTime.Now.AddDays(-1));
            dates[1] = dtoEnd.ToUnixTimeSeconds();

            DateTimeOffset dtoStart = new DateTimeOffset(DateTime.Now.AddDays(-15));
            dates[0] = dtoStart.ToUnixTimeSeconds();

            return dates;
        }
    }
}
