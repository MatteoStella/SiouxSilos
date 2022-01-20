using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class AlarmSetting
    {
        public int Id { get; set; }
        public int IdSilos { get; set; }
        public int Temperatura { get; set; }
        public int Umidita { get; set; }
        public int Pressione { get; set; }
    }
}
