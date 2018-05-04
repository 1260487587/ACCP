using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace 影院售票系统
{
    public class Cinema
    {
        public Dictionary<string, Seat> Seats = new Dictionary<string, Seat>();

        public Schedule Schedule { get; set; }
        public List<Ticket> SoldTickets = new List<Ticket>();

        /// <summary>
        /// 保存售票记录
        /// </summary>
        public void Save()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("售票记录.bin",FileMode.Create);
            bf.Serialize(fs,this.SoldTickets);
            fs.Close();
        }

        public void Load()
        {
            
        }
    }
}
