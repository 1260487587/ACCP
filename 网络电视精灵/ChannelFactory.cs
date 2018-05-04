using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 网络电视精灵
{
    /// <summary>
    /// 简单工厂，根据入参类型，返回对应的子类对象
    /// </summary>
    public class ChannelFactory
    {
        //通过工厂创建频道子类
        public static ChannelBase CreateChannel(string type)
        {
            ChannelBase channel = null;
            switch (type)
            {
                case "TypeA":
                    channel = new TypeAChannel();
                    break;
                case "TypeB":
                    channel = new TypeBChannel();
                    break;
            }
            return channel;
        }
    }
}
