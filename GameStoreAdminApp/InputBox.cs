using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameStoreAdminApp
{
    public partial class InputBox : Form
    {
        private string answer;

        public InputBox(string question)
        {
            InitializeComponent();
            lblQuestion.Text = question;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbNew.Checked || rbPreowned.Checked)
            {
                answer = rbPreowned.Checked == true ? "Preowned" : "New";
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string getAnswer()
        {
            return answer;
        }
    }
}