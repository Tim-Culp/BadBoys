using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Data
{
    public enum OfficerRank
    {
        Technician = 1,
        Officer,
        Detective,
        Corporal,
        Sergeant,
        Lieutenant,
        Captain,
        DeputyChief,
        Chief
    };
    public class Officer
    {
        [Key]
        public int BadgeId { get; set; }
        public Guid OfficerId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public OfficerRank RankOfOfficer { get; set; }
    }
}
