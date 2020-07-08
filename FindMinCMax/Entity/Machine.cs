using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMinCMax.Entity
{
    class Machine
    {
        public int Id { get; set; }
        public int AvailableTime { get; set; }
        public int CurrentJobPosition { get; set; }
    }
}
