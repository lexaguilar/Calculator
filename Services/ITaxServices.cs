
using System.Threading.Tasks;
using Calculator.Models;

namespace Calculator.Services
{
    public interface ITaxServices<T> where T : class 
    {     
        T[] GetTable();
        Inss GetInss();
        Task<int> SetInssAsync(Inss inss);
    }

    public abstract class TaxBase{
        public virtual int GetInterval => 12;
    }
  
}