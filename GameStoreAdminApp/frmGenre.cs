using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GameStoreAdminApp
{
    public partial class frmGenre : Form
    {
        public frmGenre()
        {
            InitializeComponent();
        }

        private static Dictionary<string, frmGenre> _GenreFormList = new Dictionary<string, frmGenre>();
        private clsGenre _Genre;

        private async void refreshFormFromDB(string prGenreName)
        {
            SetDetails(await ServiceClient.GetGenreAsync(prGenreName));
        }

        public static void Run(string prGenreName)
        {
            frmGenre lcGenreForm;
            if (string.IsNullOrEmpty(prGenreName) ||
            !_GenreFormList.TryGetValue(prGenreName, out lcGenreForm))
            {
                lcGenreForm = new frmGenre();
                if (string.IsNullOrEmpty(prGenreName))
                    lcGenreForm.SetDetails(new clsGenre());
                else
                {
                    _GenreFormList.Add(prGenreName, lcGenreForm);
                    lcGenreForm.refreshFormFromDB(prGenreName);
                    lcGenreForm.Show();
                }
            }
            else
            {
                lcGenreForm.Show();
                lcGenreForm.Activate();
            }
        }

        public void SetDetails(clsGenre prGenre)
        {
            _Genre = prGenre;
            UpdateDisplay(prGenre);

            if (!this.Enabled)
                ShowDialog();
        }
        
        private void UpdateDisplay(clsGenre prGenre)
        {
            lstGames.DataSource = null;
            if (_Genre.GameList != null)
                lstGames.DataSource = prGenre.GameList;

            this.Text = string.Format("Admin - {0} Games", prGenre.GenreName);
            lblSubGenres.Text = string.Format("Sub Genres: {0}", prGenre.SubGenres);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void lstGames_DoubleClick(object sender, EventArgs e)
        {
            frmGame.DispatchWorkForm(lstGames.SelectedValue as clsAllGame);
            refreshFormFromDB(_Genre.GenreName);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstGames.SelectedItem != null)
                frmGame.DispatchWorkForm(lstGames.SelectedValue as clsAllGame);
            else
                MessageBox.Show("Please select and item from the list", "Selection missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            refreshFormFromDB(_Genre.GenreName);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string lcReply;
            InputBox inputBox = new InputBox("New or Preowned?");
            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                // Get answer
                lcReply = (inputBox.getAnswer());
                Console.WriteLine(lcReply);

                // Make new game of corresponding type
                clsAllGame lcGame = new clsAllGame();
                if (lcReply != string.Empty)
                    lcGame.GenreID = _Genre.GenreID;
                    lcGame.GameType = lcReply;

                // Open correct form
                frmGame.DispatchWorkForm(lcGame);
                refreshFormFromDB(_Genre.GenreName);
            }
            else
            {
                inputBox.Close();
                Console.WriteLine("No response");
            }
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult lcResult = MessageBox.Show("Are you sure you want to delete this item?", "Remove item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (lcResult == DialogResult.Yes)
            {
                MessageBox.Show(await ServiceClient.DeleteGameAsync(lstGames.SelectedItem as clsAllGame));
                refreshFormFromDB(_Genre.GenreName);
            }
        }
    }
}