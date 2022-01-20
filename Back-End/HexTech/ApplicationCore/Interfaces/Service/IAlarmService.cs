using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Service
{
    public interface IAlarmService
    {
        IEnumerable<Alarm> GetAllAlarms();
        Alarm GetAlarmById(int id);
        void InserAlarm(Alarm alarm);
        void DeleteAlarm(int id);
    }
}
