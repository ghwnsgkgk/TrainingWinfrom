﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace BookRentalShop20
{
    public partial class LoginForm :MetroForm
    {
        string strConnString = "Data Source=192.168.0.28;Initial Catalog=BookRentalshopDB;Persist Security Info=True;User ID=sa;Password=p@ssw0rd!";
        public LoginForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 캔슬버튼 클릭이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //Application.Exit(); //단점이 있다 정확하게 해제가 안되는 경우가 있다.
            Environment.Exit(0); // 0 false 에러가 없다 -> 정상적인 종료 1 true 에러가 있다. 
        }
        /// <summary>
        /// 로그인 처리버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOk_Click(object sender, EventArgs e)
        {
            LoginProcess();
        }

        private void TxtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==13) //엔터
            {
                TxtPassword.Focus();
            }  
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                LoginProcess();
            }
        }

        private void LoginProcess()  //기본적이 널 값 처리
        {

            //throw new NotImplementedException(); //throw 예외 처리 구현이 안된 에러처리
            if ((string.IsNullOrEmpty(TxtUserID.Text) ) ||  (string.IsNullOrEmpty(TxtPassword.Text) ))   // 이즈널 오아 엠티로  간단하게 변경
            {
                MetroMessageBox.Show(this, "아이디/패스워드를 입력하세요!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string strUserId = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnString)) //ip 보면 서울에 있는지 대구에 있는지 알수 있다. 접속할려면 아이디 페스워드 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT userID FROM userTBL  " +                 //SQL 구문을 가져 와서 넣을 때는 꼭 구문 사이사이를 띄워줘야 한다.
                                  "  WHERE userID = @userID " +                   //SQL구문을 가져 와서 넣는다.
                                  "  AND password = @password";                  //사용자가 사용 하면 바로 진행되는 !
               //////////////////////////////////////////////////////////////////// ID
                SqlParameter parmUserId = new SqlParameter("@userID", SqlDbType.VarChar, 12);                                                //CommandText 를  파라미터
                parmUserId.Value = TxtUserID.Text;
                cmd.Parameters.Add(parmUserId);
                ///////////////////////////////////////////////////////////////// PASSWORD
                SqlParameter parPassword = new SqlParameter("@password", SqlDbType.VarChar, 12);                                              //CommandText 를  파라미터
                parPassword.Value = TxtPassword.Text;
                cmd.Parameters.Add(parPassword);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                strUserId = reader["userID"].ToString();

                MetroMessageBox.Show(this, "접속성공", " 로그인");
                Debug.WriteLine("On the Debug");
            }
        }
    }
}