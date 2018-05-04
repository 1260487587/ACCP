using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 网络电视精灵
{
    /// <summary>
    /// 节目单父类
    /// </summary>
    public abstract class ChannelBase
    {
        //频道名称
        public string ChannelName { get; set; }
        //频道路径
        public string Path { get; set; }
        //节目列表，该频道上的所有节目列表
        public List<TvProgram> TvList { get; set; }
        //获取频道列表，通过Fetch方法获取所有的节目列表
        public abstract void Fetch();

        public ChannelBase() { }
        public ChannelBase(string channelName,string path,List<TvProgram> list)
        {
            this.ChannelName = channelName;
            this.Path = path;
            this.TvList = list;
        }
    }
}
