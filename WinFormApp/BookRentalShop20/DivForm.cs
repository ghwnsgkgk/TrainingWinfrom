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
    public partial class DivForm : MetroForm
    {
        //링크 지워버림
        string mode = "";
        public DivForm()
        {
            InitializeComponent();
        }

        private void DivForm_Load(object sender, EventArgs e)
        {
            UpdateData(); // 데이터그리드DB 데이터 로딩하기
        }

        private void UpdateData()
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING)) //여기서 변수명을 바꿔서 여기서 링크 한다.
            {
                conn.Open(); // Db 열기
                string strQuery = "SELECT Division, Names FROM divtbl";
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery,conn); //데이타 가져오는 플러그 !!1
                DataSet ds = new DataSet(); 
                dataAdapter.Fill(ds, "divtbl");//데이타 집합  //ds 통에다가 divtbl 이름으로 넣었다
                GrdDivTbl.DataSource = ds;
                GrdDivTbl.DataMember = "divtbl";  //그걸 다시 Grd 통에 넣는다 ,
            }
            //throw new NotImplementedException();
        }

        private void GrdDivTbl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
        }

        private void GrdDivTbl_CellClick(object sender, DataGridViewCellEventArgs e)  //꼭 CellClick
        {
            if (e.RowIndex >-1 )
            {   //var data
                DataGridViewRow data = GrdDivTbl.Rows[e.RowIndex];
                TxtDvision.Text      = data.Cells[0].Value.ToString();
                TxtNames.Text        = data.Cells[1].Value.ToString();
                TxtDvision.ReadOnly = true;  // PK 값은 수정하면 단된다. TXTDIVISION이 PK값이다.
                TxtDvision.BackColor = Color.Beige;

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
            if(String.IsNullOrEmpty(TxtDvision.Text) || String.IsNullOrEmpty(TxtNames.Text))
            {
                MetroMessageBox.Show(this, "빈값은 저장할 수 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  //이 리턴 값이 중요하다 ,@@
            } 
            SaveProcess(); //DB저장프로세스
            UpdateData();
            ClearTextControls();
        }

        private void ClearTextControls()
        {
            TxtDvision.Text = TxtNames.Text = "";
            TxtDvision.ReadOnly = false;
            TxtDvision.BackColor = Color.White;
            TxtDvision.Focus();
        }

        private void SaveProcess()
        {
            if (string.IsNullOrEmpty(mode))
            {
                MetroMessageBox.Show(this, "신규버튼을 누르고 데이터를 저장하십시오","경고",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))//다른 창에 STATIC 문으로 작성하여  연결하는 방법 만약 링크를 바꿔야하면 창을 모두 다 열어서 
                                                                              //바꿔야하는데 이렇게 코딩을 하면 해당 창에만 링크 주소를 바꾸면 모두 다 적용된다. 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                String strQuery = "";

                if (mode == "UPDATE")
                {
                    strQuery = "UPDATE dbo.divtbl " +
                               "   SET Names = @Names " +
                               " WHERE Division = @Division ";
                }
                else if (mode == "INSERT")
                {
                    strQuery = "INSERT INTO dbo.divtbl(Division,Names) " +
                              " VALUES(@Division, @Names) ";
                    cmd.CommandText = strQuery;
                }
                ////////////////////////////////////////////////////////////////names
                SqlParameter parmNames = new SqlParameter("@Names", SqlDbType.NVarChar, 45);                                                //CommandText 를  파라미터
                parmNames.Value = TxtNames.Text;
                cmd.Parameters.Add(parmNames);
                ///////////////////////////////////////////////////////////////// division
                SqlParameter parDivision = new SqlParameter("@Division", SqlDbType.Char, 4);                                                //CommandText 를  파라미터
                parDivision.Value = TxtDvision.Text;
                cmd.Parameters.Add(parDivision);
                cmd.ExecuteNonQuery();  //데이터 값을 돌려 받지 않는 
            }
        }

        private void TxtNames_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13) 
            {
                BtnSave_Click(sender, new EventArgs());
            }
        }

        private void BtnDelet_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtDvision.Text) || String.IsNullOrEmpty(TxtNames.Text))
            {
                MetroMessageBox.Show(this, "빈값은 삭제할 수 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  //이 리턴 값이 중요하다 ,@@
            }
            DeletProcess();
            UpdateData();
            ClearTextControls();

        }

        private void DeletProcess()
        {
            using (SqlConnection coon = new SqlConnection(Commons.CONNSTRING))//다른 창에 STATIC 문으로 작성하여  연결하는 방법 만약 링크를 바꿔야하면 창을 모두 다 열어서 
                                                                              //바꿔야하는데 이렇게 코딩을 하면 해당 창에만 링크 주소를 바꾸면 모두 다 적용된다. 
            {
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandText = "DELETE FROM dbo.divtbl WHERE Division = @Division";
                SqlParameter parameter = new SqlParameter("@Division", SqlDbType.Char, 4);
                parameter.Value = TxtDvision.Text;
                cmd.Parameters.Add(parameter);
                cmd.ExecuteNonQuery(); // 이게 마지막으로 실행시켜주는 
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
