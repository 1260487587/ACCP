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
    public class FreeTicket:Ticket
    {
        public string CustomerName { get; set; }

        public override void CalcPrice()
        {
            this.Price = 0;
        }

        public override void Print()
        {
            string fileName = this.ScheduleItem.Time.Replace(":", "-") + " " + this.Seat.SeatNum + ".txt";
            FileStream fs = new FileStream("Tickets\\" + fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("***************************");
            sw.WriteLine("     青鸟影院 (赠票)");
            sw.WriteLine("---------------------------");
            sw.WriteLine(" 电影名：\t{0}", this.ScheduleItem.Movie.MovieName);
            sw.WriteLine(" 时间：  \t{0}", this.ScheduleItem.Time);
            sw.WriteLine(" 座位号：\t{0}", this.Seat.SeatNum);
            sw.WriteLine(" 姓名：  \t{0}", this.CustomerName);
            sw.WriteLine("***************************");
            sw.Close();
            fs.Close();
        }

        public override void Show()
        {
            MessageBox.Show("已售出!\n\n 赠送者：" + this.CustomerName);
        }

        public FreeTicket(){}

        public FreeTicket(ScheduleItem scheduleItem, Seat seat, string customerName)
        {
            this.ScheduleItem = scheduleItem;
            this.Seat = seat;
            this.CustomerName = customerName;
        }
    }
}
