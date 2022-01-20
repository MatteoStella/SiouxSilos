using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Data
{
    public interface IAlarmSettingRepository
    {
        IEnumerable<AlarmSetting> GetAlarms();
        AlarmSetting GetBySilosId(int id);
        void Inser(AlarmSetting alarm);
        void Delete(int id);
    }
}
