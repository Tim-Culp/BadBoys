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
        [ForeignKey(nameof(Case))]
        public int CaseId { get; set; }
        public virtual Case Case { get; set; }
        [ForeignKey(nameof(Officer))]
        public int OfficerId { get; set; }
        public virtual Officer Officer { get; set; }

    }
}
