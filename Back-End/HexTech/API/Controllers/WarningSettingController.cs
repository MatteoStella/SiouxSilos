using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarningSettingController : ControllerBase
    {
        private readonly IWarningSettingService _warningSettingService;

        public WarningSettingController(IWarningSettingService warningSettingService)
        {
            _warningSettingService = warningSettingService;
        }

        // GET: api/<WarningSettingController>
        [HttpGet]
        public IEnumerable<WarningSetting> Get()
        {
            return _warningSettingService.GetAllWarningSetting();
        }

        // GET api/<WarningSettingController>/5
        [HttpGet("{id}")]
        public WarningSetting Get(int id)
        {
            return _warningSettingService.GetWarningBySilosId(id);
        }

        // POST api/<WarningSettingController>
        [HttpPost]
        public void Post(WarningSetting value)
        {
            _warningSettingService.InserWarningSetting(value);
        }
    }
}
