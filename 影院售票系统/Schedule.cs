using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace 影院售票系统
{
    /// <summary>
    /// 放映计划类
    /// </summary>
    public class Schedule
    {
        private Dictionary<string, ScheduleItem> items = new Dictionary<string, ScheduleItem>();

        internal Dictionary<string, ScheduleItem> Items
        {
            get { return items; }
            set { items = value; }
        }

        public void LoadItems()
        {
            items.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load("ShowList.xml");
            XmlNode root = doc.DocumentElement;
            foreach (XmlNode item in root.ChildNodes)
            {
                Movie movie = new Movie();
                movie.Actor = item["Actor"].InnerText;
                movie.Director = item["Director"].InnerText;
                movie.MovieName = item["Name"].InnerText;
                movie.MovieType = (MovieType)Enum.Parse(typeof(MovieType), item["Type"].InnerText);
                movie.Poster = item["Poster"].InnerText;
                movie.Price = Convert.ToInt32(item["Price"].InnerText);
                foreach (XmlNode node in item["Schedule"].ChildNodes)
                {
                    ScheduleItem schedule = new ScheduleItem();
                    schedule.Time = node.InnerText;
                    schedule.Movie = movie;
                    items.Add(schedule.Time, schedule);
                }
            }
        }
    }
}                               