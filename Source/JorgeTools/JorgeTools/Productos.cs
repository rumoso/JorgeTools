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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JorgeTools
{
    public partial class Productos : Form
    {
        Thread hilo;
        public Productos()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            cargarProductosEnDataGrid();
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
                ThreadStart delegado = new ThreadStart(cargarExcel);

                hilo = new Thread(delegado);
                hilo.Start();
            }
            else
            {
                MessageBox.Show("Seleccione el archivo");
            }
        }

        public void cargarExcel()
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
                    var worksheet = workbook.Worksheet(1); // Primera hoja

                    int rows = worksheet.RowsUsed().Count();
                    int cols = worksheet.ColumnsUsed().Count();

                    pgbProceso.Maximum = rows;

                    var connection = dbManager.GetConnection();
                    connection.Open();

                    var sQuery = "DELETE FROM Productos";
                    dbManager.ExecuteQuery(connection, sQuery);

                    // Leer cada fila (excepto los encabezados)
                    for (int row = 2; row <= rows; row++) // Empieza desde la fila 2
                    {
                        string codigoBan = worksheet.Cell(row, 1).GetValue<string>();
                        string codigoSap = worksheet.Cell(row, 2).GetValue<string>();
                        string descriptionSAP = worksheet.Cell(row, 3).GetValue<string>();
                        string linea = worksheet.Cell(row, 4).GetValue<string>();

                        lblProcess.Text = "Cargando: " + (row - 1) + "/" + rows;
                        pgbProceso.Value = row;

                        // Insertar los datos en la tabla
                        string insertQuery = @"
                INSERT INTO Productos (codigoBan, codigoSap, descriptionSAP, linea)
                VALUES (@codigoBan, @codigoSap, @descriptionSAP, @linea);";

                        using (var command = new SQLiteCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@codigoBan", codigoBan);
                            command.Parameters.AddWithValue("@codigoSap", codigoSap);
                            command.Parameters.AddWithValue("@descriptionSAP", descriptionSAP);
                            command.Parameters.AddWithValue("@linea", linea);

                            command.ExecuteNonQuery();
                        }
                    }
                    connection.Close();
                    lblProcess.Text = "Productos cargados";
                }
                btnCargar.Enabled = true;
                cargarProductosEnDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnCargar.Enabled = true;
            }
        }

        public void cargarProductosEnDataGrid()
        {
            try
            {
                // Conexión a la base de datos SQLite
                var connection = dbManager.GetConnection();
                connection.Open();

                var sFilter = string.Empty;
                sFilter = string.IsNullOrEmpty(tbxFiltro.Text) ? "" : tbxFiltro.Text.Trim();

                // Consulta SQL para obtener los productos
                string query = @"SELECT codigoBan, codigoSap, descriptionSAP, linea FROM Productos" +
                    @" WHERE " +
                    $" codigoBan LIKE '%{sFilter}%'" +
                    $" OR codigoSap LIKE '%{sFilter}%'" +
                    $" OR descriptionSAP LIKE '%{sFilter}%'" +
                    $" OR linea LIKE '%{sFilter}%'" +
                    ";";

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
                        lblResultSearch.Text = dt.Rows.Count + " Productos encontrados";
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
            cargarProductosEnDataGrid();
        }

        private void tbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarProductosEnDataGrid();
            }
        }
    }
}
