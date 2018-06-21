namespace GameStoreAdminApp
{
    partial class InputBox
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.rbNew = new System.Windows.Forms.RadioButton();
            this.rbPreowned = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(117, 79);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 79);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(56, 16);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(59, 13);
            this.lblQuestion.TabIndex = 2;
            this.lblQuestion.Text = "lblQuestion";
            this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbNew
            // 
            this.rbNew.AutoSize = true;
            this.rbNew.Checked = true;
            this.rbNew.Location = new System.Drawing.Point(24, 42);
            this.rbNew.Name = "rbNew";
            this.rbNew.Size = new System.Drawing.Size(47, 17);
            this.rbNew.TabIndex = 12;
            this.rbNew.TabStop = true;
            this.rbNew.Text = "New";
            this.rbNew.UseVisualStyleBackColor = true;
            // 
            // rbPreowned
            // 
            this.rbPreowned.AutoSize = true;
            this.rbPreowned.Location = new System.Drawing.Point(105, 42);
            this.rbPreowned.Name = "rbPreowned";
            this.rbPreowned.Size = new System.Drawing.Size(73, 17);
            this.rbPreowned.TabIndex = 12;
            this.rbPreowned.Text = "Preowned";
            this.rbPreowned.UseVisualStyleBackColor = true;
            // 
            // InputBox
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 114);
            this.Controls.Add(this.rbPreowned);
            this.Controls.Add(this.rbNew);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "InputBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.RadioButton rbNew;
        private System.Windows.Forms.RadioButton rbPreowned;
    }
}