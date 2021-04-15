using System.Linq;
using Calculator.Models;

namespace Calculator.Services
{
    public class CalculatorServices : TaxBase, ICalculatorServices<Tax>
    {
        
        private readonly ITaxServices<IR> _service;
        public CalculatorServices(ITaxServices<IR> service) => _service = service;
        
        public Tax Calculate(decimal salary)
        {
            if(salary <= 0)
                return new Tax{ Type ="Anual"};

            var divisor = this.GetInterval;

            var inssTax = _service.GetInss();

            var salaryAnualy = salary * divisor;
            var inss = (salaryAnualy * inssTax.Value / 100);

            var baseSalaryBrutoAnualy = salaryAnualy - inss;

            var salaryRanges = _service.GetTable();

            var salaryRange = salaryRanges.FirstOrDefault(x => x.From <= baseSalaryBrutoAnualy && x.To >= baseSalaryBrutoAnualy || x.To == null);

            var ir = ((baseSalaryBrutoAnualy - salaryRange.Excess) * salaryRange.Percent) + salaryRange.Base;
            var neto = baseSalaryBrutoAnualy - ir;

            return new Tax{

                Type ="Anual",
                Salary = salaryAnualy,
                IR = ir,
                Inss= inss,
                Neto=neto

            };
        }

        public Tax CalculateMonthly(Tax tax)
        {
            var divisor = this.GetInterval;
            var taxMonthly = new Tax{

                Type = "Mensual",
                Salary= tax.Salary/ divisor,
                Inss= tax.Inss/ divisor,
                IR= tax.IR/divisor,
                Neto= tax.Neto/divisor

            };

            return taxMonthly;

        }
    }
}