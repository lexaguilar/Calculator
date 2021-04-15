using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator.Models;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Services
{
    public class TaxServices : ITaxServices<IR>
    {
        private readonly CalculatorContext _db;      
        public TaxServices(CalculatorContext db) => _db = db;
        
        public IR[] GetTable() => _db.IRS.ToArray(); 
        public Inss GetInss() => _db.Inss.FirstOrDefault(x => x.Id == 1); 
        public async Task<int> SetInssAsyncs(Inss inss)  {

            _db.Inss.Add(inss);
            var result = await _db.SaveChangesAsync();
            return result;
            
        } 
        public int GetInterval() => 12;

        public Task<int> SetInssAsync(Inss inss)
        {
             _db.Attach<Inss>(inss);
             _db.Entry(inss).State = EntityState.Modified;
            var result = _db.SaveChangesAsync();
            return result;
        }
    }
}