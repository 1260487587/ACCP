using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace 网络电视精灵
{
    /// <summary>
    /// 凤凰卫视
    /// </summary>
    public class TypeBChannel : ChannelBase
    {
        public TypeBChannel() { }
        public TypeBChannel(string channelName, string path, List<TvProgram> list)
            : base(channelName, path, list)
        {
        }
        public override void Fetch()
        {
            this.Path = ChannelManager.bases["凤凰卫视"].Path;
            XmlDocument doc = new XmlDocument();
            doc.Load(Path);
            XmlNode root = doc.DocumentElement;
            TvList = new List<TvProgram>();
            foreach (XmlNode item in root.ChildNodes)
            {
                foreach (XmlNode node in item.ChildNodes)
                {
                    TvProgram tvProgram = new TvProgram();
                    tvProgram.Name = node["name"].InnerText;
                    tvProgram.Path = node["path"].InnerText;
                    tvProgram.PlayTime = Convert.ToDateTime(node["playTime"].InnerText);
                    this.TvList.Add(tvProgram);
                }
            }
        }
    }
}
