using LoanCalulatorCore.Model;

namespace LoanCalulatorCore.ViewModel.Response
{
    public class LoanResponse
    {
        public double Amount { get; set; }
        public int PaymentYears { get; set; }
        public double InterestRate { get; set; }
        public double MonthlyPayment { get; set; }
        public double TotalAmountToBePaid { get; set; }
        public double TotalInterest { get; set; }
        public LoanTypes LoanType { get; set; }
    }
}
