using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorAPI.Models
{
    public class SensorItem
    {
        public long Id { get; set; }
        public long Timestamp { get; set; }
        public string Tag { get; set; }
        public string Valor { get; set; }

    }
}
