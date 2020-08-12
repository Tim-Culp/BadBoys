using BadBoys.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Models
{
    public class OfficerList
    {
        [Display(Name = "Badge ID")]
        public int BadgeId { get; set; }
        [Display(Name = "Officer Name")]
        public string FullName { get; set; }
        [Display(Name = "Officer Rank")]
        public OfficerRank RankOfOfficer { get; set; }
    }
}
