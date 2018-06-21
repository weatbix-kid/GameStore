namespace GameStoreAdminApp
{
    partial class frmMain
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
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.lstGenres = new System.Windows.Forms.ListBox();
            this.btnOrders = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(164, 118);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(80, 32);
            this.btnQuit.TabIndex = 4;
            this.btnQuit.Text = "Quit";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(164, 29);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(80, 32);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "Show";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(17, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(136, 16);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Genres";
            // 
            // lstGenres
            // 
            this.lstGenres.Location = new System.Drawing.Point(17, 28);
            this.lstGenres.Name = "lstGenres";
            this.lstGenres.Size = new System.Drawing.Size(136, 121);
            this.lstGenres.TabIndex = 1;
            this.lstGenres.DoubleClick += new System.EventHandler(this.lstGenres_DoubleClick);
            // 
            // btnOrders
            // 
            this.btnOrders.Location = new System.Drawing.Point(164, 66);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(80, 32);
            this.btnOrders.TabIndex = 3;
            this.btnOrders.Text = "Orders";
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 161);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lstGenres);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMain";
            this.Text = "Admin - Main";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button btnQuit;
        internal System.Windows.Forms.Button btnShow;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ListBox lstGenres;
        internal System.Windows.Forms.Button btnOrders;
    }
}

