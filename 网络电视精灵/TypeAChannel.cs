using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace 网络电视精灵
{
    /// <summary>
    /// 北京电视台
    /// </summary>
    public class TypeAChannel : ChannelBase
    {
        public TypeAChannel() { }
        public TypeAChannel(string channelName, string path, List<TvProgram> list)
            : base(channelName, path, list)
        {
        }
        public override void Fetch()
        {
            this.Path = ChannelManager.bases["北京电视台"].Path;
            XmlDocument doc = new XmlDocument();
            doc.Load(Path);
            XmlNode root = doc.DocumentElement;
            TvList = new List<TvProgram>();
            foreach (XmlNode item in root.ChildNodes)
            {
                if (item.Name == "tvProgramTable")
                {
                    foreach (XmlNode node in item.ChildNodes)
                    {
                        TvProgram tvProgram = new TvProgram();
                        tvProgram.Name = node["programName"].InnerText;
                        tvProgram.Path = node["path"].InnerText;
                        tvProgram.PlayTime = Convert.ToDateTime(node["playTime"].InnerText);
                        tvProgram.ShiDuan = node["meridien"].InnerText;
                        this.TvList.Add(tvProgram);
                    }
                }
            }
        }
    }
}
