using BadBoys.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Models
{
    public class CaseDetail
    {
        public int CaseKeyId { get; set; }
        public DateTime DateOfIncident { get; set; }
        public virtual Officer Officer { get; set; }
        public virtual Suspect Suspect { get; set; }
        public virtual Crime Crime { get; set; }
    }
}
