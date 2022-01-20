using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Service
{
    public interface IAlarmSettingService
    {
        IEnumerable<AlarmSetting> GetAllAlarmSetting();
        AlarmSetting GetAlarmBySilosId(int id);
        void InserAlarmSetting(AlarmSetting alarm);
        void DeleteAlarmSetting(int id);
    }
}
