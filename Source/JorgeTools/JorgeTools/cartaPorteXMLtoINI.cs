using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ClosedXML.Excel;
using JorgeTools.Clases;

namespace JorgeTools
{
    public partial class cartaPorteXMLtoINI : Form
    {
        public cartaPorteXMLtoINI()
        {
            InitializeComponent();
            oButtonsValida();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "Archivos XML (*.xml)|*.xml";
            openFileDialog1.Title = "Selecciona los archivos XML de facturas";
            OpenFileDialog openFileDialog2 = openFileDialog1;
            XNamespace xnamespace1 = (XNamespace)"http://www.sat.gob.mx/cfd/4";
            XNamespace xnamespace2 = (XNamespace)"http://www.sat.gob.mx/TimbreFiscalDigital";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                foreach (string fileName in openFileDialog2.FileNames)
                {
                    XDocument xdocument = XDocument.Load(fileName);
                    XElement xml1 = xdocument.Descendants(xnamespace1 + "Comprobante").Select<XElement, XElement>((Func<XElement, XElement>)(x => x)).FirstOrDefault<XElement>();
                    var campo = "Folio";
                    string attributeXml1 = getAttributeXML(xml1, campo);
                    string attributeXml2 = getAttributeXML(xdocument.Descendants(xnamespace2 + "TimbreFiscalDigital").Select<XElement, XElement>((Func<XElement, XElement>)(x => x)).FirstOrDefault<XElement>(), "UUID");
                    campo = "Moneda";
                    string attributeXml3 = getAttributeXML(xml1, campo);
                    campo = "Fecha";
                    string fecha = getAttributeXML(xml1, campo);

                    campo = "Serie";
                    string Serie = getAttributeXML(xml1, campo);

                    XElement xxmlReceptor = xdocument.Descendants(xnamespace1 + "Receptor").Select<XElement, XElement>((Func<XElement, XElement>)(x => x)).FirstOrDefault<XElement>();
                    campo = "Nombre";
                    var nombreReceptor = getAttributeXML(xxmlReceptor, campo);
                    campo = "Rfc";
                    var rfcReceptor = getAttributeXML(xxmlReceptor, campo);

                    foreach (XElement concepto in xdocument.Descendants(xnamespace1 + "Concepto").Select<XElement, XElement>((Func<XElement, XElement>)(x => x)).ToList<XElement>())
                    {
                        string campo3 = "ClaveProdServ";
                        string attributeXml4 = getAttributeXML(concepto, campo3);
                        string campo4 = "Descripcion";
                        string attributeXml5 = getAttributeXML(concepto, campo4);
                        string campo5 = "Cantidad";
                        string attributeXml6 = getAttributeXML(concepto, campo5);
                        string campo6 = "ClaveUnidad";
                        string attributeXml7 = getAttributeXML(concepto, campo6);
                        string campo7 = "Unidad";
                        string attributeXml8 = getAttributeXML(concepto, campo7);
                        string str1 = "";
                        string str2 = "";
                        string str3 = "";
                        string campo8 = "Importe";
                        string Importe = getAttributeXML(concepto, campo8);
                        string str4 = "OR000001";
                        string str5 = "DE000001";

                        campo = "ValorUnitario";
                        var ValorUnitario = getAttributeXML(concepto, campo);

                        campo = "Descuento";
                        var Descuento = getAttributeXML(concepto, campo);
                        Descuento = Descuento == "" ? "0" : Descuento;

                        var traslados = concepto
                        .Element(xnamespace1 + "Impuestos")?
                        .Element(xnamespace1 + "Traslados")?
                        .Elements(xnamespace1 + "Traslado");

                        var iva = "";
                        var ieps = "";

                        if (traslados != null)
                        {
                            foreach (var traslado in traslados)
                            {
                                if(traslado.Attribute("Impuesto")?.Value == "002")
                                {
                                    iva = getAttributeXML(traslado, "Importe");
                                }
                                else if (traslado.Attribute("Impuesto")?.Value == "003")
                                {
                                    ieps = getAttributeXML(traslado, "Importe"); ;
                                }
                            }
                        }


                        this.dtgDatos.Rows.Add(
                            attributeXml1
                            , attributeXml2
                            , str4
                            , str5
                            , attributeXml6
                            , str2
                            , attributeXml4
                            , attributeXml5
                            , attributeXml6
                            , attributeXml7
                            , attributeXml8
                            , str1
                            , str3
                            , Importe
                            , attributeXml3
                            , rfcReceptor
                            , nombreReceptor
                            , fecha
                            , ValorUnitario
                            , Importe
                            , Descuento
                            , iva
                            , ieps
                            , Serie
                            );
                    }
                }
                int num = (int)MessageBox.Show("Datos cargados en la tabla", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                int num1 = (int)MessageBox.Show("No se seleccionaron archivos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            oButtonsValida();
        }

        public static string getAttributeXML(XElement xml, string campo)
        {
            string attributeXml;
            try
            {
                attributeXml = xml.Attribute((XName)campo).Value;
            }
            catch
            {
                attributeXml = "";
            }
            return attributeXml;
        }

        public string ObtenerRutaArchivos()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            int num = (int)folderBrowserDialog.ShowDialog();
            return !(folderBrowserDialog.SelectedPath != "") ? "" : folderBrowserDialog.SelectedPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tbxCarpetaDestino.Text = this.ObtenerRutaArchivos();
            oButtonsValida();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(this.tbxCarpetaDestino.Text);
            }
            catch
            {
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string str1 = "[CartaPorte]\r\nVersion=3.0\r\n[Mercancia{iCount}]\r\nBienesTransp      ={BienesTransp}\r\nDescripcion       ={Descripcion}\r\nCantidad          ={Cantidad}\r\nClaveUnidad       ={ClaveUnidad}\r\nUnidad            ={Unidad}\r\nDimensiones       ={Dimensiones}\r\n{MaterialPeligrosoEtiqueta}PesoEnKg        ={PesoEnKg}\r\nValorMercancia  ={ValorMercancia}\r\nMoneda          ={Moneda}\r\n[Mercancia{iCount}.CantidadTransporta{iCount}]\r\nCantidad      ={CantidadTransporta}\r\nIDOrigen      ={IDOrigen}\r\nIDDestino     ={IDDestino}\r\n";
            string str2 = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            List<string> stringList = this.ObtenerFoliosUnicos(this.dtgDatos);
            for (int index = 0; index < stringList.Count; ++index)
            {
                string str3 = stringList[index];
                int num = 0;
                foreach (DataGridViewRow row in (IEnumerable)this.dtgDatos.Rows)
                {
                    if (!row.IsNewRow && row.Cells["FolioFact"].Value.ToString() == str3)
                    {
                        ++num;
                        empty3 = row.Cells["UUID"].Value.ToString();
                        string newValue1 = row.Cells["idOrigen"].Value.ToString();
                        string newValue2 = row.Cells["IDDestino"].Value.ToString();
                        string newValue3 = row.Cells["TransCantidad"].Value.ToString();
                        string str4 = row.Cells["MaterialPeligroso"].Value.ToString();
                        object obj = row.Cells["BienesTrans"].Value;
                        string str5 = row.Cells["Descripcion"].Value.ToString();
                        string str6 = row.Cells["cantidad"].Value.ToString();
                        string str7 = row.Cells["ClaveUnidad"].Value.ToString();
                        string str8 = row.Cells["Unidad"].Value.ToString();
                        string str9 = row.Cells["Dimensiones"].Value.ToString();
                        string str10 = row.Cells["PesoEnKG"].Value.ToString();
                        string newValue4 = row.Cells["ValorMercancia"].Value.ToString();
                        string newValue5 = row.Cells["Moneda1"].Value.ToString();
                        string str11 = str1.Replace("{iCount}", num.ToString()).Replace("{BienesTransp}", obj.ToString()).Replace("{Descripcion}", str5.ToString()).Replace("{Cantidad}", str6.ToString()).Replace("{ClaveUnidad}", str7.ToString()).Replace("{Unidad}", str8.ToString()).Replace("{Dimensiones}", str9.ToString());
                        string str12 = (str4.ToString().Length <= 0 ? str11.Replace("{MaterialPeligrosoEtiqueta}", "") : str11.Replace("{MaterialPeligrosoEtiqueta}", "MaterialPeligroso   ={MaterialPeligroso}\r\n").Replace("{MaterialPeligroso}", str4.ToString())).Replace("{PesoEnKg}", str10.ToString()).Replace("{ValorMercancia}", newValue4).Replace("{Moneda}", newValue5).Replace("{CantidadTransporta}", newValue3).Replace("{IDOrigen}", newValue1).Replace("{IDDestino}", newValue2);
                        str2 += str12;
                    }
                }
                using (StreamWriter streamWriter = new StreamWriter($"{this.tbxCarpetaDestino.Text}/{str3}-{empty3}-{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}.ini"))
                    streamWriter.WriteLine(str2);
                str2 = "";
            }
            int num1 = (int)MessageBox.Show("Se generaron los archivos .ini", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnLimpiarGrid_Click(object sender, EventArgs e)
        {
            this.dtgDatos.Rows.Clear();
            oButtonsValida();
        }

        public List<string> ObtenerFoliosUnicos(DataGridView dtgDatos)
        {
            HashSet<string> collection = new HashSet<string>();
            foreach (DataGridViewRow row in (IEnumerable)dtgDatos.Rows)
            {
                if (!row.IsNewRow)
                {
                    string str = row.Cells[0].Value?.ToString();
                    if (!string.IsNullOrEmpty(str))
                        collection.Add(str);
                }
            }
            return new List<string>((IEnumerable<string>)collection);
        }

        private void dtgDatos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;
                int columnIndex = this.dtgDatos.CurrentCell.ColumnIndex;
                int rowIndex = this.dtgDatos.CurrentCell.RowIndex;
            if (columnIndex < this.dtgDatos.ColumnCount - 1)
                this.dtgDatos.CurrentCell = this.dtgDatos[columnIndex + 1, rowIndex];
            else if (rowIndex < this.dtgDatos.RowCount - 1)
                this.dtgDatos.CurrentCell = this.dtgDatos[0, rowIndex + 1];
                e.Handled = true;
        }

        private void dtgDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = this.dtgDatos.CurrentCell.ColumnIndex;
            if (columnIndex == 3)
            {
                object obj1 = this.dtgDatos[e.ColumnIndex, e.RowIndex].Value;
                object obj2 = this.dtgDatos[0, e.RowIndex].Value;
                foreach (DataGridViewRow row in (IEnumerable)this.dtgDatos.Rows)
                {
                    if ((object)row.Cells["FolioFact"].Value.ToString() == obj2)
                        row.Cells["IDDestino"].Value = obj1;
                }
            }
            if (columnIndex != 5)
                return;
            object obj3 = this.dtgDatos[e.ColumnIndex, e.RowIndex].Value;
            object obj4 = this.dtgDatos[0, e.RowIndex].Value;
            foreach (DataGridViewRow row in (IEnumerable)this.dtgDatos.Rows)
            {
                if ((object)row.Cells["FolioFact"].Value.ToString() == obj4)
                    row.Cells["MaterialPeligroso"].Value = obj3;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if(dtgDatos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.");
                    return;
                }
                
                if(tbxCarpetaDestino.Text.Length == 0)
                {
                    MessageBox.Show("Se necesita carpeta de destino para crear el Excel.");
                    return;
                }

                //******** INICIO CON LA CREACIÓN DEL EXCEL
                var workbook = new XLWorkbook();
                var ws = workbook.Worksheets.Add("Facturas");
                ws.SheetView.Freeze(2, 3);

                string sText = "";
                string sFromHtmlColor = "";

                int iRow2 = 2;
                int iRow3 = 2;
                int X = 0, Y = 0;
                IXLCell RangeInit = null, RangeEnd = null;
                int iWidth = 2;
                //******** ENCABEZADOS DE LA PRIMER TABLA

                #region EncabezadosTabla1

                ws.Column(iWidth).Width = 12;
                sText = "# Factura"; sFromHtmlColor = "#a9d08e";
                X = iRow3;
                Y = 2;
                ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Center, XLAlignmentVerticalValues.Center);
                ws.Cell(X, Y).Style.Fill.BackgroundColor = XLColor.FromHtml(sFromHtmlColor);
                ws.Cell(X, Y).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                ws.Cell(X, Y).Style.Border.LeftBorder = XLBorderStyleValues.Thick;
                Y++;
                iWidth++;

                ws.Column(iWidth).Width = 10;
                sText = "Fecha"; sFromHtmlColor = "#a9d08e";
                X = iRow3;
                ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Center, XLAlignmentVerticalValues.Center);
                ws.Cell(X, Y).Style.Fill.BackgroundColor = XLColor.FromHtml(sFromHtmlColor);
                ws.Cell(X, Y).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                Y++;
                iWidth++;

                ws.Column(iWidth).Width = 12;
                sText = "rfc Cliente"; sFromHtmlColor = "#a9d08e";
                X = iRow3;
                ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Center, XLAlignmentVerticalValues.Center);
                ws.Cell(X, Y).Style.Fill.BackgroundColor = XLColor.FromHtml(sFromHtmlColor);
                ws.Cell(X, Y).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                Y++;
                iWidth++;

