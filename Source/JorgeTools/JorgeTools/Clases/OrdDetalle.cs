using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JorgeTools.Clases
{
    public class OrdDetalle
    {
        public int id { get; set; }
        public int OrdenId { get; set; }
        public string itemID { get; set; }
        public string product_CodigoSap { get; set; }
        public string product_CodigoBan { get; set; }
        public string descriptionSAP { get; set; }
        public string requested_quantity { get; set; }
        public string requested_QtyUnit { get; set; }

    }
}
