using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSimulator.Interfaces.Entities
{
    public interface ISilos
    {
        
        public DateTime Data { get; set; }
        public int IdSilos { get; set; }
        public int Livello { get; set; }
        public decimal Pressione { get; set; }
        public decimal Temperatura { get; set; }
        public decimal Umidita { get; set; }
        public byte Control { get; set; }
    }
}
