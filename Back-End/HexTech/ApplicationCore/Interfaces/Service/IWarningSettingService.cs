using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Service
{
    public interface IWarningSettingService
    {
        IEnumerable<WarningSetting> GetAllWarningSetting();
        WarningSetting GetWarningBySilosId(int id);
        void InserWarningSetting(WarningSetting alarm);
        void DeleteWarningSetting(int id);
    }
}
