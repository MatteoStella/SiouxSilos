using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Alarm
    {
        public int Id { get; set; }
        public int IdSilos { get; set; }
        public int Livello { get; set; }
        public decimal Umidita { get; set; }
        public decimal Temperatura { get; set; }
        public decimal Pressione { get; set; }
        public string Descrizione { get; set; }
        //public DateTime Data { get => this.Data = this.Data; set => Data = DateTime.Now; }
        public DateTime Data { get; set; }

    }
}
