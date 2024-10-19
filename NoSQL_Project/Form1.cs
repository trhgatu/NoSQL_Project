using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Linq;
using NoSQL_Project.Models;


namespace NoSQL_Project
{
    public partial class Form1 : Form
    {
        private IDriver _driver;
        private string _id;
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


            table.Columns.Add("Image", typeof(System.Drawing.Image));

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
                        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(imagePath);
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


        private System.Drawing.Image ResizeImage(System.Drawing.Image image, int width, int height)
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
            string selectedRelationship = cb_MoiQuanHe.SelectedValue?.ToString();
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

        private async Task<DialogResult> SavePerson(string id, string hometown, string occupation, string address, string gender, string name, string deathDate, string birthDate)
        {
            try
            {
                await using (var session = _driver.AsyncSession())
                {
                    var query = @"
                MATCH (p:Person {id: $id})
                SET p.hometown = $hometown, 
                    p.occupation = $occupation, 
                    p.address = $address, 
                    p.gender = $gender, 
                    p.name = $name, 
                    p.deathDate = $deathDate, 
                    p.birthDate = $birthDate 
                RETURN p";

                    var parameters = new
                    {
                        id,
                        hometown,
                        occupation,
                        address,
                        gender,
                        name,
                        deathDate,
                        birthDate
                    };

                    var result = await session.RunAsync(query, parameters);

                    if (await result.PeekAsync() == null)
                    {
                        return DialogResult.None;
                    }
                    else
                    {
                        var singleResult = await result.SingleAsync();
                        return DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
                return DialogResult.Abort;
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
                    box_Anh.Image = System.Drawing.Image.FromFile(targetFilePath);
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
            var relationshipTypes = new Dictionary<string, string>
                {
                    { "Cha/Mẹ", "PARENT_OF" },
                    { "Vợ/Chồng", "SPOUSE_OF" },
                    { "Anh/Chị/Em", "SIBLING_OF" },
                    { "Ông/Bà", "GRANDPARENT_OF" },
                    { "Chú/Bác/Cô/Dì", "UNCLE_AUNT_OF" },
                    { "Anh/Chị/Em Họ", "COUSIN_OF" }
                };

            cb_MoiQuanHe.DataSource = new BindingSource(relationshipTypes, null);
            cb_MoiQuanHe.DisplayMember = "Key";
            cb_MoiQuanHe.ValueMember = "Value";
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cb_FilterCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var rowData = dataGridView1.Rows[rowIndex];
            _id = (string)rowData.Cells[0].Value;
            DateTime birthDate, dieDate;
            if (DateTime.TryParse(rowData.Cells[3].Value.ToString(), out birthDate))
            {
                dtp_NgaySinh.Value = birthDate;
            }
            if (string.IsNullOrEmpty(rowData.Cells[4].Value?.ToString()))
            {
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
            }
            else
            {
                if (rowData.Cells[4].Value != null && DateTime.TryParse(rowData.Cells[4].Value.ToString(), out dieDate))
                {
                    dtp_NgayMat.Value = dieDate;
                }
            }
            string gender = rowData.Cells[5].Value?.ToString();
            if (gender == "Nam")
            {
                radio_Nam.Checked = true;
                radio_Nu.Checked = false;
            }
            else if (gender == "Nữ")
            {
                radio_Nu.Checked = true;
                radio_Nam.Checked = false;
            }
            txt_Ten.Text = rowData.Cells[2].Value?.ToString() ?? string.Empty;
            txt_NgheNghiep.Text = rowData.Cells[6].Value?.ToString() ?? string.Empty;
            txt_QueQuan.Text = rowData.Cells[7].Value?.ToString() ?? string.Empty;
            txt_DiaChi.Text = rowData.Cells[8].Value?.ToString() ?? string.Empty;
        }

        [Obsolete]
        private async void btn_Luu_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ form
            string name = txt_Ten.Text;
            string birthDate = dtp_NgaySinh.Value.ToString("yyyy-MM-dd");
            string deathDate = dtp_NgayMat.Value.Date == DateTimePicker.MinimumDateTime.Date ? null : dtp_NgayMat.Value.ToString("yyyy-MM-dd");
            string gender = radio_Nam.Checked ? "Nam" : "Nữ";
            string occupation = txt_NgheNghiep.Text;
            string hometown = txt_QueQuan.Text;
            string address = txt_DiaChi.Text;

            // Kiểm tra giá trị ID
            if (string.IsNullOrEmpty(_id))
            {
                MessageBox.Show("Không có ID hợp lệ để cập nhật.");
                return;
            }

            // Giả sử _id là số, chúng ta ép kiểu từ chuỗi sang số (nếu cần)
            if (!int.TryParse(_id, out int personId))
            {
                MessageBox.Show("ID không hợp lệ. Hãy kiểm tra lại.");
                return;
            }

            MessageBox.Show($"ID hiện tại là: {personId}");

            try
            {
                await using (var session = _driver.AsyncSession())
                {
                    // Kiểm tra sự tồn tại của nút có ID trước khi cập nhật
                    var checkQuery = @"
                        MATCH (p:Person {id: $id})
                        RETURN p LIMIT 1";
                    var checkParameters = new { id = personId };
                    var checkResult = await session.RunAsync(checkQuery, checkParameters);
                    var checkRecords = await checkResult.ToListAsync();

                    if (checkRecords.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy người nào có ID này.");
                        return;
                    }

                    // Cập nhật thông tin trong transaction nếu nút tồn tại
                    await session.WriteTransactionAsync(async tx =>
                    {
                        var updateQuery = @"
         MATCH (p:Person {id: $id})
         SET p.hometown = $hometown, 
             p.occupation = $occupation, 
             p.address = $address, 
             p.gender = $gender, 
             p.name = $name, 
             p.deathDate = $deathDate, 
             p.birthDate = $birthDate
         RETURN id(p) AS Id";

                        var updateParameters = new
                        {
                            id = personId,  // Sử dụng personId là số
                            hometown,
                            occupation,
                            address,
                            gender,
                            name,
                            deathDate = string.IsNullOrEmpty(deathDate) ? null : deathDate,
                            birthDate
                        };

                        var updateResult = await tx.RunAsync(updateQuery, updateParameters);
                        var updateRecords = await updateResult.ToListAsync();

                        if (updateRecords.Count > 0)
                        {
                            var updatedId = updateRecords[0]["Id"];
                            MessageBox.Show($"Cập nhật thành công {updatedId}" + 1);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy người nào để cập nhật.");
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
            }

            // Tải lại dữ liệu sau khi cập nhật
            await LoadDataAsync();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dtp_NgayMat.Enabled = true;
            }
            else if (checkBox1.Checked == false)
            {
                dtp_NgayMat.Enabled = false;
            }
        }

        private void btn_XemCay_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
