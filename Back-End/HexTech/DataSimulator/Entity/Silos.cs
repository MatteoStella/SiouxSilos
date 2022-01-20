using DataSimulator.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSimulator.Entity
{
    public class Silos : ISilos
    {
        public Silos()
        {

        }

        public Silos(int id)
        {
            Data = DateTime.Now;
            IdSilos = id;
            Livello = new Random().Next(1, 8);
            Pressione = 999;
            Temperatura = 16;
            Umidita = 80;
            Control = 0;
        }

        public DateTime Data { get; set; }
        public int IdSilos { get; set; }
        public int Livello { get; set; }
        public decimal Pressione { get; set; }
        public decimal Temperatura { get; set; }
        public decimal Umidita { get; set; }
        public byte Control { get; set; }
    }
}
