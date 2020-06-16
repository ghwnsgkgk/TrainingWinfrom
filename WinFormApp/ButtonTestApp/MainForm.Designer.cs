namespace ButtonTestApp
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.BTNFLAT = new System.Windows.Forms.Button();
            this.BTNPOPUP = new System.Windows.Forms.Button();
            this.BTNSYSTEM = new System.Windows.Forms.Button();
            this.BTNSTANDARD = new System.Windows.Forms.Button();
            this.LBLBUTTONSTYLE = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BTNFLAT
            // 
            this.BTNFLAT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNFLAT.Location = new System.Drawing.Point(156, 109);
            this.BTNFLAT.Name = "BTNFLAT";
            this.BTNFLAT.Size = new System.Drawing.Size(115, 58);
            this.BTNFLAT.TabIndex = 0;
            this.BTNFLAT.Text = "FLAT";
            this.BTNFLAT.UseVisualStyleBackColor = true;
            this.BTNFLAT.Click += new System.EventHandler(this.BTNFLAT_Click);
            // 
            // BTNPOPUP
            // 
            this.BTNPOPUP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTNPOPUP.Location = new System.Drawing.Point(499, 109);
            this.BTNPOPUP.Name = "BTNPOPUP";
            this.BTNPOPUP.Size = new System.Drawing.Size(111, 58);
            this.BTNPOPUP.TabIndex = 2;
            this.BTNPOPUP.Text = "POPUP";
            this.BTNPOPUP.UseVisualStyleBackColor = true;
            this.BTNPOPUP.Click += new System.EventHandler(this.BTNPOPUP_Click);
            // 
            // BTNSYSTEM
            // 
            this.BTNSYSTEM.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BTNSYSTEM.Location = new System.Drawing.Point(499, 277);
            this.BTNSYSTEM.Name = "BTNSYSTEM";
            this.BTNSYSTEM.Size = new System.Drawing.Size(111, 56);
            this.BTNSYSTEM.TabIndex = 3;
            this.BTNSYSTEM.Text = "SYSTEM";
            this.BTNSYSTEM.UseVisualStyleBackColor = true;
            this.BTNSYSTEM.Click += new System.EventHandler(this.BTNSYSTEM_Click);
            // 
            // BTNSTANDARD
            // 
            this.BTNSTANDARD.Location = new System.Drawing.Point(156, 277);
            this.BTNSTANDARD.Name = "BTNSTANDARD";
            this.BTNSTANDARD.Size = new System.Drawing.Size(115, 56);
            this.BTNSTANDARD.TabIndex = 1;
            this.BTNSTANDARD.Text = "STANDARD";
            this.BTNSTANDARD.UseVisualStyleBackColor = true;
            this.BTNSTANDARD.Click += new System.EventHandler(this.BTNSTANDARD_Click);
            // 
            // LBLBUTTONSTYLE
            // 
            this.LBLBUTTONSTYLE.AutoSize = true;
            this.LBLBUTTONSTYLE.Location = new System.Drawing.Point(40, 392);
            this.LBLBUTTONSTYLE.Name = "LBLBUTTONSTYLE";
            this.LBLBUTTONSTYLE.Size = new System.Drawing.Size(45, 15);
            this.LBLBUTTONSTYLE.TabIndex = 2;
            this.LBLBUTTONSTYLE.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LBLBUTTONSTYLE);
            this.Controls.Add(this.BTNSTANDARD);
            this.Controls.Add(this.BTNSYSTEM);
            this.Controls.Add(this.BTNPOPUP);
            this.Controls.Add(this.BTNFLAT);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTNFLAT;
        private System.Windows.Forms.Button BTNPOPUP;
        private System.Windows.Forms.Button BTNSYSTEM;
        private System.Windows.Forms.Button BTNSTANDARD;
        private System.Windows.Forms.Label LBLBUTTONSTYLE;
    }
}

