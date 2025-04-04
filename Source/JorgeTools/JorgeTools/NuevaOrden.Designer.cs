namespace JorgeTools
{
    partial class NuevaOrden
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxCustomerReference = new System.Windows.Forms.TextBox();
            this.cbxNombreCliente = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxCodigoCliente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxDivision = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxSalesOrganization = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxSalesOrderType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgOrdDetalle = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.tbxPlan = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbxQtyUnit = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbxRequestQuantity = new System.Windows.Forms.TextBox();
            this.cbxNombreProd = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxCodigoProd = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOrdDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbxCustomerReference);
            this.groupBox1.Controls.Add(this.cbxNombreCliente);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbxCodigoCliente);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbxDivision);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxSalesOrganization);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxSalesOrderType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(934, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encabezado";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(728, 37);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 118;
            this.label8.Text = "Customer Reference:";
            // 
            // tbxCustomerReference
            // 
            this.tbxCustomerReference.Location = new System.Drawing.Point(731, 57);
            this.tbxCustomerReference.Name = "tbxCustomerReference";
            this.tbxCustomerReference.Size = new System.Drawing.Size(188, 20);
            this.tbxCustomerReference.TabIndex = 117;
            this.tbxCustomerReference.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxCustomerReference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCustomerReference_KeyDown);
            // 
            // cbxNombreCliente
            // 
            this.cbxNombreCliente.FormattingEnabled = true;
            this.cbxNombreCliente.Location = new System.Drawing.Point(230, 57);
            this.cbxNombreCliente.Name = "cbxNombreCliente";
            this.cbxNombreCliente.Size = new System.Drawing.Size(495, 21);
            this.cbxNombreCliente.TabIndex = 112;
            this.cbxNombreCliente.SelectionChangeCommitted += new System.EventHandler(this.cbxNombreCliente_SelectionChangeCommitted);
            this.cbxNombreCliente.TextUpdate += new System.EventHandler(this.cbxNombreCliente_TextUpdate);
            this.cbxNombreCliente.Enter += new System.EventHandler(this.cbxNombreCliente_Enter);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(211, 60);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 13);
            this.label15.TabIndex = 115;
            this.label15.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 37);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 116;
            this.label5.Text = "Nombre:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 37);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 114;
            this.label6.Text = "Código:";
            // 
            // tbxCodigoCliente
            // 
            this.tbxCodigoCliente.Location = new System.Drawing.Point(62, 57);
            this.tbxCodigoCliente.Name = "tbxCodigoCliente";
            this.tbxCodigoCliente.Size = new System.Drawing.Size(139, 20);
            this.tbxCodigoCliente.TabIndex = 110;
            this.tbxCodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxCodigoCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCodigoCliente_KeyDown);
            this.tbxCodigoCliente.Leave += new System.EventHandler(this.tbxCodigoCliente_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 60);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 113;
            this.label7.Text = "Cliente:";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(719, 13);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 7;
            this.dtpDate.Value = new System.DateTime(2025, 1, 5, 17, 59, 8, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(584, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Requested Delivery Date:";
            // 
            // tbxDivision
            // 
            this.tbxDivision.Location = new System.Drawing.Point(478, 13);
            this.tbxDivision.Name = "tbxDivision";
            this.tbxDivision.Size = new System.Drawing.Size(100, 20);
            this.tbxDivision.TabIndex = 5;
            this.tbxDivision.Text = "04";
            this.tbxDivision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(425, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Division:";
            // 
            // tbxSalesOrganization
            // 
            this.tbxSalesOrganization.Location = new System.Drawing.Point(315, 13);
            this.tbxSalesOrganization.Name = "tbxSalesOrganization";
            this.tbxSalesOrganization.Size = new System.Drawing.Size(100, 20);
            this.tbxSalesOrganization.TabIndex = 3;
            this.tbxSalesOrganization.Text = "553M";
            this.tbxSalesOrganization.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sales Organization:";
            // 
            // tbxSalesOrderType
            // 
            this.tbxSalesOrderType.Location = new System.Drawing.Point(101, 13);
            this.tbxSalesOrderType.Name = "tbxSalesOrderType";
            this.tbxSalesOrderType.Size = new System.Drawing.Size(100, 20);
            this.tbxSalesOrderType.TabIndex = 1;
            this.tbxSalesOrderType.Text = "OR";
            this.tbxSalesOrderType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sales Order Type";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgOrdDetalle);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.tbxPlan);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.tbxQtyUnit);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.tbxRequestQuantity);
            this.groupBox2.Controls.Add(this.cbxNombreProd);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tbxCodigoProd);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(12, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(934, 341);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Productos";
            // 
            // dtgOrdDetalle
            // 
            this.dtgOrdDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgOrdDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dtgOrdDetalle.Location = new System.Drawing.Point(10, 96);
            this.dtgOrdDetalle.Name = "dtgOrdDetalle";
            this.dtgOrdDetalle.Size = new System.Drawing.Size(909, 229);
            this.dtgOrdDetalle.TabIndex = 128;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Item";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Product";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Código BAAN";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Prod Name";
            this.Column4.Name = "Column4";
            this.Column4.Width = 250;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Req Quantity";
            this.Column5.Name = "Column5";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(587, 68);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 127;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // tbxPlan
            // 
            this.tbxPlan.Location = new System.Drawing.Point(481, 70);
            this.tbxPlan.Name = "tbxPlan";
            this.tbxPlan.Size = new System.Drawing.Size(100, 20);
            this.tbxPlan.TabIndex = 126;
            this.tbxPlan.Text = "3019";
            this.tbxPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(444, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 13);
            this.label16.TabIndex = 125;
            this.label16.Text = "Plant";
            // 
            // tbxQtyUnit
            // 
            this.tbxQtyUnit.Location = new System.Drawing.Point(333, 70);
            this.tbxQtyUnit.Name = "tbxQtyUnit";
            this.tbxQtyUnit.Size = new System.Drawing.Size(100, 20);
            this.tbxQtyUnit.TabIndex = 124;
            this.tbxQtyUnit.Text = "CAR";
            this.tbxQtyUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(223, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 13);
            this.label14.TabIndex = 123;
            this.label14.Text = "Requested Qty Unit:";
            // 
            // tbxRequestQuantity
            // 
            this.tbxRequestQuantity.Location = new System.Drawing.Point(117, 70);
            this.tbxRequestQuantity.Name = "tbxRequestQuantity";
            this.tbxRequestQuantity.Size = new System.Drawing.Size(100, 20);
            this.tbxRequestQuantity.TabIndex = 120;
            this.tbxRequestQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxRequestQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxRequestQuantity_KeyDown);
            this.tbxRequestQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxRequestQuantity_KeyPress);
            // 
            // cbxNombreProd
            // 
            this.cbxNombreProd.FormattingEnabled = true;
            this.cbxNombreProd.Location = new System.Drawing.Point(230, 41);
            this.cbxNombreProd.Name = "cbxNombreProd";
            this.cbxNombreProd.Size = new System.Drawing.Size(689, 21);
            this.cbxNombreProd.TabIndex = 118;
            this.cbxNombreProd.SelectionChangeCommitted += new System.EventHandler(this.cbxNombreProd_SelectionChangeCommitted);
            this.cbxNombreProd.TextUpdate += new System.EventHandler(this.cbxNombreProd_TextUpdate);
            this.cbxNombreProd.Enter += new System.EventHandler(this.cbxNombreProd_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 13);
            this.label13.TabIndex = 119;
            this.label13.Text = "Requested Quantity:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(211, 44);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 13);
            this.label9.TabIndex = 121;
            this.label9.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(227, 21);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 122;
            this.label10.Text = "Nombre:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(59, 21);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 120;
            this.label11.Text = "Código:";
            // 
            // tbxCodigoProd
            // 
            this.tbxCodigoProd.Location = new System.Drawing.Point(62, 41);
            this.tbxCodigoProd.Name = "tbxCodigoProd";
            this.tbxCodigoProd.Size = new System.Drawing.Size(139, 20);
            this.tbxCodigoProd.TabIndex = 117;
            this.tbxCodigoProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxCodigoProd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCodigoProd_KeyDown);
            this.tbxCodigoProd.Leave += new System.EventHandler(this.tbxCodigoProd_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 44);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 119;
            this.label12.Text = "Producto:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(767, 469);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(179, 39);
            this.btnGuardar.TabIndex = 129;
            this.btnGuardar.Text = "[F5] Guardar Orden";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // NuevaOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 518);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "NuevaOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NuevaOrden";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOrdDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxDivision;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxSalesOrganization;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxSalesOrderType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxNombreCliente;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxCodigoCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxCustomerReference;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbxNombreProd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxCodigoProd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbxRequestQuantity;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dtgOrdDetalle;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox tbxPlan;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbxQtyUnit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button btnGuardar;
    }
}