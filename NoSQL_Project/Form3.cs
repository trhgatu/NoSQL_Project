using Neo4j.Driver;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NoSQL_Project
{
    public partial class Form3 : Form
    {
        private IDriver _driver;
        private IAsyncSession _session;
        private ImageList imageList;

        public Form3()
        {
            InitializeComponent();
            InitializeNeo4jConnection();
            InitializeImageList(); // Initialize images
            PopulateTreeView();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Add your load logic here
        }

        private void InitializeNeo4jConnection()
        {
            // Initialize Neo4j connection using Neo4j.Driver
            _driver = GraphDatabase.Driver("neo4j+s://e1235e19.databases.neo4j.io", AuthTokens.Basic("neo4j", "FJf8JsM64-FWiPD4-gWrc4fwUDgd8fxfUR9TzcedwUs"));
            _session = _driver.AsyncSession();
        }

        private void InitializeImageList()
        {
            // Initialize the ImageList and add images
            imageList = new ImageList();
            imageList.ImageSize = new Size(32, 32); // Adjust size as needed

            // Example: Adding some sample images (replace with actual profile photos)
            imageList.Images.Add("male", Image.FromFile("C:\\Users\\chayb\\source\\repos\\NoSQL_Project1\\NoSQL_Project\\Resources\\male.png")); // Replace with actual file path
            imageList.Images.Add("female", Image.FromFile("C:\\Users\\chayb\\source\\repos\\NoSQL_Project1\\NoSQL_Project\\Resources\\female.png"));
            imageList.Images.Add("unknown", Image.FromFile("C:\\Users\\chayb\\source\\repos\\NoSQL_Project1\\NoSQL_Project\\Resources\\sales.png"));

            // Assign ImageList to the TreeView
            treeView1.ImageList = imageList;
        }

        private async void PopulateTreeView()
        {
            // Dictionary to map relationship types to Vietnamese equivalents
            var relationshipTranslations = new Dictionary<string, string>
    {
        { "GRANDPARENT_OF", "Ông/Bà" },
        { "PARENT_OF", "Cha/Mẹ" },
        { "SPOUSE_OF", "Vợ/Chồng" },
        { "COUSIN_OF", "Anh/Chị/Em họ" },
        { "SIBLING_OF", "Anh/Chị/Em" },
        { "UNCLE_AUNT_OF", "Chú/Bác/Cô/Dì" }
    };

            // Query to get family members and relationships from Neo4j
            var query = @"
        MATCH (p:Person)-[r]->(child:Person)
        RETURN p, r, child
    ";

            var result = await _session.RunAsync(query);

            // Initialize the TreeView
            TreeNode rootNode = new TreeNode("Cây gia đình");

            // Dictionary to keep track of nodes
            var nodes = new Dictionary<long, TreeNode>();

            await foreach (var record in result)
            {
                var parent = record["p"].As<INode>();
                var relationship = record["r"].As<IRelationship>();
                var child = record["child"].As<INode>();

                // Translate relationship type to Vietnamese
                var relationshipType = relationship.Type;
                var translatedRelationshipType = relationshipTranslations.ContainsKey(relationshipType)
                    ? relationshipTranslations[relationshipType]
                    : relationshipType;

                // Create or get parent node
                if (!nodes.TryGetValue(parent.Id, out TreeNode parentNode))
                {
                    parentNode = new TreeNode($"{parent["name"].As<string>()}")
                    {
                        ImageKey = GetImageKey(parent),
                        SelectedImageKey = GetImageKey(parent)
                    };
                    nodes[parent.Id] = parentNode;
                }

                // Create or get child node
                if (!nodes.TryGetValue(child.Id, out TreeNode childNode))
                {
                    childNode = new TreeNode($"{child["name"].As<string>()}")
                    {
                        ImageKey = GetImageKey(child),
                        SelectedImageKey = GetImageKey(child)
                    };
                    nodes[child.Id] = childNode;
                }

                // Add child node to parent node based on relationship
                if (relationshipType == "GRANDPARENT_OF" || relationshipType == "PARENT_OF")
                {
                    parentNode.Nodes.Add(childNode);
                }
                else if (relationshipType == "SPOUSE_OF")
                {
                    parentNode.Nodes.Add(new TreeNode($"{child["name"].As<string>()} ({translatedRelationshipType})")
                    {
                        ImageKey = GetImageKey(child),
                        SelectedImageKey = GetImageKey(child)
                    });
                }
                else if (relationshipType == "SIBLING_OF" || relationshipType == "COUSIN_OF" || relationshipType == "UNCLE_AUNT_OF")
                {
                    rootNode.Nodes.Add(childNode);
                }
            }

            // Add all top-level nodes to the root node
            foreach (var node in nodes.Values)
            {
                if (node.Parent == null)
                {
                    rootNode.Nodes.Add(node);
                }
            }

            // Add the root node to the TreeView
            treeView1.Nodes.Add(rootNode);
            treeView1.ExpandAll();
        }

        private string GetImageKey(INode person)
        {
            // Determine the image key based on the person's attributes (e.g., gender)
            var gender = person["gender"].As<string>().ToLower();
            if (gender == "nam")
            {
                return "male"; // Corresponds to male icon in the ImageList
            }
            else if (gender == "nữ")
            {
                return "female"; // Corresponds to female icon in the ImageList
            }
            else
            {
                return "unknown"; // Default icon for unknown gender
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Handle selection logic here
        }

        // Dispose of the Neo4j session and driver when closing the form
        private async void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            await _session.CloseAsync();
            await _driver.CloseAsync();
        }
    }

    // Sample Person class (not necessarily used in Neo4j.Driver context)
    public class Persons
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public Image Photo { get; set; } // Optional: Add Image property for profile pictures
    }

    // Sample Relationship class (not necessarily used in Neo4j.Driver context)
    public class Relationship
    {
        public string Type { get; set; }
    }
}