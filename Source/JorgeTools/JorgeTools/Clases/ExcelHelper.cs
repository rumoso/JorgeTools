using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using JorgeTools.SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JorgeTools.Clases
{
    public class ExcelHelper
    {
        public static void GenerarReporteDesdePlantilla(long idOrden, string rutaPlantilla, string rutaSalida)
        {
            try
            {
                System.Data.DataTable OData = new System.Data.DataTable();

                // Conexión a la base de datos SQLite
                var connection = dbManager.GetConnection();
                connection.Open();

                // Consulta SQL para obtener los clientes
                string query = @"
SELECT

	O.Id
    , O.salesOrganization
    , O.division
	, O.shipToParty
	, O.customerReference
	, O.requestDeliveryDate
	, O.plant

    , OD.itemID
    , OD.product_CodigoSap
    , OD.product_CodigoBan
    , OD.requested_quantity
    , OD.requested_QtyUnit

FROM Ordenes AS O
INNER JOIN OrdenDetalles AS OD
    ON
        OD.OrdenId = O.Id " +
@" WHERE " +
$" O.Id = {idOrden};";

                // Crear el comando SQLite
                using (var command = new SQLiteCommand(query, connection))
                {
                    // Crear un adaptador para llenar un DataTable con los datos obtenidos
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        
                        adapter.Fill(OData);
                    }
                }
                connection.Close();

                if(OData.Rows.Count > 0)
                {

                    // Cargar la plantilla de Excel
                    using (var workbook = new XLWorkbook(rutaPlantilla))
                    {
                        // Seleccionar la hoja de trabajo (puedes usar el nombre de la hoja o el índice)
                        var worksheet = workbook.Worksheet("Order Data");

                        // Escribir una tabla de datos
                        var startRow = 6;

                        for (int i = 0; i < OData.Rows.Count; i++)
                        {
                            var Id = OData.Rows[i]["Id"].ToString();
                            var salesOrganization = OData.Rows[i]["salesOrganization"].ToString();
                            var division = OData.Rows[i]["division"].ToString();
                            var shipToParty = OData.Rows[i]["shipToParty"].ToString();
                            var customerReference = OData.Rows[i]["customerReference"].ToString();
                            var requestDeliveryDate = OData.Rows[i]["requestDeliveryDate"].ToString();
                            var plant = OData.Rows[i]["plant"].ToString();

                            var itemID = OData.Rows[i]["itemID"].ToString();
                            var product_CodigoSap = OData.Rows[i]["product_CodigoSap"].ToString();
                            var product_CodigoBan = OData.Rows[i]["product_CodigoBan"].ToString();
                            var requested_quantity = OData.Rows[i]["requested_quantity"].ToString();
                            var requested_QtyUnit = OData.Rows[i]["requested_QtyUnit"].ToString();

                            var iColumn = 2;
                            // *Sales Order (Temporary ID)
                            worksheet.Cell(startRow + i, iColumn).Value = "1";
                            iColumn++;
                            // *Sales Order Type
                            worksheet.Cell(startRow + i, iColumn).Value = "OR";
                            iColumn++;
                            // *Sales Organization
                            worksheet.Cell(startRow + i, iColumn).Value = salesOrganization;
                            iColumn++;
                            // *Distribution Channel
                            worksheet.Cell(startRow + i, iColumn).Value = "";
                            iColumn++;
                            // *Division
                            worksheet.Cell(startRow + i, iColumn).Value = division;
                            iColumn++;
                            // *Sold-to Party
                            worksheet.Cell(startRow + i, iColumn).Value = "";
                            iColumn++;
                            // Ship-to Party
                            worksheet.Cell(startRow + i, iColumn).Value = shipToParty;
                            iColumn++;
                            // Customer Reference
                            worksheet.Cell(startRow + i, iColumn).Value = customerReference;
                            iColumn++;
                            // Requested Delivery Date
                            worksheet.Cell(startRow + i, iColumn).Value = requestDeliveryDate.Insert(4, "-").Insert(7, "-");
                            iColumn++;
                            // Payment Method
                            worksheet.Cell(startRow + i, iColumn).Value = "";
                            iColumn++;
                            // *Item (Temporary ID)
                            worksheet.Cell(startRow + i, iColumn).Value = itemID;
                            iColumn++;
                            // *Product
                            worksheet.Cell(startRow + i, iColumn).Value = product_CodigoSap;
                            iColumn++;
                            // CODIGO BAAN
                            worksheet.Cell(startRow + i, iColumn).Value = product_CodigoBan;
                            iColumn++;
                            // *Requested Quantity
                            worksheet.Cell(startRow + i, iColumn).Value = requested_quantity;
                            iColumn++;
                            // Requested Qty Unit
                            worksheet.Cell(startRow + i, iColumn).Value = requested_QtyUnit;
                            iColumn++;
                            // Plant
                            worksheet.Cell(startRow + i, iColumn).Value = "3019";
                            iColumn++;
                        }

                        // Guardar el archivo con un nuevo nombre
                        workbook.SaveAs(rutaSalida);
                        AbrirArchivo(rutaSalida);
                    }

                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar el reporte: " + ex.Message);
            }
        }

        public static void AbrirArchivo(string ruta)
        {
            if (File.Exists(ruta))
            {
                Process proceso = new Process();
                proceso.StartInfo.FileName = ruta;
                proceso.Start();
            }
            else
            {
                throw new FileNotFoundException($"El archivo '{ruta}' no existe.");
            }
        }

        public static void writeInExcel(ref IXLWorksheet ws, string sText, string sCord, string sFontName, int iFontSize, bool bBold, XLAlignmentHorizontalValues Horizontal, XLAlignmentVerticalValues Vertical)
        {
            ws.Cell(sCord).Value = sText;
            ws.Cell(sCord).Style.Font.SetFontName(sFontName);
            ws.Cell(sCord).Style.Font.FontSize = 8;
            ws.Cell(sCord).Style.Font.Bold = bBold;
            ws.Cell(sCord).Style.Alignment.Horizontal = Horizontal;
            ws.Cell(sCord).Style.Alignment.Vertical = Vertical;
        }

        public static void writeInExcelCoordNum(ref IXLWorksheet ws, string sText, int x, int y, string sFontName, int iFontSize, bool bBold, XLAlignmentHorizontalValues Horizontal, XLAlignmentVerticalValues Vertical)
        {
            var cell = ws.Cell(x, y);
            cell.Value = sText;
            cell.Style.Font.SetFontName(sFontName);
            cell.Style.Font.FontSize = iFontSize;
            cell.Style.Font.Bold = bBold;
            cell.Style.Alignment.Horizontal = Horizontal;
            cell.Style.Alignment.Vertical = Vertical;
        }

        // Para números con formato moneda
        public static void writeInExcelCoordNum(ref IXLWorksheet ws, decimal amount, int x, int y, string sFontName, int iFontSize, bool bBold, XLAlignmentHorizontalValues Horizontal, XLAlignmentVerticalValues Vertical)
        {
            var cell = ws.Cell(x, y);
            cell.Value = amount;
            cell.Style.NumberFormat.Format = "$ #,##0.00";
            cell.Style.Font.SetFontName(sFontName);
            cell.Style.Font.FontSize = iFontSize;
            cell.Style.Font.Bold = bBold;
            cell.Style.Alignment.Horizontal = Horizontal;
            cell.Style.Alignment.Vertical = Vertical;
        }

        public static void setColorExcel(ref IXLWorksheet ws, string sFromHtmlColor, string sCord)
        {
            ws.Cell(sCord).Style.Fill.BackgroundColor = XLColor.FromHtml(sFromHtmlColor);
        }

        public static void setColorRange(ref IXLWorksheet ws, string sFromHtmlColor, string sCordRange)
        {
            ws.Range(sCordRange).Row(1).Style.Fill.BackgroundColor = XLColor.FromHtml(sFromHtmlColor);
        }

        public static void setMergeExcel(ref IXLWorksheet ws, string sCordRange)
        {
            ws.Range(sCordRange).Row(1).Merge();
        }
    }
}
