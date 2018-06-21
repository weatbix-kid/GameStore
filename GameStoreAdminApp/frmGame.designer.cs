namespace GameStoreAdminApp
{
    partial class frmGame
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
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReleaseDate = new System.Windows.Forms.TextBox();
            this.lblModified = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(97, 81);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(96, 20);
            this.txtQuantity.TabIndex = 3;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(9, 84);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(80, 16);
            this.Label2.TabIndex = 46;
            this.Label2.Text = "Quantity";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(97, 49);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(96, 20);
            this.txtPrice.TabIndex = 2;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(9, 52);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(80, 16);
            this.Label1.TabIndex = 44;
            this.Label1.Text = "Price $";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(97, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(96, 20);
            this.txtName.TabIndex = 1;
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(9, 20);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(80, 16);
            this.Label3.TabIndex = 40;
            this.Label3.Text = "Name";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(225, 47);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(225, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(104, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 40;
            this.label4.Text = "Release Date";
            // 
            // txtReleaseDate
            // 
            this.txtReleaseDate.Location = new System.Drawing.Point(97, 114);
            this.txtReleaseDate.Name = "txtReleaseDate";
            this.txtReleaseDate.Size = new System.Drawing.Size(96, 20);
            this.txtReleaseDate.TabIndex = 4;
            // 
            // lblModified
            // 
            this.lblModified.AutoSize = true;
            this.lblModified.Location = new System.Drawing.Point(222, 81);
            this.lblModified.Name = "lblModified";
            this.lblModified.Size = new System.Drawing.Size(72, 13);
            this.lblModified.TabIndex = 47;
            this.lblModified.Text = "Last modified:";
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 176);
            this.Controls.Add(this.lblModified);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtReleaseDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmGame";
            this.Text = "Create a new record";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtQuantity;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtPrice;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtReleaseDate;
        internal System.Windows.Forms.Label lblModified;
    }
}