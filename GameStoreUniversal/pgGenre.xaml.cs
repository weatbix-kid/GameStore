using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GameStoreUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgGenre : Page
    {
        public pgGenre()
        {
            this.InitializeComponent();
        }

        private clsGenre _Genre;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // lstGames.ItemsSource = await ServiceClient.GetGenreNamesAsync();
            }
            catch (Exception)
            {
                // txbMessage.Text = "Message: " + ex.Message;
            }
        }

        private void UpdateDisplay(clsGenre prGenre)
        {
            lstGames.ItemsSource = null;
            if (_Genre.GameList != null)
                lstGames.ItemsSource = prGenre.GameList;

            txbGenreName.Text = string.Format("{0} Games", prGenre.GenreName);
            txbSubGenres.Text = string.Format("Sub Genres: {0}", prGenre.SubGenres);
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                try
                {
                    string lcGenreName = e.Parameter.ToString();
                    _Genre = await ServiceClient.GetGenreAsync(lcGenreName);
                    UpdateDisplay(_Genre);
                }
                catch (Exception ex)
                {
                    txbMessage.Text = ex.Message;
                }

            }
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            if (lstGames.SelectedItem != null)
            {
                // Frame.Navigate(typeof(pgGame), _Genre.GameList[lstGames.SelectedIndex].GameID); // Sending GameID
                Frame.Navigate(typeof(pgGame), _Genre.GameList[lstGames.SelectedIndex]); // Sending Whole Game
            }
        }
    }
}
