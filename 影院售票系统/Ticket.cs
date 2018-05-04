using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 影院售票系统
{
    [Serializable]
    public class Ticket
    {
        public ScheduleItem ScheduleItem { get; set; }
        public Seat Seat { get; set; }
        public int Price { get; set; }

        /// <summary>
        /// 计算票价
        /// </summary>
        /// <returns></returns>
        public virtual void CalcPrice()
        {
            this.Price = this.ScheduleItem.Movie.Price;
        }

        /// <summary>
        /// 打印售票信息
        /// </summary>
        public virtual void Print()
        {
            string fileName = this.ScheduleItem.Time.Replace(":", "-") + " " + this.Seat.SeatNum + ".txt";
            FileStream fs = new FileStream("Tickets\\"+fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("***************************");
            sw.WriteLine("        青鸟影院");
            sw.WriteLine("---------------------------");
            sw.WriteLine(" 电影名：\t{0}", this.ScheduleItem.Movie.MovieName);
            sw.WriteLine(" 时间：  \t{0}", this.ScheduleItem.Time);
            sw.WriteLine(" 座位号：\t{0}", this.Seat.SeatNum);
            sw.WriteLine(" 价格：  \t{0}", this.Price.ToString());
            sw.WriteLine("***************************");
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// 显示出票信息
        /// </summary>
        public virtual void Show()
        {
            MessageBox.Show("已售出");
        }

        public Ticket(){}

        public Ticket(ScheduleItem scheduleItem, Seat seat)
        {
            this.ScheduleItem = scheduleItem;
            this.Seat = seat;
        }
    }
}
