using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Data
{
    public interface IAlarmRepository
    {
        IEnumerable<Alarm> GetAlarms();
        Alarm GetById(int id);
        void Inser(Alarm alarm);
        void Delete(int id);
    }
}
