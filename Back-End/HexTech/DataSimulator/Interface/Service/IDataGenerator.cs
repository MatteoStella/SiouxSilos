using DataSimulator.Entity;
using DataSimulator.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSimulator.Interface.Service
{
    public interface IDataGenerator
    {
        int getLivello(ISilos silos);
        int riempiSilos(ISilos silos);
        decimal getPressione();
        decimal getTemperatura(ISilos silos);
        decimal getUmidita();
        ISilos getData(ISilos silos);
    }
}
