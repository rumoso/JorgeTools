using JorgeTools.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JorgeTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            dbManager.InitializeDatabase();
            InitializeComponent();
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

        private void clieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clientes Cli = new Clientes();
                this.Visible = false;
                Cli.ShowDialog();
                this.Visible = true;
            }
            catch (Exception)
            {
            }
            
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos Prod = new Productos();
            this.Visible = false;
            Prod.ShowDialog();
            this.Visible = true;
        }

        private void ordenesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ordenes Ord = new Ordenes();
            this.Visible = false;
            Ord.ShowDialog();
            this.Visible = true;
        }
    }
}
