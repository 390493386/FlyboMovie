using System;

namespace FlyboMovie.Common
{
    public abstract class RecordBase<TId>
        where TId : IEquatable<TId>
    {
        public TId Id { get; set; }

        public DateTime RecordCreatedTime { get; set; }

        public int RecordCreatedUser { get; set; }

        public DateTime? RecordUpdatedTime { get; set; }

        public int? RecordUpdatedUser { get; set; }

        public bool IsInactive { get; set; } = false;
    }
}
