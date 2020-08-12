using BadBoys.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Models
{
    public class SuspectList
    {
        public int SuspectId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DateBooked { get; set; }
    }
}
