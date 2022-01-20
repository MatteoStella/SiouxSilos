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
    public class DataCheckerService : IDataCheckerService
    {
        private readonly IDataCheckerRepository _dataCheckerRepository;

        public DataCheckerService(IDataCheckerRepository dataCheckerRepository)
        {
            _dataCheckerRepository = dataCheckerRepository;
        }

        public List<Alarm> CheckAlarm()
        {
            return _dataCheckerRepository.Check();
        }
    }
}
