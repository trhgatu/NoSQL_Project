using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQL_Project.DataAccess
{
    public class Neo4jConnection : IDisposable
    {
        private readonly IDriver _driver;

        public Neo4jConnection(string uri, string username, string password)
        {
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(username, password));
            Console.WriteLine("Kết nối tới Neo4j thành công!");
        }

        public async Task<List<Dictionary<string, object>>> RunCypherQuery(string query)
        {
            var data = new List<Dictionary<string, object>>();

            using (var session = _driver.AsyncSession())
            {
                var result = await session.RunAsync(query);

                await result.ForEachAsync(record =>
                {
                    var node = record["n"].As<INode>();
                    var properties = new Dictionary<string, object>(node.Properties);
                    properties.Add("id", node.Id);
                    data.Add(properties);
                });
            }

            return data;
        }

        public void Dispose()
        {
            _driver?.Dispose();
        }
    }
}
