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
                string strQuery = "SELECT Idx,Names,Levels,Addr,Mobile,Email " +
                                  "  FROM membertbl "; // 퀴리문 입력해야함
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "membertbl");
                GrdEmployeeTbl.DataSource = ds;
                GrdEmployeeTbl.DataMember = "membertbl";
            }
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
                TxtmemberNumber.Text = data.Cells[0].Value.ToString();
                TxtName.Text = data.Cells[1].Value.ToString();
                TxtIdentityNumber.Text = data.Cells[2].Value.ToString();
                TxtDepart.Text = data.Cells[3].Value.ToString();
                TxtRank.Text = data.Cells[4].Value.ToString();
                TxtPhoneNumber.Text = data.Cells[5].ToString();

                mode = "UPDATE";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtmemberNumber.Text) || String.IsNullOrEmpty(TxtName.Text) || String.IsNullOrEmpty(TxtIdentityNumber.Text) || String.IsNullOrEmpty(TxtDepart.Text) || String.IsNullOrEmpty(TxtRank.Text) || String.IsNullOrEmpty(TxtPhoneNumber.Text))
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
            TxtmemberNumber.Text = TxtName.Text = TxtIdentityNumber.Text = TxtDepart.Text = TxtPhoneNumber.Text = "";
            TxtmemberNumber.ReadOnly = true;
            TxtmemberNumber.BackColor = Color.Red;
            TxtName.Focus();
        }

        private void SaveProcess()
        {
            using (SqlConnection conn = new SqlConnection(Commons.ConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string strQuery = "";

                if (mode == "UPDATE")
                {
                    strQuery = " UPDATE dbo.membertbl " +
                               " SET Names = @Names, " +
                               " Levels = @Levels, " +
                               " Addr = @Addr, " +
                               " Mobile = @Mobile, " +
                               " Email = @Email " +
                               " WHERE Idx = @Idx "; /// 띄어 쓰기 잘하기 
                    cmd.CommandText = strQuery;
                }
                else if (mode == "INSERT")
                {
                    strQuery = "INSERT INTO dbo.membertbl(Names,Levels,Addr,Mobile,Email) " +
                               "      VALUES(@Names, @Levels, @Addr, @Mobile, @Email) ";
                }
                ////////////////////////////////////////////////////////////////이름
                SqlParameter parmName = new SqlParameter("@Names", SqlDbType.NVarChar, 45);                                              //CommandText 를  파라미터
                parmName.Value = TxtName.Text;
                cmd.Parameters.Add(parmName);
                ///////////////////////////////////////////////////////////////// 직급
                SqlParameter parmRank = new SqlParameter("@Levels", SqlDbType.Char, 4);                                                 //CommandText 를  파라미터
                parmRank.Value = TxtRank.Text;  // 아이템즈가 맞음 !
                cmd.Parameters.Add(parmRank);
                //////////////////////////////////////////////////////////////////휴대폰번호
                SqlParameter parmPhoneNumber = new SqlParameter("@Mobile", SqlDbType.NVarChar, 45);                                            //CommandText 를  파라미터
                parmPhoneNumber.Value = TxtPhoneNumber.Text;
                cmd.Parameters.Add(parmPhoneNumber);
                //////////////////////////////////////////////////////////////////주소
                SqlParameter parmAddr = new SqlParameter("@Addr", SqlDbType.NVarChar, 45);                                                //CommandText 를  파라미터
                parmAddr.Value = TxtDepart.Text;
                cmd.Parameters.Add(parmAddr);
                /////////////////////////////////////////////////////////////////////// 주민번호
                SqlParameter parmIdentityNumber = new SqlParameter("@Email", SqlDbType.NVarChar, 45);                                              //CommandText 를  파라미터
                parmIdentityNumber.Value = TxtIdentityNumber.Text;
                cmd.Parameters.Add(parmIdentityNumber);
                ////////////////////////////////////////////////////////////////// Idex

                if (mode == "UPDATE")
                {
                    SqlParameter parmmemberNumber = new SqlParameter("@Idx", SqlDbType.NVarChar, 45);                                                  //CommandText 를  파라미터
                    parmmemberNumber.Value = TxtmemberNumber.Text;
                    cmd.Parameters.Add(parmmemberNumber);

                }
                cmd.ExecuteNonQuery();

            }
        }
    }
}
