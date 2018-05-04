using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 影院售票系统
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        Schedule schedule = new Schedule();
        private Seat seat = null;
        private Cinema cinema = new Cinema();
        private void tvMovies_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ClearSeat();

            ShowMovieInfo();// 点击放映时间，显示电影详情
        }

        /// <summary>
        /// 点击放映时间，显示电影详情
        /// </summary>
        public void ShowMovieInfo()
        {
            TreeNode node = tvMovies.SelectedNode;
            if (node == null) return;
            if (node.Level != 1) return;
            string key = node.Text;
            labMovieName.Text = cinema.Schedule.Items[key].Movie.MovieName;
            labDirector.Text = cinema.Schedule.Items[key].Movie.Director;
            labActor.Text = cinema.Schedule.Items[key].Movie.Actor;
            labType.Text = cinema.Schedule.Items[key].Movie.MovieType.ToString();
            labShowTime.Text = cinema.Schedule.Items[key].Time;
            labPrice.Text = cinema.Schedule.Items[key].Movie.Price.ToString();
            pictureMovieName.Image = Image.FromFile(cinema.Schedule.Items[key].Movie.Poster);
            InitSeatLabel();
            foreach (Ticket ticket in cinema.SoldTickets)
            {
                foreach (Seat seat in cinema.Seats.Values)
                {
                    if (ticket.ScheduleItem.Time == key && ticket.Seat.SeatNum == seat.SeatNum)
                    {
                        seat.Color = Color.Red;
                        foreach (Control lab in pageSeats.Controls)
                        {
                            if (lab.Text == seat.SeatNum)
                            {
                                lab.BackColor = Color.Red;
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// 清空座位，所有座位变为黄色
        /// </summary>
        public void ClearSeat()
        {
            foreach (Control item in pageSeats.Controls)
            {
                if (item is Label)
                {
                    item.BackColor = Color.Yellow;
                }
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            InitSeatLabel();
            string path = "售票记录.bin";
            if (File.Exists(path))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(path, FileMode.Open);
                List<Ticket> list = (List<Ticket>)bf.Deserialize(fs);

                cinema.SoldTickets = list;
                fs.Close();
            }
        }
        /// <summary>
        /// 座位集合
        /// </summary>
        Dictionary<string, Label> labels = new Dictionary<string, Label>();
        /// <summary>
        /// 添加座位标签
        /// </summary>
        private void InitSeatLabel()
        {
            labels.Clear();
            cinema.Seats.Clear();
            int seatRow = 5;
            int seatLine = 7;
            Label label = null;
            for (int i = 0; i < seatLine; i++)
            {
                for (int j = 0; j < seatRow; j++)
                {
                    label = new Label();
                    label.BackColor = Color.Yellow;
                    label.Font = new Font("宋体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
                    label.AutoSize = false;
                    label.Size = new System.Drawing.Size(50, 25);
                    label.Text = (j + 1).ToString() + "-" + (i + 1).ToString();
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Location = new Point(60 + (i * 90), 60 + (j * 60));
                    label.Click += new System.EventHandler(lblSeat_Click);
                    pageSeats.Controls.Add(label);
                    labels.Add(label.Text, label);

                    seat = new Seat((j + 1).ToString() + "-" + (i + 1).ToString(), Color.Yellow);
                    cinema.Seats.Add(seat.SeatNum, seat);
                }
            }
        }

        private void lblSeat_Click(object sender, EventArgs e)
        {
            try
            {
                string seatNum = ((Label)sender).Text;
                string customerName = txtGive.Text;
                int discount = 0;
                string type = "";
                if (tvMovies.SelectedNode == null)
                {
                    return;
                }
                string key = tvMovies.SelectedNode.Text;
                if (rdoStudent.Checked)  //学生票
                {
                    type = "Student";
                    if (cboStudent.Text == null)
                    {
                        MessageBox.Show("请输入折扣数！", "提示");
                        return;
                    }
                    else
                    {
                        discount = int.Parse(cboStudent.Text);
                    }
                }
                else if (rdoGive.Checked)
                {
                    if (txtGive.Text == null)
                    {
                        MessageBox.Show("请输入赠票者姓名", "提示");
                        return;
                    }
                    else
                    {
                        type = "Free";
                    }
                }
                Ticket newTicket = TicketUtil.CreateTicket(cinema.Schedule.Items[key], cinema.Seats[seatNum], discount, customerName, type);
                if (cinema.Seats[seatNum].Color == Color.Yellow)
                {
                    DialogResult result;
                    result = MessageBox.Show("是否购买？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        cinema.Seats[seatNum].Color = Color.Red;
                        UpdateSeat();
                        Label lab = (Label)sender;
                        lab.BackColor = Color.Red;
                        newTicket.CalcPrice();
                        cinema.SoldTickets.Add(newTicket);
                        labCheapPrice.Text = newTicket.Price.ToString();
                        newTicket.Print();
                    }
                    else if (result == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    foreach (Ticket ticket in cinema.SoldTickets)
                    {
                        if (ticket.Seat.SeatNum == seatNum && ticket.ScheduleItem.Time == tvMovies.SelectedNode.Text && ticket.ScheduleItem.Movie.MovieName == tvMovies.SelectedNode.Parent.Text)
                        {
                            ticket.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生异常！" + ex);
            }
        }

        public void UpdateSeat()
        {
            foreach (string key in cinema.Seats.Keys)
            {
                labels[key].BackColor = cinema.Seats[key].Color;
            }
        }

        public void LoadTreeNodes()
        {
            TreeNode tn = null;
            string movieName = string.Empty;
            foreach (ScheduleItem nodes in schedule.Items.Values)
            {
                if (nodes.Movie.MovieName != movieName)
                {
                    tn = new TreeNode();
                    tn.Text = nodes.Movie.MovieName;
                    tvMovies.Nodes.Add(tn);
                }
                TreeNode node = new TreeNode();
                node.Text = nodes.Time;
                tn.Nodes.Add(node);
                movieName = nodes.Movie.MovieName;
            }

        }

        private void 获取新放映列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cinema.SoldTickets.Clear();
            cinema.Seats.Clear();
            DeleteAlltxt();
            ClearSeat();
            schedule.LoadItems();
            if (File.Exists("售票记录.bin"))
            {
                File.Delete("售票记录.bin");
            }
            this.tvMovies.Nodes.Clear();
            this.cinema.Schedule = schedule;
            LoadTreeNodes();
        }

        public void DeleteAlltxt()
        {
            string path = @"C:\Users\12604\Documents\visual studio 2012\Projects\影院售票系统\影院售票系统\bin\Debug\Tickets";
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] info = directory.GetFiles();
            if (info.Length != 0)
            {
                string[] fileName = Directory.GetFiles(path, "*.txt");
                foreach (string fileInfo in fileName)
                {
                    File.Delete(fileInfo);
                }
            }
        }

        private void rdoStudent_CheckedChanged(object sender, EventArgs e)
        {
            cboStudent.Enabled = true;
            txtGive.Enabled = false;
        }

        private void rdoGive_CheckedChanged(object sender, EventArgs e)
        {
            txtGive.Enabled = true;
            cboStudent.Enabled = false;
        }

        private void rdoNormal_CheckedChanged(object sender, EventArgs e)
        {
            txtGive.Enabled = false;
            cboStudent.Enabled = false;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否保存售票记录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cinema.Save();
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否要保存？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                cinema.Save();
            }
        }

        private void 继续销售ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schedule.LoadItems();
            this.tvMovies.Nodes.Clear();
            this.cinema.Schedule = schedule;
            LoadTreeNodes();
        }

        private void rdoNormal_CheckedChanged_1(object sender, EventArgs e)
        {
            txtGive.Enabled = false;
            cboStudent.Enabled = false;
        }
    }
}
