namespace AdapterExample
{
    class StockDataHTML
    {
        // this is a demo class that doesn't call data
        // it is used as an example for Adapter patter as it doesn't return StockPrice[]
        // this is the Adaptee class
        public string GetSomeData(string stockSymbol)
        {
            return "nonsense text here for demo purpose only";
        }
    }
}
