using FootballPlayersCatalog.Dal.Enums;
using FootballPlayersCatalog.Core.Dal.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FootballPlayersCatalog.Dal.Models
{
    [Table("players")]
    public record class FootballPlayer : IDalModel<int>
    {
        [Column("Id")]
        [Key]
        public int Id { get; init; }

        [Column("firstname")]
        public required string FirstName { get; init; }

        [Column("lastname")]
        public required string LastName { get; init; }

        [Column("gender")]
        public Gender Gender { get; init; }

        [Column("birthday")]
        public DateOnly Birthday { get; init; }

        [Column("teamid")]
        public int TeamId { get; init; }

        [ForeignKey(nameof(TeamId))]
        public Team Team { get; init; }

        [Column("countryid")]
        public int CountryId { get; init; }

        [ForeignKey(nameof(CountryId))]
        public Country Country { get; init; }
    }
}
