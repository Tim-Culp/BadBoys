using System;
using System.Collections.Generic;
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
        public Guid OfficerId { get; set; }
        public string FullName { get; set; }
        public OfficerRank RankOfOfficer { get; set; }

        [ForeignKey(nameof(Case))]
        public int CurrentCase { get; set; }

        //public virtual Case Case { get; set; }  ???



        public Officer() { }
        public Officer(Guid officerId, string fullName, int currentCase)
        {
            OfficerId = officerId;
            FullName = fullName;
            CurrentCase = currentCase;
        }
    }
}
