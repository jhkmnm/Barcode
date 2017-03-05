namespace Barcode
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ddlChooser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpSendDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlIsAssign = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlIswrong = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlIsowegoods = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtTop = new Utilities.UserControls.TextIntegerOnly();
            this.txtDown = new Utilities.UserControls.TextIntegerOnly();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtWeight_2 = new Utilities.UserControls.TextIntegerOnly();
            this.label11 = new System.Windows.Forms.Label();
            this.txtWeight_1 = new Utilities.UserControls.TextIntegerOnly();
            this.label10 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.ddlPageSize = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ddlProt = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ddlPrinter = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ucPagerEx1 = new Utilities.UserControls.UcPagerEx();
            this.dgvData = new RowMergeView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coloID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colsendOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colchooseOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colkNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colremark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colOwd = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colisAssign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colisOwegoods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colisWrong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colrealNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colsendDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colu_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colchooserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chooseDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chooseDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlChooser
            // 
            this.ddlChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlChooser.FormattingEnabled = true;
            this.ddlChooser.Location = new System.Drawing.Point(78, 20);
            this.ddlChooser.Name = "ddlChooser";
            this.ddlChooser.Size = new System.Drawing.Size(121, 20);
            this.ddlChooser.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "分拣员:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "配送顺序范围:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(525, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "送货日期:";
            // 
            // dtpSendDate
            // 
            this.dtpSendDate.Checked = false;
            this.dtpSendDate.CustomFormat = "yyyy-MM-dd";
            this.dtpSendDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSendDate.Location = new System.Drawing.Point(590, 21);
            this.dtpSendDate.Name = "dtpSendDate";
            this.dtpSendDate.ShowCheckBox = true;
            this.dtpSendDate.Size = new System.Drawing.Size(102, 21);
            this.dtpSendDate.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "是否已分:";
            // 
            // ddlIsAssign
            // 
            this.ddlIsAssign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlIsAssign.FormattingEnabled = true;
            this.ddlIsAssign.Location = new System.Drawing.Point(78, 54);
            this.ddlIsAssign.Name = "ddlIsAssign";
            this.ddlIsAssign.Size = new System.Drawing.Size(121, 20);
            this.ddlIsAssign.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "是否保存:";
            // 
            // ddlIswrong
            // 
            this.ddlIswrong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlIswrong.FormattingEnabled = true;
            this.ddlIswrong.Location = new System.Drawing.Point(330, 55);
            this.ddlIswrong.Name = "ddlIswrong";
            this.ddlIswrong.Size = new System.Drawing.Size(121, 20);
            this.ddlIswrong.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(525, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "是否欠货:";
            // 
            // ddlIsowegoods
            // 
            this.ddlIsowegoods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlIsowegoods.FormattingEnabled = true;
            this.ddlIsowegoods.Location = new System.Drawing.Point(590, 54);
            this.ddlIsowegoods.Name = "ddlIsowegoods";
            this.ddlIsowegoods.Size = new System.Drawing.Size(102, 20);
            this.ddlIsowegoods.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.ddlChooser);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTop);
            this.groupBox1.Controls.Add(this.ddlIsowegoods);
            this.groupBox1.Controls.Add(this.txtDown);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ddlIswrong);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ddlIsAssign);
            this.groupBox1.Controls.Add(this.dtpSendDate);
            this.groupBox1.Location = new System.Drawing.Point(6, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(825, 87);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(722, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 39);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtTop
            // 
            this.txtTop.IsDecimal = false;
            this.txtTop.IsNegativeNumbers = false;
            this.txtTop.Location = new System.Drawing.Point(331, 21);
            this.txtTop.Name = "txtTop";
            this.txtTop.Size = new System.Drawing.Size(69, 21);
            this.txtTop.TabIndex = 9;
            // 
            // txtDown
            // 
            this.txtDown.IsDecimal = false;
            this.txtDown.IsNegativeNumbers = false;
            this.txtDown.Location = new System.Drawing.Point(408, 21);
            this.txtDown.Name = "txtDown";
            this.txtDown.Size = new System.Drawing.Size(69, 21);
            this.txtDown.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtWeight_2);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtWeight_1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnTest);
            this.groupBox2.Controls.Add(this.ddlPageSize);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.ddlProt);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.ddlPrinter);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(6, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(825, 100);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "打印";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(645, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 30;
            this.label13.Text = "斤";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(458, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 29;
            this.label12.Text = "斤";
            // 
            // txtWeight_2
            // 
            this.txtWeight_2.IsDecimal = true;
            this.txtWeight_2.IsNegativeNumbers = false;
            this.txtWeight_2.Location = new System.Drawing.Point(574, 61);
            this.txtWeight_2.Name = "txtWeight_2";
            this.txtWeight_2.Size = new System.Drawing.Size(69, 21);
            this.txtWeight_2.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(509, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 28;
            this.label11.Text = "手动数值:";
            // 
            // txtWeight_1
            // 
            this.txtWeight_1.IsDecimal = true;
            this.txtWeight_1.IsNegativeNumbers = false;
            this.txtWeight_1.Location = new System.Drawing.Point(387, 61);
            this.txtWeight_1.Name = "txtWeight_1";
            this.txtWeight_1.Size = new System.Drawing.Size(69, 21);
            this.txtWeight_1.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(322, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "实时数值:";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(220, 60);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 23;
            this.btnTest.Text = "测试端口";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // ddlPageSize
            // 
            this.ddlPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPageSize.FormattingEnabled = true;
            this.ddlPageSize.Location = new System.Drawing.Point(387, 24);
            this.ddlPageSize.Name = "ddlPageSize";
            this.ddlPageSize.Size = new System.Drawing.Size(99, 20);
            this.ddlPageSize.TabIndex = 25;
            this.ddlPageSize.SelectedIndexChanged += new System.EventHandler(this.ddlPageSize_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(346, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 26;
            this.label9.Text = "纸张:";
            // 
            // ddlProt
            // 
            this.ddlProt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlProt.FormattingEnabled = true;
            this.ddlProt.Location = new System.Drawing.Point(89, 61);
            this.ddlProt.Name = "ddlProt";
            this.ddlProt.Size = new System.Drawing.Size(99, 20);
            this.ddlProt.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "电子秤串口:";
            // 
            // ddlPrinter
            // 
            this.ddlPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPrinter.FormattingEnabled = true;
            this.ddlPrinter.Location = new System.Drawing.Point(89, 24);
            this.ddlPrinter.Name = "ddlPrinter";
            this.ddlPrinter.Size = new System.Drawing.Size(206, 20);
            this.ddlPrinter.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "打印机:";
            // 
            // ucPagerEx1
            // 
            this.ucPagerEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucPagerEx1.Location = new System.Drawing.Point(211, 588);
            this.ucPagerEx1.Name = "ucPagerEx1";
            this.ucPagerEx1.PageIndex = 1;
            this.ucPagerEx1.PageSize = 15;
            this.ucPagerEx1.PreviousPage = 0;
            this.ucPagerEx1.RecordCount = 0;
            this.ucPagerEx1.Size = new System.Drawing.Size(417, 30);
            this.ucPagerEx1.TabIndex = 23;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeight = 31;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.coloID,
            this.colsendOrder,
            this.colcName,
            this.colname,
            this.colunit,
            this.colchooseOrder,
            this.colkNum,
            this.colnum,
            this.colremark,
            this.colWeight,
            this.colAction,
            this.colOwd,
            this.colpID,
            this.colisAssign,
            this.colisOwegoods,
            this.colisWrong,
            this.colprice,
            this.colrealNum,
            this.colorderDate,
            this.colsendDate,
            this.colu_ID,
            this.coluid,
            this.colchooserID});
            this.dgvData.DataSource = this.chooseDataBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.Location = new System.Drawing.Point(6, 202);
            this.dgvData.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgvData.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvData.MergeColumnNames")));
            this.dgvData.Name = "dgvData";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.RowHeadersWidth = 21;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvData.RowTemplate.Height = 33;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(825, 380);
            this.dgvData.TabIndex = 7;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            this.dgvData.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvData_CellPainting);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            // 
            // coloID
            // 
            this.coloID.DataPropertyName = "O_ID";
            this.coloID.HeaderText = "订单号";
            this.coloID.Name = "coloID";
            this.coloID.Width = 65;
            // 
            // colsendOrder
            // 
            this.colsendOrder.DataPropertyName = "Send_Order";
            this.colsendOrder.HeaderText = "配送顺序";
            this.colsendOrder.Name = "colsendOrder";
            this.colsendOrder.Width = 80;
            // 
            // colcName
            // 
            this.colcName.DataPropertyName = "CName";
            this.colcName.HeaderText = "客户名称";
            this.colcName.Name = "colcName";
            this.colcName.Width = 140;
            // 
            // colname
            // 
            this.colname.DataPropertyName = "Name";
            this.colname.HeaderText = "商品名称";
            this.colname.Name = "colname";
            this.colname.Width = 140;
            // 
            // colunit
            // 
            this.colunit.DataPropertyName = "Unit";
            this.colunit.HeaderText = "单位";
            this.colunit.Name = "colunit";
            this.colunit.Width = 60;
            // 
            // colchooseOrder
            // 
            this.colchooseOrder.DataPropertyName = "Choose_Order";
            this.colchooseOrder.HeaderText = "存放位置";
            this.colchooseOrder.Name = "colchooseOrder";
            this.colchooseOrder.Width = 80;
            // 
            // colkNum
            // 
            this.colkNum.DataPropertyName = "K_Num";
            this.colkNum.HeaderText = "库存";
            this.colkNum.Name = "colkNum";
            this.colkNum.Width = 60;
            // 
            // colnum
            // 
            this.colnum.DataPropertyName = "Num";
            this.colnum.HeaderText = "数量";
            this.colnum.Name = "colnum";
            this.colnum.Width = 60;
            // 
            // colremark
            // 
            this.colremark.DataPropertyName = "Remark";
            this.colremark.HeaderText = "要求";
            this.colremark.Name = "colremark";
            this.colremark.Width = 220;
            // 
            // colWeight
            // 
            this.colWeight.DataPropertyName = "Weight";
            this.colWeight.HeaderText = "重量";
            this.colWeight.Name = "colWeight";
            // 
            // colAction
            // 
            this.colAction.DataPropertyName = "Action";
            this.colAction.HeaderText = "操作";
            this.colAction.Name = "colAction";
            this.colAction.ReadOnly = true;
            // 
            // colOwd
            // 
            this.colOwd.DataPropertyName = "Owd";
            this.colOwd.HeaderText = "Owd";
            this.colOwd.Name = "colOwd";
            this.colOwd.ReadOnly = true;
            // 
            // colpID
            // 
            this.colpID.DataPropertyName = "P_ID";
            this.colpID.HeaderText = "P_ID";
            this.colpID.Name = "colpID";
            this.colpID.Visible = false;
            // 
            // colisAssign
            // 
            this.colisAssign.DataPropertyName = "Is_Assign";
            this.colisAssign.HeaderText = "Is_Assign";
            this.colisAssign.Name = "colisAssign";
            this.colisAssign.Visible = false;
            // 
            // colisOwegoods
            // 
            this.colisOwegoods.DataPropertyName = "Is_Owegoods";
            this.colisOwegoods.HeaderText = "Is_Owegoods";
            this.colisOwegoods.Name = "colisOwegoods";
            this.colisOwegoods.Visible = false;
            // 
            // colisWrong
            // 
            this.colisWrong.DataPropertyName = "Is_Wrong";
            this.colisWrong.HeaderText = "Is_Wrong";
            this.colisWrong.Name = "colisWrong";
            this.colisWrong.Visible = false;
            // 
            // colprice
            // 
            this.colprice.DataPropertyName = "Price";
            this.colprice.HeaderText = "Price";
            this.colprice.Name = "colprice";
            this.colprice.Visible = false;
            // 
            // colrealNum
            // 
            this.colrealNum.DataPropertyName = "Real_Num";
            this.colrealNum.HeaderText = "Real_Num";
            this.colrealNum.Name = "colrealNum";
            this.colrealNum.Visible = false;
            // 
            // colorderDate
            // 
            this.colorderDate.DataPropertyName = "Order_Date";
            this.colorderDate.HeaderText = "Order_Date";
            this.colorderDate.Name = "colorderDate";
            this.colorderDate.Visible = false;
            // 
            // colsendDate
            // 
            this.colsendDate.DataPropertyName = "Send_Date";
            this.colsendDate.HeaderText = "Send_Date";
            this.colsendDate.Name = "colsendDate";
            this.colsendDate.Visible = false;
            this.colsendDate.Width = 90;
            // 
            // colu_ID
            // 
            this.colu_ID.DataPropertyName = "U_ID";
            this.colu_ID.HeaderText = "U_ID";
            this.colu_ID.Name = "colu_ID";
            this.colu_ID.Visible = false;
            // 
            // coluid
            // 
            this.coluid.DataPropertyName = "Uid";
            this.coluid.HeaderText = "Uid";
            this.coluid.Name = "coluid";
            this.coluid.Visible = false;
            // 
            // colchooserID
            // 
            this.colchooserID.DataPropertyName = "Chooser_ID";
            this.colchooserID.HeaderText = "Chooser_ID";
            this.colchooserID.Name = "colchooserID";
            this.colchooserID.Visible = false;
            // 
            // chooseDataBindingSource
            // 
            this.chooseDataBindingSource.DataSource = typeof(Barcode.ChooseData);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 621);
            this.Controls.Add(this.ucPagerEx1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chooseDataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RowMergeView dgvData;
        private System.Windows.Forms.ComboBox ddlChooser;
        private Utilities.UserControls.TextIntegerOnly txtTop;
        private Utilities.UserControls.TextIntegerOnly txtDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpSendDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlIsAssign;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddlIswrong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlIsowegoods;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private Utilities.UserControls.TextIntegerOnly txtWeight_2;
        private System.Windows.Forms.Label label11;
        private Utilities.UserControls.TextIntegerOnly txtWeight_1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ComboBox ddlPageSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox ddlProt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ddlPrinter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource chooseDataBindingSource;        
        private Utilities.UserControls.UcPagerEx ucPagerEx1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;        
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn coloID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colsendOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colchooseOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colkNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colremark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewButtonColumn colAction;
        private System.Windows.Forms.DataGridViewButtonColumn colOwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colisAssign;
        private System.Windows.Forms.DataGridViewTextBoxColumn colisOwegoods;
        private System.Windows.Forms.DataGridViewTextBoxColumn colisWrong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colrealNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colsendDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colu_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colchooserID;
    }
}

