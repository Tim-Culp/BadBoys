using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Data
{
    public class OfficerCase
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(CaseId))]
        public int CaseId { get; set; }
        [ForeignKey(nameof(OfficerId))]
        public int OfficerId { get; set; }
        public virtual Officer Officer { get; set; }
        public virtual Case Case { get; set; }
    }
}
