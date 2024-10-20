﻿using NoSQL_Project.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoSQL_Project
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            RunApplication();
        }

        private static void RunApplication()
        {
            var uri = "neo4j+s://e1235e19.databases.neo4j.io";
            var username = "neo4j";
            var password = "FJf8JsM64-FWiPD4-gWrc4fwUDgd8fxfUR9TzcedwUs";

            // Kết nối tới Neo4j
            using (var neo4jConnection = new Neo4jConnection(uri, username, password))
            {
                try
                {
                    // Mở form chính và truyền driver vào form
                    var form = new Form1(neo4jConnection.Driver);
                    Application.Run(form);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
