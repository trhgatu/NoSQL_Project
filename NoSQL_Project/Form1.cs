﻿using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoSQL_Project
{
    public partial class Form1 : Form
    {
        private IDriver _driver;

        public Form1(IDriver driver)
        {
            InitializeComponent();
            SetupPanel();
            SetupDataGridView();
            _driver = driver;
            LoadRelationshipTypes();
            LoadPersonsToComboBoxAsync();
            LoadDataAsync();
            dtp_NgayMat.Value = DateTimePicker.MinimumDateTime;
            LoadFilterCriteria();
        }

        private void SetupPanel()
        {
            header_Panel.BackColor = Color.FromArgb(29, 59, 113);
        }

        private void SetupDataGridView()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.LightGray;
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 179);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.RowTemplate.Height = 150;
        }

        public async Task LoadDataAsync()
        {
            var query = @"
        MATCH (p:Person) 
        RETURN p.id AS Id, p.name AS Name, p.birthDate AS BirthDate, 
               p.deathDate AS DeathDate, p.gender AS Gender, 
               p.image AS Image, p.occupation AS Occupation, 
               p.hometown AS Hometown, p.address AS Address 
        ORDER BY p.id"; 

            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

            await using (var session = _driver.AsyncSession())
            {
                try
                {
                    var result = await session.RunAsync(query);
                    await foreach (var record in result)
                    {
                        var dict = new Dictionary<string, object>
                        {
                            { "Id", record["Id"] == null ? null : record["Id"].As<string>() },
                            { "Name", record["Name"].As<string>() },
                            { "BirthDate", record["BirthDate"].As<string>() },
                            { "DeathDate", record["DeathDate"] == null ? "N/A" : record["DeathDate"].As<string>() },
                            { "Gender", record["Gender"].As<string>() },
                            { "Image", record["Image"].As<string>() },
                            { "Occupation", record["Occupation"].As<string>() },
                            { "Hometown", record["Hometown"].As<string>() },
                            { "Address", record["Address"].As<string>() }
                        };
                                data.Add(dict);
                            }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }

            LoadDataToGrid(data);
        }

        public void LoadDataToGrid(List<Dictionary<string, object>> data)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(string));

    
            table.Columns.Add("Image", typeof(Image));

            if (data.Count > 0)
            {
                foreach (var key in data[0].Keys)
                {
                    if (key != "Id" && key != "Image") 
                    {
                        table.Columns.Add(key, typeof(string));
                    }
                }

                foreach (var record in data)
                {
                    DataRow row = table.NewRow();
                    row["Id"] = record["Id"]?.ToString();

                    
                    string imagePath = record["Image"]?.ToString();
                    if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                    {
                        Image originalImage = Image.FromFile(imagePath);
                        row["Image"] = ResizeImage(originalImage, 150, 150); 
                    }
                    else
                    {
                        row["Image"] = null;
                    }

                    foreach (var key in record.Keys)
                    {
                        if (key != "Id" && key != "Image")
                        {
                            row[key] = record[key]?.ToString();
                        }
                    }
                    table.Rows.Add(row);
                }
            }

            dataGridView1.DataSource = table;

            
            dataGridView1.Columns["Image"].Width = 150; 
            dataGridView1.Columns["Image"].DefaultCellStyle.NullValue = null;
            dataGridView1.Columns["Image"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            dataGridView1.Columns["Image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None; 

            
            dataGridView1.RowTemplate.Height = 150; 
        }


        private Image ResizeImage(Image image, int width, int height)
        {
            
            double ratioX = (double)width / image.Width;
            double ratioY = (double)height / image.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            return new Bitmap(image, new Size(newWidth, newHeight)); 
        }
        private void LoadFilterCriteria()
        {
            var filterCriteria = new List<string>
            {
                "Giới Tính",
                "Nghề Nghiệp",
                "Địa Chỉ",
                "Quê Quán"
            };

            cb_FilterCriteria.DataSource = filterCriteria;
        }

        private async void btn_TimKiem_Click(object sender, EventArgs e)
        {
            string filterCriteria = cb_FilterCriteria.SelectedItem?.ToString();
            string filterValue = txt_filterValue.Text.Trim();

            if (string.IsNullOrEmpty(filterCriteria) || string.IsNullOrEmpty(filterValue))
            {
                MessageBox.Show("Vui lòng chọn tiêu chí lọc và nhập giá trị tìm kiếm.");
                return;
            }

            string query = "MATCH (p:Person) WHERE ";

            switch (filterCriteria)
            {
                case "Giới Tính":
                    query += "toLower(p.gender) = toLower($filterValue)";
                    break;
                case "Nghề Nghiệp":
                    query += "toLower(p.occupation) CONTAINS toLower($filterValue)";
                    break;
                case "Địa Chỉ":
                    query += "toLower(p.address) CONTAINS toLower($filterValue)";
                    break;
                case "Quê Quán":
                    query += "toLower(p.hometown) CONTAINS toLower($filterValue)";
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm hợp lệ.");
                    return;
            }

            query += " RETURN p.id AS Id, p.name AS Name, p.birthDate AS BirthDate, p.deathDate AS DeathDate, p.gender AS Gender, p.occupation AS Occupation, p.hometown AS Hometown, p.address AS Address, p.image AS Image"; // Thêm thuộc tính hình ảnh vào truy vấn

            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

            await using (var session = _driver.AsyncSession())
            {
                try
                {
                    var result = await session.RunAsync(query, new { filterValue });
                    await foreach (var record in result)
                    {
                        var dict = new Dictionary<string, object>
                {
                    { "Id", record["Id"]?.As<string>() ?? "N/A" },
                    { "Name", record["Name"]?.As<string>() ?? "N/A" },
                    { "BirthDate", record["BirthDate"]?.As<string>() ?? "N/A" },
                    { "DeathDate", record["DeathDate"]?.As<string>() ?? "N/A" },
                    { "Gender", record["Gender"]?.As<string>() ?? "N/A" },
                    { "Occupation", record["Occupation"]?.As<string>() ?? "N/A" },
                    { "Hometown", record["Hometown"]?.As<string>() ?? "N/A" },
                    { "Address", record["Address"]?.As<string>() ?? "N/A" },
                    { "Image", record.ContainsKey("Image") ? record["Image"].As<string>() : null } 
                };
                        data.Add(dict);
                    }

                    if (data.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy cá nhân nào với tiêu chí lọc đã chọn.");
                    }
                    else
                    {
                        LoadDataToGrid(data);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}");
                }
            }
        }



        private string _imagePath;
        private async void btn_Them_Click(object sender, EventArgs e)
        {
            
            string name = txt_Ten.Text;
            string birthDate = dtp_NgaySinh.Value.ToString("yyyy-MM-dd");
            string deathDate = dtp_NgayMat.Value.Date == DateTimePicker.MinimumDateTime.Date ? null : dtp_NgayMat.Value.ToString("yyyy-MM-dd");
            string gender = radio_Nam.Checked ? "Nam" : "Nữ";
            string occupation = txt_NgheNghiep.Text;
            string hometown = txt_QueQuan.Text;
            string address = txt_DiaChi.Text;

          
            if (string.IsNullOrEmpty(_imagePath))
            {
                MessageBox.Show("Chưa chọn ảnh.");
                return; 
            }


            string image = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", System.IO.Path.GetFileName(_imagePath));

            var findMaxIdQuery = "MATCH (p:Person) RETURN max(p.id) AS MaxId";

            await using (var session = _driver.AsyncSession())
            {
                try
                {
                    var maxIdResult = await session.RunAsync(findMaxIdQuery);
                    int newId = 1;

                    if (await maxIdResult.FetchAsync())
                    {
                        newId = maxIdResult.Current["MaxId"].As<int>() + 1;
                    }

                    var query = @"
                CREATE (p:Person {
                    id: $id, 
                    name: $name, 
                    birthDate: $birthDate, 
                    deathDate: $deathDate, 
                    gender: $gender, 
                    occupation: $occupation, 
                    hometown: $hometown, 
                    address: $address, 
                    image: $image
                })
                RETURN id(p) AS Id";

                    var parameters = new
                    {
                        id = newId,
                        name,
                        birthDate,
                        deathDate,
                        gender,
                        occupation,
                        hometown,
                        address,
                        image 
                    };

                    await session.RunAsync(query, parameters);
                    MessageBox.Show("Thêm cá nhân thành công!");

                    
                    string selectedRelationship = cb_MoiQuanHe.SelectedItem?.ToString();
                    string relatedPersonName = cb_MoiQuanHeVoi.SelectedItem?.ToString();

                    if (!string.IsNullOrEmpty(selectedRelationship) && !string.IsNullOrEmpty(relatedPersonName))
                    {
                       
                        var findPersonIdQuery = "MATCH (p:Person {name: $name}) RETURN p.id AS Id";
                        var relatedPersonResult = await session.RunAsync(findPersonIdQuery, new { name = relatedPersonName });

                        if (await relatedPersonResult.FetchAsync())
                        {
                            int relatedPersonId = relatedPersonResult.Current["Id"].As<int>();


                            var createRelationshipQuery = $@"
                        MATCH (a:Person {{id: $newId}}), (b:Person {{id: $relatedPersonId}})
                        CREATE (a)-[:{selectedRelationship}]->(b)";

                            await session.RunAsync(createRelationshipQuery, new { newId, relatedPersonId });
                            MessageBox.Show("Thêm mối quan hệ thành công!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa chọn mối quan hệ hoặc cá nhân liên quan.");
                    }

                    await LoadDataAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm cá nhân: {ex.Message}");
                }
            }
        }






        private async void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một cá nhân để xóa.");
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];
            int selectedId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa cá nhân này không?",
                                                 "Xác nhận xóa",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                var query = "MATCH (p:Person {id: $id}) DELETE p";

                await using (var session = _driver.AsyncSession())
                {
                    try
                    {
                        var parameters = new { id = selectedId };
                        await session.RunAsync(query, parameters);
                        MessageBox.Show("Đã xóa cá nhân thành công!");
                        await LoadDataAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa cá nhân: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Đã hủy thao tác xóa.");
            }
        }

        private async Task LoadPersonsToComboBoxAsync()
        {
            var query = "MATCH (p:Person) RETURN p.name AS Name";

            await using (var session = _driver.AsyncSession())
            {
                try
                {
                    var result = await session.RunAsync(query);
                    var names = new List<string>();

                    await foreach (var record in result)
                    {
                        names.Add(record["Name"].As<string>());
                    }

                    cb_MoiQuanHeVoi.DataSource = names;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading relationship data: {ex.Message}");
                }
            }
        }

        private void btn_ChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Chọn ảnh";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Đường dẫn tệp mà người dùng đã chọn
                _imagePath = openFileDialog.FileName; // Lưu đường dẫn tệp hình ảnh

                // Tạo thư mục Images nếu chưa tồn tại
                string targetDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                if (!System.IO.Directory.Exists(targetDirectory))
                {
                    System.IO.Directory.CreateDirectory(targetDirectory);
                }

                // Tạo tên tệp mới (bạn có thể thay đổi cách đặt tên nếu cần)
                string targetFilePath = System.IO.Path.Combine(targetDirectory, System.IO.Path.GetFileName(_imagePath));

                // Sao chép tệp vào thư mục Images
                try
                {
                    System.IO.File.Copy(_imagePath, targetFilePath, true); // true để ghi đè nếu tệp đã tồn tại
                    MessageBox.Show("Đã lưu ảnh thành công!");

                    // Hiển thị ảnh trong PictureBox
                    box_Anh.Image = Image.FromFile(targetFilePath);
                    box_Anh.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu ảnh: {ex.Message}");
                }
            }
        }



        private void LoadRelationshipTypes()
        {
            var relationshipTypes = new List<string>
            {
                "PARENT_OF",
                "SPOUSE_OF",
                "SIBLING_OF",
                "GRANDPARENT_OF",
                "UNCLE_AUNT_OF",
                "COUSIN_OF"
            };

            cb_MoiQuanHe.DataSource = relationshipTypes;
        }

        private async void btn_ChiTiet_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int selectedId = Convert.ToInt32(selectedRow.Cells["Id"].Value); // Lấy Id cá nhân đã chọn

                // Tạo truy vấn để lấy thông tin chi tiết cá nhân từ cơ sở dữ liệu
                var query = "MATCH (p:Person {id: $id}) RETURN p.name AS Name, p.birthDate AS BirthDate, p.deathDate AS DeathDate, " +
                            "p.gender AS Gender, p.occupation AS Occupation, p.hometown AS Hometown, p.address AS Address, p.image AS Image";

                List<Dictionary<string, object>> details = new List<Dictionary<string, object>>();

                await using (var session = _driver.AsyncSession())
                {
                    try
                    {
                        var result = await session.RunAsync(query, new { id = selectedId });
                        await foreach (var record in result)
                        {
                            var dict = new Dictionary<string, object>
                    {
                        { "Name", record["Name"].As<string>() },
                        { "BirthDate", record["BirthDate"].As<string>() },
                        { "DeathDate", record["DeathDate"].As<string>() },
                        { "Gender", record["Gender"].As<string>() },
                        { "Occupation", record["Occupation"].As<string>() },
                        { "Hometown", record["Hometown"].As<string>() },
                        { "Address", record["Address"].As<string>() },
                        { "Image", record["Image"].As<string>() } // Lấy đường dẫn hình ảnh
                    };
                            details.Add(dict);
                        }

                        // Kiểm tra nếu không có dữ liệu
                        if (details.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy thông tin chi tiết cho cá nhân này.");
                            return;
                        }

                        // Mở FormDetails và truyền thông tin
                        var detail = details[0]; // Lấy thông tin chi tiết đầu tiên
                        FormDetails detailsForm = new FormDetails(
                            detail["Name"].ToString(),
                            detail["BirthDate"].ToString(),
                            detail["DeathDate"]?.ToString(),
                            detail["Gender"].ToString(),
                            detail["Occupation"].ToString(),
                            detail["Hometown"].ToString(),
                            detail["Address"].ToString(),
                            detail["Image"].ToString() // Truyền đường dẫn hình ảnh
                        );
                        detailsForm.ShowDialog(); // Mở form như một dialog
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi lấy thông tin chi tiết: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xem chi tiết.");
            }
        }


    }
}
