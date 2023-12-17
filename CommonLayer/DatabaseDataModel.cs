using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class DatabaseDataModel
    {
        public string Symbol { get; set; }
        public string fullCompanyName { get; set; }
        public long marcetCap { get; set; }
        public int? yearFounded { get; set; }
        public int numberOfEmployees { get; set; }
        public string headquartersCity { get; set; }
        public string headquartersCountry { get; set; }
        public DateTime date { get; set; }
        public decimal closePrice { get; set; }
        public decimal openPrice { get; set; }
    }
}
