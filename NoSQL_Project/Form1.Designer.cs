namespace NoSQL_Project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sideBar_Panel = new TableLayoutPanel();
            button3 = new Button();
            button4 = new Button();
            header_Panel = new TableLayoutPanel();
            footer_Panel = new TableLayoutPanel();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            btn_Xoa = new Button();
            btn_Luu = new Button();
            groupBox1 = new GroupBox();
            label4 = new Label();
            btn_ChonAnh = new Button();
            box_Anh = new PictureBox();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button1 = new Button();
            txt_TimKiem = new TextBox();
            cb_Loc = new ComboBox();
            label5 = new Label();
            comboBox1 = new ComboBox();
            label6 = new Label();
            button2 = new Button();
            sideBar_Panel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)box_Anh).BeginInit();
            SuspendLayout();
            // 
            // sideBar_Panel
            // 
            sideBar_Panel.BackColor = Color.RosyBrown;
            sideBar_Panel.ColumnCount = 1;
            sideBar_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            sideBar_Panel.Controls.Add(button3, 0, 1);
            sideBar_Panel.Controls.Add(button4, 0, 2);
            sideBar_Panel.Dock = DockStyle.Left;
            sideBar_Panel.Location = new Point(0, 0);
            sideBar_Panel.Name = "sideBar_Panel";
            sideBar_Panel.RowCount = 5;
            sideBar_Panel.RowStyles.Add(new RowStyle(SizeType.Percent, 15.3539381F));
            sideBar_Panel.RowStyles.Add(new RowStyle(SizeType.Percent, 7.27816534F));
            sideBar_Panel.RowStyles.Add(new RowStyle(SizeType.Percent, 7.17846441F));
            sideBar_Panel.RowStyles.Add(new RowStyle(SizeType.Percent, 15.1545362F));
            sideBar_Panel.RowStyles.Add(new RowStyle(SizeType.Percent, 54.9351959F));
            sideBar_Panel.Size = new Size(261, 1003);
            sideBar_Panel.TabIndex = 0;
            // 
            // button3
            // 
            button3.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(3, 157);
            button3.Name = "button3";
            button3.Size = new Size(255, 65);
            button3.TabIndex = 0;
            button3.Text = "Trang chủ";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(3, 230);
            button4.Name = "button4";
            button4.Size = new Size(255, 65);
            button4.TabIndex = 1;
            button4.Text = "Cây gia phả";
            button4.UseVisualStyleBackColor = true;
            // 
            // header_Panel
            // 
            header_Panel.BackColor = Color.RosyBrown;
            header_Panel.ColumnCount = 1;
            header_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            header_Panel.Dock = DockStyle.Top;
            header_Panel.Location = new Point(261, 0);
            header_Panel.Name = "header_Panel";
            header_Panel.RowCount = 1;
            header_Panel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            header_Panel.Size = new Size(1401, 80);
            header_Panel.TabIndex = 3;
            // 
            // footer_Panel
            // 
            footer_Panel.BackColor = Color.RosyBrown;
            footer_Panel.ColumnCount = 1;
            footer_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            footer_Panel.Dock = DockStyle.Bottom;
            footer_Panel.Location = new Point(261, 953);
            footer_Panel.Name = "footer_Panel";
            footer_Panel.RowCount = 1;
            footer_Panel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            footer_Panel.Size = new Size(1401, 50);
            footer_Panel.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(261, 80);
            panel1.Name = "panel1";
            panel1.Size = new Size(1401, 873);
            panel1.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(40, 135);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(908, 715);
            dataGridView1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(label6);
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(txt_TimKiem);
            panel2.Controls.Add(cb_Loc);
            panel2.Location = new Point(40, 35);
            panel2.Name = "panel2";
            panel2.Size = new Size(1361, 815);
            panel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btn_Xoa, 0, 0);
            tableLayoutPanel1.Controls.Add(btn_Luu, 1, 0);
            tableLayoutPanel1.Location = new Point(943, 21);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(415, 55);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // btn_Xoa
            // 
            btn_Xoa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Xoa.Location = new Point(3, 3);
            btn_Xoa.Name = "btn_Xoa";
            btn_Xoa.Size = new Size(197, 49);
            btn_Xoa.TabIndex = 1;
            btn_Xoa.Text = "Xóa";
            btn_Xoa.UseVisualStyleBackColor = true;
            // 
            // btn_Luu
            // 
            btn_Luu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Luu.Location = new Point(210, 3);
            btn_Luu.Name = "btn_Luu";
            btn_Luu.Size = new Size(197, 49);
            btn_Luu.TabIndex = 0;
            btn_Luu.Text = "Lưu";
            btn_Luu.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.BurlyWood;
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btn_ChonAnh);
            groupBox1.Controls.Add(box_Anh);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.FlatStyle = FlatStyle.Popup;
            groupBox1.Font = new Font("Century", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.ActiveCaptionText;
            groupBox1.Location = new Point(943, 100);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(406, 715);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thành viên";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(27, 248);
            label4.Name = "label4";
            label4.Size = new Size(55, 28);
            label4.TabIndex = 8;
            label4.Text = "Ảnh:";
            // 
            // btn_ChonAnh
            // 
            btn_ChonAnh.Font = new Font("Segoe UI", 12F);
            btn_ChonAnh.Location = new Point(177, 502);
            btn_ChonAnh.Name = "btn_ChonAnh";
            btn_ChonAnh.Size = new Size(205, 47);
            btn_ChonAnh.TabIndex = 7;
            btn_ChonAnh.Text = "Chọn ảnh ...";
            btn_ChonAnh.UseVisualStyleBackColor = true;
            btn_ChonAnh.Click += btn_ChonAnh_Click;
            // 
            // box_Anh
            // 
            box_Anh.BackColor = Color.White;
            box_Anh.BorderStyle = BorderStyle.FixedSingle;
            box_Anh.Location = new Point(177, 248);
            box_Anh.Name = "box_Anh";
            box_Anh.Size = new Size(205, 241);
            box_Anh.SizeMode = PictureBoxSizeMode.StretchImage;
            box_Anh.TabIndex = 6;
            box_Anh.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(23, 198);
            label3.Name = "label3";
            label3.Size = new Size(112, 28);
            label3.TabIndex = 5;
            label3.Text = "Ngày sinh:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(177, 192);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(205, 34);
            dateTimePicker1.TabIndex = 4;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 143);
            label2.Name = "label2";
            label2.Size = new Size(134, 28);
            label2.TabIndex = 3;
            label2.Text = "Nghề nghiệp";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 86);
            label1.Name = "label1";
            label1.Size = new Size(50, 28);
            label1.TabIndex = 2;
            label1.Text = "Tên:";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 12F);
            textBox2.Location = new Point(177, 137);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(205, 34);
            textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(83, 83);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(299, 34);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(327, 21);
            button1.Name = "button1";
            button1.Size = new Size(94, 43);
            button1.TabIndex = 2;
            button1.Text = "Tìm kiếm";
            button1.UseVisualStyleBackColor = true;
            // 
            // txt_TimKiem
            // 
            txt_TimKiem.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_TimKiem.Location = new Point(0, 21);
            txt_TimKiem.Multiline = true;
            txt_TimKiem.Name = "txt_TimKiem";
            txt_TimKiem.Size = new Size(321, 43);
            txt_TimKiem.TabIndex = 1;
            // 
            // cb_Loc
            // 
            cb_Loc.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_Loc.FormattingEnabled = true;
            cb_Loc.Location = new Point(704, 26);
            cb_Loc.Name = "cb_Loc";
            cb_Loc.Size = new Size(204, 39);
            cb_Loc.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(21, 571);
            label5.Name = "label5";
            label5.Size = new Size(136, 28);
            label5.TabIndex = 9;
            label5.Text = "Mối quan hệ:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(173, 563);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(209, 43);
            comboBox1.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(611, 29);
            label6.Name = "label6";
            label6.Size = new Size(87, 31);
            label6.TabIndex = 5;
            label6.Text = "Bộ lọc:";
            // 
            // button2
            // 
            button2.Location = new Point(139, 637);
            button2.Name = "button2";
            button2.Size = new Size(136, 60);
            button2.TabIndex = 11;
            button2.Text = "Thêm";
            button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1662, 1003);
            Controls.Add(panel1);
            Controls.Add(footer_Panel);
            Controls.Add(header_Panel);
            Controls.Add(sideBar_Panel);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            sideBar_Panel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)box_Anh).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel sideBar_Panel;
        private TableLayoutPanel header_Panel;
        private TableLayoutPanel footer_Panel;
        private Panel panel1;
        private Panel panel2;
        private ComboBox cb_Loc;
        private TextBox txt_TimKiem;
        private DataGridView dataGridView1;
        private Button button1;
        private GroupBox groupBox1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private Label label1;
        private Label label4;
        private Button btn_ChonAnh;
        private PictureBox box_Anh;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btn_Luu;
        private Button button3;
        private Button button4;
        private Button btn_Xoa;
        private Label label6;
        private ComboBox comboBox1;
        private Label label5;
        private Button button2;
    }
}
