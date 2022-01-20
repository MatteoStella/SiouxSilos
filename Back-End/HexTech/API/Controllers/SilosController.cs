using ApplicationCore.Interfaces.Service;
using DataSimulator.Entity;
using DataSimulator.Interfaces.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class SilosController : ControllerBase
    {
        private readonly ISilosService _silosService;

        public SilosController(ISilosService silosService)
        {
            _silosService = silosService;
        }

        // GET: api/<SilosController>
        [HttpGet]
        public IEnumerable<ISilos> Get()
        {
            return _silosService.GetAllSilosData();
        }

        // GET api/<SilosController>/5
        [HttpGet("{id}")]
        public ISilos Get(int id)
        {
            return _silosService.GetSilosById(id);

        }

        // POST api/<SilosController>
        [HttpPost]
        public void Post(Silos value)
        {
            _silosService.InsertData(value);
        }

    }
}
