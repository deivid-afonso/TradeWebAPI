using System.Diagnostics;
using TradeWebAPI.Models;

namespace TradeWebAPI.Services
{
	public class TradeCategorizationService : ITradeCategorizationService
	{
		public List<TradeCategory> CategorizeTrades(List<ITrade> trades)
		{
			var categories = new List<TradeCategory>();
			foreach (var trade in trades)
			{
				if (trade.Value < 1000000 && trade.ClientSector == "Public")
					categories.Add(TradeCategory.LOWRISK);
				else if (trade.Value >= 1000000 && trade.ClientSector == "Public")
					categories.Add(TradeCategory.MEDIUMRISK);
				else if (trade.Value >= 1000000 && trade.ClientSector == "Private")
					categories.Add(TradeCategory.HIGHRISK);
				else
					categories.Add(TradeCategory.LOWRISK); 
			}
			return categories;
		}
	}
}
