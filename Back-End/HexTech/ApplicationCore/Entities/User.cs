using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class User
    {
        public string IdUser { get; set; }
        public string Password { get; set; }
        public int Permission { get; set; }
    }
}
