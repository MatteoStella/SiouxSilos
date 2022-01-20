using ApplicationCore.Interfaces.Service;
using DataSimulator.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SilosGenerator : ControllerBase
    {
        private readonly ISilosService _silosService;
        private readonly IDataCheckerService _dataCheckerService;

        Silos silos1 = new Silos(1);
        Silos silos2 = new Silos(2);
        Silos silos3 = new Silos(3);
        Silos silos4 = new Silos(4);
        Silos silos5 = new Silos(5);
        Silos silos6 = new Silos(6);
        Silos silos7 = new Silos(7);

        public SilosGenerator(ISilosService silosService, IDataCheckerService dataCheckerService)
        {
            _silosService = silosService;
            _dataCheckerService = dataCheckerService;
        }

        // api/silosGenerator
        [HttpGet]
        async public void Get()
        {
            
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44387/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            for(; ; )
            {
                await client.PostAsJsonAsync("Silos", silos1);
                silos1 = (Silos)_silosService.GetSilosById(1);

                await client.PostAsJsonAsync("Silos", silos2);
                silos2 = (Silos)_silosService.GetSilosById(2);

                await client.PostAsJsonAsync("Silos", silos3);
                silos3 = (Silos)_silosService.GetSilosById(3);

                await client.PostAsJsonAsync("Silos", silos4);
                silos4 = (Silos)_silosService.GetSilosById(4);

                await client.PostAsJsonAsync("Silos", silos5);
                silos5 = (Silos)_silosService.GetSilosById(5);

                await client.PostAsJsonAsync("Silos", silos6);
                silos6 = (Silos)_silosService.GetSilosById(6);

                await client.PostAsJsonAsync("Silos", silos7);
                silos7 = (Silos)_silosService.GetSilosById(7);

                _dataCheckerService.CheckAlarm();

                await Task.Delay(60000);
            }
            

        }
    }
}
