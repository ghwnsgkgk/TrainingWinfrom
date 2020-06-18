using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChartControlApp
{
    public partial class Form1 : MetroFramework.Forms.MetroForm  //요거하면 이뻐진다.
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Using Chart Control";

            // 10명의 학생 랜덤 점수 생성 및 차트 바인딩
            Random random = new Random();
            chart1.Titles.Add("중간고사 성적");
            for (int i = 0; i < 10; i++)
            {
                int valure = random.Next(10, 100);
                chart1.Series["Score"].Points.Add(valure);
                chart1.Series["Score"].ToolTip = valure.ToString();
            }
            chart1.Series["Score"].LegendText = "수학점수";
            chart1.Series["Score"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series["Score"].ToolTip = "테스트";
        
        } // 로직을 이해하면 된다 !!!!!!!! 제발 ㅡㅡ

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["Score"].Points.Clear();
            MetroMessageBox.Show(this,"데이터를 지웠습니다.", "처리", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
