using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace OrderManagement
{
    public partial class EditOrderForm : Form
    {
        public Order CurrentOrder { get; }
        private readonly BindingList<OrderDetails> detailsList;

        public EditOrderForm(Order existingOrder = null)
        {
            InitializeComponent();
            CurrentOrder = existingOrder ?? new Order("", "");
            detailsList = new BindingList<OrderDetails>(CurrentOrder.Details.ToList());
            InitializeDataBinding();
        }

        private void InitializeDataBinding()
        {
            txtOrderId.DataBindings.Add("Text", CurrentOrder, "OrderId");
            txtCustomer.DataBindings.Add("Text", CurrentOrder, "Customer");
            dgvEditDetails.DataSource = detailsList;
        }

        private void BtnAddDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProduct.Text))
            {
                MessageBox.Show("请输入商品名称");
                return;
            }

            var detail = new OrderDetails
            {
                ProductName = txtProduct.Text,
                UnitPrice = numUnitPrice.Value,
                Quantity = (int)numQuantity.Value
            };

            if (detailsList.Any(d => d.Equals(detail)))
            {
                MessageBox.Show("商品明细已存在");
                return;
            }

            detailsList.Add(detail);
            ClearDetailInputs();
        }

        private void ClearDetailInputs()
        {
            txtProduct.Clear();
            numUnitPrice.Value = 0;
            numQuantity.Value = 1;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CurrentOrder.OrderId))
            {
                MessageBox.Show("订单号不能为空");
                return;
            }

            if (detailsList.Count == 0)
            {
                MessageBox.Show("至少需要添加一个订单明细");
                return;
            }

            CurrentOrder.Details.Clear();
            CurrentOrder.Details.AddRange(detailsList);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
