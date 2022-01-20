using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class AlarmSettingService : IAlarmSettingService
    {
        private readonly IAlarmSettingRepository _alarmSettingRepository;

        public AlarmSettingService(IAlarmSettingRepository alarmSettingRepository)
        {
            _alarmSettingRepository = alarmSettingRepository;
        }

        public AlarmSetting GetAlarmBySilosId(int id)
        {
            return _alarmSettingRepository.GetBySilosId(id);
        }

        public IEnumerable<AlarmSetting> GetAllAlarmSetting()
        {
            return _alarmSettingRepository.GetAlarms();
        }

        public void InserAlarmSetting(AlarmSetting alarm)
        {
            if( _alarmSettingRepository.GetBySilosId(alarm.IdSilos) != null)
            {
                _alarmSettingRepository.Delete(alarm.IdSilos);
            }
            _alarmSettingRepository.Inser(alarm);
        }

        public void DeleteAlarmSetting(int id)
        {
            _alarmSettingRepository.Delete(id);
        }
    }
}
