using System.ComponentModel.DataAnnotations;
using LoanCalulatorCore.Model;

namespace LoanCalulatorCore.ViewModel.Request
{
    public class LoanRequest
    {
        [Required(ErrorMessage = "Amount is required")]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Please enter an amount bigger than {1}")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "Payment year is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a year bigger than {1}")]
        public int PaymentYears { get; set; }
        [Required(ErrorMessage = "LoanType is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter an amount bigger than {1}")]
        public LoanTypes LoanType { get; set; }
    }
}
