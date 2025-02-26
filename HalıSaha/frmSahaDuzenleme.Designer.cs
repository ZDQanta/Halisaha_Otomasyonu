namespace HalıSaha
{
    partial class frmSahaDuzenleme
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
            this.pnl_Logo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pnl_UstMenu = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.txtacıklama = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_sahaadi = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RB_DOGAL = new System.Windows.Forms.RadioButton();
            this.rb_yapay = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_kapali = new System.Windows.Forms.RadioButton();
            this.rb_acik = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ıd = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.sec_combo = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbl_cimturu = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lbl_sahaturu = new System.Windows.Forms.Label();
            this.pnl_Logo.SuspendLayout();
            this.pnl_UstMenu.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Logo
            // 
            this.pnl_Logo.BackColor = System.Drawing.Color.White;
            this.pnl_Logo.Controls.Add(this.label1);
            this.pnl_Logo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Logo.Location = new System.Drawing.Point(0, 0);
            this.pnl_Logo.Name = "pnl_Logo";
            this.pnl_Logo.Size = new System.Drawing.Size(165, 56);
            this.pnl_Logo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 56);
            this.label1.TabIndex = 1;
            this.label1.Text = "SAHA DÜZENLE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Cornsilk;
            this.button1.Location = new System.Drawing.Point(877, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 56);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnl_UstMenu
            // 
            this.pnl_UstMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.pnl_UstMenu.Controls.Add(this.button3);
            this.pnl_UstMenu.Controls.Add(this.button1);
            this.pnl_UstMenu.Controls.Add(this.pnl_Logo);
            this.pnl_UstMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_UstMenu.Location = new System.Drawing.Point(0, 0);
            this.pnl_UstMenu.Name = "pnl_UstMenu";
            this.pnl_UstMenu.Size = new System.Drawing.Size(926, 56);
            this.pnl_UstMenu.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.RosyBrown;
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Cornsilk;
            this.button3.Location = new System.Drawing.Point(828, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(49, 56);
            this.button3.TabIndex = 2;
            this.button3.Text = "SİL";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtacıklama
            // 
            this.txtacıklama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtacıklama.Location = new System.Drawing.Point(3, 30);
            this.txtacıklama.Multiline = true;
            this.txtacıklama.Name = "txtacıklama";
            this.txtacıklama.Size = new System.Drawing.Size(282, 287);
            this.txtacıklama.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtacıklama);
            this.groupBox4.ForeColor = System.Drawing.Color.Lime;
            this.groupBox4.Location = new System.Drawing.Point(627, 85);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(288, 320);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "AÇIKLAMA";
            // 
            // txt_sahaadi
            // 
            this.txt_sahaadi.Location = new System.Drawing.Point(6, 50);
            this.txt_sahaadi.Name = "txt_sahaadi";
            this.txt_sahaadi.Size = new System.Drawing.Size(276, 34);
            this.txt_sahaadi.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_sahaadi);
            this.groupBox1.ForeColor = System.Drawing.Color.Lime;
            this.groupBox1.Location = new System.Drawing.Point(18, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 90);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SAHA İSMİ";
            // 
            // RB_DOGAL
            // 
            this.RB_DOGAL.AutoSize = true;
            this.RB_DOGAL.Checked = true;
            this.RB_DOGAL.Location = new System.Drawing.Point(6, 43);
            this.RB_DOGAL.Name = "RB_DOGAL";
            this.RB_DOGAL.Size = new System.Drawing.Size(99, 32);
            this.RB_DOGAL.TabIndex = 6;
            this.RB_DOGAL.TabStop = true;
            this.RB_DOGAL.Text = "DOĞAL";
            this.RB_DOGAL.UseVisualStyleBackColor = true;
            this.RB_DOGAL.CheckedChanged += new System.EventHandler(this.RB_DOGAL_CheckedChanged);
            // 
            // rb_yapay
            // 
            this.rb_yapay.AutoSize = true;
            this.rb_yapay.Location = new System.Drawing.Point(143, 43);
            this.rb_yapay.Name = "rb_yapay";
            this.rb_yapay.Size = new System.Drawing.Size(90, 32);
            this.rb_yapay.TabIndex = 7;
            this.rb_yapay.Text = "YAPAY";
            this.rb_yapay.UseVisualStyleBackColor = true;
            this.rb_yapay.CheckedChanged += new System.EventHandler(this.rb_yapay_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_yapay);
            this.groupBox2.Controls.Add(this.RB_DOGAL);
            this.groupBox2.ForeColor = System.Drawing.Color.Lime;
            this.groupBox2.Location = new System.Drawing.Point(18, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 90);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ÇİM TÜRÜ";
            // 
            // rb_kapali
            // 
            this.rb_kapali.AutoSize = true;
            this.rb_kapali.Location = new System.Drawing.Point(143, 42);
            this.rb_kapali.Name = "rb_kapali";
            this.rb_kapali.Size = new System.Drawing.Size(98, 32);
            this.rb_kapali.TabIndex = 9;
            this.rb_kapali.Text = "KAPALI";
            this.rb_kapali.UseVisualStyleBackColor = true;
            this.rb_kapali.CheckedChanged += new System.EventHandler(this.rb_kapali_CheckedChanged);
            // 
            // rb_acik
            // 
            this.rb_acik.AutoSize = true;
            this.rb_acik.Checked = true;
            this.rb_acik.Location = new System.Drawing.Point(6, 42);
            this.rb_acik.Name = "rb_acik";
            this.rb_acik.Size = new System.Drawing.Size(76, 32);
            this.rb_acik.TabIndex = 8;
            this.rb_acik.TabStop = true;
            this.rb_acik.Text = "AÇIK";
            this.rb_acik.UseVisualStyleBackColor = true;
            this.rb_acik.CheckedChanged += new System.EventHandler(this.rb_acik_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rb_acik);
            this.groupBox3.Controls.Add(this.rb_kapali);
            this.groupBox3.ForeColor = System.Drawing.Color.Lime;
            this.groupBox3.Location = new System.Drawing.Point(18, 315);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(288, 90);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SAHA TÜRÜ";
            // 
            // ıd
            // 
            this.ıd.AutoSize = true;
            this.ıd.Location = new System.Drawing.Point(950, 115);
            this.ıd.Name = "ıd";
            this.ıd.Size = new System.Drawing.Size(29, 28);
            this.ıd.TabIndex = 14;
            this.ıd.Text = "ıd";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Lime;
            this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button2.Location = new System.Drawing.Point(0, 440);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(926, 49);
            this.button2.TabIndex = 13;
            this.button2.Text = "TAMAMLA";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.sec_combo);
            this.groupBox5.ForeColor = System.Drawing.Color.Lime;
            this.groupBox5.Location = new System.Drawing.Point(323, 85);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(288, 90);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "SAHA İSMİ";
            // 
            // sec_combo
            // 
            this.sec_combo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sec_combo.FormattingEnabled = true;
            this.sec_combo.Location = new System.Drawing.Point(3, 51);
            this.sec_combo.Name = "sec_combo";
            this.sec_combo.Size = new System.Drawing.Size(282, 36);
            this.sec_combo.TabIndex = 0;
            this.sec_combo.SelectedIndexChanged += new System.EventHandler(this.sec_combo_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lbl_cimturu);
            this.groupBox6.ForeColor = System.Drawing.Color.Lime;
            this.groupBox6.Location = new System.Drawing.Point(323, 203);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(288, 90);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "MEVCUT ÇİM";
            // 
            // lbl_cimturu
            // 
            this.lbl_cimturu.AutoSize = true;
            this.lbl_cimturu.Location = new System.Drawing.Point(16, 45);
            this.lbl_cimturu.Name = "lbl_cimturu";
            this.lbl_cimturu.Size = new System.Drawing.Size(78, 28);
            this.lbl_cimturu.TabIndex = 15;
            this.lbl_cimturu.Text = "DOĞAL";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lbl_sahaturu);
            this.groupBox7.ForeColor = System.Drawing.Color.Lime;
            this.groupBox7.Location = new System.Drawing.Point(323, 315);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(288, 90);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "MEVCUT SAHA";
            // 
            // lbl_sahaturu
            // 
            this.lbl_sahaturu.AutoSize = true;
            this.lbl_sahaturu.Location = new System.Drawing.Point(16, 46);
            this.lbl_sahaturu.Name = "lbl_sahaturu";
            this.lbl_sahaturu.Size = new System.Drawing.Size(55, 28);
            this.lbl_sahaturu.TabIndex = 16;
            this.lbl_sahaturu.Text = "AÇIK";
            // 
            // frmSahaDuzenleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(926, 489);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ıd);
            this.Controls.Add(this.pnl_UstMenu);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSahaDuzenleme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSahaDuzenleme";
            this.Load += new System.EventHandler(this.frmSahaDuzenleme_Load);
            this.pnl_Logo.ResumeLayout(false);
            this.pnl_UstMenu.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Logo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnl_UstMenu;
        private System.Windows.Forms.TextBox txtacıklama;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txt_sahaadi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RB_DOGAL;
        private System.Windows.Forms.RadioButton rb_yapay;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_kapali;
        private System.Windows.Forms.RadioButton rb_acik;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label ıd;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox sec_combo;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lbl_cimturu;
        private System.Windows.Forms.Label lbl_sahaturu;
        private System.Windows.Forms.Button button3;
    }
}