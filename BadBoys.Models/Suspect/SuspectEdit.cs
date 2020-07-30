using BadBoys.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Models
{
    public class SuspectEdit 
    {
        public int SuspectId { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
        public int Weight { get; set; }
    }
}
