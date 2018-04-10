using FlyboMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Data.Repository.Implement
{
    public class BuyOrderRepository : RecordRepositoryBase<int, BuyOrder>, IBuyOrderRepository
    {
        public BuyOrderRepository(AppDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
