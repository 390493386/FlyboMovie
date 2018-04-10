using FlyboMovie.Common;

namespace FlyboMovie.Models
{
    public class UserRole : RecordBase<int>
    {
        public string UserId { get; set; }

        public int RoleId { get; set; }
    }
}
