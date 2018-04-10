using FlyboMovie.Common;
using System;

namespace FlyboMovie.Models
{
    public class User : RecordBase<string>
    {
        public string Account { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public UserType Type { get; set; }

        public int Points { get; set; }
    }
}
