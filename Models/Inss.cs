
using System.ComponentModel.DataAnnotations;

namespace Calculator.Models
{
    public class Inss
    {   
        [Key]
        public int Id { get; set; }
        public decimal Value { get; set; }
    }
}
