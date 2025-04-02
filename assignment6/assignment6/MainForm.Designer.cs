namespace OrderManagement
{
    partial class MainForm
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
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();

            // dgvOrders
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;

            // dgvDetails
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;

            // txtKeyword
            this.txtKeyword.Size = new System.Drawing.Size(200, 23);
            this.txtKeyword.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);

            // btnSearch
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);

            // btnAdd
            this.btnAdd.Text = "添加订单";
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            // btnDelete
            this.btnDelete.Text = "删除订单";
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            // btnReset
            this.btnReset.Text = "重置";
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);

            // flowLayoutPanel1
            this.flowLayoutPanel1.Controls.Add(this.txtKeyword);
            this.flowLayoutPanel1.Controls.Add(this.btnSearch);
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Controls.Add(this.btnReset);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);

            // tableLayoutPanel1
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvOrders, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvDetails, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;

            // MainForm
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Text = "订单管理系统";
            this.Controls.Add(this.tableLayoutPanel1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }

        private DataGridView dgvOrders;
        private DataGridView dgvDetails;
        private TextBox txtKeyword;
        private Button btnSearch;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnReset;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;

        #endregion
    }
}