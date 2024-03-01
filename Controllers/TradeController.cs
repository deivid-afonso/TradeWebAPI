using Microsoft.AspNetCore.Mvc;
using TradeWebAPI.Models;
using TradeWebAPI.Repository;
using TradeWebAPI.Services;

namespace TradeWebAPI.Controllers
{
	// TradeController.cs
	[ApiController]
	[Route("api/[controller]")]
	public class TradeController : ControllerBase
	{
		private readonly ITradeRepository _tradeRepository;

		public TradeController(ITradeRepository tradeRepository)
		{
			_tradeRepository = tradeRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Trade>>> GetAllTrades()
		{
			var trades = await _tradeRepository.GetAllTrades();
			return Ok(trades);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Trade>> GetTradeById(int id)
		{
			var trade = await _tradeRepository.GetTradeById(id);
			if (trade == null)
			{
				return NotFound();
			}
			return Ok(trade);
		}

		[HttpPost]
		public async Task<ActionResult<int>> AddTrade(Trade trade)
		{
			var id = await _tradeRepository.AddTrade(trade);
			return Ok(id);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateTrade(int id, Trade trade)
		{
			if (id != trade.Id)
			{
				return BadRequest();
			}
			await _tradeRepository.UpdateTrade(id, trade);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTrade(int id)
		{
			await _tradeRepository.DeleteTrade(id);
			return NoContent();
		}
	}


}
