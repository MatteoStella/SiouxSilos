using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmController : ControllerBase
    {
        private readonly IAlarmService _alarmService;

        public AlarmController(IAlarmService alarmService)
        {
            _alarmService = alarmService;
        }

        
        [HttpGet]
        public IEnumerable<Alarm> Get()
        {
            return _alarmService.GetAllAlarms();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _alarmService.DeleteAlarm(id);
        }
    }
}
