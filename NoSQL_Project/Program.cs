using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neo4j.Driver;

namespace NoSQL_Project
{
    internal static class Program
    {
        private static IDriver _driver;

        [STAThread]
        static async Task Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                // Kết nối tới Neo4j
                ConnectToNeo4j();

                // Lấy dữ liệu từ Neo4j
                var data = await RunCypherQuery("MATCH (n) RETURN n LIMIT 10");

                // Mở form chính và truyền dữ liệu vào form
                var form = new Form1();
                form.LoadDataToGrid(data);
                Application.Run(form);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng kết nối Neo4j khi ứng dụng kết thúc
                _driver?.Dispose();
            }
        }

        private static void ConnectToNeo4j()
        {
            var uri = "neo4j+s://e1235e19.databases.neo4j.io";
            var username = "neo4j";
            var password = "FJf8JsM64-FWiPD4-gWrc4fwUDgd8fxfUR9TzcedwUs";

            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(username, password));
            Console.WriteLine("Kết nối tới Neo4j thành công!");
        }

        private static async Task<List<Dictionary<string, object>>> RunCypherQuery(string query)
        {
            var data = new List<Dictionary<string, object>>();

            using (var session = _driver.AsyncSession())
            {
                var result = await session.RunAsync(query);

                await result.ForEachAsync(record =>
                {
                    var node = record["n"].As<INode>(); // "n" là một node trong đồ thị
                    var properties = new Dictionary<string, object>(node.Properties);
                    properties.Add("id", node.Id); // Thêm ID của node vào dữ liệu
                    data.Add(properties);
                });
            }

            return data; // Trả về danh sách dữ liệu
        }
    }
}
