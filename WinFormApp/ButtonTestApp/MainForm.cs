using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonTestApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BTNFLAT_Click(object sender, EventArgs e)
        {
            LBLBUTTONSTYLE.Text = FlatStyle.Flat.ToString();
        }

        private void BTNPOPUP_Click(object sender, EventArgs e)
        {
            LBLBUTTONSTYLE.Text = FlatStyle.Popup.ToString();

        }

        private void BTNSTANDARD_Click(object sender, EventArgs e)
        {
            LBLBUTTONSTYLE.Text = FlatStyle.Standard.ToString();

        }

        private void BTNSYSTEM_Click(object sender, EventArgs e)
        {
            LBLBUTTONSTYLE.Text = FlatStyle.System.ToString();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LBLBUTTONSTYLE.Text = "결과표시";
        }
    }
}
