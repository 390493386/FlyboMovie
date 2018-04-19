using FlyboMovie.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.ViewModels
{
    public class MovieSearchCriteria : PageSearch
    {
        public MovieSearchCriteria()
            : base(1, 20)
        {
        }

        public MovieSearchCriteria(int pageIndex, int pageSize)
            : base(pageIndex, pageSize)
        {
        }

        public string MovieName { get; set; }
    }
}
