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
    public partial class ClientForm : MetroForm
    {
        string mode = "";
        public ClientForm()
        {
            InitializeComponent();
        }
        private void UpdateData()
        {
            using (SqlConnection conn = new SqlConnection(Commons.ConnString))
            {
                conn.Open();
                string strQuery = "SELECT IDX,PERSONNAL,NUMBER "+
                                  " , NAME, OWNER, ADDRESS "+
                                  " , PHONENUMBER, SORT "+
                                  " , PART, SITUATION "+
                                  " FROM dbo.ClientTbl ";
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "ClientTbl");
                GrdClientTbl.DataSource = ds;
                GrdClientTbl.DataMember = "ClientTbl";
            }
            //DataGridViewColumn column = GrdClientTbl.Columns[2]; //id컬럼
            //column.Visible = false;

        }
        private void ClientForm_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void GrdClientTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrdClientTbl.Rows[e.RowIndex];
                TxtClientidx.Text = data.Cells[0].Value.ToString();
                TxtClientidx.ReadOnly = true;
                TxtClientpersonnal.Text = data.Cells[1].Value.ToString();
                TxtClientNumber.Text = data.Cells[2].Value.ToString();
                TxtClientName.Text = data.Cells[3].Value.ToString();
                TxtClientOwner.Text = data.Cells[4].Value.ToString();
                TxtClientAddress.Text = data.Cells[5].Value.ToString();
                TxtClientphoneNum.Text = data.Cells[6].Value.ToString();
                TxtClientSort.Text = data.Cells[7].Value.ToString();
                TxtClientpart.Text = data.Cells[8].Value.ToString();
                TxtClientsituation.Text = data.Cells[9].Value.ToString();


                mode = "UPDATE";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtClientpersonnal.Text) ||
                String.IsNullOrEmpty(TxtClientNumber.Text) ||
                String.IsNullOrEmpty(TxtClientOwner.Text) ||
                String.IsNullOrEmpty(TxtClientName.Text) ||
                String.IsNullOrEmpty(TxtClientAddress.Text) ||
                String.IsNullOrEmpty(TxtClientsituation.Text) ||
                String.IsNullOrEmpty(TxtClientphoneNum.Text) ||
                String.IsNullOrEmpty(TxtClientSort.Text) ||
                String.IsNullOrEmpty(TxtClientpart.Text))
            {
                MetroMessageBox.Show(this, "빈값은 저장할 수 없습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveProcess(); //DB저장프로세스
            UpdateData();
            ClearTextControls();
        }

        private void ClearTextControls()
        {
            TxtClientpersonnal.Text = TxtClientNumber.Text = TxtClientOwner.Text =
            TxtClientName.Text = TxtClientAddress.Text = TxtClientsituation.Text = TxtClientphoneNum.Text =
            TxtClientSort.Text = TxtClientpart.Text = TxtClientidx.Text = "";
            TxtClientidx.ReadOnly = false;
            TxtClientidx.BackColor = Color.White;
            TxtClientidx.Focus();
        }



        private void SaveProcess()
        {
            if (string.IsNullOrEmpty(mode))
            {
                MetroMessageBox.Show(this, "신규버튼을 누르고 데이터를 저장하십시오", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection conn = new SqlConnection(Commons.ConnString))//다른 창에 STATIC 문으로 작성하여  연결하는 방법 만약 링크를 바꿔야하면 창을 모두 다 열어서 
                                                                              //바꿔야하는데 이렇게 코딩을 하면 해당 창에만 링크 주소를 바꾸면 모두 다 적용된다. 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                String strQuery = "";

                if (mode == "UPDATE")
                {
                    strQuery = "UPDATE dbo.ClientTbl "+
                              " SET PERSONNAL = @PERSONNAL "+
                                 " , NUMBER = @NUMBER "+
                                 " , NAME = @NAME "+
                                 " , OWNER = @OWNER "+
                                 " , ADDRESS = @ADDRESS "+
                                 " , PHONENUMBER = @PHONENUMBER "+
                                 " , SORT = @SORT "+
                                 " , PART = @PART "+
                                 " , SITUATION = @SITUATION "+
                                 " WHERE IDX = @IDX "; 
                }
                else if (mode == "INSERT")
                {
                    strQuery = "INSERT INTO dbo.ClientTbl "+
                               " (IDX, PERSONNAL, NUMBER, NAME, OWNER, ADDRESS, PHONENUMBER, SORT, PART, SITUATION) "+
                               " VALUES(@IDX, @PERSONNAL, @NUMBER, @NAME, @OWNER, @ADDRESS, @PHONENUMBER, @SORT, @PART, @SITUATION) ";
                    cmd.CommandText = strQuery;
                }
                

                ////////////////////////////////////////////////////////////////names
                SqlParameter parmClientOwner = new SqlParameter("@OWNER", SqlDbType.NChar, 10);                                              //CommandText 를  파라미터
                parmClientOwner.Value = TxtClientOwner.Text;
                cmd.Parameters.Add(parmClientOwner);
                ///////////////////////////////////////////////////////////////// division
                SqlParameter parmClientpersonnal = new SqlParameter("@PERSONNAL", SqlDbType.NChar, 10);                                                 //CommandText 를  파라미터
                parmClientpersonnal.Value = TxtClientpersonnal.Text;  // 아이템즈가 맞음 !
                cmd.Parameters.Add(parmClientpersonnal);
                //////////////////////////////////////////////////////////////////level
                SqlParameter parmClientName = new SqlParameter("@NAME", SqlDbType.NVarChar, 50);                                            //CommandText 를  파라미터
                parmClientName.Value = TxtClientName.Text;
                cmd.Parameters.Add(parmClientName);
                //////////////////////////////////////////////////////////////////addr
                SqlParameter parmClientphoneNum = new SqlParameter("@PHONENUMBER", SqlDbType.NVarChar, 50);                                                //CommandText 를  파라미터
                parmClientphoneNum.Value = TxtClientphoneNum.Text;
                cmd.Parameters.Add(parmClientphoneNum);
                /////////////////////////////////////////////////////////////////////// email
                SqlParameter parmClientNumber = new SqlParameter("@NUMBER", SqlDbType.NVarChar, 50);                                              //CommandText 를  파라미터
                parmClientNumber.Value = TxtClientNumber.Text;
                cmd.Parameters.Add(parmClientNumber);
                /////////////////////////////////////////////////////////////////////// price
                SqlParameter parmClientpart = new SqlParameter("@PART", SqlDbType.NChar, 10);                                              //CommandText 를  파라미터
                parmClientpart.Value = TxtClientpart.Text;
                cmd.Parameters.Add(parmClientpart);
                /////////////////////////////////////////////////////////////////////// price
                SqlParameter parmClientAddress = new SqlParameter("@ADDRESS", SqlDbType.NVarChar, 100);                                              //CommandText 를  파라미터
                parmClientAddress.Value = TxtClientAddress.Text;
                cmd.Parameters.Add(parmClientAddress);
                /////////////////////////////////////////////////////////////////////// price
                SqlParameter parmClientsituation = new SqlParameter("@SITUATION", SqlDbType.NChar, 10);                                              //CommandText 를  파라미터
                parmClientsituation.Value = TxtClientsituation.Text;
                cmd.Parameters.Add(parmClientsituation);
                /////////////////////////////////////////////////////////////////////// price
                SqlParameter parmClientSort = new SqlParameter("@SORT", SqlDbType.NChar, 10);                                              //CommandText 를  파라미터
                parmClientSort.Value = TxtClientSort.Text;
                cmd.Parameters.Add(parmClientSort);
                ////////////////////////////////////////////////////////////////// Idex
                SqlParameter parmClientidx = new SqlParameter("@IDX", SqlDbType.NChar, 10);                                                  //CommandText 를  파라미터
                parmClientidx.Value = TxtClientidx.Text;
                cmd.Parameters.Add(parmClientidx);
                
                cmd.ExecuteNonQuery();  //데이터 값을 돌려 받지 않는 
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearTextControls();
            mode = "INSERT"; //신규는 INSERT
        }
    }
}
