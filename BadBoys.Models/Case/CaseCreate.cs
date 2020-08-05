using BadBoys.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Models
{
    public class CaseCreate
    {
        public DateTime DateOfIncident { get; set; }
     
        public int SuspectId { get; set; }

        public int CrimeId { get; set; }

        public int OfficerKeyId { get; set; }
    }
}
