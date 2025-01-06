using JorgeTools.Clases;
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
    public partial class Ordenes : Form
    {
        Thread hilo;
        public Ordenes()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            cargarOrdenesEnDataGrid();
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

        private void btnNewOrden_Click(object sender, EventArgs e)
        {
            NuevaOrden NOrd = new NuevaOrden();
            this.Visible = false;
            NOrd.ShowDialog();
            this.Visible = true;
            cargarOrdenesEnDataGrid();
        }

        public void cargarOrdenesEnDataGrid()
        {
            try
            {
                // Conexión a la base de datos SQLite
                var connection = dbManager.GetConnection();
                connection.Open();

                var iCount = 0;
                using (var command = new SQLiteCommand("SELECT COUNT(*) FROM Ordenes", connection))
                {
                    // Ejecutar la consulta y obtener el resultado
                    iCount = Convert.ToInt32(command.ExecuteScalar());
                }

                var sFilter = string.Empty;
                sFilter = string.IsNullOrEmpty(tbxFiltro.Text) ? "" : tbxFiltro.Text.Trim();

                // Consulta SQL para obtener los clientes
                string query = @"SELECT
	O.Id
	, O.shipToParty AS idCliente
	, C.name_org1 AS ClientName
	, O.customerReference
	, O.requestDeliveryDate
	, O.plant
FROM Ordenes AS O
INNER JOIN Clientes AS C
	ON
		C.source_id = O.shipToParty" +
                    @" WHERE " +
                    $" O.shipToParty LIKE '%{sFilter}%'" +
                    $" OR C.name_org1 LIKE '%{sFilter}%'" +
                    $" OR O.customerReference LIKE '%{sFilter}%'" +
                    $" OR O.plant LIKE '%{sFilter}%'" +
                    $" ORDER BY O.Id DESC " +
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
                        lblResultSearch.Text = dt.Rows.Count + " Ordenes encontradas" + (!rdbAll.Checked ? " de " + iCount + " que existen." : "");
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
            cargarOrdenesEnDataGrid();
        }

        private void tbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarOrdenesEnDataGrid();
            }
        }

        private void Ordenes_Load(object sender, EventArgs e)
        {
            
        }

        private void dtgDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que no sea un encabezado
            {
                // Obtener los datos de la fila seleccionada
                var idOrden = Convert.ToInt64(dtgDatos.Rows[e.RowIndex].Cells["Id"].Value?.ToString());

                // Preguntar si desea reimprimir
                DialogResult result = MessageBox.Show($"¿Deseas reimprimir la orden con ID {idOrden}?",
                                                      "Reimprimir Orden",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ReimprimirOrden(idOrden);
                }
            }
        }

        private void ReimprimirOrden(long idOrden)
        {
            // Crear un formulario modal con un mensaje de "procesando"
            using (Form processingDialog = new Form())
            {
                processingDialog.StartPosition = FormStartPosition.CenterParent;
                processingDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                processingDialog.ControlBox = false;
                processingDialog.Text = "Procesando...";
                processingDialog.Size = new Size(300, 100);

                // Etiqueta para el mensaje
                Label lblMessage = new Label();
                lblMessage.Text = "Generando Excel de la orden, por favor espera...";
                lblMessage.Dock = DockStyle.Fill;
                lblMessage.TextAlign = ContentAlignment.MiddleCenter;
                processingDialog.Controls.Add(lblMessage);

                // Ejecutar la lógica en un hilo separado
                Task.Run(() =>
                {
                    try
                    {
                        // Aquí va tu lógica de reimpresión
                        // Por ejemplo: ImprimirOrden(idOrden);
                        ExcelHelper.GenerarReporteDesdePlantilla(idOrden, @"Excel\\Plantilla\\SalesOrderImportTemplate.xlsx", @"Excel\\Salidas\\SalesOrderImportTemplate_" + idOrden + ".xlsx");

                        // Cerrar el formulario al terminar
                        processingDialog.Invoke(new Action(() => processingDialog.Close()));

                        // Mostrar mensaje de éxito
                        MessageBox.Show($"Orden con ID {idOrden} generada correctamente.",
                                        "Éxito",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        processingDialog.Invoke(new Action(() => processingDialog.Close()));

                        // Mostrar mensaje de error
                        MessageBox.Show($"Error al reimprimir la orden: {ex.Message}",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                });

                // Mostrar el formulario como modal
                processingDialog.ShowDialog();
            }
        }


    }
}
