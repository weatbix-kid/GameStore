using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameStoreAdminApp
{
    public partial class frmGameNew : GameStoreAdminApp.frmGame
    {
        public frmGameNew()
        {
            InitializeComponent();
        }

        public static readonly frmGameNew _Instance = new frmGameNew();
        public static frmGameNew Instance
        {
            get { return frmGameNew._Instance; }
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
            nudPrice.Value = Convert.ToDecimal(_Game.Price);
            nudQuantity.Value = _Game.Quantity;
            txtReleaseDate.Text = _Game.ReleaseDate;
            lblModified.Text = string.Format("Last Modified:\n{0}", _Game.DateTimeModified);
            nudWarranty.Value = Convert.ToDecimal(_Game.Warranty);
        }

        protected override void pushData()
        {
            _Game.Title = txtName.Text;
            _Game.Price = Convert.ToDouble(nudPrice.Value);
            _Game.Quantity = Convert.ToInt16(nudQuantity.Value);
            _Game.ReleaseDate = txtReleaseDate.Text;
            _Game.DateTimeModified = string.Format("{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
            _Game.Warranty = Convert.ToString(nudWarranty.Value);
        }
    }
}