                ws.Column(iWidth).Width = 25;
                sText = "Cliente"; sFromHtmlColor = "#a9d08e";
                X = iRow3;
                ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Center, XLAlignmentVerticalValues.Center);
                ws.Cell(X, Y).Style.Fill.BackgroundColor = XLColor.FromHtml(sFromHtmlColor);
                ws.Cell(X, Y).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                Y++;
                iWidth++;
                
                ws.Column(iWidth).Width = 25;
                sText = "Descripcion"; sFromHtmlColor = "#a9d08e";
                X = iRow3;
                ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Center, XLAlignmentVerticalValues.Center);
                ws.Cell(X, Y).Style.Fill.BackgroundColor = XLColor.FromHtml(sFromHtmlColor);
                ws.Cell(X, Y).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                Y++;
                iWidth++;

                ws.Column(iWidth).Width = 7;
                sText = "Moneda"; sFromHtmlColor = "#a9d08e";
                X = iRow3;
                ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Center, XLAlignmentVerticalValues.Center);
                ws.Cell(X, Y).Style.Fill.BackgroundColor = XLColor.FromHtml(sFromHtmlColor);
                ws.Cell(X, Y).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                Y++;
                iWidth++;

                ws.Column(iWidth).Width = 8;
                sText = "Cantidad"; sFromHtmlColor = "#a9d08e";
                X = iRow3;
                ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Center, XLAlignmentVerticalValues.Center);
                ws.Cell(X, Y).Style.Fill.BackgroundColor = XLColor.FromHtml(sFromHtmlColor);
                ws.Cell(X, Y).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                Y++;
                iWidth++;

                ws.Column(iWidth).Width = 15;
                sText = "P Unitario"; sFromHtmlColor = "#a9d08e";
                X = iRow3;
                ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Center, XLAlignmentVerticalValues.Center);
                ws.Cell(X, Y).Style.Fill.BackgroundColor = XLColor.FromHtml(sFromHtmlColor);
                ws.Cell(X, Y).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                Y++;
                iWidth++;

                ws.Column(iWidth).Width = 15;
                sText = "Importe"; sFromHtmlColor = "#a9d08e";
                X = iRow3;
                ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Center, XLAlignmentVerticalValues.Center);
                ws.Cell(X, Y).Style.Fill.BackgroundColor = XLColor.FromHtml(sFromHtmlColor);
                ws.Cell(X, Y).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                Y++;
                iWidth++;

                ws.Column(iWidth).Width = 15;
                sText = "Descuento"; sFromHtmlColor = "#a9d08e";
                X = iRow3;
                ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Center, XLAlignmentVerticalValues.Center);
                ws.Cell(X, Y).Style.Fill.BackgroundColor = XLColor.FromHtml(sFromHtmlColor);
                ws.Cell(X, Y).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                Y++;
                iWidth++;

                ws.Column(iWidth).Width = 15;
                sText = "Subtotal"; sFromHtmlColor = "#a9d08e";
                X = iRow3;
                ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Center, XLAlignmentVerticalValues.Center);
                ws.Cell(X, Y).Style.Fill.BackgroundColor = XLColor.FromHtml(sFromHtmlColor);
                ws.Cell(X, Y).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                Y++;
                iWidth++;

                ws.Column(iWidth).Width = 15;
                sText = "Iva"; sFromHtmlColor = "#a9d08e";
                X = iRow3;
                ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Center, XLAlignmentVerticalValues.Center);
                ws.Cell(X, Y).Style.Fill.BackgroundColor = XLColor.FromHtml(sFromHtmlColor);
                ws.Cell(X, Y).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                Y++;
                iWidth++;

                ws.Column(iWidth).Width = 15;
                sText = "IEPS"; sFromHtmlColor = "#a9d08e";
                X = iRow3;
                ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Center, XLAlignmentVerticalValues.Center);
                ws.Cell(X, Y).Style.Fill.BackgroundColor = XLColor.FromHtml(sFromHtmlColor);
                ws.Cell(X, Y).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                Y++;
                iWidth++;

                ws.Column(iWidth).Width = 15;
                sText = "Total"; sFromHtmlColor = "#a9d08e";
                X = iRow3;
                ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Center, XLAlignmentVerticalValues.Center);
                ws.Cell(X, Y).Style.Fill.BackgroundColor = XLColor.FromHtml(sFromHtmlColor);
                ws.Cell(X, Y).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                ws.Cell(X, Y).Style.Border.RightBorder = XLBorderStyleValues.Thick;
                Y++;
                iWidth++;

                #endregion

                #region ContenidoTabla1

                var line = 3;

                for (int i = 0; i < dtgDatos.Rows.Count; i++)
                {
                    var oData = dtgDatos.Rows[i];

                    var Serie = oData.Cells["Serie"].Value.ToString();
                    var folio = oData.Cells["FolioFact"].Value.ToString();
                    folio = Serie == "" ? folio : Serie + "-" + folio;

                    sText = folio;
                    X = line;
                    Y = 2;
                    ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Left, XLAlignmentVerticalValues.Center);
                    ws.Cell(X, Y).Style.Border.LeftBorder = XLBorderStyleValues.Thick;
                    Y++;

                    sText = Convert.ToDateTime(oData.Cells["fecha"].Value.ToString()).ToString("yyyy-MM-dd");
                    X = line;
                    ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Center, XLAlignmentVerticalValues.Center);
                    Y++;

                    sText = oData.Cells["rfcReceptor"].Value.ToString();
                    X = line;
                    ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Left, XLAlignmentVerticalValues.Center);
                    Y++;

                    sText = oData.Cells["nombreReceptor"].Value.ToString();
                    X = line;
                    ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Left, XLAlignmentVerticalValues.Center);
                    Y++;

                    sText = oData.Cells["Descripcion"].Value.ToString();
                    X = line;
                    ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Left, XLAlignmentVerticalValues.Center);
                    Y++;
                        
                    sText = oData.Cells["Moneda1"].Value.ToString();
                    X = line;
                    ExcelHelper.writeInExcelCoordNum(ref ws, sText, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Center, XLAlignmentVerticalValues.Center);
                    Y++;

                    var cantidad = Convert.ToDecimal(oData.Cells["Cantidad"].Value.ToString());

                    ExcelHelper.writeInExcelCoordNum(ref ws, cantidad, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Right, XLAlignmentVerticalValues.Center);
                    ws.Cell(X, Y).Style.NumberFormat.Format = "#,##0.00";
                    Y++;

                    var sPreciounitario = oData.Cells["preciounitario"].Value.ToString();
                    sPreciounitario = sPreciounitario == "" ? "0" : sPreciounitario;
                    var preciounitario = Convert.ToDecimal(sPreciounitario);

                    X = line;
                    ExcelHelper.writeInExcelCoordNum(ref ws, preciounitario, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Right, XLAlignmentVerticalValues.Center);
                    ws.Cell(X, Y).Style.NumberFormat.Format = "#,##0.00";
                    Y++;

                    var sImporte = oData.Cells["importe"].Value.ToString();
                    sImporte = sImporte == "" ? "0" : sImporte;
                    var importe = Convert.ToDecimal(sImporte);

                    X = line;
                    ExcelHelper.writeInExcelCoordNum(ref ws, importe, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Right, XLAlignmentVerticalValues.Center);
                    ws.Cell(X, Y).Style.NumberFormat.Format = "#,##0.00";
                    Y++;

                    var sDescuento = oData.Cells["descuento"].Value.ToString();
                    sDescuento = sDescuento == "" ? "0" : sDescuento;
                    var descuento = Convert.ToDecimal(sDescuento);

                    X = line;
                    ExcelHelper.writeInExcelCoordNum(ref ws, descuento, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Right, XLAlignmentVerticalValues.Center);
                    ws.Cell(X, Y).Style.NumberFormat.Format = "#,##0.00";
                    Y++;

                    var subtotal = importe - descuento;

                    X = line;
                    ExcelHelper.writeInExcelCoordNum(ref ws, subtotal, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Right, XLAlignmentVerticalValues.Center);
                    ws.Cell(X, Y).Style.NumberFormat.Format = "#,##0.00";
                    Y++;

                    var sIva = oData.Cells["iva"].Value.ToString();
                    sIva = sIva == "" ? "0" : sIva;
                    var iva = Convert.ToDecimal(sIva);

                    X = line;
                    ExcelHelper.writeInExcelCoordNum(ref ws, iva, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Right, XLAlignmentVerticalValues.Center);
                    ws.Cell(X, Y).Style.NumberFormat.Format = "#,##0.00";
                    Y++;

                    var sIeps = oData.Cells["ieps"].Value.ToString();
                    sIeps = sIeps == "" ? "0" : sIeps;
                    var ieps = Convert.ToDecimal(sIeps);

                    X = line;
                    ExcelHelper.writeInExcelCoordNum(ref ws, ieps, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Right, XLAlignmentVerticalValues.Center);
                    ws.Cell(X, Y).Style.NumberFormat.Format = "#,##0.00";
                    Y++;

                    var total = subtotal + iva + ieps;

                    X = line;
                    ExcelHelper.writeInExcelCoordNum(ref ws, total, X, Y, "Arial", 8, true, XLAlignmentHorizontalValues.Right, XLAlignmentVerticalValues.Center);
                    ws.Cell(X, Y).Style.NumberFormat.Format = "#,##0.00";
                    ws.Cell(X, Y).Style.Border.RightBorder = XLBorderStyleValues.Thick;
                    Y++;

                    line++;
                }

                #endregion

                ws.Columns().AdjustToContents();

                var rutaSalida = $"{ tbxCarpetaDestino.Text }\\Excel-"+ Guid.NewGuid() + ".xlsx";
                workbook.SaveAs(rutaSalida);

                ExcelHelper.AbrirArchivo(rutaSalida);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void oButtonsValida()
        {
            if (this.dtgDatos.Rows.Count > 0 && tbxCarpetaDestino.Text.Length > 0)
            {
                this.btnGenerar.Enabled = true;
                this.btnExcel.Enabled = true;
            }
            else
            {
                this.btnGenerar.Enabled = false;
                this.btnExcel.Enabled = false;
            }
        }

    }

}
