using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NoSQL_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupPanel();
            SetupDataGridView();
        }

        private void SetupPanel()
        {
            header_Panel.BackColor = Color.FromArgb(29, 59, 113);
            footer_Panel.BackColor = Color.FromArgb(29, 59, 113);
            sideBar_Panel.BackColor = Color.FromArgb(0, 102, 179);
        }

        private void SetupDataGridView()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.LightGray;
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 179);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        public void LoadDataToGrid(List<Dictionary<string, object>> data)
        {
            DataTable table = new DataTable();

            if (data.Count > 0)
            {
                foreach (var key in data[0].Keys)
                {
                    table.Columns.Add(key, typeof(string));
                }

                foreach (var record in data)
                {
                    DataRow row = table.NewRow();
                    foreach (var key in record.Keys)
                    {
                        row[key] = record[key]?.ToString();
                    }
                    table.Rows.Add(row);
                }
            }

            dataGridView1.DataSource = table;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_ChonAnh_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"; 
            openFileDialog.Title = "Chọn ảnh";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                box_Anh.Image = Image.FromFile(openFileDialog.FileName);
                box_Anh.SizeMode = PictureBoxSizeMode.StretchImage; 
            }
        }

    }
}
