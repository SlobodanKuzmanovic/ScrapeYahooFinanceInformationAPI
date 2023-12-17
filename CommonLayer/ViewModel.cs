using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class ViewModel
    {
        public List<CorrectData> data { get; set; }
        public List<string> badData { get; set; }

        public ViewModel()
        {
            data = new List<CorrectData>();
            badData = new List<string>();
        }
    }

    public class CorrectData
    {
        public string symbol { get; set; }
        public DisplayDataModel data { get; set; }

        public CorrectData(string symbol, DisplayDataModel data)
        {
            this.symbol = symbol;
            this.data = data;
        }
    }
}
