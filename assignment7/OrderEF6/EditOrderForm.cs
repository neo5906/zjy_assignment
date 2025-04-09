using OrderEF6.Models;
using System;
using System.Windows.Forms;

namespace OrderEF6
{
    public partial class EditOrderForm : Form
    {
        public Order Order { get; private set; } = new Order();

        public EditOrderForm()
        {
            InitializeComponent();
            InitializeDataBinding();
        }

        private void InitializeDataBinding()
        {
            txtOrderId.DataBindings.Add("Text", Order, "OrderId");
            txtCustomer.DataBindings.Add("Text", Order, "Customer");
            dgvEditDetails.DataSource = Order.Details;
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            var detail = new OrderDetail
            {
                ProductName = txtProduct.Text,
                UnitPrice = numUnitPrice.Value,
                Quantity = (int)numQuantity.Value
            };

            if (Order.Details.Any(d => d.ProductName == detail.ProductName))
            {
                MessageBox.Show("该商品已存在");
                return;
            }

            Order.Details.Add(detail);
            dgvEditDetails.DataSource = null;
            dgvEditDetails.DataSource = Order.Details;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Order.OrderId))
            {
                MessageBox.Show("订单号不能为空");
                return;
            }

            if (Order.Details.Count == 0)
            {
                MessageBox.Show("至少需要添加一个商品");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}