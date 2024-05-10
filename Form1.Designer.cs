namespace BookShop
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgBook = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numBookPrice = new System.Windows.Forms.NumericUpDown();
            this.numBookQuantity = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbBookType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBook = new System.Windows.Forms.TextBox();
            this.btnRemoveBook = new System.Windows.Forms.Button();
            this.btnEditBook = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRemoveBookType = new System.Windows.Forms.Button();
            this.btnEditBookType = new System.Windows.Forms.Button();
            this.btnAddBookType = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPhoneNum = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnRemoveInvoice = new System.Windows.Forms.Button();
            this.btnEditInvoice = new System.Windows.Forms.Button();
            this.btnAddInvoice = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBook)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBookPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBookQuantity)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(28, 23);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1681, 921);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgBook);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(8, 47);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1665, 866);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sách";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgBook
            // 
            this.dgBook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBook.Location = new System.Drawing.Point(37, 32);
            this.dgBook.Name = "dgBook";
            this.dgBook.RowHeadersWidth = 82;
            this.dgBook.RowTemplate.Height = 33;
            this.dgBook.Size = new System.Drawing.Size(1585, 578);
            this.dgBook.TabIndex = 3;
            this.dgBook.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBook_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numBookPrice);
            this.panel2.Controls.Add(this.numBookQuantity);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cbBookType);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtAuthor);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtBook);
            this.panel2.Controls.Add(this.btnRemoveBook);
            this.panel2.Controls.Add(this.btnEditBook);
            this.panel2.Controls.Add(this.btnAddBook);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(37, 639);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1585, 201);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // numBookPrice
            // 
            this.numBookPrice.Location = new System.Drawing.Point(1196, 119);
            this.numBookPrice.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numBookPrice.Name = "numBookPrice";
            this.numBookPrice.Size = new System.Drawing.Size(173, 38);
            this.numBookPrice.TabIndex = 16;
            // 
            // numBookQuantity
            // 
            this.numBookQuantity.Location = new System.Drawing.Point(877, 118);
            this.numBookQuantity.Name = "numBookQuantity";
            this.numBookQuantity.Size = new System.Drawing.Size(112, 38);
            this.numBookQuantity.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1035, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 31);
            this.label5.TabIndex = 14;
            this.label5.Text = "Đơn Giá";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(701, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 31);
            this.label4.TabIndex = 12;
            this.label4.Text = "Số lượng";
            // 
            // cbBookType
            // 
            this.cbBookType.FormattingEnabled = true;
            this.cbBookType.Location = new System.Drawing.Point(207, 113);
            this.cbBookType.Name = "cbBookType";
            this.cbBookType.Size = new System.Drawing.Size(415, 39);
            this.cbBookType.TabIndex = 10;
            this.cbBookType.SelectedIndexChanged += new System.EventHandler(this.cbBookType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(701, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 31);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tác giả";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(877, 40);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(378, 38);
            this.txtAuthor.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "Loại Sách";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tên Sách";
            // 
            // txtBook
            // 
            this.txtBook.Location = new System.Drawing.Point(207, 40);
            this.txtBook.Name = "txtBook";
            this.txtBook.Size = new System.Drawing.Size(415, 38);
            this.txtBook.TabIndex = 4;
            // 
            // btnRemoveBook
            // 
            this.btnRemoveBook.Location = new System.Drawing.Point(1432, 140);
            this.btnRemoveBook.Name = "btnRemoveBook";
            this.btnRemoveBook.Size = new System.Drawing.Size(128, 48);
            this.btnRemoveBook.TabIndex = 3;
            this.btnRemoveBook.Text = "Xóa";
            this.btnRemoveBook.UseVisualStyleBackColor = true;
            this.btnRemoveBook.Click += new System.EventHandler(this.btnRemoveBook_Click);
            // 
            // btnEditBook
            // 
            this.btnEditBook.Location = new System.Drawing.Point(1432, 71);
            this.btnEditBook.Name = "btnEditBook";
            this.btnEditBook.Size = new System.Drawing.Size(128, 48);
            this.btnEditBook.TabIndex = 2;
            this.btnEditBook.Text = "Sửa";
            this.btnEditBook.UseVisualStyleBackColor = true;
            this.btnEditBook.Click += new System.EventHandler(this.btnEditBook_Click);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(1432, 7);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(128, 48);
            this.btnAddBook.TabIndex = 1;
            this.btnAddBook.Text = "Thêm";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(8, 47);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1665, 866);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Loại Sách";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(40, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1585, 578);
            this.dataGridView1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnRemoveBookType);
            this.panel1.Controls.Add(this.btnEditBookType);
            this.panel1.Controls.Add(this.btnAddBookType);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(40, 637);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1585, 201);
            this.panel1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(312, 79);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(312, 38);
            this.textBox2.TabIndex = 8;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(118, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 31);
            this.label9.TabIndex = 7;
            this.label9.Text = "Loại Sách";
            // 
            // btnRemoveBookType
            // 
            this.btnRemoveBookType.Location = new System.Drawing.Point(1423, 147);
            this.btnRemoveBookType.Name = "btnRemoveBookType";
            this.btnRemoveBookType.Size = new System.Drawing.Size(128, 48);
            this.btnRemoveBookType.TabIndex = 3;
            this.btnRemoveBookType.Text = "Xóa";
            this.btnRemoveBookType.UseVisualStyleBackColor = true;
            // 
            // btnEditBookType
            // 
            this.btnEditBookType.Location = new System.Drawing.Point(1423, 78);
            this.btnEditBookType.Name = "btnEditBookType";
            this.btnEditBookType.Size = new System.Drawing.Size(128, 48);
            this.btnEditBookType.TabIndex = 2;
            this.btnEditBookType.Text = "Sửa";
            this.btnEditBookType.UseVisualStyleBackColor = true;
            // 
            // btnAddBookType
            // 
            this.btnAddBookType.Location = new System.Drawing.Point(1423, 14);
            this.btnAddBookType.Name = "btnAddBookType";
            this.btnAddBookType.Size = new System.Drawing.Size(128, 48);
            this.btnAddBookType.TabIndex = 1;
            this.btnAddBookType.Text = "Thêm";
            this.btnAddBookType.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView2);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(8, 47);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(1665, 866);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Hóa Đơn";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(40, 30);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 82;
            this.dataGridView2.RowTemplate.Height = 33;
            this.dataGridView2.Size = new System.Drawing.Size(1585, 578);
            this.dataGridView2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.txtPhoneNum);
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtUserName);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.btnRemoveInvoice);
            this.panel3.Controls.Add(this.btnEditInvoice);
            this.panel3.Controls.Add(this.btnAddInvoice);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(40, 637);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1585, 201);
            this.panel3.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(755, 125);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(211, 31);
            this.label17.TabIndex = 19;
            this.label17.Text = "Sđt Khách Hàng";
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.Location = new System.Drawing.Point(1027, 122);
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.Size = new System.Drawing.Size(359, 38);
            this.txtPhoneNum.TabIndex = 18;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(350, 48);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(569, 38);
            this.dateTimePicker1.TabIndex = 17;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(217, 31);
            this.label8.TabIndex = 9;
            this.label8.Text = "Tên Khách Hàng";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(350, 117);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(359, 38);
            this.txtUserName.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(227, 31);
            this.label11.TabIndex = 5;
            this.label11.Text = "Ngày tạo hóa đơn";
            // 
            // btnRemoveInvoice
            // 
            this.btnRemoveInvoice.Location = new System.Drawing.Point(1432, 140);
            this.btnRemoveInvoice.Name = "btnRemoveInvoice";
            this.btnRemoveInvoice.Size = new System.Drawing.Size(128, 48);
            this.btnRemoveInvoice.TabIndex = 3;
            this.btnRemoveInvoice.Text = "Xóa";
            this.btnRemoveInvoice.UseVisualStyleBackColor = true;
            // 
            // btnEditInvoice
            // 
            this.btnEditInvoice.Location = new System.Drawing.Point(1432, 71);
            this.btnEditInvoice.Name = "btnEditInvoice";
            this.btnEditInvoice.Size = new System.Drawing.Size(128, 48);
            this.btnEditInvoice.TabIndex = 2;
            this.btnEditInvoice.Text = "Sửa";
            this.btnEditInvoice.UseVisualStyleBackColor = true;
            // 
            // btnAddInvoice
            // 
            this.btnAddInvoice.Location = new System.Drawing.Point(1432, 7);
            this.btnAddInvoice.Name = "btnAddInvoice";
            this.btnAddInvoice.Size = new System.Drawing.Size(128, 48);
            this.btnAddInvoice.TabIndex = 1;
            this.btnAddInvoice.Text = "Thêm";
            this.btnAddInvoice.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel4);
            this.tabPage4.Controls.Add(this.dataGridView3);
            this.tabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage4.Location = new System.Drawing.Point(8, 47);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(1665, 866);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Phiếu Nhập";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dateTimePicker2);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.textBox3);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(40, 638);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1585, 201);
            this.panel4.TabIndex = 6;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(348, 48);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(573, 38);
            this.dateTimePicker2.TabIndex = 17;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(236, 31);
            this.label7.TabIndex = 9;
            this.label7.Text = "Tên Nhà Xuất Bản";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(348, 120);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(359, 38);
            this.textBox3.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(263, 31);
            this.label10.TabIndex = 5;
            this.label10.Text = "Ngày tạo phiếu nhập";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1432, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 48);
            this.button1.TabIndex = 3;
            this.button1.Text = "Xóa";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1432, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 48);
            this.button2.TabIndex = 2;
            this.button2.Text = "Sửa";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1432, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 48);
            this.button3.TabIndex = 1;
            this.button3.Text = "Thêm";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(40, 30);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 82;
            this.dataGridView3.RowTemplate.Height = 33;
            this.dataGridView3.Size = new System.Drawing.Size(1585, 578);
            this.dataGridView3.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(1753, 979);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book Shop";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBook)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBookPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBookQuantity)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgBook;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numBookPrice;
        private System.Windows.Forms.NumericUpDown numBookQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbBookType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBook;
        private System.Windows.Forms.Button btnRemoveBook;
        private System.Windows.Forms.Button btnEditBook;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRemoveBookType;
        private System.Windows.Forms.Button btnEditBookType;
        private System.Windows.Forms.Button btnAddBookType;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtPhoneNum;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnRemoveInvoice;
        private System.Windows.Forms.Button btnEditInvoice;
        private System.Windows.Forms.Button btnAddInvoice;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

