using LoanCalulatorCore.Infrastructure;
using LoanCalulatorCore.Model;
using LoanCalulatorCore.ViewModel.Request;
using LoanCalulatorCore.ViewModel.Response;

namespace LoanCalulatorCore.Services
{
    public class HouseLoan : ILoan
    {

        public double InterestRate { get; set; } = 3.5;

        public LoanResponse CalculateLoan(LoanRequest request)
        {
            var interestAmount = (request.Amount * request.PaymentYears * InterestRate) / 100;
            var totalAmountToBePaid = request.Amount + interestAmount;
            var montlyPayment = totalAmountToBePaid / (request.PaymentYears * 12);

            var loanResonse = new LoanResponse()
            {
                InterestRate = this.InterestRate,
                Amount = request.Amount,
                LoanType = LoanTypes.HouseLoan,
                MonthlyPayment = montlyPayment,
                TotalAmountToBePaid = totalAmountToBePaid,
                TotalInterest = interestAmount,
                PaymentYears = request.PaymentYears
            };

            return loanResonse;
        }

    }
}
