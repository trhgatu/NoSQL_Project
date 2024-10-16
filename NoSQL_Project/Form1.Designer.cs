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
            header_Panel = new TableLayoutPanel();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            cb_FilterCriteria = new ComboBox();
            btn_XemCay = new Button();
            groupBox1 = new GroupBox();
            lbl_QueQuan = new Label();
            txt_QueQuan = new TextBox();
            cb_MoiQuanHe = new ComboBox();
            lbl_MoiQuanHe = new Label();
            dtp_NgayMat = new DateTimePicker();
            lbl_NgayMat = new Label();
            txt_DiaChi = new TextBox();
            lbl_DiaChi = new Label();
            lbl_GioiTinh = new Label();
            radio_Nu = new RadioButton();
            radio_Nam = new RadioButton();
            cb_MoiQuanHeVoi = new ComboBox();
            lbl_MoiQuanHeVoi = new Label();
            btn_ChonAnh = new Button();
            box_Anh = new PictureBox();
            lbl_NgaySinh = new Label();
            dtp_NgaySinh = new DateTimePicker();
            lbl_NgheNghiep = new Label();
            lbl_Ten = new Label();
            txt_NgheNghiep = new TextBox();
            txt_Ten = new TextBox();
            label6 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            btn_Xoa = new Button();
            btn_Them = new Button();
            btn_Luu = new Button();
            btn_ChiTiet = new Button();
            btn_TimKiem = new Button();
            txt_filterValue = new TextBox();
            cb_Loc = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)box_Anh).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // header_Panel
            // 
            header_Panel.BackColor = Color.RosyBrown;
            header_Panel.ColumnCount = 1;
            header_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            header_Panel.Dock = DockStyle.Top;
            header_Panel.Location = new Point(0, 0);
            header_Panel.Name = "header_Panel";
            header_Panel.RowCount = 1;
            header_Panel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            header_Panel.Size = new Size(1662, 80);
            header_Panel.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 80);
            panel1.Name = "panel1";
            panel1.Size = new Size(1662, 923);
            panel1.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(576, 102);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1050, 782);
            dataGridView1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(cb_FilterCriteria);
            panel2.Controls.Add(btn_XemCay);
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Controls.Add(btn_TimKiem);
            panel2.Controls.Add(txt_filterValue);
            panel2.Controls.Add(cb_Loc);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1662, 923);
            panel2.TabIndex = 0;
            // 
            // cb_FilterCriteria
            // 
            cb_FilterCriteria.FormattingEnabled = true;
            cb_FilterCriteria.Location = new Point(1158, 31);
            cb_FilterCriteria.Name = "cb_FilterCriteria";
            cb_FilterCriteria.Size = new Size(151, 28);
            cb_FilterCriteria.TabIndex = 7;
            // 
            // btn_XemCay
            // 
            btn_XemCay.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_XemCay.Location = new Point(576, 21);
            btn_XemCay.Name = "btn_XemCay";
            btn_XemCay.Size = new Size(165, 49);
            btn_XemCay.TabIndex = 3;
            btn_XemCay.Text = "Xem cây gia phả";
            btn_XemCay.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.BurlyWood;
            groupBox1.Controls.Add(lbl_QueQuan);
            groupBox1.Controls.Add(txt_QueQuan);
            groupBox1.Controls.Add(cb_MoiQuanHe);
            groupBox1.Controls.Add(lbl_MoiQuanHe);
            groupBox1.Controls.Add(dtp_NgayMat);
            groupBox1.Controls.Add(lbl_NgayMat);
            groupBox1.Controls.Add(txt_DiaChi);
            groupBox1.Controls.Add(lbl_DiaChi);
            groupBox1.Controls.Add(lbl_GioiTinh);
            groupBox1.Controls.Add(radio_Nu);
            groupBox1.Controls.Add(radio_Nam);
            groupBox1.Controls.Add(cb_MoiQuanHeVoi);
            groupBox1.Controls.Add(lbl_MoiQuanHeVoi);
            groupBox1.Controls.Add(btn_ChonAnh);
            groupBox1.Controls.Add(box_Anh);
            groupBox1.Controls.Add(lbl_NgaySinh);
            groupBox1.Controls.Add(dtp_NgaySinh);
            groupBox1.Controls.Add(lbl_NgheNghiep);
            groupBox1.Controls.Add(lbl_Ten);
            groupBox1.Controls.Add(txt_NgheNghiep);
            groupBox1.Controls.Add(txt_Ten);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.ActiveCaptionText;
            groupBox1.Location = new Point(30, 102);
            groupBox1.Name = "groupBox1";
            groupBox1.RightToLeft = RightToLeft.No;
            groupBox1.Size = new Size(511, 782);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thành viên";
            // 
            // lbl_QueQuan
            // 
            lbl_QueQuan.AutoSize = true;
            lbl_QueQuan.Font = new Font("Segoe UI", 11.8F, FontStyle.Bold);
            lbl_QueQuan.Location = new Point(35, 459);
            lbl_QueQuan.Name = "lbl_QueQuan";
            lbl_QueQuan.Size = new Size(108, 28);
            lbl_QueQuan.TabIndex = 22;
            lbl_QueQuan.Text = "Quê quán:";
            // 
            // txt_QueQuan
            // 
            txt_QueQuan.Font = new Font("Segoe UI", 11F);
            txt_QueQuan.Location = new Point(177, 455);
            txt_QueQuan.Name = "txt_QueQuan";
            txt_QueQuan.Size = new Size(284, 32);
            txt_QueQuan.TabIndex = 21;
            // 
            // cb_MoiQuanHe
            // 
            cb_MoiQuanHe.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_MoiQuanHe.FormattingEnabled = true;
            cb_MoiQuanHe.Location = new Point(177, 401);
            cb_MoiQuanHe.Name = "cb_MoiQuanHe";
            cb_MoiQuanHe.Size = new Size(284, 33);
            cb_MoiQuanHe.TabIndex = 20;
            // 
            // lbl_MoiQuanHe
            // 
            lbl_MoiQuanHe.AutoSize = true;
            lbl_MoiQuanHe.Font = new Font("Segoe UI", 11.8F, FontStyle.Bold);
            lbl_MoiQuanHe.Location = new Point(35, 401);
            lbl_MoiQuanHe.Name = "lbl_MoiQuanHe";
            lbl_MoiQuanHe.Size = new Size(136, 28);
            lbl_MoiQuanHe.TabIndex = 19;
            lbl_MoiQuanHe.Text = "Mối quan hệ:";
            // 
            // dtp_NgayMat
            // 
            dtp_NgayMat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtp_NgayMat.Format = DateTimePickerFormat.Custom;
            dtp_NgayMat.Location = new Point(177, 293);
            dtp_NgayMat.Name = "dtp_NgayMat";
            dtp_NgayMat.Size = new Size(284, 34);
            dtp_NgayMat.TabIndex = 18;
            // 
            // lbl_NgayMat
            // 
            lbl_NgayMat.AutoSize = true;
            lbl_NgayMat.Font = new Font("Segoe UI", 11.8F, FontStyle.Bold);
            lbl_NgayMat.Location = new Point(32, 298);
            lbl_NgayMat.Name = "lbl_NgayMat";
            lbl_NgayMat.Size = new Size(110, 28);
            lbl_NgayMat.TabIndex = 17;
            lbl_NgayMat.Text = "Ngày mất:";
            // 
            // txt_DiaChi
            // 
            txt_DiaChi.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_DiaChi.Location = new Point(177, 243);
            txt_DiaChi.Name = "txt_DiaChi";
            txt_DiaChi.Size = new Size(284, 31);
            txt_DiaChi.TabIndex = 16;
            // 
            // lbl_DiaChi
            // 
            lbl_DiaChi.AutoSize = true;
            lbl_DiaChi.Font = new Font("Segoe UI", 11.8F, FontStyle.Bold);
            lbl_DiaChi.Location = new Point(32, 243);
            lbl_DiaChi.Name = "lbl_DiaChi";
            lbl_DiaChi.Size = new Size(83, 28);
            lbl_DiaChi.TabIndex = 15;
            lbl_DiaChi.Text = "Địa chỉ:";
            // 
            // lbl_GioiTinh
            // 
            lbl_GioiTinh.AutoSize = true;
            lbl_GioiTinh.Font = new Font("Segoe UI", 11.8F, FontStyle.Bold);
            lbl_GioiTinh.Location = new Point(32, 151);
            lbl_GioiTinh.Name = "lbl_GioiTinh";
            lbl_GioiTinh.Size = new Size(100, 28);
            lbl_GioiTinh.TabIndex = 14;
            lbl_GioiTinh.Text = "Giới tính:";
            // 
            // radio_Nu
            // 
            radio_Nu.AutoSize = true;
            radio_Nu.Font = new Font("Segoe UI", 10.8F);
            radio_Nu.Location = new Point(264, 149);
            radio_Nu.Name = "radio_Nu";
            radio_Nu.Size = new Size(57, 29);
            radio_Nu.TabIndex = 13;
            radio_Nu.TabStop = true;
            radio_Nu.Text = "Nữ";
            radio_Nu.UseVisualStyleBackColor = true;
            // 
            // radio_Nam
            // 
            radio_Nam.AutoSize = true;
            radio_Nam.Font = new Font("Segoe UI", 10.8F);
            radio_Nam.Location = new Point(177, 149);
            radio_Nam.Name = "radio_Nam";
            radio_Nam.Size = new Size(71, 29);
            radio_Nam.TabIndex = 12;
            radio_Nam.TabStop = true;
            radio_Nam.Text = "Nam";
            radio_Nam.UseVisualStyleBackColor = true;
            // 
            // cb_MoiQuanHeVoi
            // 
            cb_MoiQuanHeVoi.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_MoiQuanHeVoi.FormattingEnabled = true;
            cb_MoiQuanHeVoi.Location = new Point(240, 346);
            cb_MoiQuanHeVoi.Name = "cb_MoiQuanHeVoi";
            cb_MoiQuanHeVoi.Size = new Size(221, 33);
            cb_MoiQuanHeVoi.TabIndex = 10;
            // 
            // lbl_MoiQuanHeVoi
            // 
            lbl_MoiQuanHeVoi.AutoSize = true;
            lbl_MoiQuanHeVoi.Font = new Font("Segoe UI", 11.8F, FontStyle.Bold);
            lbl_MoiQuanHeVoi.Location = new Point(32, 346);
            lbl_MoiQuanHeVoi.Name = "lbl_MoiQuanHeVoi";
            lbl_MoiQuanHeVoi.Size = new Size(172, 28);
            lbl_MoiQuanHeVoi.TabIndex = 9;
            lbl_MoiQuanHeVoi.Text = "Mối quan hệ với:";
            // 
            // btn_ChonAnh
            // 
            btn_ChonAnh.Font = new Font("Segoe UI", 12F);
            btn_ChonAnh.Location = new Point(32, 521);
            btn_ChonAnh.Name = "btn_ChonAnh";
            btn_ChonAnh.Size = new Size(162, 47);
            btn_ChonAnh.TabIndex = 7;
            btn_ChonAnh.Text = "Chọn ảnh ...";
            btn_ChonAnh.UseVisualStyleBackColor = true;
            btn_ChonAnh.Click += btn_ChonAnh_Click;
            // 
            // box_Anh
            // 
            box_Anh.BackColor = Color.White;
            box_Anh.BorderStyle = BorderStyle.FixedSingle;
            box_Anh.Location = new Point(32, 574);
            box_Anh.Name = "box_Anh";
            box_Anh.Size = new Size(162, 179);
            box_Anh.SizeMode = PictureBoxSizeMode.StretchImage;
            box_Anh.TabIndex = 6;
            box_Anh.TabStop = false;
            // 
            // lbl_NgaySinh
            // 
            lbl_NgaySinh.AutoSize = true;
            lbl_NgaySinh.Font = new Font("Segoe UI", 11.8F, FontStyle.Bold);
            lbl_NgaySinh.Location = new Point(32, 104);
            lbl_NgaySinh.Name = "lbl_NgaySinh";
            lbl_NgaySinh.Size = new Size(112, 28);
            lbl_NgaySinh.TabIndex = 5;
            lbl_NgaySinh.Text = "Ngày sinh:";
            // 
            // dtp_NgaySinh
            // 
            dtp_NgaySinh.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtp_NgaySinh.Format = DateTimePickerFormat.Custom;
            dtp_NgaySinh.Location = new Point(177, 99);
            dtp_NgaySinh.Name = "dtp_NgaySinh";
            dtp_NgaySinh.Size = new Size(284, 34);
            dtp_NgaySinh.TabIndex = 4;
            // 
            // lbl_NgheNghiep
            // 
            lbl_NgheNghiep.AutoSize = true;
            lbl_NgheNghiep.Font = new Font("Segoe UI", 11.8F, FontStyle.Bold);
            lbl_NgheNghiep.Location = new Point(32, 199);
            lbl_NgheNghiep.Name = "lbl_NgheNghiep";
            lbl_NgheNghiep.Size = new Size(139, 28);
            lbl_NgheNghiep.TabIndex = 3;
            lbl_NgheNghiep.Text = "Nghề nghiệp:";
            // 
            // lbl_Ten
            // 
            lbl_Ten.AutoSize = true;
            lbl_Ten.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbl_Ten.Location = new Point(35, 52);
            lbl_Ten.Name = "lbl_Ten";
            lbl_Ten.Size = new Size(48, 25);
            lbl_Ten.TabIndex = 2;
            lbl_Ten.Text = "Tên:";
            // 
            // txt_NgheNghiep
            // 
            txt_NgheNghiep.Font = new Font("Segoe UI", 11F);
            txt_NgheNghiep.Location = new Point(177, 195);
            txt_NgheNghiep.Name = "txt_NgheNghiep";
            txt_NgheNghiep.Size = new Size(284, 32);
            txt_NgheNghiep.TabIndex = 1;
            // 
            // txt_Ten
            // 
            txt_Ten.Font = new Font("Segoe UI", 12F);
            txt_Ten.Location = new Point(177, 46);
            txt_Ten.Name = "txt_Ten";
            txt_Ten.Size = new Size(284, 34);
            txt_Ten.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(836, 34);
            label6.Name = "label6";
            label6.Size = new Size(87, 31);
            label6.TabIndex = 5;
            label6.Text = "Bộ lọc:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(btn_Xoa, 0, 0);
            tableLayoutPanel1.Controls.Add(btn_Them, 3, 0);
            tableLayoutPanel1.Controls.Add(btn_Luu, 2, 0);
            tableLayoutPanel1.Controls.Add(btn_ChiTiet, 1, 0);
            tableLayoutPanel1.Location = new Point(30, 18);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(511, 55);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // btn_Xoa
            // 
            btn_Xoa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Xoa.Location = new Point(3, 3);
            btn_Xoa.Name = "btn_Xoa";
            btn_Xoa.Size = new Size(98, 49);
            btn_Xoa.TabIndex = 1;
            btn_Xoa.Text = "Xóa";
            btn_Xoa.UseVisualStyleBackColor = true;
            btn_Xoa.Click += btn_Xoa_Click;
            // 
            // btn_Them
            // 
            btn_Them.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Them.Location = new Point(384, 3);
            btn_Them.Name = "btn_Them";
            btn_Them.Size = new Size(124, 47);
            btn_Them.TabIndex = 11;
            btn_Them.Text = "Thêm";
            btn_Them.UseVisualStyleBackColor = true;
            btn_Them.Click += btn_Them_Click;
            // 
            // btn_Luu
            // 
            btn_Luu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Luu.Location = new Point(257, 3);
            btn_Luu.Name = "btn_Luu";
            btn_Luu.Size = new Size(95, 49);
            btn_Luu.TabIndex = 0;
            btn_Luu.Text = "Lưu";
            btn_Luu.UseVisualStyleBackColor = true;
            // 
            // btn_ChiTiet
            // 
            btn_ChiTiet.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_ChiTiet.Location = new Point(130, 3);
            btn_ChiTiet.Name = "btn_ChiTiet";
            btn_ChiTiet.Size = new Size(97, 49);
            btn_ChiTiet.TabIndex = 2;
            btn_ChiTiet.Text = "Chi tiết";
            btn_ChiTiet.UseVisualStyleBackColor = true;
            btn_ChiTiet.Click += btn_ChiTiet_Click;
            // 
            // btn_TimKiem
            // 
            btn_TimKiem.Location = new Point(1530, 30);
            btn_TimKiem.Name = "btn_TimKiem";
            btn_TimKiem.Size = new Size(94, 43);
            btn_TimKiem.TabIndex = 2;
            btn_TimKiem.Text = "Tìm kiếm";
            btn_TimKiem.UseVisualStyleBackColor = true;
            btn_TimKiem.Click += btn_TimKiem_Click;
            // 
            // txt_filterValue
            // 
            txt_filterValue.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_filterValue.Location = new Point(1315, 29);
            txt_filterValue.Multiline = true;
            txt_filterValue.Name = "txt_filterValue";
            txt_filterValue.Size = new Size(196, 43);
            txt_filterValue.TabIndex = 1;
            // 
            // cb_Loc
            // 
            cb_Loc.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_Loc.FormattingEnabled = true;
            cb_Loc.Location = new Point(947, 31);
            cb_Loc.Name = "cb_Loc";
            cb_Loc.Size = new Size(151, 39);
            cb_Loc.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1662, 1003);
            Controls.Add(panel1);
            Controls.Add(header_Panel);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)box_Anh).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel header_Panel;
        private Panel panel1;
        private Panel panel2;
        private ComboBox cb_Loc;
        private TextBox txt_filterValue;
        private DataGridView dataGridView1;
        private Button btn_TimKiem;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btn_Luu;
        private Button btn_Xoa;
        private Label label6;
        private GroupBox groupBox1;
        private Button btn_Them;
        private ComboBox cb_MoiQuanHeVoi;
        private Label lbl_MoiQuanHeVoi;
        private Button btn_ChonAnh;
        private PictureBox box_Anh;
        private Label lbl_NgaySinh;
        private DateTimePicker dtp_NgaySinh;
        private Label lbl_NgheNghiep;
        private Label lbl_Ten;
        private TextBox txt_NgheNghiep;
        private TextBox txt_Ten;
        private RadioButton radio_Nam;
        private Label lbl_GioiTinh;
        private RadioButton radio_Nu;
        private Label lbl_NgayMat;
        private TextBox txt_DiaChi;
        private Label lbl_DiaChi;
        private ComboBox cb_MoiQuanHe;
        private Label lbl_MoiQuanHe;
        private DateTimePicker dtp_NgayMat;
        private Button btn_ChiTiet;
        private Button btn_XemCay;
        private Label lbl_QueQuan;
        private TextBox txt_QueQuan;
        private ComboBox cb_FilterCriteria;
    }
}
