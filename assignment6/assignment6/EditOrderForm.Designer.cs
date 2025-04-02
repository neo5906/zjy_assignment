namespace OrderManagement
{
    partial class EditOrderForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.dgvEditDetails = new System.Windows.Forms.DataGridView();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.numUnitPrice = new System.Windows.Forms.NumericUpDown();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddDetail = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();

            // txtOrderId
            this.txtOrderId.PlaceholderText = "输入订单号";
            this.txtOrderId.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);

            // txtCustomer
            this.txtCustomer.PlaceholderText = "输入客户名称";
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);

            // dgvEditDetails
            this.dgvEditDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEditDetails.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.dgvEditDetails.ReadOnly = true;

            // txtProduct
            this.txtProduct.PlaceholderText = "商品名称";
            this.txtProduct.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);

            // numUnitPrice
            this.numUnitPrice.DecimalPlaces = 2;
            this.numUnitPrice.Maximum = 1000000;
            this.numUnitPrice.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);

            // numQuantity
            this.numQuantity.Minimum = 1;
            this.numQuantity.Value = 1;
            this.numQuantity.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);

            // btnAddDetail
            this.btnAddDetail.Text = "添加明细";
            this.btnAddDetail.Click += new System.EventHandler(this.BtnAddDetail_Click);

            // btnOK
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);

            // btnCancel
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);

            // tableLayoutPanel1
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtOrderId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCustomer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvEditDetails, 0, 2);
            this.tableLayoutPanel1.SetColumnSpan(this.dgvEditDetails, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtProduct, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.numUnitPrice, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.numQuantity, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnAddDetail, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);

            // EditOrderForm
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Text = "编辑订单";
            this.Controls.Add(this.tableLayoutPanel1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }

        private TextBox txtOrderId;
        private TextBox txtCustomer;
        private DataGridView dgvEditDetails;
        private TextBox txtProduct;
        private NumericUpDown numUnitPrice;
        private NumericUpDown numQuantity;
        private Button btnAddDetail;
        private Button btnOK;
        private Button btnCancel;
        private TableLayoutPanel tableLayoutPanel1;

        #endregion
    }
}
