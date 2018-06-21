using System;
using System.Windows.Forms;

namespace GameStoreAdminApp
{
    public sealed partial class frmMain : Form
    {
        private static readonly frmMain _Instance = new frmMain();

        public frmMain()
        {
            InitializeComponent();
        }

        public static frmMain Instance
        {
            get { return frmMain._Instance; }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private async void UpdateDisplay()
        {
            lstGenres.DataSource = null;
            try
            {
                lstGenres.DataSource = await ServiceClient.GetGenreNamesAsync();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message + " Do you want to retry the connection?", "Connection time out", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Retry)
                    UpdateDisplay();
            }
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            frmOrders.Instance.Run();
        }

        private void ShowGenreForm()
        {
            string lcKey;

            lcKey = Convert.ToString(lstGenres.SelectedItem);
            if (lcKey != null)
            {
                try
                {
                    frmGenre.Run(lstGenres.SelectedItem as string);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                UpdateDisplay();
            }
        }

        private void lstGenres_DoubleClick(object sender, EventArgs e)
        {
            ShowGenreForm();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowGenreForm();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}