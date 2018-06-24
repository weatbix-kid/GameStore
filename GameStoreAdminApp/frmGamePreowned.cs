using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameStoreAdminApp
{
    public partial class frmGamePreowned : GameStoreAdminApp.frmGame
    {
        public frmGamePreowned()
        {
            InitializeComponent();
        }

        public static readonly frmGamePreowned _Instance = new frmGamePreowned();
        public static frmGamePreowned Instance
        {
            get { return frmGamePreowned._Instance; }
        }

        public static void Run(clsAllGame prGame)
        {
            Instance.SetDetails(prGame);
        }

        protected override void UpdateDisplay()
        {
            this.Text = string.Format("{0} - Details", _Game.Title);
            txtName.Enabled = string.IsNullOrEmpty(_Game.Title);
            txtName.Text = _Game.Title;
            txtPrice.Text = _Game.Price.ToString();
            txtQuantity.Text = _Game.Quantity.ToString();
            txtReleaseDate.Text = _Game.ReleaseDate;
            lblModified.Text = string.Format("Last Modified:\n{0}", _Game.DateTimeModified);
            txtDiscount.Text = _Game.Discount.ToString();
        }

        protected override void pushData()
        {
            _Game.Title = txtName.Text;
            _Game.Price = Convert.ToDouble(txtPrice.Text);
            _Game.Quantity = Convert.ToInt16(txtQuantity.Text);
            _Game.ReleaseDate = txtReleaseDate.Text;
            _Game.DateTimeModified = string.Format("{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
            _Game.Discount = Convert.ToDouble(txtDiscount.Text == string.Empty ? "0" : txtDiscount.Text);
        }
    }
}
