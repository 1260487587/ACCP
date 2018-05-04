using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 影院售票系统
{
    [Serializable]
    public class Seat
    {
        public string SeatNum { get; set; }
        public Color Color { get; set; }

        public Seat(){}

        public Seat(string seatNum, Color color)
        {
            this.SeatNum = seatNum;
            this.Color = color;
        }
    }
}
