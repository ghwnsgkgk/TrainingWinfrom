using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace BookRentalShop20
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
        /// <summary>
        /// 한번에 프로그램 종료 되도록 하기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MetroMessageBox.Show(this,"정말 종료하시겠습니까?","종료",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
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
            form.Text =  strFormTitle;
            form.Dock = DockStyle.Fill; // 화면 다채우는거
            form.MdiParent = this; // 부모 집단이 어디냐 ?  -> 여기다 (MainForm) // Mdi 가되면 창이 밖으로 안나가게 한다 .
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }
        /// <summary>
        /// 코딩의 메소드화 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuItemDivMng_Click(object sender, EventArgs e)
        {
            DivForm form = new DivForm();
            InItChildForm( form, "구분코드 관리");
        }

        private void 사용자관리UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm();
            InItChildForm( form, "사용자 관리");
        }

        private void 회원관리MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemberForm form = new MemberForm();
            InItChildForm(form, "회원 관리");
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            LblUserID.Text = Commons.LOGINUSERID;
        }

        private void 책관리BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BooksForm form = new BooksForm();
            InItChildForm(form, "책 관리");
        }

        private void 책대여관리RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RentalForm form = new RentalForm();
            InItChildForm(form, "책 대여 관리");
        }
    }
}
