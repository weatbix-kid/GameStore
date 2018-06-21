namespace GameStoreAdminApp
{
    partial class frmGenre
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.lstGames = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblSubGenres = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(255, 83);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(255, 7);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 32);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(12, 26);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(210, 17);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Name                    Price $          Quantity";
            // 
            // lstGames
            // 
            this.lstGames.Location = new System.Drawing.Point(15, 46);
            this.lstGames.Name = "lstGames";
            this.lstGames.Size = new System.Drawing.Size(230, 69);
            this.lstGames.TabIndex = 1;
            this.lstGames.DoubleClick += new System.EventHandler(this.lstGames_DoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(255, 45);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(35, 32);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "+";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(300, 45);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(35, 32);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "-";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblSubGenres
            // 
            this.lblSubGenres.Location = new System.Drawing.Point(12, 9);
            this.lblSubGenres.Name = "lblSubGenres";
            this.lblSubGenres.Size = new System.Drawing.Size(278, 17);
            this.lblSubGenres.TabIndex = 8;
            this.lblSubGenres.Text = "Sub Genres:";
            // 
            // frmGenre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 124);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblSubGenres);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lstGames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmGenre";
            this.Text = "Admin - ___";
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnEdit;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ListBox lstGames;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Button btnRemove;
        internal System.Windows.Forms.Label lblSubGenres;
    }
}

