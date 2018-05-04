using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 影院售票系统
{
    /// <summary>
    /// 电影场次类
    /// </summary>
    [Serializable]
    public class ScheduleItem
    {
        public Movie Movie { get; set; }
        public string Time { get; set; }

        public  ScheduleItem(){}

        public ScheduleItem(Movie movie, string time)
        {
            this.Movie = movie;
            this.Time = time;
        }
    }
}
