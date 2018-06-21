using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GameStoreAdminApp
{
    public partial class frmGame : Form
    {
        public frmGame()
        {
            InitializeComponent();
        }

        protected clsAllGame _Game;

        public static readonly frmGame _Instance = new frmGame();
        public static frmGame Instance
        {
            get { return frmGame._Instance; }
        }

        public delegate void LoadGameFormDelegate(clsAllGame prGame);
        public static Dictionary<string, Delegate> _GamesForm = new Dictionary<string, Delegate>
            {
                {"New", new LoadGameFormDelegate(frmGameNew.Run)},
                {"Preowned", new LoadGameFormDelegate(frmGamePreowned.Run)}
            };

        public static void Run(clsAllGame prGame)
        {
            Instance.SetDetails(prGame);
        }

        public void SetDetails(clsAllGame prGame)
        {
            _Game = prGame;
            UpdateDisplay();
            ShowDialog();
        }

        public static void DispatchWorkForm(clsAllGame prGame)
        {
           _GamesForm[prGame.GameType].DynamicInvoke(prGame);
        }

        protected virtual void UpdateDisplay()
        {
            txtName.Text = _Game.Title;
            txtPrice.Text = _Game.Price.ToString();
            txtQuantity.Text = _Game.Quantity.ToString();
            txtReleaseDate.Text = _Game.ReleaseDate;
            lblModified.Text = _Game.DateTimeModified;
        }

        protected virtual void pushData()
        {
            _Game.Title = txtName.Text;
            _Game.Price = Convert.ToDouble(txtPrice.Text);
            _Game.Quantity = Convert.ToInt16(txtQuantity.Text);
            _Game.ReleaseDate = txtReleaseDate.Text;
            _Game.DateTimeModified = "Test";
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            pushData();
            if (txtName.Enabled)
                MessageBox.Show(await ServiceClient.PostGameAsync(_Game), "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
            else
                MessageBox.Show(await ServiceClient.UpdateGameAsync(_Game), "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}