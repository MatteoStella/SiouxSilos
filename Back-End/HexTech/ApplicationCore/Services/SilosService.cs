
using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Service;
using DataSimulator.Entity;
using DataSimulator.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class SilosService : ISilosService
    {
        private readonly ISilosRepository _silosRepository;

        public SilosService(ISilosRepository silosRepository)
        {
            _silosRepository = silosRepository;
        }

        public IEnumerable<ISilos> GetAllSilosData()
        {
            return _silosRepository.GetData();
        }

        public ISilos GetSilosById(int id)
        {
           return _silosRepository.GetById(id);
        }

        public void InsertData(ISilos model)
        {
            _silosRepository.Insert(model);
        }
    }
}
