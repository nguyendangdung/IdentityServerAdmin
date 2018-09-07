using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Setting
    {
        public string ConnectionString { get; set; }
        public int PortNumber { get; set; }
        public string Schema { get; set; }

        public Setting()
        {
            PortNumber = 9000;
            Schema = "dbo";
        }
    }
}
