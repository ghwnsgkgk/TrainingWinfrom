using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BookRentalShop20
{
    public partial class BooksForm : MetroForm
    {
        
        string mode = "";
        public BooksForm()
        {
            InitializeComponent();
        }

     

        private void UpdateData()  //이거 정확하게 이해해자 
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))//다른 창에 STATIC 문으로 작성하여  연결하는 방법 만약 링크를 바꿔야하면 창을 모두 다 열어서 
                                                                              //바꿔야하는데 이렇게 코딩을 하면 해당 창에만 링크 주소를 바꾸면 모두 다 적용된다. 
            {
                conn.Open(); // Db 열기
                string strQuery = "SELECT b.Idx, b.Author, b.Division, " +
                                  "              d.Names AS 'DivNames', " +
                                  "        b.Names,b.ReleaseDate,b.ISBN, " +
                                  "        REPLACE(CONVERT(VARCHAR, CONVERT(Money, b.Price), 1), '.00', '') AS Price " +
                                  "        FROM dbo.bookstbl AS b " +
                                  "        INNER JOIN dbo. divtbl AS d " +
                                  "        ON b.Division = d.Division ";
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery,conn); //데이타 가져오는 플러그 !!1
                DataSet ds = new DataSet(); 
                dataAdapter.Fill(ds, "bookstbl");//데이타 집합  //ds 통에다가 divtbl 이름으로 넣었다
                GridBooksTbl.DataSource = ds;
                GridBooksTbl.DataMember = "bookstbl";  //그걸 다시 Grd 통에 넣는다 ,
            }
            DataGridViewColumn column = GridBooksTbl.Columns[2]; //id컬럼
            column.Visible = false;
            //throw new NotImplementedException();
        }

        private void GrdDivTbl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GrdDivTbl_CellClick(object sender, DataGridViewCellEventArgs e)  //꼭 CellClick
        {
            if (e.RowIndex >-1 )
            {   //var data
                DataGridViewRow data = GridBooksTbl.Rows[e.RowIndex];
                TxtIdx.Text     = data.Cells[0].Value.ToString();
                
                TxtIdx.ReadOnly = true;  // PK 값은 수정하면 단된다. TXTDIVISION이 PK값이다.
                TxtIdx.BackColor = Color.Beige;
                TxtAuthor.Text   = data.Cells[1].Value.ToString();

               // CboNames.SelectedIndex =CboNames.FindString(data.Cells[2].Value.ToString());  // 콤보 박스에서 찾은 인덱스는 = 데이터에서 2번값에서 가져온 값을 찾아라

                CboNames.SelectedValue = data.Cells[2].Value;
                TxtNames.Text = data.Cells[4].Value.ToString();


                DtpReleaseDate.CustomFormat = "yyyy-MM-dd";
                DtpReleaseDate.Format = DateTimePickerFormat.Custom; // 값을 리셋해주는 방법



                DtpReleaseDate.Value = DateTime.Parse( data.Cells[5].Value.ToString());
                TxtISBN.Text = data.Cells[6].Value.ToString();
                TxtPrice.Text = data.Cells[7].Value.ToString();


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
            if(String.IsNullOrEmpty(TxtNames.Text) || String.IsNullOrEmpty(TxtAuthor.Text) || String.IsNullOrEmpty(DtpReleaseDate.Text) || String.IsNullOrEmpty(TxtISBN.Text))
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
            TxtIdx.Text = TxtAuthor.Text = TxtISBN.Text = TxtNames.Text= DtpReleaseDate.Text = "";
            TxtPrice.Text = "";
            CboNames.SelectedIndex = -1; //이거 필수 레벨 설정하는거랑 관련해서 -1부터 시작!!!1
            TxtIdx.ReadOnly = true;
            TxtIdx.BackColor = Color.Beige;

            DtpReleaseDate.CustomFormat = " ";
            DtpReleaseDate.Format = DateTimePickerFormat.Custom; // 값을 리셋해주는 방법
            
            TxtAuthor.Focus();

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
                    strQuery =   "UPDATE dbo.bookstbl " +
                                 " SET Author = @Author, " +
                                 " Division = @Division, " +
                                 " Names = @Names, " +
                                 " ReleaseDate = @ReleaseDate, " +
                                 " ISBN = @ISBN, " +
                                 " Price = @Price " +
                                 " WHERE Idx = @Idx  "; /// 띄어 쓰기 잘하기 
                
                      
                }
                else if (mode == "INSERT")
                {
                    strQuery = "INSERT INTO dbo.bookstbl "+           
                               " (Author, Division, Names, ReleaseDate, ISBN, Price) " +
                               " VALUES (@Author, @Division, @Names, @ReleaseDate, @ISBN, @Price) ";
                }
                   cmd.CommandText = strQuery;// 쿼리문을 실행 시키는 부분 ! 


                ////////////////////////////////////////////////////////////////names
                SqlParameter parmAuthor = new SqlParameter("@Author", SqlDbType.VarChar, 45);                                              //CommandText 를  파라미터
                parmAuthor.Value = TxtAuthor.Text;
                cmd.Parameters.Add(parmAuthor);
                ///////////////////////////////////////////////////////////////// division
                SqlParameter parmDivision = new SqlParameter("@Division", SqlDbType.Char, 4);                                                 //CommandText 를  파라미터
                parmDivision.Value = CboNames.SelectedValue;  // 아이템즈가 맞음 !
                cmd.Parameters.Add(parmDivision);
                //////////////////////////////////////////////////////////////////level
                SqlParameter parmNames = new SqlParameter("@Names", SqlDbType.VarChar, 100);                                            //CommandText 를  파라미터
                parmNames.Value = TxtNames.Text;
                cmd.Parameters.Add(parmNames);
                //////////////////////////////////////////////////////////////////addr
                SqlParameter parmReleaseDate = new SqlParameter("@ReleaseDate", SqlDbType.NVarChar, 45);                                                //CommandText 를  파라미터
                parmReleaseDate.Value = DtpReleaseDate.Text;
                cmd.Parameters.Add(parmReleaseDate);
                /////////////////////////////////////////////////////////////////////// email
                SqlParameter parmISBN = new SqlParameter("@ISBN", SqlDbType.VarChar, 200);                                              //CommandText 를  파라미터
                parmISBN.Value = TxtISBN.Text;
                cmd.Parameters.Add(parmISBN);
               
                /////////////////////////////////////////////////////////////////////// price
                SqlParameter parmPrice = new SqlParameter("@Price", SqlDbType.Decimal, 10);                                              //CommandText 를  파라미터
                parmPrice.Value = TxtPrice.Text;
                cmd.Parameters.Add(parmPrice);
                ////////////////////////////////////////////////////////////////// Idex
                if (mode == "UPDATE")
                {
                    SqlParameter parmIdx = new SqlParameter("@Idx", SqlDbType.Int, 2);                                                  //CommandText 를  파라미터
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
            if (String.IsNullOrEmpty(TxtIdx.Text) || String.IsNullOrEmpty(TxtAuthor.Text))
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

            DtpReleaseDate.CustomFormat = " ";
            DtpReleaseDate.Format = DateTimePickerFormat.Custom; // 값을 리셋해주는 방법


            UpdateData(); // 데이터그리드DB 데이터 로딩하기

            UpdateCboDvision();
        }

        private void UpdateCboDvision()
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT Division, Names FROM divtbl";
                SqlDataReader reader = cmd.ExecuteReader(); // 이거 먼지 확인 ?????????
                Dictionary<string, string> temps = new Dictionary<string, string>(); // 제네릭!  division 키 names 는 벨류
                while (reader.Read()) //할때마다 한줄 씩 읽는다.
                {
                    temps.Add(reader[0].ToString(), reader[1].ToString());
                }
                CboNames.DataSource = new BindingSource(temps, null);
                CboNames.DisplayMember = "Value";
                CboNames.ValueMember = "Key";
                CboNames.SelectedIndex = -1;
                
                    

            }
        }

        private void DtpReleaseDate_ValueChanged(object sender, EventArgs e)
        {
            DtpReleaseDate.CustomFormat = "yyyy-MM-dd";
            DtpReleaseDate.Format = DateTimePickerFormat.Custom; // 값을 리셋해주는 방법

        }

        private void TxtAuthor_Click(object sender, EventArgs e)
        {

        }
    }
}
