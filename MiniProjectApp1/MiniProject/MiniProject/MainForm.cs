using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();

        }

        private void MiniProject_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MetroMessageBox.Show(this, "정말 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Form item in this.MdiChildren)
                {
                    item.Close();
                }
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void InItChildForm(Form form , string strFormTitle)
        {
            form.Text = strFormTitle;
            form.Dock = DockStyle.Fill;
           // form.MdiParent = this;
            form.Show();
            //form.WindowState = FormWindowState.Maximized;
        }


        private void MemberManaged_Click(object sender, EventArgs e)
        {
            EmployeeForm form = new EmployeeForm();
            InItChildForm(form, "사원관리");
        }

        private void ClientManaged_Click(object sender, EventArgs e)
        {
            //ClientForm form = new ClientForm();
            //InItChildForm(form, "거래처관리");
        }

        private void ClientManaged_Click_1(object sender, EventArgs e)
        {
            ClientForm form = new ClientForm();
            InItChildForm(form, "거래처관리");
        }

        private void BtnInOutPut_Click(object sender, EventArgs e)
        {
            InOutForm form = new InOutForm();
            InItChildForm(form, "입.출관리");
        }
    }
}
