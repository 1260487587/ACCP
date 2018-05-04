using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace 网络电视精灵
{
    public partial class frmMian : Form
    {
        public frmMian()
        {
            InitializeComponent();
        }

        //创建所有电视台根节点
        TreeNode allNodes = new TreeNode();
        TreeNode tn = new TreeNode();
        //保存我的电视台中的数据
        Dictionary<string, List<TvProgram>> dic = new Dictionary<string, List<TvProgram>>();
        private void frmMian_Load(object sender, EventArgs e)
        {
            tn.Text = "我的电视台";
            allNodes.Text = "所有电视台";
            tvList.Nodes.Add(tn);
            tvList.Nodes.Add(allNodes);
            AddTreeNode();//给TreeView添加频道子节点
            dgvProgramList.AutoGenerateColumns = false;
            dgvProgramList.ReadOnly = true;
        }

        /// <summary>
        /// 填充dgvList
        /// </summary>
        private void FillDgvList()
        {
            TreeNode selectedNode = tvList.SelectedNode;
            ChannelBase channel = (ChannelBase)selectedNode.Tag;
            channel.Fetch();
            dgvProgramList.DataSource = channel.TvList;
        }

        /// <summary>
        /// 给TreeView添加频道子节点
        /// </summary>
        private void AddTreeNode()
        {
            ChannelManager cm = new ChannelManager();
            cm.LoadAllChannel();
            foreach (ChannelBase item in ChannelManager.bases.Values)
            {
                TreeNode tn = new TreeNode();
                tn.Text = item.ChannelName;
                tn.Tag = item;
                allNodes.Nodes.Add(tn);
            }
        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedNode = tvList.SelectedNode.Text;
            int Level = tvList.SelectedNode.Level;
            TreeNode tn = tvList.SelectedNode.Parent;
            if (Level == 1)
            {
                FillDgvList();//填充dgvList
            }
            if (tn == null)
            {
                return;
            }
            else if (tn.Text == "所有电视台" && Level == 1)
            {
                tvList.ContextMenuStrip = cmsInto;
            }
            else if (tn.Text == "我的电视台" && Level == 1)
            {
                tvList.ContextMenuStrip = cmsDelete;
            }
        }

        private void 加入我的电台ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvList.SelectedNode;
            ChannelBase channel = (ChannelBase)selectedNode.Tag;
            channel.Fetch();
            foreach (TreeNode item in tn.Nodes)
            {
                if (item.Text == channel.ChannelName)
                {
                    MessageBox.Show("此电视台已加入，无需重复添加!");
                    return;
                }
            }
            dic.Add(channel.ChannelName, channel.TvList);
            TreeNode node = new TreeNode();
            node.Text = channel.ChannelName;
            node.Tag = channel;
            tn.Nodes.Add(node);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvList.SelectedNode;
            ChannelBase channel = (ChannelBase)selectedNode.Tag;
            dic.Remove(channel.ChannelName);
            tn.Nodes.Remove(selectedNode);
        }

        private void 播放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string programName = dgvProgramList.SelectedRows[0].Cells[1].Value.ToString();
            MessageBox.Show("正在播放:"+programName+"");
        }
    }
}
