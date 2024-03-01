using System.Diagnostics;
using TradeWebAPI.Models;

namespace TradeWebAPI.Services
{
	public interface ITradeCategorizationService
	{
		List<TradeCategory> CategorizeTrades(List<ITrade> trades);

	}
}
