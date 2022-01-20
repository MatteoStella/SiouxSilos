using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Data
{
    public interface IWarningSettingRepository
    {
        IEnumerable<WarningSetting> GetWarnings();
        WarningSetting GetBySilosId(int id);
        void Inser(WarningSetting alarm);
        void Delete(int id);
    }
}
