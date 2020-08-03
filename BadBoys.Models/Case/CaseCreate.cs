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
        
        //public Guid OfficerId { get; set; }
    
        public DateTime DateOfIncident { get; set; }
     
        public string Suspect { get; set; }

        public string Crime { get; set; }
    }
}
