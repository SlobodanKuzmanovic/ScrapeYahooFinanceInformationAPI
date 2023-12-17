using CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ICollectData
    {
        Task<ViewModel> GetData(string symbols, DateTime date);
    }
}
