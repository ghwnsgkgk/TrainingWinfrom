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

namespace BookRentalShop20
{
    public partial class UserForm : MetroForm
    {
        string strConnString = "Data Source=192.168.0.28;Initial Catalog=BookRentalshopDB;Persist Security Info=True;User ID=sa;Password=p@ssw0rd!";
        string mode = "";
        public UserForm()
        {
            InitializeComponent();
        }

        private void DivForm_Load(object sender, EventArgs e)
        {
            UpdateData(); // 데이터그리드DB 데이터 로딩하기
        }
        /// <summary>
        /// 사용자 데이터 가져오기
        /// </summary>
        private void UpdateData()
        {
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                conn.Open(); // Db 열기
                string strQuery = "SELECT id,userID,password,lastLoginDt,loginIpAddr" +
                    "  FROM dbo.userTbl";
 
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery,conn); //데이타 가져오는 플러그 !!1
                DataSet ds = new DataSet(); 
                dataAdapter.Fill(ds, "userTbl");//데이타 집합  //ds 통에다가 divtbl 이름으로 넣었다
                GrdUserTbl.DataSource = ds;
                GrdUserTbl.DataMember = "userTbl";  //그걸 다시 Grd 통에 넣는다 ,
            }
           
            DataGridViewColumn column = GrdUserTbl.Columns[0]; //id컬럼
            column.Width = 40;
            column.HeaderText = "순번";
            column = GrdUserTbl.Columns[1];
            column.Width = 80;
            column.HeaderText = "아이디";
            column = GrdUserTbl.Columns[2];
            column.Width = 100;
            column.HeaderText = "패스워드";
            column = GrdUserTbl.Columns[3];
            column.Width = 120;
            column.HeaderText = "최종접속시간";
            column = GrdUserTbl.Columns[4];
            column.Width = 150;
            column.HeaderText = "접속아이피주소";
            //throw new NotImplementedException();
        }
        

        private void GrdDivTbl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        /// <summary>
        /// 그리드 셀클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdDivTbl_CellClick(object sender, DataGridViewCellEventArgs e)  //꼭 CellClick
        {
            if (e.RowIndex >-1 )
            {   //var data
                DataGridViewRow data = GrdUserTbl.Rows[e.RowIndex];
                Txtid.Text           = data.Cells[0].Value.ToString();
                TxtUserID.Text       = data.Cells[1].Value.ToString();
                TxtPassword.Text     = data.Cells[2].Value.ToString();
               

                mode = "UPDATE"; //수정은 UPDATE
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearTextControls();
            mode = "INSERT"; //신규는 INSERT

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(TxtUserID.Text) || String.IsNullOrEmpty(TxtPassword.Text))
            {
                MetroMessageBox.Show(this, "빈값은 저장할 수 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  //이 리턴 값이 중요하다 ,@@
            }
            SaveProcess(); //DB저장프로세스
            UpdateData();  //이미수정 완료 
            ClearTextControls();
        }

        private void ClearTextControls()
        {

            Txtid.Text= TxtUserID.Text = TxtPassword.Text = "";
           //TxtUserID.ReadOnly = false;
            //TxtUserID.BackColor = Color.White;
            TxtUserID.Focus();
        }

        private void SaveProcess()
        {
            if (string.IsNullOrEmpty(mode))
            {
                MetroMessageBox.Show(this, "신규버튼을 누르고 데이터를 저장하십시오","경고",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                String strQuery = "";

                if (mode == "UPDATE")
                {
                    strQuery = "UPDATE dbo.userTbl "+
                               " SET userID = @UserID "+
                               "   , password = @Password "+
                               " WHERE Id = @Id ";
                }
                else if (mode == "INSERT")
                {
                    strQuery = "INSERT INTO dbo.userTbl(userID,password) "+
                               " VALUES(@userID, @password) ";
                    cmd.CommandText = strQuery;
                }
                ////////////////////////////////////////////////////////////////userid
                SqlParameter parmUserID = new SqlParameter("@UserID", SqlDbType.VarChar, 12);                                                //CommandText 를  파라미터
                parmUserID.Value = TxtUserID.Text;
                cmd.Parameters.Add(parmUserID);
                ///////////////////////////////////////////////////////////////// password
                SqlParameter parmPassword = new SqlParameter("@Password", SqlDbType.VarChar, 20);                                                //CommandText 를  파라미터
                parmPassword.Value = TxtPassword.Text;
                cmd.Parameters.Add(parmPassword);
                ///////////////////////////////////////////////////////////////// id
                if (mode == "UPDATE")
                {
                    SqlParameter parmID = new SqlParameter("@Id", SqlDbType.Int);                                                //CommandText 를  파라미터
                    parmID.Value = TxtPassword.Text;
                    cmd.Parameters.Add(parmID);
                }
                cmd.ExecuteNonQuery();  //데이터 값을 돌려 받지 않는 
            }
        }

  

        private void BtnDelet_Click(object sender, EventArgs e)
        {
          
            
            
            
            /* if (String.IsNullOrEmpty(TxtUserID.Text) || String.IsNullOrEmpty(TxtPassword.Text))
            {
                MetroMessageBox.Show(this, "빈값은 삭제할 수 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  //이 리턴 값이 중요하다 ,@@
            }
            DeletProcess();
            UpdateData();
            ClearTextControls();*/

        }

        private void DeletProcess()
        {
            using (SqlConnection coon = new SqlConnection(strConnString))
            {
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandText = "DELETE FROM dbo.divtbl WHERE Division = @Division";
                SqlParameter parameter = new SqlParameter("@Division", SqlDbType.Char, 4);
                parameter.Value = TxtUserID.Text;
                cmd.Parameters.Add(parameter);
                cmd.ExecuteNonQuery(); // 이게 마지막으로 실행시켜주는 
            }
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
