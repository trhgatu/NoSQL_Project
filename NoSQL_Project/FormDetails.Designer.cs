namespace NoSQL_Project
{
    partial class FormDetails
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
            lbl_Ten = new Label();
            lbl_NgaySinh = new Label();
            lbl_GioiTinh = new Label();
            lbl_NgheNghiep = new Label();
            lbl_QueQuan = new Label();
            lbl_DiaChi = new Label();
            lbl_NgayMat = new Label();
            box_Anh = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)box_Anh).BeginInit();
            SuspendLayout();
            // 
            // lbl_Ten
            // 
            lbl_Ten.AutoSize = true;
            lbl_Ten.Location = new Point(58, 80);
            lbl_Ten.Name = "lbl_Ten";
            lbl_Ten.Size = new Size(55, 20);
            lbl_Ten.TabIndex = 0;
            lbl_Ten.Text = "lbl_Ten";
            // 
            // lbl_NgaySinh
            // 
            lbl_NgaySinh.AutoSize = true;
            lbl_NgaySinh.Location = new Point(58, 118);
            lbl_NgaySinh.Name = "lbl_NgaySinh";
            lbl_NgaySinh.Size = new Size(50, 20);
            lbl_NgaySinh.TabIndex = 1;
            lbl_NgaySinh.Text = "label1";
            // 
            // lbl_GioiTinh
            // 
            lbl_GioiTinh.AutoSize = true;
            lbl_GioiTinh.Location = new Point(63, 151);
            lbl_GioiTinh.Name = "lbl_GioiTinh";
            lbl_GioiTinh.Size = new Size(50, 20);
            lbl_GioiTinh.TabIndex = 2;
            lbl_GioiTinh.Text = "label1";
            // 
            // lbl_NgheNghiep
            // 
            lbl_NgheNghiep.AutoSize = true;
            lbl_NgheNghiep.Location = new Point(63, 197);
            lbl_NgheNghiep.Name = "lbl_NgheNghiep";
            lbl_NgheNghiep.Size = new Size(50, 20);
            lbl_NgheNghiep.TabIndex = 3;
            lbl_NgheNghiep.Text = "label1";
            // 
            // lbl_QueQuan
            // 
            lbl_QueQuan.AutoSize = true;
            lbl_QueQuan.Location = new Point(58, 232);
            lbl_QueQuan.Name = "lbl_QueQuan";
            lbl_QueQuan.Size = new Size(50, 20);
            lbl_QueQuan.TabIndex = 4;
            lbl_QueQuan.Text = "label1";
            // 
            // lbl_DiaChi
            // 
            lbl_DiaChi.AutoSize = true;
            lbl_DiaChi.Location = new Point(63, 270);
            lbl_DiaChi.Name = "lbl_DiaChi";
            lbl_DiaChi.Size = new Size(50, 20);
            lbl_DiaChi.TabIndex = 5;
            lbl_DiaChi.Text = "label1";
            // 
            // lbl_NgayMat
            // 
            lbl_NgayMat.AutoSize = true;
            lbl_NgayMat.Location = new Point(63, 305);
            lbl_NgayMat.Name = "lbl_NgayMat";
            lbl_NgayMat.Size = new Size(50, 20);
            lbl_NgayMat.TabIndex = 6;
            lbl_NgayMat.Text = "label1";
            // 
            // box_Anh
            // 
            box_Anh.Location = new Point(496, 83);
            box_Anh.Name = "box_Anh";
            box_Anh.Size = new Size(168, 169);
            box_Anh.TabIndex = 7;
            box_Anh.TabStop = false;
            // 
            // FormDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(box_Anh);
            Controls.Add(lbl_NgayMat);
            Controls.Add(lbl_DiaChi);
            Controls.Add(lbl_QueQuan);
            Controls.Add(lbl_NgheNghiep);
            Controls.Add(lbl_GioiTinh);
            Controls.Add(lbl_NgaySinh);
            Controls.Add(lbl_Ten);
            Name = "FormDetails";
            Text = "FormDetails";
            ((System.ComponentModel.ISupportInitialize)box_Anh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Ten;
        private Label lbl_NgaySinh;
        private Label lbl_GioiTinh;
        private Label lbl_NgheNghiep;
        private Label lbl_QueQuan;
        private Label lbl_DiaChi;
        private Label lbl_NgayMat;
        private PictureBox box_Anh;
    }
}