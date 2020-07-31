using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Data
{
    public class Officer
    {   [Key]
        public Guid OfficerId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
