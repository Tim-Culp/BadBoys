using BadBoys.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Models
{
    public class SuspectEdit 
    {
        [Required]
        public int SuspectId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Height { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public bool PriorConviction { get; set; }
    }
}
