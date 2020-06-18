using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuStart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 열기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text += 열기OToolStripMenuItem.Text + Environment.NewLine;
        }

        private void 붙여넣기VToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 새파일NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text += MnuNewFile.Text + Environment.NewLine;
            toolStripStatusLabel1.Text = MnuNewFile.Text;
            //실제 새파일 로직 집어 넣아야 함
        }

        private void 저장SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text += 저장SToolStripMenuItem.Text + Environment.NewLine;
            MessageBox.Show("저장했습니다");
        }

        private void 종료XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 프로그램정보AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e) //MouseEventArgs e 중요한 정보가 여기에 다들어 있다.
        {
            if(e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(e.Location); 
            }
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            LBLMouseLocation.Text = $"(X,Y) =({ e.Location.X}, {e.Location.Y})";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                열기OToolStripMenuItem_Click(sender, e);

            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            새파일NToolStripMenuItem_Click(sender, e);

        }
    }
}
