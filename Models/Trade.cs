using System.ComponentModel.DataAnnotations;

namespace TradeWebAPI.Models
{
	public class Trade
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "O campo Value é obrigatório.")]
		[Range(0, double.MaxValue, ErrorMessage = "O campo Value deve ser um número positivo.")]
		public double Value { get; set; }

		[Required(ErrorMessage = "O campo ClientSector é obrigatório.")]
		public string ClientSector { get; set; }
	}
}
