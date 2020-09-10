namespace MiniProject
{
    partial class InOutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GrdInOutTbl = new MetroFramework.Controls.MetroGrid();
            this.lblinoutput = new System.Windows.Forms.Label();
            this.Txtidx = new System.Windows.Forms.TextBox();
            this.TxtProductidx = new System.Windows.Forms.TextBox();
            this.TxtProductUnit = new System.Windows.Forms.TextBox();
            this.TxtClientidx = new System.Windows.Forms.TextBox();
            this.BtnIn = new System.Windows.Forms.Button();
            this.BtnOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblinoutidx = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnNew = new System.Windows.Forms.Button();
            this.DtpReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.CbowhereHouse = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdInOutTbl)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(20, 60);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GrdInOutTbl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.CbowhereHouse);
            this.splitContainer1.Panel2.Controls.Add(this.DtpReleaseDate);
            this.splitContainer1.Panel2.Controls.Add(this.BtnNew);
            this.splitContainer1.Panel2.Controls.Add(this.BtnOut);
            this.splitContainer1.Panel2.Controls.Add(this.BtnIn);
            this.splitContainer1.Panel2.Controls.Add(this.TxtClientidx);
            this.splitContainer1.Panel2.Controls.Add(this.TxtProductUnit);
            this.splitContainer1.Panel2.Controls.Add(this.TxtProductidx);
            this.splitContainer1.Panel2.Controls.Add(this.Txtidx);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.lblinoutidx);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.lblinoutput);
            this.splitContainer1.Size = new System.Drawing.Size(1090, 454);
            this.splitContainer1.SplitterDistance = 763;
            this.splitContainer1.TabIndex = 0;
            // 
            // GrdInOutTbl
            // 
            this.GrdInOutTbl.AllowUserToAddRows = false;
            this.GrdInOutTbl.AllowUserToDeleteRows = false;
            this.GrdInOutTbl.AllowUserToResizeRows = false;
            this.GrdInOutTbl.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.GrdInOutTbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdInOutTbl.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GrdInOutTbl.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrdInOutTbl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.GrdInOutTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrdInOutTbl.DefaultCellStyle = dataGridViewCellStyle14;
            this.GrdInOutTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdInOutTbl.EnableHeadersVisualStyles = false;
            this.GrdInOutTbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.GrdInOutTbl.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.GrdInOutTbl.Location = new System.Drawing.Point(0, 0);
            this.GrdInOutTbl.Name = "GrdInOutTbl";
            this.GrdInOutTbl.ReadOnly = true;
            this.GrdInOutTbl.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrdInOutTbl.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.GrdInOutTbl.RowHeadersWidth = 51;
            this.GrdInOutTbl.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GrdInOutTbl.RowTemplate.Height = 27;
            this.GrdInOutTbl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdInOutTbl.Size = new System.Drawing.Size(763, 454);
            this.GrdInOutTbl.TabIndex = 0;
            this.GrdInOutTbl.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdInOutTbl_CellClick);
            // 
            // lblinoutput
            // 
            this.lblinoutput.AutoSize = true;
            this.lblinoutput.Location = new System.Drawing.Point(13, 16);
            this.lblinoutput.Name = "lblinoutput";
            this.lblinoutput.Size = new System.Drawing.Size(57, 15);
            this.lblinoutput.TabIndex = 0;
            this.lblinoutput.Text = "입.출고";
            // 
            // Txtidx
            // 
            this.Txtidx.Location = new System.Drawing.Point(105, 60);
            this.Txtidx.Name = "Txtidx";
            this.Txtidx.Size = new System.Drawing.Size(176, 25);
            this.Txtidx.TabIndex = 1;
            // 
            // TxtProductidx
            // 
            this.TxtProductidx.Location = new System.Drawing.Point(105, 148);
            this.TxtProductidx.Name = "TxtProductidx";
            this.TxtProductidx.Size = new System.Drawing.Size(176, 25);
            this.TxtProductidx.TabIndex = 1;
            // 
            // TxtProductUnit
            // 
            this.TxtProductUnit.Location = new System.Drawing.Point(105, 192);
            this.TxtProductUnit.Name = "TxtProductUnit";
            this.TxtProductUnit.Size = new System.Drawing.Size(176, 25);
            this.TxtProductUnit.TabIndex = 1;
            // 
            // TxtClientidx
            // 
            this.TxtClientidx.Location = new System.Drawing.Point(105, 280);
            this.TxtClientidx.Name = "TxtClientidx";
            this.TxtClientidx.Size = new System.Drawing.Size(176, 25);
            this.TxtClientidx.TabIndex = 1;
            // 
            // BtnIn
            // 
            this.BtnIn.Location = new System.Drawing.Point(105, 380);
            this.BtnIn.Name = "BtnIn";
            this.BtnIn.Size = new System.Drawing.Size(75, 43);
            this.BtnIn.TabIndex = 2;
            this.BtnIn.Text = "IN";
            this.BtnIn.UseVisualStyleBackColor = true;
            this.BtnIn.Click += new System.EventHandler(this.BtnIn_Click);
            // 
            // BtnOut
            // 
            this.BtnOut.Location = new System.Drawing.Point(206, 380);
            this.BtnOut.Name = "BtnOut";
            this.BtnOut.Size = new System.Drawing.Size(75, 43);
            this.BtnOut.TabIndex = 2;
            this.BtnOut.Text = "OUT";
            this.BtnOut.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "품목코드";
            // 
            // lblinoutidx
            // 
            this.lblinoutidx.AutoSize = true;
            this.lblinoutidx.Location = new System.Drawing.Point(59, 65);
            this.lblinoutidx.Name = "lblinoutidx";
            this.lblinoutidx.Size = new System.Drawing.Size(37, 15);
            this.lblinoutidx.TabIndex = 0;
            this.lblinoutidx.Text = "번호";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "일자";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "수량";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "창고";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "거래처번호";
            // 
            // BtnNew
            // 
            this.BtnNew.Location = new System.Drawing.Point(105, 322);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(176, 40);
            this.BtnNew.TabIndex = 3;
            this.BtnNew.Text = "신규등록";
            this.BtnNew.UseVisualStyleBackColor = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // DtpReleaseDate
            // 
            this.DtpReleaseDate.Location = new System.Drawing.Point(105, 103);
            this.DtpReleaseDate.Name = "DtpReleaseDate";
            this.DtpReleaseDate.Size = new System.Drawing.Size(176, 25);
            this.DtpReleaseDate.TabIndex = 4;
            // 
            // CbowhereHouse
            // 
            this.CbowhereHouse.FormattingEnabled = true;
            this.CbowhereHouse.Location = new System.Drawing.Point(105, 238);
            this.CbowhereHouse.Name = "CbowhereHouse";
            this.CbowhereHouse.Size = new System.Drawing.Size(176, 23);
            this.CbowhereHouse.TabIndex = 5;
            // 
            // InOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 534);
            this.Controls.Add(this.splitContainer1);
            this.Name = "InOutForm";
            this.Text = "InOutForm";
            this.Load += new System.EventHandler(this.In_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdInOutTbl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private MetroFramework.Controls.MetroGrid GrdInOutTbl;
        private System.Windows.Forms.Button BtnOut;
        private System.Windows.Forms.Button BtnIn;
        private System.Windows.Forms.TextBox TxtClientidx;
        private System.Windows.Forms.TextBox TxtProductUnit;
        private System.Windows.Forms.TextBox TxtProductidx;
        private System.Windows.Forms.TextBox Txtidx;
        private System.Windows.Forms.Label lblinoutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblinoutidx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.ComboBox CbowhereHouse;
        private System.Windows.Forms.DateTimePicker DtpReleaseDate;
    }
}