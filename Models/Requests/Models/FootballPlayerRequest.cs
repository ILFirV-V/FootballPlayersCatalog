using FootballPlayersCatalog.Attributes;
using FootballPlayersCatalog.Dal.Enums;
using FootballPlayersCatalog.Models.Requests.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FootballPlayersCatalog.Controllers.Models
{
    public class FootballPlayerRequest : IFootballPlayerRequest
    {
        [NameValidation]
        [Required(ErrorMessage = "Имя обязательно для заполнения")]
        public required string FirstName { get; init; }

        [NameValidation]
        [Required(ErrorMessage = "Фамилия обязательна для заполнения")]
        public required string LastName { get; init; }

        [Required(ErrorMessage = "Пол обязателен для заполнения")]
        public Gender Gender { get; init; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Дата рождения обязательна для заполнения")]
        public DateOnly Birthday { get; init; }

        [Required(ErrorMessage = "Идентификатор команды обязателен для заполнения")]
        public int TeamId { get; init; }

        [Required(ErrorMessage = "Идентификатор страны обязателен для заполнения")]
        public int CountryId { get; init; }
    }
}
