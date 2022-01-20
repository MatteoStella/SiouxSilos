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
    public class AlarmSettingController : ControllerBase
    {
        private readonly IAlarmSettingService _alarmSettingService;

        public AlarmSettingController(IAlarmSettingService alarmSettingService)
        {
            _alarmSettingService = alarmSettingService;
        }

        // GET: api/<WarningSettingController>
        [HttpGet]
        public IEnumerable<AlarmSetting> Get()
        {
            return _alarmSettingService.GetAllAlarmSetting();
        }

        // GET api/<WarningSettingController>/5
        [HttpGet("{id}")]
        public AlarmSetting Get(int id)
        {
            return _alarmSettingService.GetAlarmBySilosId(id);
        }

        // POST api/<WarningSettingController>
        [HttpPost]
        public void Post(AlarmSetting value)
        {
            _alarmSettingService.InserAlarmSetting(value);
        }
    }
}
