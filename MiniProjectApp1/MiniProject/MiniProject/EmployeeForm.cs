using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class EmployeeForm : MetroForm
    {
        string mode = "";
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void UpdateData()
        {
            using(SqlConnection conn = new SqlConnection(Commons.ConnString))
            {
                conn.Open();
                string strQuery =    "SELECT IDX "+
                                     " , NAME "+
                                     " , IDENTITYNUMBER "+
                                     " , PART "+
                                     " , RANK "+
                                     " , PHONENUMBER "+
                                     " FROM dbo.EmployeeTbl "; // 퀴리문 입력해야함
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "EmployeeTbl");
                GrdEmployeeTbl.DataSource = ds;
                GrdEmployeeTbl.DataMember = "EmployeeTbl";
            }
            //DataGridViewColumn column = GrdUserTbl.Columns[0]; //id컬럼
            //column.Width = 40;
            //column.HeaderText = "순번";
            //column = GrdUserTbl.Columns[1];
            //column.Width = 80;
            //column.HeaderText = "아이디";
            //column = GrdUserTbl.Columns[2];
            //column.Width = 100;
            //column.HeaderText = "패스워드";
            //column = GrdUserTbl.Columns[3];
            //column.Width = 120;
            //column.HeaderText = "최종접속시간";
            //column = GrdUserTbl.Columns[4];
            //column.Width = 150;
            //column.HeaderText = "접속아이피주소";
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Employee_Load(object sender, EventArgs e)
        {
            UpdateData();//데이터 로딩
        }

        private void GrdEmployeeTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrdEmployeeTbl.Rows[e.RowIndex];
                Txtmemberidx.Text = data.Cells[0].Value.ToString();
                TxtName.Text = data.Cells[1].Value.ToString();
                TxtIdentityNumber.Text = data.Cells[2].Value.ToString();
                TxtDepart.Text = data.Cells[3].Value.ToString();
                TxtRank.Text = data.Cells[4].Value.ToString();
                TxtPhoneNumber.Text = data.Cells[5].Value.ToString();

                mode = "UPDATE";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtName.Text) || String.IsNullOrEmpty(TxtIdentityNumber.Text) || String.IsNullOrEmpty(TxtDepart.Text) || String.IsNullOrEmpty(TxtRank.Text) || String.IsNullOrEmpty(TxtPhoneNumber.Text))
            {
                MetroMessageBox.Show(this, "빈값은 저장할 수 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveProcess();
            UpdateData();
            ClearTextControl();
        }

        private void ClearTextControl()
        {
            Txtmemberidx.Text = TxtName.Text = TxtIdentityNumber.Text = TxtDepart.Text = TxtPhoneNumber.Text = TxtIdentityNumber.Text= TxtRank.Text= "";
            Txtmemberidx.ReadOnly = false;
            Txtmemberidx.BackColor = Color.White;
            TxtName.Focus();
        }

        private void SaveProcess()
        {
            if (string.IsNullOrEmpty(mode))
            {
                MetroMessageBox.Show(this, "신규버튼을 누르고 데이터를 저장하십시오", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(Commons.ConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                String strQuery = "";

                if (mode == "UPDATE")
                {
                    strQuery = "UPDATE dbo.EmployeeTbl " +
                               "   SET NAME = @NAME, " +
                               "   IDENTITYNUMBER = @IDENTITYNUMBER,  " +
                               "   PART = @PART,  " +
                               "   RANK = @RANK,  " +
                               "   PHONENUMBER = @PHONENUMBER, " +
                               "   WHERE IDX = @IDX ";
                   
                }
                else if (mode == "INSERT")
                {
                    strQuery = "INSERT INTO dbo.EmployeeTbl(IDX, NAME, IDENTITYNUMBER, PART, RANK, PHONENUMBER)  " +
                               "  VALUES(@IDX, @NAME, @IDENTITYNUMBER, @PART, @RANK, @PHONENUMBER)  ";
                    cmd.CommandText = strQuery;
                }
                ////////////////////////////////////////////////////////////////이름
                SqlParameter parmName = new SqlParameter("@NAME", SqlDbType.NChar, 10);                                              //CommandText 를  파라미터
                parmName.Value = TxtName.Text;
                cmd.Parameters.Add(parmName);
                ///////////////////////////////////////////////////////////////// 직급
                SqlParameter parmRank = new SqlParameter("@RANK", SqlDbType.NChar, 10);                                                 //CommandText 를  파라미터
                parmRank.Value = TxtRank.Text;  // 아이템즈가 맞음 !
                cmd.Parameters.Add(parmRank);
                //////////////////////////////////////////////////////////////////휴대폰번호
                SqlParameter parmPhoneNumber = new SqlParameter("@PHONENUMBER", SqlDbType.NVarChar, 50);                                            //CommandText 를  파라미터
                parmPhoneNumber.Value = TxtPhoneNumber.Text;
                cmd.Parameters.Add(parmPhoneNumber);
                //////////////////////////////////////////////////////////////////부서
                SqlParameter parmDepart = new SqlParameter("@PART", SqlDbType.NChar, 10);                                                //CommandText 를  파라미터
                parmDepart.Value = TxtDepart.Text;
                cmd.Parameters.Add(parmDepart);
                /////////////////////////////////////////////////////////////////////// 주민번호
                SqlParameter parmIdentityNumber = new SqlParameter("@IDENTITYNUMBER", SqlDbType.NVarChar, 50);                                              //CommandText 를  파라미터
                parmIdentityNumber.Value = TxtIdentityNumber.Text;
                cmd.Parameters.Add(parmIdentityNumber);
                ////////////////////////////////////////////////////////////////// Idex
                SqlParameter parmmemberNumber = new SqlParameter("@IDX", SqlDbType.Int);                                                  //CommandText 를  파라미터
                parmmemberNumber.Value = Txtmemberidx.Text;
                cmd.Parameters.Add(parmmemberNumber);
                cmd.ExecuteNonQuery();

            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearTextControl();
            mode = "INSERT"; //신규는 INSERT
        }

        private void TxtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BtnSave_Click(sender, new EventArgs());
            }
        }
    }
}
