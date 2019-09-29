using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureApi.Models
{
    [Table("TemperatureData")]
    public class TemperatureEntry
    {
        [Key]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        [Column("Temperature(F)")]
        public decimal TemperatureF { get; set; }
    }
}
