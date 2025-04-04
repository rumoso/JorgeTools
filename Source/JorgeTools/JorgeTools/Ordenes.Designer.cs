namespace JorgeTools
{
    partial class Ordenes
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNewOrden = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.rdbLimit = new System.Windows.Forms.RadioButton();
            this.lblResultSearch = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtgDatos = new System.Windows.Forms.DataGridView();
            this.tbxFiltro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNewOrden);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 54);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones";
            // 
            // btnNewOrden
            // 
            this.btnNewOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewOrden.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNewOrden.Location = new System.Drawing.Point(6, 19);
            this.btnNewOrden.Name = "btnNewOrden";
            this.btnNewOrden.Size = new System.Drawing.Size(140, 23);
            this.btnNewOrden.TabIndex = 0;
            this.btnNewOrden.Text = "[F1] Nueva orden";
            this.btnNewOrden.UseVisualStyleBackColor = true;
            this.btnNewOrden.Click += new System.EventHandler(this.btnNewOrden_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbAll);
            this.groupBox2.Controls.Add(this.rdbLimit);
            this.groupBox2.Controls.Add(this.lblResultSearch);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.dtgDatos);
            this.groupBox2.Controls.Add(this.tbxFiltro);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1096, 448);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ordenes";
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(1039, 64);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(50, 17);
            this.rdbAll.TabIndex = 14;
            this.rdbAll.Text = "Todo";
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // rdbLimit
            // 
            this.rdbLimit.AutoSize = true;
            this.rdbLimit.Checked = true;
            this.rdbLimit.Location = new System.Drawing.Point(966, 64);
            this.rdbLimit.Name = "rdbLimit";
            this.rdbLimit.Size = new System.Drawing.Size(73, 17);
            this.rdbLimit.TabIndex = 13;
            this.rdbLimit.TabStop = true;
            this.rdbLimit.Text = "Limite 100";
            this.rdbLimit.UseVisualStyleBackColor = true;
            // 
            // lblResultSearch
            // 
            this.lblResultSearch.AutoSize = true;
            this.lblResultSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultSearch.Location = new System.Drawing.Point(310, 66);
            this.lblResultSearch.Name = "lblResultSearch";
            this.lblResultSearch.Size = new System.Drawing.Size(29, 20);
            this.lblResultSearch.TabIndex = 11;
            this.lblResultSearch.Text = "....";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(6, 64);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(298, 23);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtgDatos
            // 
            this.dtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatos.Location = new System.Drawing.Point(6, 89);
            this.dtgDatos.Name = "dtgDatos";
            this.dtgDatos.Size = new System.Drawing.Size(1083, 347);
            this.dtgDatos.TabIndex = 10;
            this.dtgDatos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDatos_CellDoubleClick);
            // 
            // tbxFiltro
            // 
            this.tbxFiltro.Location = new System.Drawing.Point(6, 38);
            this.tbxFiltro.Name = "tbxFiltro";
            this.tbxFiltro.Size = new System.Drawing.Size(1083, 20);
            this.tbxFiltro.TabIndex = 9;
            this.tbxFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxFiltro_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(442, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Filtro: SE PUEDE FILTRAR POR CUALQUIER DATO Y PRESIONAR ENTER:";
            // 
            // Ordenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 532);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Ordenes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenes";
            this.Load += new System.EventHandler(this.Ordenes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNewOrden;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.RadioButton rdbLimit;
        private System.Windows.Forms.Label lblResultSearch;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dtgDatos;
        private System.Windows.Forms.TextBox tbxFiltro;
        private System.Windows.Forms.Label label2;
    }
}