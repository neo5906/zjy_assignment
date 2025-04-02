using System;
using System.Linq;
using System.Windows.Forms;

namespace OrderManagement
{
    public partial class MainForm : Form
    {
        private readonly OrderService orderService = new OrderService();
        private readonly BindingSource ordersBinding = new BindingSource();
        private readonly BindingSource detailsBinding = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
            InitializeDataBinding();
            LoadSampleData();
        }

        private void InitializeDataBinding()
        {
            // 主订单绑定
            ordersBinding.DataSource = orderService.Orders;
            dgvOrders.DataSource = ordersBinding;

            // 明细绑定
            detailsBinding.DataSource = ordersBinding;
            detailsBinding.DataMember = "Details";
            dgvDetails.DataSource = detailsBinding;

            ConfigureDataGridColumns();
        }

        private void ConfigureDataGridColumns()
        {
            // 订单列表
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.Columns.Clear();
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderId",
                HeaderText = "订单号",
                Width = 150
            });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Customer",
                HeaderText = "客户",
                Width = 120
            });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalAmount",
                HeaderText = "总金额",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 120
            });

            // 明细列表
            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.Columns.Clear();
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductName",
                HeaderText = "商品名称",
                Width = 200
            });
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "单价",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 100
            });
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "数量",
                Width = 80
            });
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Total",
                HeaderText = "小计",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 120
            });
        }

        private void LoadSampleData()
        {
            var order1 = new Order("2024001", "张三");
            order1.Details.Add(new OrderDetails
            {
                ProductName = "智能手机",
                UnitPrice = 2999m,
                Quantity = 1
            });
            orderService.AddOrder(order1);

            var order2 = new Order("2024002", "李四");
            order2.Details.Add(new OrderDetails
            {
                ProductName = "蓝牙耳机",
                UnitPrice = 399m,
                Quantity = 2
            });
            order2.Details.Add(new OrderDetails
            {
                ProductName = "钢化膜",
                UnitPrice = 29.9m,
                Quantity = 3
            });
            orderService.AddOrder(order2);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using var editForm = new EditOrderForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    orderService.AddOrder(editForm.CurrentOrder);
                    ordersBinding.ResetBindings(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作失败",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (ordersBinding.Current is Order selectedOrder)
            {
                try
                {
                    orderService.RemoveOrder(selectedOrder.OrderId);
                    ordersBinding.RemoveCurrent();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "删除失败",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var keyword = txtKeyword.Text.Trim();
            var results = orderService.QueryOrders(o =>
                o.OrderId.Contains(keyword) ||
                o.Customer.Contains(keyword) ||
                o.Details.Any(d => d.ProductName.Contains(keyword)));

            ordersBinding.DataSource = results;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtKeyword.Clear();
            ordersBinding.DataSource = orderService.Orders;
            ordersBinding.ResetBindings(false);
        }
    }
}
