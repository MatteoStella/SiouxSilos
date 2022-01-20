
using DataSimulator.Entity;
using DataSimulator.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Service
{
    public interface ISilosService
    {
        IEnumerable<ISilos> GetAllSilosData();
        void InsertData(ISilos model);
        ISilos GetSilosById(int id);
    }
}
