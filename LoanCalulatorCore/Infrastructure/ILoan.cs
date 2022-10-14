using LoanCalulatorCore.ViewModel.Request;
using LoanCalulatorCore.ViewModel.Response;

namespace LoanCalulatorCore.Infrastructure
{
    public interface ILoan
    {
  
        public double InterestRate { get; set; }

        LoanResponse CalculateLoan(LoanRequest request);
    }
}
