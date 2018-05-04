using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 网络电视精灵
{
    /// <summary>
    /// 节目单实体
    /// </summary>
    public class TvProgram
    {
        //播出时间
        public DateTime PlayTime{ get; set; }
        //早间档，午间档，晚间档
        public string ShiDuan { get; set; }
        //节目名称
        public string Name { get; set; }
        //视频路径
        public string Path { get; set; }
    }
}
