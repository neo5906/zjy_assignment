using OrderEF6.Models;
using OrderEF6.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OrderEF6
{
    public partial class MainForm : Form
    {
        private OrderService _service = new OrderService();
        private BindingSource _ordersBinding = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
            InitializeDataGridColumns();
            LoadData();
        }

        private void InitializeDataGridColumns()
        {
            // 订单列表配置
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.Columns.Clear();
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colOrderId",
                HeaderText = "订单号",
                DataPropertyName = "OrderId",
                Width = 150
            });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCustomer",
                HeaderText = "客户",
                DataPropertyName = "Customer",
                Width = 120
            });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTotalAmount",
                HeaderText = "总金额",
                DataPropertyName = "TotalAmount",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 120
            });

            // 订单明细配置
            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.Columns.Clear();
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProduct",
                HeaderText = "商品名称",
                DataPropertyName = "ProductName",
                Width = 200
            });
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colUnitPrice",
                HeaderText = "单价",
                DataPropertyName = "UnitPrice",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 100
            });
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colQuantity",
                HeaderText = "数量",
                DataPropertyName = "Quantity",
                Width = 80
            });
        }

        private void LoadData()
        {
            _ordersBinding.DataSource = _service.GetOrders("");
            dgvOrders.DataSource = _ordersBinding;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var editForm = new EditOrderForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _service.AddOrder(editForm.Order);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"添加失败：{ex.Message}");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow?.DataBoundItem is Order selected)
            {
                try
                {
                    _service.DeleteOrder(selected.OrderId);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"删除失败：{ex.Message}");
                }
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow?.DataBoundItem is Order order)
            {
                dgvDetails.DataSource = order.Details.ToList();
            }
        }
    }
}
