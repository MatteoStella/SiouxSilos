
using DataSimulator.Entity;
using DataSimulator.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Data
{
    public interface ISilosRepository
    {
        IEnumerable<ISilos> GetData();
        void Insert(ISilos model);
        ISilos GetById(int id);
    }
}
