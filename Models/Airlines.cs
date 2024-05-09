using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Airline.Models
{
	public class Airlines
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "*Обов'язкове поле!")]
		[DisplayName("Назва авіакомпанії")]
		public string? Name { get; set; }

		[Required(ErrorMessage = "*Обов'язкове поле!")]
		[DisplayName("Країна, де авіакомпанія базується")]
		public string? NameCountry { get; set; }

		[Required(ErrorMessage = "*Обов'язкове поле!")]
		[DisplayName("Порядок відображення")]
		[Range(1, int.MaxValue, ErrorMessage = "Значення порядку відображення повинно бути більше нуля!")]
		public int DisplayOrder { get; set; }
	}
}
