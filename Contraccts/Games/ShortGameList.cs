namespace Contracts.Games
{
    public sealed class ShortGameList
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Category { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
