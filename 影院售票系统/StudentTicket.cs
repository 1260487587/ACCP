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
    public class StudentTicket:Ticket
    {
        public int Discount { get; set; } //学生票折扣

        public override void CalcPrice()
        {
            this.Price = this.ScheduleItem.Movie.Price * Discount / 10;
        }

        public override void Print()
        {
            string fileName = this.ScheduleItem.Time.Replace(":", "-") + " " + this.Seat.SeatNum + ".txt";
            FileStream fs = new FileStream("Tickets\\" + fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("***************************");
            sw.WriteLine("     青鸟影院 (学生)");
            sw.WriteLine("---------------------------");
            sw.WriteLine(" 电影名：\t{0}", this.ScheduleItem.Movie.MovieName);
            sw.WriteLine(" 时间：  \t{0}", this.ScheduleItem.Time);
            sw.WriteLine(" 座位号：\t{0}", this.Seat.SeatNum);
            sw.WriteLine(" 价格：  \t{0}", this.Price.ToString());
            sw.WriteLine("***************************");
            sw.Close();
            fs.Close();
        }

        public override void Show()
        {
            MessageBox.Show("已售出!\n\n " + this.Discount + "折学生票!");
        }

        public StudentTicket(){}

        public StudentTicket(ScheduleItem scheduleItem, Seat seat,
            int discount)
        {
            this.ScheduleItem = scheduleItem;
            this.Seat = seat;
            this.Discount = discount;
        }
    }
}
