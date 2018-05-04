using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace 网络电视精灵
{
    /// <summary>
    /// 解析频道xml,转换成泛型集合
    /// </summary>
    public class ChannelManager
    {
        /// <summary>
        /// 解析FullChanels.xml
        /// </summary>
        /// 报存各个频道的对象
        public static Dictionary<string, ChannelBase> bases = new Dictionary<string, ChannelBase>();
        public void LoadAllChannel()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("FullChannels.xml");
            XmlNode root = doc.DocumentElement;
            foreach (XmlNode item in root)
            {   
                string typeName = item["channelType"].InnerText.ToString();
                ChannelBase channel = ChannelFactory.CreateChannel(typeName);
                channel.ChannelName = item["tvChannel"].InnerText;
                channel.Path = item["path"].InnerText;
                bases.Add(channel.ChannelName, channel);
            }
            
        }
    }
}
