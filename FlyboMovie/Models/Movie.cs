using FlyboMovie.Common;

namespace FlyboMovie.Models
{
    public class Movie : RecordBase<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int LikedCount { get; set; }

        public int CollectedCount { get; set; }

        public string PosterLink { get; set; }

        public string MovieLink1 { get; set; }

        public string MovieLink2 { get; set; }

        public string MovieLink3 { get; set; }

        public int Price { get; set; }

        public int? TrySeconds { get; set; }
    }
}
