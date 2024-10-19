using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoSQL_Project
{
    public partial class FormDetails : Form
    {
        public FormDetails(string name, string birthDate, string deathDate, string gender, string occupation, string hometown, string address, string imagePath)
        {
            InitializeComponent();

            // Gán thông tin vào các Label/TextBox
            lbl_Ten.Text = name;
            lbl_NgaySinh.Text = birthDate;
            lbl_NgayMat.Text = deathDate ?? "N/A";
            lbl_GioiTinh.Text = gender;
            lbl_NgheNghiep.Text = occupation;
            lbl_QueQuan.Text = hometown;
            lbl_DiaChi.Text = address;

            // Hiển thị hình ảnh
            if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
            {
                box_Anh.Image = Image.FromFile(imagePath); // Giả sử bạn có PictureBox tên là picBoxImage
                box_Anh.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                box_Anh.Image = null; // Nếu không có hình ảnh, đặt là null
            }
        }

        private void FormDetails_Load(object sender, EventArgs e)
        {

        }
    }


}
