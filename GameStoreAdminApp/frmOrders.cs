using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStoreAdminApp
{
    public sealed partial class frmOrders : Form
    {
        public frmOrders()
        {
            InitializeComponent();
        }

        private static readonly frmOrders _Instance = new frmOrders();
        private static clsOrder _Order;
        // private static Dictionary<int, clsOrder> _OrderList = new Dictionary<int, clsOrder>();

        public static frmOrders Instance
        {
            get { return frmOrders._Instance; }
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        public void Run()
        {
            frmOrders lcOrderForm = frmOrders.Instance;
            lcOrderForm.ShowDialog();
            lcOrderForm.Activate();
        }

        private async void RefreshformFromDB()
        {
            SetDetails(await ServiceClient.GetOrderDetailsAsync(Convert.ToInt16(lstOrders.SelectedItem)));
            UpdateTotalOrderValue();
        }

        private async void SetDetails(clsOrder prOrder)
        {
            _Order = prOrder;
            List<string> lcOrderTitle = await(ServiceClient.GetGameTitleAsync(prOrder.GameID));
            lblOrderDetails.Text = string.Format("Title: {0}\nPrice: ${1}\n\nQuantity: {2}\nDate Ordered: {3}\n\nCustomer Name: {4}\nCity: {5}",
                lcOrderTitle[0], Convert.ToString(prOrder.OrderPrice), prOrder.Quantity, prOrder.OrderDate, prOrder.CustomerName, prOrder.City);
        }

        private async void UpdateDisplay()
        {
            try
            {
                // lstOrders.DataSource = null; // Crashes when reopening the order form?
                lstOrders.DataSource = await ServiceClient.GetOrdersListAsync();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message + "Do you want to retry the connection?", "Connection time out", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Retry)
                    UpdateDisplay();
            }
            RefreshformFromDB();
        }

        private async void UpdateTotalOrderValue()
        {
            double lcTotalValue = 0;
            List<double> lcPrice = new List<double>();

            try
            {
                lcPrice = await ServiceClient.GetTotalOrdersValueAsync();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message + " Do you want to retry the connection?", "Connection time out", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Retry)
                    UpdateTotalOrderValue();
            }

            foreach (var price in lcPrice)
            {
                lcTotalValue += price;
            }

            lblTotalValue.Text = string.Format("Total Value: ${0}", lcTotalValue.ToString());
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult lcResult = MessageBox.Show("Are you sure you want to delete this item?", "Remove item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (lcResult == DialogResult.Yes)
            {
                MessageBox.Show(await (ServiceClient.DeleteOrderAsync(_Order.OrderID)));
                UpdateDisplay();
            }
        }

        private void lstOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshformFromDB();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}