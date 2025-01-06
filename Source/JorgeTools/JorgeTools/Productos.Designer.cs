namespace JorgeTools
{
    partial class Productos
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgDatos = new System.Windows.Forms.DataGridView();
            this.tbxFiltro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.tbxRutaExcel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscarRutaExcel = new System.Windows.Forms.Button();
            this.lblProcess = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblResultSearch = new System.Windows.Forms.Label();
            this.pgbProceso = new System.Windows.Forms.ProgressBar();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblResultSearch);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.dtgDatos);
            this.groupBox2.Controls.Add(this.tbxFiltro);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 412);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clientes Cargados";
            // 
            // dtgDatos
            // 
            this.dtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatos.Location = new System.Drawing.Point(6, 83);
            this.dtgDatos.Name = "dtgDatos";
            this.dtgDatos.Size = new System.Drawing.Size(761, 347);
            this.dtgDatos.TabIndex = 4;
            // 
            // tbxFiltro
            // 
            this.tbxFiltro.Location = new System.Drawing.Point(6, 32);
            this.tbxFiltro.Name = "tbxFiltro";
            this.tbxFiltro.Size = new System.Drawing.Size(761, 20);
            this.tbxFiltro.TabIndex = 3;
            this.tbxFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxFiltro_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(442, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Filtro: SE PUEDE FILTRAR POR CUALQUIER DATO Y PRESIONAR ENTER:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pgbProceso);
            this.groupBox1.Controls.Add(this.lblProcess);
            this.groupBox1.Controls.Add(this.btnBuscarRutaExcel);
            this.groupBox1.Controls.Add(this.btnCargar);
            this.groupBox1.Controls.Add(this.tbxRutaExcel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 124);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Carga de excel";
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(9, 58);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(75, 23);
            this.btnCargar.TabIndex = 2;
            this.btnCargar.Text = "Cargar Excel";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // tbxRutaExcel
            // 
            this.tbxRutaExcel.Location = new System.Drawing.Point(9, 32);
            this.tbxRutaExcel.Name = "tbxRutaExcel";
            this.tbxRutaExcel.Size = new System.Drawing.Size(705, 20);
            this.tbxRutaExcel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(477, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ruta del excel a cargar: ASEGURARSE DE SELECCIONAR EL EXCEL CORRECTO";
            // 
            // btnBuscarRutaExcel
            // 
            this.btnBuscarRutaExcel.Location = new System.Drawing.Point(720, 32);
            this.btnBuscarRutaExcel.Name = "btnBuscarRutaExcel";
            this.btnBuscarRutaExcel.Size = new System.Drawing.Size(47, 23);
            this.btnBuscarRutaExcel.TabIndex = 3;
            this.btnBuscarRutaExcel.Text = "...";
            this.btnBuscarRutaExcel.UseVisualStyleBackColor = true;
            this.btnBuscarRutaExcel.Click += new System.EventHandler(this.btnBuscarRutaExcel_Click);
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcess.Location = new System.Drawing.Point(90, 63);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(29, 20);
            this.lblProcess.TabIndex = 4;
            this.lblProcess.Text = "....";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(6, 58);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(298, 23);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblResultSearch
            // 
            this.lblResultSearch.AutoSize = true;
            this.lblResultSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultSearch.Location = new System.Drawing.Point(310, 60);
            this.lblResultSearch.Name = "lblResultSearch";
            this.lblResultSearch.Size = new System.Drawing.Size(29, 20);
            this.lblResultSearch.TabIndex = 5;
            this.lblResultSearch.Text = "....";
            // 
            // pgbProceso
            // 
            this.pgbProceso.Location = new System.Drawing.Point(9, 86);
            this.pgbProceso.Name = "pgbProceso";
            this.pgbProceso.Size = new System.Drawing.Size(758, 23);
            this.pgbProceso.TabIndex = 5;
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 567);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Productos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgDatos;
        private System.Windows.Forms.TextBox tbxFiltro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.TextBox tbxRutaExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscarRutaExcel;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.Label lblResultSearch;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ProgressBar pgbProceso;
    }
}