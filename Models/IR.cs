
using System.ComponentModel.DataAnnotations;

namespace Calculator.Models
{
    public class IR
    {
        [Key]
        public int Id { get; set; }
        public decimal From { get; set; }
        public decimal? To { get; set; }
        public decimal Base { get; set; }
        public decimal Percent { get; set; }
        public decimal Excess { get; set; }
    }
}
