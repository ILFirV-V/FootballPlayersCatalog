namespace FootballPlayersCatalog.Core.Dal.Interfaces
{
    public interface IDalModel<TType>
    {
        /// <summary>
        /// Уникальный id 
        /// </summary>
        public TType Id { get; init; }
    }
}
