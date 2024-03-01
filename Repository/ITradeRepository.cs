using TradeWebAPI.Models;

namespace TradeWebAPI.Repository
{
	public interface ITradeRepository
	{
		Task<IEnumerable<Trade>> GetAllTrades();
		Task<Trade> GetTradeById(int id);
		Task<int> AddTrade(Trade trade);
		Task UpdateTrade(int id, Trade trade);
		Task DeleteTrade(int id);
	}
}
