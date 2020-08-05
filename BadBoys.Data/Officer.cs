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
        DeputyCheif,
        Cheif
    };
    public class Officer
    {
        [Key]
        public int OfficerKeyId { get; set; }
        public Guid OfficerId { get; set; }
        public string FullName { get; set; }
        public OfficerRank RankOfOfficer { get; set; }
        /*public int CurrentCase { get; set; }

        [ForeignKey(nameof(CurrentCase))]
        public virtual Case Case { get; set; } 



        public Officer() { }
        public Officer(Guid officerId, string fullName, int currentCase)
        {
            OfficerId = officerId;
            FullName = fullName;
            CurrentCase = currentCase;
        }*/

    }
}
