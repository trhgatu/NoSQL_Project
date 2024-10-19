using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoSQL_Project
{
    public partial class Form2 : Form
    {
        private readonly IDriver _driver;
        private int _id;
        public Form2(int id)
        {            
            _id = id;
            InitializeComponent();
            label1.Text = _id.ToString();
            // Initialize Neo4j driver
            _driver = GraphDatabase.Driver(
                "neo4j+s://e1235e19.databases.neo4j.io",
                AuthTokens.Basic("neo4j", "FJf8JsM64-FWiPD4-gWrc4fwUDgd8fxfUR9TzcedwUs"));

            // Assign event handlers
            treeView1.NodeMouseClick += TreeView1_NodeMouseClick;
            treeView1.AfterSelect += TreeView1_AfterSelect;
            Load += Form2_Load;
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialize ImageList and load images
                ImageList imgList = new ImageList();
                string resourcesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");

                imgList.Images.Add("person", LoadImage(Path.Combine(resourcesPath, "default.png")));
                treeView1.ImageList = imgList;

                // Load data from Neo4j
                await LoadDataFromNeo4j();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing form: {ex.Message}", "Initialization Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image LoadImage(string path)
        {
            try
            {
                return Image.FromFile(path);
            }
            catch (Exception)
            {

                return new Bitmap(16, 16);  // Return placeholder image
            }
        }

        private async Task LoadDataFromNeo4j()
        {
            try
            {
                using var session = _driver.AsyncSession();
                var result = await session.RunAsync(@"
            MATCH (p:Person {id: $id})-[r]->(related:Person)
            RETURN p, type(r) AS relationship, related", new { id = _id });

                var personMap = new Dictionary<string, TreeNode>();

                await result.ForEachAsync(record =>
                {
                    var personNode = NodeToPerson(record["p"].As<INode>());
                    var relatedPersonNode = NodeToPerson(record["related"].As<INode>());
                    string relationship = record["relationship"].As<string>();

                    // Add or update nodes in the TreeView
                    Invoke(() =>
                    {
                        var parentNode = GetOrCreatePersonNode(treeView1.Nodes, personMap, personNode);
                        var childNode = AddPersonNode(parentNode.Nodes, relatedPersonNode);
                        childNode.Text += $" ({relationship})";
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TreeNode GetOrCreatePersonNode(TreeNodeCollection nodes, Dictionary<string, TreeNode> personMap, Person person)
        {
            if (!personMap.TryGetValue(person.name, out TreeNode node))
            {
                node = AddPersonNode(nodes, person);
                personMap[person.name] = node;
            }
            return node;
        }

        private TreeNode AddPersonNode(TreeNodeCollection nodes, Person person)
        {
            // Create and add a new TreeNode with person data
            var node = new TreeNode($"{person.name} ({person.gender})")
            {
                ImageKey = "person",
                SelectedImageKey = "person",
                Tag = person  // Store person object in the node's Tag for reference
            };

            nodes.Add(node);
            return node;
        }

        private Person NodeToPerson(INode node)
        {
            return new Person
            {
                name = node["name"].As<string>(),
                gender = node["gender"].As<string>(),
                birthDate = node["birthDate"].As<string>(),
                image = node.Properties.TryGetValue("image", out var imagePath) && !string.IsNullOrEmpty(imagePath.As<string>())
                        ? LoadImage(imagePath.As<string>())
                        : null
            };
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is Person person)
            {
                string message = $"Name: {person.name}\nGender: {person.gender}\nBirthDate: {person.birthDate}";
                MessageBox.Show(message, "Person Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView1.SelectedNode = e.Node;
                contextMenuStrip1.Show(treeView1, e.Location);
            }
        }

        private void ViewDetails_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode?.Tag is Person person)
            {
                ShowPersonDetails(person);
            }
        }

        private void ShowPersonDetails(Person person)
        {
            string details = $"Name: {person.name}\nGender: {person.gender}\nBirthDate: {person.birthDate}";

            if (person.image != null)
            {
                var pictureBox = new PictureBox
                {
                    Image = person.image,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(100, 100)
                };

                var imageForm = new Form
                {
                    Text = "Person Image",
                    Size = new Size(120, 140)
                };
                imageForm.Controls.Add(pictureBox);
                imageForm.ShowDialog();
            }
            else
            {
                MessageBox.Show(details, "Person Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode?.Tag is Person person)
            {
                MessageBox.Show($"Editing: {person.name}", "Edit Person", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddNewMember_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                var newNode = new TreeNode("New Person")
                {
                    ImageKey = "person",
                    SelectedImageKey = "person"
                };
                treeView1.SelectedNode.Nodes.Add(newNode);
                treeView1.SelectedNode.Expand();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    public class Person
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string birthDate { get; set; }
        public Image image { get; set; }
    }
}
