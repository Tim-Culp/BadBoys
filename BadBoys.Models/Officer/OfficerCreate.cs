using BadBoys.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Models
{
    public class OfficerCreate
    {
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(30, ErrorMessage = "There are too many characters in this field.")]
        public string FullName { get; set; }
        public OfficerRank RankOfOfficer { get; set; }
    }
}
