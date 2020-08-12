using BadBoys.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Models
{
    public class SuspectCreate
    { 
        [Required]
        public string Name { get; set; }
        [Required]
        public string Height { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool PriorConviction { get; set; }
        public DateTime? DateBooked { get; set; }
    }
}
