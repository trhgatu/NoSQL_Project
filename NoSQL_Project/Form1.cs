using System.Data;

namespace NoSQL_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // Điều này sẽ khởi tạo DataGridView đã được tạo trong Designer
        }

        public void LoadDataToGrid(List<Dictionary<string, object>> data)
        {
            DataTable table = new DataTable();

            // Thêm các cột vào DataTable
            if (data.Count > 0)
            {
                foreach (var key in data[0].Keys)
                {
                    table.Columns.Add(key, typeof(string));
                }

                // Thêm dữ liệu vào bảng
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

            // Hiển thị dữ liệu trong DataGridView đã được tạo bởi Designer
            dataGridView1.DataSource = table;
        }
    }

}
