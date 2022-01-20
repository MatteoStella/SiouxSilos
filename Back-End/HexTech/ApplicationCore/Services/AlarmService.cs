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
    public class AlarmService : IAlarmService
    {
        private readonly IAlarmRepository _alarmRepository;

        public AlarmService(IAlarmRepository alarmRepository)
        {
            _alarmRepository = alarmRepository;
        }

        public Alarm GetAlarmById(int id)
        {
            return _alarmRepository.GetById(id);
        }

        public IEnumerable<Alarm> GetAllAlarms()
        {
            return _alarmRepository.GetAlarms();
        }

        public void InserAlarm(Alarm alarm)
        {
            _alarmRepository.Inser(alarm);
        }

        public void DeleteAlarm(int id)
        {
            _alarmRepository.Delete(id);
        }
    }
}
