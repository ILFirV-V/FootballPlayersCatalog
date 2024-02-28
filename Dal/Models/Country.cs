using FootballPlayersCatalog.Core.Dal.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FootballPlayersCatalog.Dal.Models
{
    [Table("countries")]
    public record class Country : IDalModel<int>
    {
        [Column("Id")]
        [Key]
        public required int Id { get; init; }

        [Column("name")]
        public required string Name { get; init; }

        public IList<FootballPlayer> FootballPlayers { get; init; }
    }
}
