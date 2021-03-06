﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Form1_Paint,폼에 이미지 그리기 메서드
        /// created date : 2020.06.17
        /// creator : ghwnsgkgkgk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();

            Pen pen = new Pen(Color.DeepPink);
            pen.Width = 3.2f;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            //Point starpoint = new Point(45, 45);
            //Point endpoint = new Point(180, 150);
            //g.DrawLine(pen, starpoint, endpoint);
            //g.DrawLine(pen, 190, 60, 65, 170);

            Rectangle[] rects = new Rectangle[]
            {
                new Rectangle(40,40,40,100),
                new Rectangle(100,40,100,40),
                new Rectangle(100,100,100,40)

            };
            //Rectangle rect = new Rectangle(50, 50, 100, 100);
            g.FillRectangles(Brushes.BlueViolet, rects);
            g.DrawRectangles(pen, rects);


            Point[] pts =
            {
                new Point(515,30),    new Point(540,90),
                new Point(600,115),   new Point(540,140),
                new Point(515,200),   new Point(490,140),
                new Point(430,115),   new Point(490,90),

            };
            g.FillClosedCurve(Brushes.YellowGreen, pts);
                g.DrawClosedCurve(pen, pts);
        }
    }
}
