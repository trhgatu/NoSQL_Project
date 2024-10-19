using NoSQL_Project.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NoSQL_Project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            // Tạo ImageList
            ImageList imgList = new ImageList();
            imgList.Images.Add("manager", Image.FromFile("C:\\Users\\chayb\\source\\repos\\NoSQL_Project\\NoSQL_Project\\Resources\\manager.png"));
            imgList.Images.Add("employee", Image.FromFile("C:\\Users\\chayb\\source\\repos\\NoSQL_Project\\NoSQL_Project\\Resources\\employee.png"));
            imgList.Images.Add("sales", Image.FromFile("C:\\Users\\chayb\\source\\repos\\NoSQL_Project\\NoSQL_Project\\Resources\\sales.png"));
            imgList.Images.Add("marketing", Image.FromFile("C:\\Users\\chayb\\source\\repos\\NoSQL_Project\\NoSQL_Project\\Resources\\marketing.png"));

            // Load a default image
            Image defaultImage = Image.FromFile("C:\\Users\\chayb\\source\\repos\\NoSQL_Project\\NoSQL_Project\\Resources\\default.png");

            // Gán ImageList cho TreeView
            treeView1.ImageList = imgList;

            // Tạo dữ liệu mẫu
            Employee ceo = new Employee("John Doe", "Manager", defaultImage);
            ceo.Subordinates.Add(new Employee("Jane Smith", "Sales", defaultImage));
            ceo.Subordinates.Add(new Employee("Mike Johnson", "Marketing", defaultImage));

            // Thêm các node vào TreeView
            AddEmployeeNode(treeView1.Nodes, ceo);
        }

        private void AddEmployeeNode(TreeNodeCollection nodes, Employee employee)
        {
            TreeNode node = new TreeNode($"{employee.Name} - {employee.Position}")
            {
                ImageKey = employee.Position switch
                {
                    "Manager" => "manager",
                    "Sales" => "sales",
                    "Marketing" => "marketing",
                    _ => "employee"
                },
                SelectedImageKey = employee.Position switch
                {
                    "Manager" => "manager",
                    "Sales" => "sales",
                    "Marketing" => "marketing",
                    _ => "employee"
                }
            };

            foreach (var subordinate in employee.Subordinates)
            {
                AddEmployeeNode(node.Nodes, subordinate);
            }

            nodes.Add(node);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Xử lý khi form load
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Xử lý khi một node được chọn
            TreeNode selectedNode = e?.Node;
            if (selectedNode != null)
            {
                MessageBox.Show($"Selected Employee: {selectedNode.Text}");
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView1.SelectedNode = e.Node;
                contextMenuStrip1.Show(treeView1, e.Location);
            }
        }

        private void ViewDetails_Click(object sender, EventArgs e)
        {
            // Hiển thị chi tiết của nhân viên
            TreeNode selectedNode = treeView1.SelectedNode;
            if (selectedNode != null)
            {
                MessageBox.Show($"Viewing details for: {selectedNode.Text}");
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            // Chỉnh sửa thông tin nhân viên
            TreeNode selectedNode = treeView1.SelectedNode;
            if (selectedNode != null)
            {
                MessageBox.Show($"Editing: {selectedNode.Text}");
            }
        }

        private void AddNewMember_Click(object sender, EventArgs e)
        {
            // Thêm nhân viên mới
            TreeNode selectedNode = treeView1.SelectedNode;
            if (selectedNode != null)
            {
                TreeNode newNode = new TreeNode("New Employee")
                {
                    ImageKey = "employee",
                    SelectedImageKey = "employee"
                };
                selectedNode.Nodes.Add(newNode);
                selectedNode.Expand();
            }
        }
    }
}