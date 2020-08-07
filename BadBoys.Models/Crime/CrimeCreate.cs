using BadBoys.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Models
{
    public class CrimeCreate
    {
        public CrimeTypes CrimeType { get; set; }
        public string CrimeDescription { get; set; }
        public string Penalty { get; set; }
    }
}
