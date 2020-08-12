using BadBoys.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Models
{
    public class CaseList
    {
        [Display(Name = "Case ID")]
        public int CaseKeyId { get; set; }
        public DateTime DateOfIncident { get; set; }
        [Display(Name = "Officer Assigned")]
        public virtual Officer Officer { get; set; }
        [Display(Name = "Suspect Detail")]
        public virtual Suspect Suspect { get; set; }
        [Display(Name = "Crime Detail")]
        public virtual Crime Crime { get; set; }
    }
}
