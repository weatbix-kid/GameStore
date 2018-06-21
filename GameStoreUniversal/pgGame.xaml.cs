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
    public sealed partial class pgGame : Page
    {
        public pgGame()
        {
            this.InitializeComponent();
        }

        private clsAllGame _Game;

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

        private void UpdateDisplay(clsAllGame prGame)
        {
            txbTitle.Text = prGame.Title;
            txbRelease.Text = string.Format("Sub Genres: {0}", prGame.ReleaseDate);
            txbQuantity.Text = string.Format("Stock: {0} copies left", prGame.Quantity);
            txbType.Text = string.Format("Type: {0}", prGame.GameType);
            txbPrice.Text = "$" + Convert.ToString(prGame.Price);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                try
                {
                    _Game = e.Parameter as clsAllGame;
                    UpdateDisplay(_Game);
                }
                catch (Exception ex)
                {
                    txbErrorMessage.Text = ex.Message;
                }
            }
        }

        private clsOrder createNewOrder(clsAllGame prGame)
        {
            string lcDate = DateTime.Now.ToString();
            clsOrder lcOrder = new clsOrder()
            {
                GameID = prGame.GameID,
                Quantity = Convert.ToInt16(txtOrderQuantity.Text),
                OrderPrice = prGame.Price * Convert.ToDouble(txtOrderQuantity.Text),
                OrderDate = lcDate.Substring(0, 10),
                CustomerName = txtName.Text,
                City = txtCity.Text
            };
            return lcOrder;
        }

        private void updateGameQuantity()
        {
            _Game.Quantity -= Convert.ToInt16(txtOrderQuantity.Text);
            txbQuantity.Text = string.Format("Stock: {0} copies left",(_Game.Quantity));
        }

        private async void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtName.Text == string.Empty || txtCity.Text == string.Empty || txtOrderQuantity.Text == string.Empty)
                {
                    txbErrorMessage.Text = "Please enter correct values";
                }
                else
                {
                    txbErrorMessage.Text = await ServiceClient.PostOrderAsync(createNewOrder(_Game));
                    updateGameQuantity();
                    txbErrorMessage.Text = await ServiceClient.UpdateGameAsync(_Game);
                }
            }
            catch (Exception ex)
            {
                txbErrorMessage.Text = ex.Message;
            }
        }
    }
}
