using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //this.menuStrip2.Items.Insert(menuStrip2.Items.Count - 1, new ToolStripSeparator());
            foreach (ToolStripItem item in menuStrip2.Items)
            {
                item.Size = new Size(229, 53);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void sgsgfToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sdvgsgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form clients = new Clients();
            clients.Show();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //menuStrip2.Items[0].Width = this.Width/5;
            pictureBox1.Size = new Size(this.Width-pictureBox1.Location.X, this.Height * 2 / 3  - 2);

            groupBox1.Size = new Size((this.Width - pictureBox1.Location.X) / 3, this.Height * 1 / 3 );
            groupBox2.Size = new Size((this.Width - pictureBox1.Location.X) / 3, this.Height * 1 / 3);
            groupBox3.Size = new Size((this.Width - pictureBox1.Location.X) / 3, this.Height * 1 / 3 );

            groupBox1.Location = new Point(this.menuStrip2.Width + groupBox1.Width*2 + 1, pictureBox1.Height);  //this.Height / 2 - 20;
            groupBox2.Location = new Point(this.menuStrip2.Width + groupBox1.Width + 1, pictureBox1.Height);
            groupBox3.Location = new Point(this.menuStrip2.Width+1, pictureBox1.Height);
        }

        private void sgszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form products = new Products();
            products.Show();
        }
    }
}
