using DocumentFormat.OpenXml.Office2010.Excel;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JorgeTools
{
    public partial class NuevaOrden : Form
    {
        bool inicia = true;
        long idOrden = 0;
        Orden _orden = new Orden();
        OrdDetalle _ordDetalle = new OrdDetalle();
        List<cbxProductos> _productsList = new List<cbxProductos>();
        List<cbxClientes> _clientsList = new List<cbxClientes>();
        public NuevaOrden()
        {
            InitializeComponent();
            ObtenerClientesParaComboBox();
            ObtenerProdParaComboBox();
            inicia = false;
            _orden.ordDetalle = new List<Clases.OrdDetalle>();
            cbxNombreCliente.Focus();
            dtpDate.Value = DateTime.Now;
            cbxNombreCliente.DropDownStyle = ComboBoxStyle.DropDown;
            cbxNombreProd.DropDownStyle = ComboBoxStyle.DropDown;
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

                    GuardarOrden(_orden);

                    break;

                case Keys.F6:

                    break;

                case Keys.Escape:
                    this.Close();
                    break;

            }
            return bHandled;
        }

        public void ObtenerClientesParaComboBox()
        {
            try
            {
                // Conexión a la base de datos SQLite
                var connection = dbManager.GetConnection();
                connection.Open();

                // Consulta SQL para obtener los clientes
                string query = @"SELECT source_id, name_org1, name_org2, name_org3, name_org4 FROM Clientes;";

                // Crear el comando SQLite
                using (var command = new SQLiteCommand(query, connection))
                {
                    // Crear un adaptador para llenar un DataTable con los datos obtenidos
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable OData = new DataTable();
                        adapter.Fill(OData);

                        for (int i = 0; i < OData.Rows.Count; i++)
                        {
                            var source_id = OData.Rows[i]["source_id"].ToString();
                            var name_org1 = OData.Rows[i]["name_org1"].ToString();
                            _clientsList.Add(new cbxClientes() { source_id = source_id, name_org1 = name_org1 });
                        }

                        cbxNombreCliente.Items.AddRange(_clientsList.ToArray());
                        cbxNombreCliente.DisplayMember = "name_org1";
                        cbxNombreCliente.ValueMember = "source_id";
                        cbxNombreCliente.Focus();
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void ObtenerProdParaComboBox()
        {
            try
            {
                // Conexión a la base de datos SQLite
                var connection = dbManager.GetConnection();
                connection.Open();

                // Consulta SQL para obtener los clientes
                string query = @"SELECT codigoSap, descriptionSAP FROM Productos;";

                // Crear el comando SQLite
                using (var command = new SQLiteCommand(query, connection))
                {
                    // Crear un adaptador para llenar un DataTable con los datos obtenidos
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable OData = new DataTable();
                        adapter.Fill(OData);

                        for (int i = 0; i < OData.Rows.Count; i++)
                        {
                            var codigoSap = OData.Rows[i]["codigoSap"].ToString();
                            var descriptionSAP = OData.Rows[i]["descriptionSAP"].ToString();
                            _productsList.Add(new cbxProductos() { codigoSap = codigoSap, descriptionSAP = descriptionSAP });
                        }

                        cbxNombreProd.Items.AddRange(_productsList.ToArray());
                        cbxNombreProd.DisplayMember = "descriptionSAP";
                        cbxNombreProd.ValueMember = "codigoSap";
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void ObtenerCliente(string sCodigo)
        {
            if (sCodigo != "")
            {
                // Conexión a la base de datos SQLite
                var connection = dbManager.GetConnection();
                connection.Open();

                // Consulta SQL para obtener los clientes
                string query = $"SELECT source_id, name_org1, name_org2, name_org3, name_org4 FROM Clientes" +
                    $" WHERE source_id LIKE '%{sCodigo}%';";

                // Crear el comando SQLite
                using (var command = new SQLiteCommand(query, connection))
                {
                    // Crear un adaptador para llenar un DataTable con los datos obtenidos
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            tbxCodigoCliente.Text = dt.Rows[0][0].ToString();
                            cbxNombreCliente.Text = dt.Rows[0][1].ToString();

                            _orden.shipToParty = dt.Rows[0][0].ToString();
                            tbxCustomerReference.Focus();
                        }
                        else
                        {
                            tbxCodigoCliente.Text = "";
                            cbxNombreCliente.Text = "";
                        }
                    }
                }
                connection.Close();
            }
            else
            {
                tbxCodigoCliente.Text = "";
                cbxNombreCliente.Text = "";
            }
        }

        public void ObtenerProdByID(string sCodigo)
        {
            if (sCodigo != "")
            {
                // Conexión a la base de datos SQLite
                var connection = dbManager.GetConnection();
                connection.Open();

                // Consulta SQL para obtener los clientes
                string query = $"SELECT Id, codigoBan, codigoSap, descriptionSAP FROM Productos" +
                    $" WHERE codigoSap LIKE '%{sCodigo}%';";

                // Crear el comando SQLite
                using (var command = new SQLiteCommand(query, connection))
                {
                    // Crear un adaptador para llenar un DataTable con los datos obtenidos
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            var codigoBan = dt.Rows[0][1].ToString();
                            var codigoSap = dt.Rows[0][2].ToString();
                            var descriptionSAP = dt.Rows[0][3].ToString();

                            tbxCodigoProd.Text = dt.Rows[0][2].ToString();
                            cbxNombreProd.Text = dt.Rows[0][3].ToString();

                            _ordDetalle.itemID = "0" + (_orden.ordDetalle.Count + 1);
                            _ordDetalle.product_CodigoSap = codigoSap;
                            _ordDetalle.product_CodigoBan = codigoBan;
                            _ordDetalle.descriptionSAP = descriptionSAP;

                            tbxRequestQuantity.Focus();
                        }
                        else
                        {
                            tbxCodigoCliente.Text = "";
                            cbxNombreCliente.Text = "";
                        }
                    }
                }
                connection.Close();
            }
            else
            {
                tbxCodigoCliente.Text = "";
                cbxNombreCliente.Text = "";
            }
        }

        private void tbxCodigoCliente_Leave(object sender, EventArgs e)
        {
            ObtenerCliente(tbxCodigoCliente.Text);
        }

        private void tbxCustomerReference_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxNombreProd.Focus();
            }
        }

        private void tbxRequestQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAgregar.Focus();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(
                tbxCodigoProd.Text != ""
                && cbxNombreProd.Text != ""
                && Convert.ToInt32( ( string.IsNullOrEmpty(tbxRequestQuantity.Text) ? "0" : tbxRequestQuantity.Text) ) > 0
                && tbxQtyUnit.Text != ""
                && tbxPlan.Text != "")
            {
                _ordDetalle.requested_quantity = tbxRequestQuantity.Text;
                _ordDetalle.requested_QtyUnit = tbxQtyUnit.Text;

                _orden.salesOrganization = tbxSalesOrganization.Text;
                _orden.division = tbxDivision.Text;

                _orden.customerReference = tbxCustomerReference.Text;
                _orden.requestDeliveryDate = dtpDate.Value.ToString("yyyyMMdd");
                _orden.plant = tbxPlan.Text;

                dtgOrdDetalle.Rows.Add(
                        _ordDetalle.itemID
                        , _ordDetalle.product_CodigoSap
                        , _ordDetalle.product_CodigoBan
                        , _ordDetalle.descriptionSAP
                        , _ordDetalle.requested_quantity
                        );

                _orden.ordDetalle.Add(_ordDetalle);

                _ordDetalle = new OrdDetalle();

                tbxCodigoProd.Text = "";
                cbxNombreProd.Text = "";
                tbxRequestQuantity.Text = "";
                cbxNombreProd.Focus();
            }
            else
            {
                MessageBox.Show("Algun dato está vacío");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarOrden(_orden);
        }

        public void GuardarOrden(Orden orden)
        {
            if(idOrden == 0)
            {
                var connection = dbManager.GetConnection();
                connection.Open();

                // Iniciar una transacción para asegurar la atomicidad
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insertar el encabezado de la orden
                        string insertOrdenQuery = @"
                        INSERT INTO Ordenes (salesOrganization, division, shipToParty, customerReference, requestDeliveryDate, plant)
                        VALUES (@salesOrganization, @division, @shipToParty, @customerReference, @requestDeliveryDate, @plant);
                    ";

                        using (var command = new SQLiteCommand(insertOrdenQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@salesOrganization", orden.salesOrganization);
                            command.Parameters.AddWithValue("@division", orden.division);
                            command.Parameters.AddWithValue("@shipToParty", orden.shipToParty);
                            command.Parameters.AddWithValue("@customerReference", orden.customerReference);
                            command.Parameters.AddWithValue("@requestDeliveryDate", orden.requestDeliveryDate);
                            command.Parameters.AddWithValue("@plant", orden.plant);

                            command.ExecuteNonQuery();
                        }

                        // Obtener el ID generado para la orden
                        long ordenId;
                        using (var command = new SQLiteCommand("SELECT last_insert_rowid();", connection, transaction))
                        {
                            idOrden = ordenId = (long)command.ExecuteScalar();
                        }

                        // Insertar los detalles de la orden
                        string insertOrdenDetalleQuery = @"
                        INSERT INTO OrdenDetalles (OrdenId, itemID, product_CodigoSap, product_CodigoBan, requested_quantity, requested_QtyUnit)
                        VALUES (@OrdenId, @itemID, @product_CodigoSap, @product_CodigoBan, @requested_quantity, @requested_QtyUnit);
                    ";

                        foreach (var detalle in orden.ordDetalle)
                        {
                            using (var command = new SQLiteCommand(insertOrdenDetalleQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@OrdenId", ordenId);
                                command.Parameters.AddWithValue("@itemID", detalle.itemID);
                                command.Parameters.AddWithValue("@product_CodigoSap", detalle.product_CodigoSap);
                                command.Parameters.AddWithValue("@product_CodigoBan", detalle.product_CodigoBan);
                                command.Parameters.AddWithValue("@requested_quantity", detalle.requested_quantity);
                                command.Parameters.AddWithValue("@requested_QtyUnit", detalle.requested_QtyUnit);

                                command.ExecuteNonQuery();
                            }
                        }

                        // Confirmar la transacción
                        transaction.Commit();
                        MessageBox.Show("Orden generada con éxito");
                        ReimprimirOrden(ordenId);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        // Revertir la transacción en caso de error
                        transaction.Rollback();
                        throw new Exception("Error al guardar la orden y sus detalles: " + ex.Message);
                    }
                }

                connection.Close();
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

        private void tbxCodigoProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ObtenerProdByID(tbxCodigoProd.Text);
            }
        }

        private void tbxCodigoProd_Leave(object sender, EventArgs e)
        {
            ObtenerProdByID(tbxCodigoProd.Text);
        }

        private void tbxCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ObtenerCliente(tbxCodigoCliente.Text);
            }
        }

        private void tbxRequestQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada no es un número y no es la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true; // Cancela la tecla presionada
            }
        }

        private void cbxNombreProd_TextUpdate(object sender, EventArgs e)
        {
            // Texto ingresado por el usuario
            string searchText = cbxNombreProd.Text.ToLower();

            //if (string.IsNullOrEmpty(searchText))
            //{
                cbxNombreProd.Items.Clear();
                    var filteredProductos = _productsList
                .Where(p => p.codigoSap.ToLower().Contains(searchText) ||
                            p.descriptionSAP.ToLower().Contains(searchText))
                .ToList();
                cbxNombreProd.Items.AddRange(filteredProductos.ToArray());
            //}

            if (!string.IsNullOrEmpty(cbxNombreProd.Text))
            {
                

                // Desactivar eventos para evitar comportamientos extraños
                cbxNombreProd.TextUpdate -= cbxNombreProd_TextUpdate;

                // Filtrar productos directamente en los ítems del ComboBox
                for (int i = 0; i < cbxNombreProd.Items.Count; i++)
                {
                    var producto = cbxNombreProd.Items[i] as cbxProductos;
                    if (producto != null)
                    {
                        // Mostrar solo los que coinciden
                        if (producto.codigoSap.ToLower().Contains(searchText) ||
                            producto.descriptionSAP.ToLower().Contains(searchText))
                        {
                            cbxNombreProd.Items[i] = producto; // Mostrar
                        }
                        else
                        {
                            cbxNombreProd.Items.Remove(producto); // Ocultar
                            i--; // Ajustar índice por remoción
                        }
                    }
                }

                // Restaurar el texto ingresado
                cbxNombreProd.Text = searchText;
                cbxNombreProd.SelectionStart = searchText.Length;

                // Mantener el combo desplegado
                cbxNombreProd.DroppedDown = true;

                // Reasignar el evento
                cbxNombreProd.TextUpdate += cbxNombreProd_TextUpdate;
            }
        }

        private void cbxNombreProd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!inicia && cbxNombreProd.Items.Count > 0 && cbxNombreProd.SelectedIndex > -1)
            {
                cbxProductos selectedProduct = cbxNombreProd.SelectedItem as cbxProductos;
                var id = selectedProduct.codigoSap;
                ObtenerProdByID(id);
            }
        }

       

        private void cbxNombreProd_Enter(object sender, EventArgs e)
        {
            cbxNombreProd.DroppedDown = true;
        }

        private void cbxNombreCliente_TextUpdate(object sender, EventArgs e)
        {
            // Texto ingresado por el usuario
            string searchText = cbxNombreCliente.Text.ToLower();

            cbxNombreCliente.Items.Clear();
            var filteredClientes = _clientsList
            .Where(p => p.source_id.ToLower().Contains(searchText) ||
                        p.name_org1.ToLower().Contains(searchText))
            .ToList();
            cbxNombreCliente.Items.AddRange(filteredClientes.ToArray());

            if (!string.IsNullOrEmpty(cbxNombreCliente.Text))
            {


                // Desactivar eventos para evitar comportamientos extraños
                cbxNombreCliente.TextUpdate -= cbxNombreCliente_TextUpdate;

                // Filtrar productos directamente en los ítems del ComboBox
                for (int i = 0; i < cbxNombreCliente.Items.Count; i++)
                {
                    var cliente = cbxNombreCliente.Items[i] as cbxClientes;
                    if (cliente != null)
                    {
                        // Mostrar solo los que coinciden
                        if (cliente.source_id.ToLower().Contains(searchText) ||
                            cliente.name_org1.ToLower().Contains(searchText))
                        {
                            cbxNombreCliente.Items[i] = cliente; // Mostrar
                        }
                        else
                        {
                            cbxNombreCliente.Items.Remove(cliente); // Ocultar
                            i--; // Ajustar índice por remoción
                        }
                    }
                }

                // Restaurar el texto ingresado
                cbxNombreCliente.Text = searchText;
                cbxNombreCliente.SelectionStart = searchText.Length;

                // Mantener el combo desplegado
                cbxNombreCliente.DroppedDown = true;

                // Reasignar el evento
                cbxNombreCliente.TextUpdate += cbxNombreCliente_TextUpdate;
            }
        }

        private void cbxNombreCliente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!inicia && cbxNombreCliente.Items.Count > 0 && cbxNombreCliente.SelectedIndex > -1)
            {
                cbxClientes selected = cbxNombreCliente.SelectedItem as cbxClientes;
                var id = selected.source_id;
                ObtenerCliente(id);
            }
        }

        private void cbxNombreCliente_Enter(object sender, EventArgs e)
        {
            cbxNombreCliente.DroppedDown = true;
        }
    }
}
