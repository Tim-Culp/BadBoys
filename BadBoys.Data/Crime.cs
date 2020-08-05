using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Data
{
    public enum CrimeTypes { Theft = 1, DrugPossession, Jaywalking, Homicide, Treason}
    public class Crime
    {
        [Key]
        public int CrimeId { get; set; }

        [Required]
        public CrimeTypes CrimeType { get; set; }
        [Required]
        public string CrimeDescription { get; set; }
        [Required]
        public string Penalty { get; set; }
    }
}
