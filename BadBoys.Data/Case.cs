using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Data
{
    public class Case
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid OfficerId { get; set; }
        [Required]
        public DateTime DateOfIncident { get; set; }
        [Required]
        public string Suspect { get; set; }
        //[ForeignKey(nameof(SuspectId))]
        //public virtual Suspect Suspect { get; set; }
        [Required]
        public string Crime { get; set; }
        //[ForeignKey(nameof(CrimeId))]
        //public virtual Crime Crime { get; set; }
    }
}
