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
        private static Dictionary<int, clsOrder> _OrderList = new Dictionary<int, clsOrder>();

        public static frmOrders Instance
        {
            get { return frmOrders._Instance; }
        }

        /* Maybe this is needed for the OrderDisplay once deleting (and total value) is functional*/

        // private async void refreshFormFromDB(int prOrderID)
        // {
        //     Instance.SetDetails(await ServiceClient.GetOrderDetailsAsync(lstOrders.SelectedIndex));
        // }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            CreateOrders();
            UpdateOrderDisplay();
            UpdateTotalOrderValue();
        }

        private async void CreateOrders()
        {
            if (_OrderList.Count == 0)
            {
                try
                {
                    List<int> lcOrderList = await ServiceClient.GetOrdersListAsync();
                    int i = 0;
                    foreach (var order in lcOrderList)
                    {
                        i++;
                        _OrderList.Add(i, new clsOrder());
                    }
                }
                catch (Exception ex)
                {
                    DialogResult result = MessageBox.Show(ex.Message + "Do you want to retry the connection?", "Connection time out", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Retry)
                        CreateOrders();
                }
                
            }
        }

        private async void UpdateOrderDisplay()
        {
            lstOrders.DataSource = null;
            try
            {
                lstOrders.DataSource = await ServiceClient.GetOrdersListAsync();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message + "Do you want to retry the connection?", "Connection time out", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Retry)
                    UpdateOrderDisplay();
            }
        }

        private async void UpdateOrderDetailsDisplay(int prOrderID)
        {
            clsOrder lcOrder = _OrderList[prOrderID];
            List<string> lcOrderTitle = await (ServiceClient.GetGameTitleAsync(lcOrder.GameID));
            lblOrderDetails.Text = string.Format(
                "Title: {0}\n" +
                "Price: ${1}\n" +
                "\n" +
                "Quantity: {2}\n" +
                "Date Ordered: {3}\n" +
                "\n" +
                "Name: {4}\n" +
                "City: {5}\n",
                lcOrderTitle[0], lcOrder.OrderPrice, lcOrder.Quantity, 
                lcOrder.OrderDate, lcOrder.CustomerName, lcOrder.City);
        }

        private async static void GetSelectedOrderDetails(int prOrderID)
        {
            // If an order doesnt exist make one
            clsOrder lcOrder;
            if (!_OrderList.TryGetValue(prOrderID, out lcOrder))
            {
                MessageBox.Show("Record doesnt exist making ne wone");
                int lcNewOrderCount = _OrderList.Count + 1;
                _OrderList.Add(lcNewOrderCount, new clsOrder());
                Instance.SetDetails(await ServiceClient.GetOrderDetailsAsync(lcNewOrderCount));
            }
            else
	        {
                Instance.SetDetails(await ServiceClient.GetOrderDetailsAsync(prOrderID));
            }
        }

        private void SetDetails(clsOrder prOrder)
        {
            int lcOrderID = lstOrders.SelectedIndex + 1;
            _OrderList[lcOrderID] = prOrder;
            UpdateOrderDetailsDisplay(lcOrderID);
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
            int lcSelectedID = lstOrders.SelectedIndex + 1;
            if (lcSelectedID >= 0)
            {
                DialogResult lcResult = MessageBox.Show("Are you sure you want to delete this item?", "Remove item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (lcResult == DialogResult.Yes)
                {
                    clsOrder lcOrder;
                    _OrderList.TryGetValue(lcSelectedID, out lcOrder);

                    // Deletes order form database
                    string lcMsg = await(ServiceClient.DeleteOrderAsync(lcOrder.OrderID));
                    // Console.WriteLine(lcMsg);

                    // if lcMsg == Success

                        // Delete key from the dictionary
                        // _OrderList.Remove(lcSelectedID);

                        // Refresh the dictionary
                        // UpdateOrderDisplay();
                }
            }
            else
            {
                MessageBox.Show("Please select and item from the list", "Selection missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void lstOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedOrderDetails(lstOrders.SelectedIndex + 1);
        }
    }
}