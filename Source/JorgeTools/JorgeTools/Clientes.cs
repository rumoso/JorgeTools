using ClosedXML.Excel;
using JorgeTools.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JorgeTools
{
    public partial class Clientes : Form
    {
        Thread hilo;
        public Clientes()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            cargarClientesEnDataGrid();
        }

        //*********************************************METODOS*********************************************
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool bHandled = false;

            switch (keyData)
            {
                case Keys.F1:

                    break;

                case Keys.F5:

                    break;

                case Keys.F6:

                    break;

                case Keys.Escape:
                    this.Close();
                    break;

            }
            return bHandled;
        }

        private void btnBuscarRutaExcel_Click(object sender, EventArgs e)
        {
            tbxRutaExcel.Text = ObtenerRutaArchivo();
        }

        public string ObtenerRutaArchivo()
        {
            string rutaArchivo = string.Empty;
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx"; // Limita a archivos Excel
                dialog.Title = "Seleccione el Excel de productos";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    rutaArchivo = dialog.FileName;
                }
            }
            return rutaArchivo;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxRutaExcel.Text))
            {
                ThreadStart delegado = new ThreadStart(cargarExcelClientes);

                hilo = new Thread(delegado);
                hilo.Start();
            }
            else
            {
                MessageBox.Show("Seleccione el archivo");
            }
        }

        public void cargarExcelClientes()
        {
            try
            {
                btnCargar.Enabled = false;
                lblProcess.Text = "Procesando...";
                pgbProceso.Visible = true;
                pgbProceso.Value = 0;

                // Cargar el archivo Excel con ClosedXML
                using (var workbook = new XLWorkbook(tbxRutaExcel.Text))
                {
                    var worksheet = workbook.Worksheet(2); // Primera hoja

                    int rows = worksheet.RowsUsed().Count();
                    int cols = worksheet.ColumnsUsed().Count();

                    pgbProceso.Maximum = rows;

                    var connection = dbManager.GetConnection();
                    connection.Open();

                    var sQuery = "DELETE FROM Clientes";
                    dbManager.ExecuteQuery(connection, sQuery);

                    // Leer cada fila (excepto los encabezados)
                    for (int row = 3; row <= rows; row++) // Empieza desde la fila 2
                    {
                        string sourceId = worksheet.Cell(row, 1).GetValue<string>();
                        string partner = worksheet.Cell(row, 2).GetValue<string>();
                        int type = worksheet.Cell(row, 3).GetValue<int>();
                        string buGroup = worksheet.Cell(row, 4).GetValue<string>();
                        string bpext = worksheet.Cell(row, 5).GetValue<string>();
                        string buSort1 = worksheet.Cell(row, 6).GetValue<string>();
                        string buSort2 = worksheet.Cell(row, 7).GetValue<string>();
                        string nameOrg1 = worksheet.Cell(row, 11).GetValue<string>();
                        string nameOrg2 = worksheet.Cell(row, 12).GetValue<string>();
                        string nameOrg3 = worksheet.Cell(row, 13).GetValue<string>();
                        string nameOrg4 = worksheet.Cell(row, 14).GetValue<string>();

                        lblProcess.Text = "Cargando: " + (row - 1) + "/" + rows;
                        pgbProceso.Value = row;

                        // Insertar los datos en la tabla
                        string insertQuery = @"
        INSERT INTO Clientes (source_id, partner, type, bu_group, bpext, bu_sort1, bu_sort2, name_org1, name_org2, name_org3, name_org4)
        VALUES (@sourceId, @partner, @type, @buGroup, @bpext, @buSort1, @buSort2, @nameOrg1, @nameOrg2, @nameOrg3, @nameOrg4);";

                        using (var command = new SQLiteCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@sourceId", sourceId);
                            command.Parameters.AddWithValue("@partner", partner);
                            command.Parameters.AddWithValue("@type", type);
                            command.Parameters.AddWithValue("@buGroup", buGroup);
                            command.Parameters.AddWithValue("@bpext", bpext);
                            command.Parameters.AddWithValue("@buSort1", buSort1);
                            command.Parameters.AddWithValue("@buSort2", buSort2);
                            command.Parameters.AddWithValue("@nameOrg1", nameOrg1);
                            command.Parameters.AddWithValue("@nameOrg2", nameOrg2);
                            command.Parameters.AddWithValue("@nameOrg3", nameOrg3);
                            command.Parameters.AddWithValue("@nameOrg4", nameOrg4);

                            command.ExecuteNonQuery();
                        }
                    }
                    connection.Close();
                    lblProcess.Text = "Clientes cargados";
                }
                btnCargar.Enabled = true;
                cargarClientesEnDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnCargar.Enabled = true;
            }
        }

        //public void cargarClientesEnDataGrid()
        //{
        //    (new Thread(new ThreadStart(cargarClientesEnDataGridHilo))).Start();
        //}

        public void cargarClientesEnDataGrid()
        {
            try
            {
                // Conexión a la base de datos SQLite
                var connection = dbManager.GetConnection();
                connection.Open();

                var iCount = 0;
                using (var command = new SQLiteCommand("SELECT COUNT(*) FROM Clientes", connection))
                {
                    // Ejecutar la consulta y obtener el resultado
                    iCount = Convert.ToInt32(command.ExecuteScalar());
                }

                var sFilter = string.Empty;
                sFilter = string.IsNullOrEmpty(tbxFiltro.Text) ? "" : tbxFiltro.Text.Trim();

                // Consulta SQL para obtener los clientes
                string query = @"SELECT source_id, partner, name_org1, name_org2, name_org3, name_org4, type, bu_group, bpext, bu_sort1, bu_sort2 FROM Clientes" +
                    @" WHERE " +
                    $" source_id LIKE '%{sFilter}%'" +
                    $" OR partner LIKE '%{sFilter}%'" +
                    $" OR bu_group LIKE '%{sFilter}%'" +
                    $" OR bpext LIKE '%{sFilter}%'" +
                    $" OR bu_sort1 LIKE '%{sFilter}%'" +
                    $" OR bu_sort2 LIKE '%{sFilter}%'" +
                    $" OR name_org1 LIKE '%{sFilter}%'" +
                    $" OR name_org2 LIKE '%{sFilter}%'" +
                    $" OR name_org3 LIKE '%{sFilter}%'" +
                    $" OR name_org4 LIKE '%{sFilter}%'" +
                    $" {(!rdbAll.Checked ? "LIMIT 100" : "")};";

                // Crear el comando SQLite
                using (var command = new SQLiteCommand(query, connection))
                {
                    // Crear un adaptador para llenar un DataTable con los datos obtenidos
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Asignar el DataTable al DataGridView
                        dtgDatos.DataSource = dt;
                        dtgDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        lblResultSearch.Text = dt.Rows.Count + " Clientes encontrados" + ( !rdbAll.Checked ? " de " + iCount + " que existen." : "");
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarClientesEnDataGrid();
        }

        private void tbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarClientesEnDataGrid();
            }
        }
    }
}
