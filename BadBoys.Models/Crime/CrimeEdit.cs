using BadBoys.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Models
{
    public class CrimeEdit
    {
        [Required]
        public int CrimeId { get; set; }
        [Required]
        public CrimeTypes CrimeType { get; set; }
        [Required]
        public string CrimeDescription { get; set; }
        [Required]
        public string Penalty { get; set; }
    }
}
