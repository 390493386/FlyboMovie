using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Common
{
    public abstract class PageSearch
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public PageSearch()
        {
            PageIndex = 1;
            PageSize = 20;
        }

        public PageSearch(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex > 0 ? pageIndex : 1;
            PageSize = pageSize > 0 ? pageSize : 20;
        }
    }
}
