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
    public partial class MemberForm : MetroForm
    {
        
        string mode = "";
        public MemberForm()
        {
            InitializeComponent();
        }

     

        private void UpdateData()  //이거 정확하게 이해해자 
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))//다른 창에 STATIC 문으로 작성하여  연결하는 방법 만약 링크를 바꿔야하면 창을 모두 다 열어서 
                                                                              //바꿔야하는데 이렇게 코딩을 하면 해당 창에만 링크 주소를 바꾸면 모두 다 적용된다. 
            {
                conn.Open(); // Db 열기
                string strQuery = "SELECT Idx,Names,Levels,Addr,Mobile,Email " +
                                  "  FROM membertbl ";
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery,conn); //데이타 가져오는 플러그 !!1
                DataSet ds = new DataSet(); 
                dataAdapter.Fill(ds, "membertbl");//데이타 집합  //ds 통에다가 divtbl 이름으로 넣었다
                GridMemberTbl.DataSource = ds;
                GridMemberTbl.DataMember = "membertbl";  //그걸 다시 Grd 통에 넣는다 ,
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
                DataGridViewRow data = GridMemberTbl.Rows[e.RowIndex];
                TxtIdx.Text     = data.Cells[0].Value.ToString();
                TxtNames.Text   = data.Cells[1].Value.ToString();
                TxtIdx.ReadOnly = true;  // PK 값은 수정하면 단된다. TXTDIVISION이 PK값이다.
                TxtIdx.BackColor = Color.Beige;
               
                CboLevels.SelectedIndex =CboLevels.FindString(data.Cells[2].Value.ToString());  // 콤보 박스에서 찾은 인덱스는 = 데이터에서 2번값에서 가져온 값을 찾아라
                
                TxtAddr.Text = data.Cells[3].Value.ToString();
                TxtMobile.Text = data.Cells[4].Value.ToString();
                TxtEmail.Text = data.Cells[5].Value.ToString();



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
            if(String.IsNullOrEmpty(TxtAddr.Text) || String.IsNullOrEmpty(TxtNames.Text) || String.IsNullOrEmpty(TxtMobile.Text) || String.IsNullOrEmpty(TxtEmail.Text))
                //이걸 안 집어 넣고 널로 두면 에러난다!
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
            TxtIdx.Text = TxtNames.Text = TxtEmail.Text = TxtAddr.Text= TxtMobile.Text = "";
            CboLevels.SelectedIndex = -1; //이거 필수 레벨 설정하는거랑 관련해서 -1부터 시작!!!1
            TxtIdx.ReadOnly = true;
            TxtIdx.BackColor = Color.Beige;
            TxtNames.Focus();

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
                    strQuery =  " UPDATE dbo.membertbl " +
                                " SET Names = @Names, "+
                                " Levels = @Levels, "+
                                " Addr = @Addr, "+
                                " Mobile = @Mobile, " +
                                " Email = @Email " +
                                " WHERE Idx = @Idx "; /// 띄어 쓰기 잘하기 
                
                    cmd.CommandText = strQuery; // 쿼리문을 실행 시키는 부분 !   
                }
                else if (mode == "INSERT")
                {
                    strQuery = "INSERT INTO dbo.membertbl(Names,Levels,Addr,Mobile,Email) " +
                               "      VALUES(@Names, @Levels, @Addr, @Mobile, @Email) ";
                }

                

                ////////////////////////////////////////////////////////////////names
                SqlParameter parmNames = new SqlParameter("@Names", SqlDbType.NVarChar, 45);                                              //CommandText 를  파라미터
                parmNames.Value = TxtNames.Text;
                cmd.Parameters.Add(parmNames);
                ///////////////////////////////////////////////////////////////// division
                SqlParameter parmLevels = new SqlParameter("@Levels", SqlDbType.Char, 4);                                                 //CommandText 를  파라미터
                parmLevels.Value = CboLevels.SelectedItem;  // 아이템즈가 맞음 !
                cmd.Parameters.Add(parmLevels);
                //////////////////////////////////////////////////////////////////level
                SqlParameter parmMobile = new SqlParameter("@Mobile", SqlDbType.NVarChar, 45);                                            //CommandText 를  파라미터
                parmMobile.Value = TxtMobile.Text;
                cmd.Parameters.Add(parmMobile);
                //////////////////////////////////////////////////////////////////addr
                SqlParameter parmAddr = new SqlParameter("@Addr", SqlDbType.NVarChar, 45);                                                //CommandText 를  파라미터
                parmAddr.Value = TxtAddr.Text;
                cmd.Parameters.Add(parmAddr);
                /////////////////////////////////////////////////////////////////////// email
                SqlParameter parmEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 45);                                              //CommandText 를  파라미터
                parmEmail.Value = TxtEmail.Text;
                cmd.Parameters.Add(parmEmail);
                ////////////////////////////////////////////////////////////////// Idex
                if (mode == "UPDATE")
                {
                    SqlParameter parmIdx = new SqlParameter("@Idx", SqlDbType.NVarChar, 45);                                                  //CommandText 를  파라미터
                    parmIdx.Value = TxtIdx.Text;
                    cmd.Parameters.Add(parmIdx);
                    
                }
               
                
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
            if (String.IsNullOrEmpty(TxtIdx.Text) || String.IsNullOrEmpty(TxtNames.Text))
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
            using (SqlConnection coon = new SqlConnection(Commons.CONNSTRING))  //다른 창에 STATIC 문으로 작성하여  연결하는 방법 만약 링크를 바꿔야하면 창을 모두 다 열어서 
                                                                                //바꿔야하는데 이렇게 코딩을 하면 해당 창에만 링크 주소를 바꾸면 모두 다 적용된다. 
            {
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandText = "DELETE FROM dbo.divtbl WHERE Division = @Division";
                SqlParameter parameter = new SqlParameter("@Division", SqlDbType.Char, 4);
                parameter.Value = TxtIdx.Text;
                cmd.Parameters.Add(parameter);
                cmd.ExecuteNonQuery(); // 이게 마지막으로 실행시켜주는 
            }
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            UpdateData(); // 데이터그리드DB 데이터 로딩하기
        }

        private void CboLevels_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
