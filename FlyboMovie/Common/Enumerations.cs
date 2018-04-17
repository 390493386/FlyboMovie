using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Common
{
    public enum UserType
    {
        //游客
        Visitor = 0,
        //注册用户
        Registered = 1,
    }

    public enum BuyOrderStatus
    {
        //购买单已创建
        Created = 0,
        //购买单已确认
        Confirmed = 1,
        //已消费
        Comsumed = 2
    }

    public enum OrderType
    {
        //购买单
        BuyOrder = 0,
        //电影
        Movie = 1,
    }
}
