#region References

using System;

#endregion

namespace ExampleForKevin.Data
{
    public class StockMarketStuff
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool? MutualFund { get; set; }

        public string Note { get; set; }

        public int StockMarketStuffId { get; set; }

        public string TickerSymbol { get; set; }
    }
}