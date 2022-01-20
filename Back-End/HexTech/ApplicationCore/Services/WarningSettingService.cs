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
    public class WarningSettingService : IWarningSettingService
    {
        private readonly IWarningSettingRepository _warningSettingRepository;

        public WarningSettingService(IWarningSettingRepository warningSettingRepository)
        {
            _warningSettingRepository = warningSettingRepository;
        }

        public WarningSetting GetWarningBySilosId(int id)
        {
            return _warningSettingRepository.GetBySilosId(id);
        }

        public IEnumerable<WarningSetting> GetAllWarningSetting()
        {
            return _warningSettingRepository.GetWarnings();
        }

        public void InserWarningSetting(WarningSetting alarm)
        {
            if( _warningSettingRepository.GetBySilosId(alarm.IdSilos) != null)
            {
                _warningSettingRepository.Delete(alarm.IdSilos);
            }
            _warningSettingRepository.Inser(alarm);
        }

        public void DeleteWarningSetting(int id)
        {
            _warningSettingRepository.Delete(id);
        }
    }
}
