using DataSimulator.Entity;
using DataSimulator.Interface.Service;
using DataSimulator.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSimulator.Service
{
    public class DataGenerator : IDataGenerator
    {
        private DateTime now = DateTime.Now;
        
        public int getLivello(ISilos obj)
        {
            if (obj.Livello == 0 || obj.Control == 1)
            {
                obj.Control = 1;
                obj.Livello = riempiSilos(obj);
                if (obj.Livello == 8) // silos pieno
                    obj.Control = 0;

                return obj.Livello;
            }

            // ogni minuto il livello scende di una tacca
            int diff = (int)(now - obj.Data).TotalMinutes;

            if (diff >= 1)
            {
                obj.Data = DateTime.Now;
                obj.Livello = obj.Livello - diff;
                if (obj.Livello < 0)
                    obj.Livello = 0;
                    

                return obj.Livello;
            }
            else
            {
                return obj.Livello;
            }
        }

        public int riempiSilos(ISilos obj)
        {
            int diff = (int)(now - obj.Data).TotalMinutes;
            if (diff >= 1)
            {
                obj.Data = DateTime.Now;
                return obj.Livello = obj.Livello + diff;
            }
            else
            {
                return obj.Livello;
            }
        }

        public decimal getPressione()
        {
            
            return new Random().Next(2, 5);
        }

        public decimal getTemperatura(ISilos obj)
        {
            decimal temperatura;
            decimal diff;

            do
            {
                temperatura = Decimal.Round((decimal)(new Random().NextDouble() * (28 - 22) + 10), 2);
                diff = temperatura - obj.Temperatura;

            } while (diff > 1 || diff < -1);

            return temperatura;
        }

        public decimal getUmidita()
        {
            return new Random().Next(75, 90);
        }

        public ISilos getData(ISilos silos)
        {

            //silos.Data = DateTime.Now;
            silos.Livello = getLivello(silos);
            silos.Pressione = getPressione();
            silos.Temperatura = getTemperatura(silos);
            silos.Umidita = getUmidita();

            return silos;

        }

    }
}
