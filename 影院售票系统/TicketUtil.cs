using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 影院售票系统
{
    public class TicketUtil
    {
        /// <summary>
        /// 创建电影票
        /// </summary>
        public static Ticket CreateTicket(ScheduleItem scheduleItem, Seat seat,
           int discount, string customerName, string type)
        {
            Ticket ticket = null;
            switch (type)
            {
                case "Student":
                    ticket = new StudentTicket(scheduleItem, seat, discount);
                    break;
                case "Free":
                    ticket = new FreeTicket(scheduleItem, seat, customerName);
                    break;
                case "":
                    ticket = new Ticket(scheduleItem, seat);
                    break;
            }
            return ticket;
        }
    }
}
