using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Data
{
    //[JsonConverter(typeof(StringEnumConverter))]
    public enum CrimeTypes { Theft = 1, DrugPossession, Jaywalking, Homicide, Treason}
    public class Crime
    {
        [Key]
        public int CrimeId { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public CrimeTypes CrimeType { get; set; }
        [Required]
        public string CrimeDescription { get; set; }
        [Required]
        public string Penalty { get; set; }
    }
}
