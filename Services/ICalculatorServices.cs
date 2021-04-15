
namespace Calculator.Services
{
     public interface ICalculatorServices<T> where T : class 
    {     
        T Calculate(decimal salary);
        T CalculateMonthly(T obj);
    }
  
}