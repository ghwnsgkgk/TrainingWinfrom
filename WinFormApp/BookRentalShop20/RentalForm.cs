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
    public partial class RentalForm : MetroForm
    {

        string strConnString = "Data Source=192.168.0.28;Initial Catalog=BookRentalshopDB;Persist Security Info=True;User ID=sa;Password=p@ssw0rd!";
        public RentalForm()
        {
            InitializeComponent();
        }
        private void UpdateDate()
        {
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                conn.Open(); // Db 열기
                string strQuery = "SELECT r.idx AS '순번', m.Idx AS '회원번호', " +
                                  " b.Idx AS '책번호', " +
                                  " r.rentalDate AS '대여일', r.returnDate AS '반납일' " +
                                  " FROM rentaltbl AS r " +
                                  " INNER JOIN membertbl AS m " +
                                  "  ON r.memberIdx = m.Idx " +
                                  " INNER JOIN bookstbl AS b " +
                                  "  ON r.bookIdx = b.Idx  " +
                                  " INNER JOIN divtbl AS t " +
                                  "   ON b.division = t.division ";
                // SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn); //데이타 가져오는 플러그 !!1
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "rentaltbl");//데이타 집합  //ds 통에다가 divtbl 이름으로 넣었다
                GrdRentaltbl.DataSource = ds;
                GrdRentaltbl.DataMember = "rentaltbl";  //그걸 다시 Grd 통에 넣는다 ,
            }
            DataGridViewColumn column = GrdRentaltbl.Columns[2]; //id컬럼
            column.Visible = false;
        }
        private void RentalForm_Load(object sender, EventArgs e)
        {
            UpdateDate();
        }
    

        


    }

}
