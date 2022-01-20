using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Service;
using DataSimulator.Entity;
using DataSimulator.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DataCheckerRepository : IDataCheckerRepository
    {
        private readonly ISilosService _silosService;
        private readonly IAlarmService _alarmService;

        private readonly IAlarmSettingService _alarmSettingService;
        private readonly IWarningSettingService _warningSettingService;

        private IEnumerable<ISilos> allSilos;

        private List<ISilos> silos1 = new List<ISilos>();
        private List<ISilos> silos2 = new List<ISilos>();
        private List<ISilos> silos3 = new List<ISilos>();
        private List<ISilos> silos4 = new List<ISilos>();
        private List<ISilos> silos5 = new List<ISilos>();
        private List<ISilos> silos6 = new List<ISilos>();
        private List<ISilos> silos7 = new List<ISilos>();

        private List<ISilos>[] allDataSilos = new List<ISilos>[8];

        public DataCheckerRepository(ISilosService silosService, IAlarmService alarmService, IAlarmSettingService alarmSettingService, IWarningSettingService warningSettingService)
        {
            _silosService = silosService;
            _alarmService = alarmService;
            _alarmSettingService = alarmSettingService;
            _warningSettingService = warningSettingService;
        }

        public List<Alarm> Check()
        {
            allSilos = _silosService.GetAllSilosData();
            List<Alarm> alarm = new List<Alarm>();

            //suddivido i dati di ogni silon in liste
            foreach (var item in allSilos)
            {
                switch (item.IdSilos)
                {
                    case 1:
                        silos1.Add(item);
                        break;
                    case 2:
                        silos2.Add(item);
                        break;
                    case 3:
                        silos3.Add(item);
                        break;
                    case 4:
                        silos4.Add(item);
                        break;
                    case 5:
                        silos5.Add(item);
                        break;
                    case 6:
                        silos6.Add(item);
                        break;
                    case 7:
                        silos7.Add(item);
                        break;
                }
            }

            //aggiungo le liste all'array
            for (int i = 1; i <= allDataSilos.Length; i++)
            {
                switch (i)
                {
                    case 1:
                        allDataSilos[i] = silos1;
                        break;
                    case 2:
                        allDataSilos[i] = silos2;
                        break;
                    case 3:
                        allDataSilos[i] = silos3;
                        break;
                    case 4:
                        allDataSilos[i] = silos4;
                        break;
                    case 5:
                        allDataSilos[i] = silos5;
                        break;
                    case 6:
                        allDataSilos[i] = silos6;
                        break;
                    case 7:
                        allDataSilos[i] = silos7;
                        break;
                }
            }

            for (int i = 1; i < allDataSilos.Length; i++)
            {
                var obj = allDataSilos[i];

                decimal lastTemperature;
                decimal secondLastTemperature;

                decimal lastHumidity;
                decimal secondLastHumidity;

                decimal lastPressure;
                decimal secondLastPressure;

                try
                {
                    lastTemperature = obj[obj.Count - 1].Temperatura;
                    secondLastTemperature = obj[obj.Count - 2].Temperatura;

                    lastHumidity = obj[obj.Count - 1].Umidita;
                    secondLastHumidity = obj[obj.Count - 2].Umidita;

                    lastPressure = obj[obj.Count - 1].Pressione;
                    secondLastPressure = obj[obj.Count - 2].Pressione;
                }
                catch (Exception)
                {
                    return alarm;
                }

                var alarmParameter = _alarmSettingService.GetAlarmBySilosId(obj[obj.Count - 1].IdSilos);
                var warningParameter = _warningSettingService.GetWarningBySilosId(obj[obj.Count - 1].IdSilos);


                var plusRangeT = (secondLastTemperature * alarmParameter.Temperatura / 100) + secondLastTemperature;
                var minusRangeT = secondLastTemperature - (secondLastTemperature * alarmParameter.Temperatura / 100);

                var plusRangeH = (secondLastHumidity * alarmParameter.Umidita / 100) + secondLastHumidity;
                var minusRangeH = secondLastHumidity - (secondLastHumidity * alarmParameter.Umidita / 100);

                var plusRangeP = (secondLastPressure * alarmParameter.Pressione / 100) + secondLastPressure;
                var minusRangeP = secondLastPressure - (secondLastPressure * alarmParameter.Pressione / 100);

                if (lastTemperature > plusRangeT || lastTemperature < minusRangeT)
                {
                    _alarmService.InserAlarm(new Alarm
                    {
                        IdSilos = obj[obj.Count - 1].IdSilos,
                        Livello = obj[obj.Count - 1].Livello,
                        Umidita = obj[obj.Count - 1].Umidita,
                        Temperatura = obj[obj.Count - 1].Temperatura,
                        Pressione = obj[obj.Count - 1].Pressione,
                        Descrizione = "Allarme Temperatura"
                    });
                }

                if (lastHumidity > plusRangeH || lastHumidity < minusRangeH)
                {
                    _alarmService.InserAlarm(new Alarm
                    {
                        IdSilos = obj[obj.Count - 1].IdSilos,
                        Livello = obj[obj.Count - 1].Livello,
                        Umidita = obj[obj.Count - 1].Umidita,
                        Temperatura = obj[obj.Count - 1].Temperatura,
                        Pressione = obj[obj.Count - 1].Pressione,
                        Descrizione = "Allarme Umidità"
                    });
                }

                if (lastPressure > plusRangeP || lastPressure < minusRangeP)
                {
                    _alarmService.InserAlarm(new Alarm
                    {
                        IdSilos = obj[obj.Count - 1].IdSilos,
                        Livello = obj[obj.Count - 1].Livello,
                        Umidita = obj[obj.Count - 1].Umidita,
                        Temperatura = obj[obj.Count - 1].Temperatura,
                        Pressione = obj[obj.Count - 1].Pressione,
                        Descrizione = "Allarme Pressione"
                    });
                }
            }

            return alarm;
        } //fine metodo
    }
}
