using Microsoft.EntityFrameworkCore;
using TradeWebAPI.Data;
using TradeWebAPI.Models;

namespace TradeWebAPI.Repository
{
	public class TradeRepository : ITradeRepository
	{
		private readonly ApplicationDbContext _context;

		public TradeRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Trade>> GetAllTrades()
		{
			return await _context.Trades.ToListAsync();
		}

		public async Task<Trade> GetTradeById(int id)
		{
			return await _context.Trades.FindAsync(id);
		}

		public async Task<int> AddTrade(Trade trade)
		{
			_context.Trades.Add(trade);
			await _context.SaveChangesAsync();
			return trade.Id;
		}

		public async Task UpdateTrade(int id, Trade trade)
		{
			_context.Entry(trade).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteTrade(int id)
		{
			var trade = await _context.Trades.FindAsync(id);
			if (trade != null)
			{
				_context.Trades.Remove(trade);
				await _context.SaveChangesAsync();
			}
		}
	}
}
