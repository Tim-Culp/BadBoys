using BadBoys.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Models
{
    public class OfficerDetail
    {
        public int OfficerKeyId { get; set; }
        public Guid OfficerId { get; set; }
        public string FullName { get; set; }
        public OfficerRank RankOfOfficer { get; set; }
        public int? CurrentCase { get; set; }
    }
}
