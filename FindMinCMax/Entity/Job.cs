using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMinCMax.Entity
{
    class Job
    {
        public int Id { get; set; }
        public int CurrentTime { get; set; }
        public List<List<int>> AssignableMachines { get; set; } // Table Eligibility - AM[i][j] = machine j is assignable to this job at stage i
        public List<List<int>> ProcessingTime { get; set; } // PT[i][j] = processing time at machine j, stage i of this job
        public List<List<int>> LagTime { get; set; } // LagTime[i][j] = lag time at machine j, stage i of this job
        
        // TODO: SetupTime

    }
}
