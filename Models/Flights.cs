using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Airline.Models
{
    public class Flights
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "*Обов'язкове поле!")]
        [DisplayName("Номер рейсу")]
        public string? Namber { get; set; }


        [Required(ErrorMessage = "*Обов'язкове поле!")]
        [DisplayName("Аеропорт вильоту")]
        public string? DepartureAirport { get; set; }


        [Required(ErrorMessage = "*Обов'язкове поле!")]
        [DisplayName("Аеропорт прильоту")]
        public string? ArrivalAirport { get; set; }


        [Required(ErrorMessage = "*Обов'язкове поле!")]
        [DisplayName("Дата відправлення")]
        public string? DepartureDate { get; set; }


        [Required(ErrorMessage = "*Обов'язкове поле!")]
        [DisplayName("Дата прибуття")]
        public string? ArrivalDate { get; set; }


        [Required(ErrorMessage = "*Обов'язкове поле!")]
        [DisplayName("Час відправлення")]
        public string? DepartureTime { get; set; }


        [Required(ErrorMessage = "*Обов'язкове поле!")]
        [DisplayName("Час прибуття")]
        public string? ArrivalTime { get; set; }


        [DisplayName("Авіакомпанія, яка надає послуги")]
        public int AirlinesId { get; set; }

        [ForeignKey("AirlinesId")]
        public virtual Airlines? Airlines { get; set; }
    }
}
