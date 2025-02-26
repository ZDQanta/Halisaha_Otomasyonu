namespace HalıSaha
{
    partial class frmSahaListele
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
            this.pnl_UstMenu = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pnl_Logo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.sahaListePanel = new System.Windows.Forms.Panel();
            this.pnl_UstMenu.SuspendLayout();
            this.pnl_Logo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_UstMenu
            // 
            this.pnl_UstMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.pnl_UstMenu.Controls.Add(this.button1);
            this.pnl_UstMenu.Controls.Add(this.pnl_Logo);
            this.pnl_UstMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_UstMenu.Location = new System.Drawing.Point(0, 0);
            this.pnl_UstMenu.Name = "pnl_UstMenu";
            this.pnl_UstMenu.Size = new System.Drawing.Size(645, 56);
            this.pnl_UstMenu.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Cornsilk;
            this.button1.Location = new System.Drawing.Point(596, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 56);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.label1.Text = "SAHA LİSTESİ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sahaListePanel
            // 
            this.sahaListePanel.BackColor = System.Drawing.Color.Teal;
            this.sahaListePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sahaListePanel.Location = new System.Drawing.Point(0, 56);
            this.sahaListePanel.Name = "sahaListePanel";
            this.sahaListePanel.Size = new System.Drawing.Size(645, 434);
            this.sahaListePanel.TabIndex = 4;
            // 
            // frmSahaListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 490);
            this.Controls.Add(this.sahaListePanel);
            this.Controls.Add(this.pnl_UstMenu);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSahaListele";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSahaListele";
            this.Load += new System.EventHandler(this.frmSahaListele_Load);
            this.pnl_UstMenu.ResumeLayout(false);
            this.pnl_Logo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_UstMenu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnl_Logo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel sahaListePanel;
    }
}