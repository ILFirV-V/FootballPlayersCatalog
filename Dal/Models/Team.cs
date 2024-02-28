using FootballPlayersCatalog.Core.Dal.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballPlayersCatalog.Dal.Models
{
    [Table("teams")]
    public record class Team : IDalModel<int>
    {
        [Column("Id")]
        [Key]
        public int Id { get; init; }

        [Column("name")]
        public required string Name { get; init; }


        public required IList<FootballPlayer> FootballPlayers { get; init; }
    }
}
