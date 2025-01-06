using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JorgeTools.Clases
{
    public class Orden
    {
        public int id { get; set; }
        public string salesOrganization { get; set; }
        public string division { get; set; }
        public string shipToParty { get; set; }
        public string customerReference { get; set; }
        public string requestDeliveryDate { get; set; }
        public string plant { get; set; }
        public List<OrdDetalle> ordDetalle { get; set; }
    }
}
