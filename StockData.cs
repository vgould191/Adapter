namespace AdapterExample
{
    /**
     * The target used by client code
     */
    interface IStockData
    {
        StockPrice[] GetStockData(string symbol);
    }
}
