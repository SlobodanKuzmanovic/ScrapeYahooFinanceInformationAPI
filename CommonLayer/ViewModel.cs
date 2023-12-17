using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class ViewModel
    {
        public List<InnerViewModel> data { get; set; }
        public List<string> badData { get; set; }

        public ViewModel()
        {
            data = new List<InnerViewModel>();
            badData = new List<string>();
        }
    }

    public class InnerViewModel
    {
        public string symbol { get; set; }
        public DisplayDataModel data { get; set; }

        public InnerViewModel(string symbol, DisplayDataModel data)
        {
            this.symbol = symbol;
            this.data = data;
        }
    }
}
