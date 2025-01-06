using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JorgeTools.SQLite
{
    public class dbManager
    {
        private static string databasePath = "db_jt.sqlite";

        public static void InitializeDatabase()
        {
            // Verificar si la base de datos existe
            if (!File.Exists(databasePath))
            {
                // Crear la base de datos
                SQLiteConnection.CreateFile(databasePath);
                //MessageBox.Show("Base de datos creada correctamente.");

                // Crear tablas iniciales
                using (var connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
                {
                    connection.Open();
                    CreateTables(connection);
                }
            }
            else
            {
                //MessageBox.Show("La base de datos ya existe.");
            }
        }

        private static void CreateTables(SQLiteConnection connection)
        {
            string createClientesTable = @"
                CREATE TABLE IF NOT EXISTS Clientes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    source_id TEXT,
                    partner TEXT,
                    type INT,
                    bu_group TEXT,
                    bpext TEXT,
                    bu_sort1 TEXT,
                    bu_sort2 TEXT,
                    name_org1 TEXT,
                    name_org2 TEXT,
                    name_org3 TEXT,
                    name_org4 TEXT
                );";

            string createProductosTable = @"
                CREATE TABLE IF NOT EXISTS Productos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    codigoBan TEXT NOT NULL,
                    codigoSap TEXT NOT NULL,
                    descriptionSAP TEXT NOT NULL,
                    linea TEXT NOT NULL
                );";

            string createOrdenesTable = @"
                CREATE TABLE IF NOT EXISTS Ordenes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    salesOrganization TEXT NOT NULL,
                    division TEXT NOT NULL,
                    shipToParty TEXT NOT NULL,
                    customerReference TEXT,
                    requestDeliveryDate TEXT,
                    plant TEXT
                );";

            string createOrdenDetallesTable = @"
                CREATE TABLE IF NOT EXISTS OrdenDetalles (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    OrdenId INTEGER NOT NULL,

                    itemID TEXT,
                    product_CodigoSap TEXT NOT NULL,
                    product_CodigoBan TEXT NOT NULL,
                    requested_quantity TEXT,
                    requested_QtyUnit TEXT,

                    FOREIGN KEY (OrdenId) REFERENCES Ordenes(Id)
                );";

            // Ejecutar las consultas para crear las tablas
            ExecuteQuery(connection, createClientesTable);
            ExecuteQuery(connection, createProductosTable);
            ExecuteQuery(connection, createOrdenesTable);
            ExecuteQuery(connection, createOrdenDetallesTable);

            //MessageBox.Show("Tablas creadas correctamente.");
        }

        public static void ExecuteQuery(SQLiteConnection connection, string query)
        {
            using (var command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection($"Data Source={databasePath};Version=3;");
        }
    }
}
