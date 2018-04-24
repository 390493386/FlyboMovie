using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string MovieNumber { get; set; }
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

    public class MovieLiteDto
    {
        public int Id { get; set; }
        public string MovieNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LikedCount { get; set; }
        public int CollectedCount { get; set; }
        public string PosterLink { get; set; }
        public DateTime RecordCreatedTime { get; set; }
        public int RecordCreatedUser { get; set; }
        public int? TrySeconds { get; set; }
    }
}
