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
        public int CaseKeyId { get; set; }
        [Required]
        public Guid OwnerId { get; set; } 
        [Required]
        public DateTime DateOfIncident { get; set; }
        
        public int OfficerKeyId { get; set; }
        [ForeignKey(nameof(OfficerKeyId))]
        public virtual Officer Officer { get; set; }
       
        public int SuspectId { get; set; }
        [ForeignKey(nameof(SuspectId))]
        public virtual Suspect Suspect { get; set; }
       
        public int CrimeId { get; set; }
        [ForeignKey(nameof(CrimeId))]
        public virtual Crime Crime { get; set; }
    }
}
