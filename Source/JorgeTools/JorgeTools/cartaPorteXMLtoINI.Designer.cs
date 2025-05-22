namespace JorgeTools
{
    partial class cartaPorteXMLtoINI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAbrir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbxCarpetaDestino = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnLimpiarGrid = new System.Windows.Forms.Button();
            this.dtgDatos = new System.Windows.Forms.DataGridView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.FolioFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialPeligroso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BienesTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClaveUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dimensiones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PesoEnKG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorMercancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moneda1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rfcReceptor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreReceptor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciounitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ieps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(1218, 23);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(41, 23);
            this.btnAbrir.TabIndex = 7;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1180, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxCarpetaDestino
            // 
            this.tbxCarpetaDestino.Location = new System.Drawing.Point(12, 23);
            this.tbxCarpetaDestino.Name = "tbxCarpetaDestino";
            this.tbxCarpetaDestino.Size = new System.Drawing.Size(1162, 20);
            this.tbxCarpetaDestino.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Selecciona la carpeta destino";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 49);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(158, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Seleccionar facturas";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(176, 49);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(158, 23);
            this.btnGenerar.TabIndex = 9;
            this.btnGenerar.Text = "Generar archivo .ini";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnLimpiarGrid
            // 
            this.btnLimpiarGrid.Location = new System.Drawing.Point(720, 51);
            this.btnLimpiarGrid.Name = "btnLimpiarGrid";
            this.btnLimpiarGrid.Size = new System.Drawing.Size(158, 23);
            this.btnLimpiarGrid.TabIndex = 10;
            this.btnLimpiarGrid.Text = "Limpiar tabla";
            this.btnLimpiarGrid.UseVisualStyleBackColor = true;
            this.btnLimpiarGrid.Click += new System.EventHandler(this.btnLimpiarGrid_Click);
            // 
            // dtgDatos
            // 
            this.dtgDatos.AllowUserToAddRows = false;
            this.dtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FolioFact,
            this.UUID,
            this.IDOrigen,
            this.IDDestino,
            this.TransCantidad,
            this.MaterialPeligroso,
            this.BienesTrans,
            this.Descripcion,
            this.cantidad,
            this.ClaveUnidad,
            this.Unidad,
            this.Dimensiones,
            this.PesoEnKG,
            this.ValorMercancia,
            this.Moneda1,
            this.rfcReceptor,
            this.nombreReceptor,
            this.fecha,
            this.preciounitario,
            this.importe,
            this.descuento,
            this.iva,
            this.ieps,
            this.serie});
            this.dtgDatos.Location = new System.Drawing.Point(12, 80);
            this.dtgDatos.Name = "dtgDatos";
            this.dtgDatos.Size = new System.Drawing.Size(1261, 555);
            this.dtgDatos.TabIndex = 11;
            this.dtgDatos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDatos_CellEndEdit);
            this.dtgDatos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgDatos_KeyDown);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(340, 49);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(158, 23);
            this.btnExcel.TabIndex = 12;
            this.btnExcel.Text = "Generar Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // FolioFact
            // 
            this.FolioFact.HeaderText = "FolioFact";
            this.FolioFact.Name = "FolioFact";
            this.FolioFact.ReadOnly = true;
            // 
            // UUID
            // 
            this.UUID.HeaderText = "UUID";
            this.UUID.Name = "UUID";
            this.UUID.ReadOnly = true;
            this.UUID.Visible = false;
            // 
            // IDOrigen
            // 
            this.IDOrigen.HeaderText = "IDOrigen";
            this.IDOrigen.Name = "IDOrigen";
            this.IDOrigen.ReadOnly = true;
            this.IDOrigen.Width = 70;
            // 
            // IDDestino
            // 
            this.IDDestino.HeaderText = "IDDestino";
            this.IDDestino.Name = "IDDestino";
            this.IDDestino.Width = 70;
            // 
            // TransCantidad
            // 
            this.TransCantidad.HeaderText = "Cantidad a transportar";
            this.TransCantidad.Name = "TransCantidad";
            this.TransCantidad.Width = 70;
            // 
            // MaterialPeligroso
            // 
            this.MaterialPeligroso.HeaderText = "MaterialPeligroso";
            this.MaterialPeligroso.Name = "MaterialPeligroso";
            this.MaterialPeligroso.Width = 70;
            // 
            // BienesTrans
            // 
            this.BienesTrans.HeaderText = "BienesTrans";
            this.BienesTrans.Name = "BienesTrans";
            this.BienesTrans.ReadOnly = true;
            this.BienesTrans.Width = 70;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 150;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 70;
            // 
            // ClaveUnidad
            // 
            this.ClaveUnidad.HeaderText = "ClaveUnidad";
            this.ClaveUnidad.Name = "ClaveUnidad";
            this.ClaveUnidad.ReadOnly = true;
            this.ClaveUnidad.Width = 70;
            // 
            // Unidad
            // 
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.ReadOnly = true;
            this.Unidad.Width = 50;
            // 
            // Dimensiones
            // 
            this.Dimensiones.HeaderText = "Dimensiones";
            this.Dimensiones.Name = "Dimensiones";
            // 
            // PesoEnKG
            // 
            this.PesoEnKG.HeaderText = "PesoEnKG";
            this.PesoEnKG.Name = "PesoEnKG";
            // 
            // ValorMercancia
            // 
            this.ValorMercancia.HeaderText = "ValorMercancia";
            this.ValorMercancia.Name = "ValorMercancia";
            this.ValorMercancia.ReadOnly = true;
            // 
            // Moneda1
            // 
            this.Moneda1.HeaderText = "Moneda";
            this.Moneda1.Name = "Moneda1";
            this.Moneda1.ReadOnly = true;
            // 
            // rfcReceptor
            // 
            this.rfcReceptor.HeaderText = "rfcReceptor";
            this.rfcReceptor.Name = "rfcReceptor";
            this.rfcReceptor.ReadOnly = true;
            this.rfcReceptor.Visible = false;
            // 
            // nombreReceptor
            // 
            this.nombreReceptor.HeaderText = "nombreReceptor";
            this.nombreReceptor.Name = "nombreReceptor";
            this.nombreReceptor.ReadOnly = true;
            this.nombreReceptor.Visible = false;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Visible = false;
            // 
            // preciounitario
            // 
            this.preciounitario.HeaderText = "preciounitario";
            this.preciounitario.Name = "preciounitario";
            this.preciounitario.ReadOnly = true;
            this.preciounitario.Visible = false;
            // 
            // importe
            // 
            this.importe.HeaderText = "importe";
            this.importe.Name = "importe";
            this.importe.ReadOnly = true;
            this.importe.Visible = false;
            // 
            // descuento
            // 
            this.descuento.HeaderText = "descuento";
            this.descuento.Name = "descuento";
            this.descuento.ReadOnly = true;
            this.descuento.Visible = false;
            // 
            // iva
            // 
            this.iva.HeaderText = "iva";
            this.iva.Name = "iva";
            this.iva.ReadOnly = true;
            this.iva.Visible = false;
            // 
            // ieps
            // 
            this.ieps.HeaderText = "ieps";
            this.ieps.Name = "ieps";
            this.ieps.ReadOnly = true;
            this.ieps.Visible = false;
            // 
            // serie
            // 
            this.serie.HeaderText = "serie";
            this.serie.Name = "serie";
            this.serie.ReadOnly = true;
            this.serie.Visible = false;
            // 
            // cartaPorteXMLtoINI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 650);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.dtgDatos);
            this.Controls.Add(this.btnLimpiarGrid);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxCarpetaDestino);
            this.Controls.Add(this.label1);
            this.Name = "cartaPorteXMLtoINI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "cartaPorteXMLtoINI";
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbxCarpetaDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnLimpiarGrid;
        private System.Windows.Forms.DataGridView dtgDatos;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn FolioFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn UUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialPeligroso;
        private System.Windows.Forms.DataGridViewTextBoxColumn BienesTrans;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaveUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dimensiones;
        private System.Windows.Forms.DataGridViewTextBoxColumn PesoEnKG;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorMercancia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rfcReceptor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreReceptor;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn preciounitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn iva;
        private System.Windows.Forms.DataGridViewTextBoxColumn ieps;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie;
    }
}