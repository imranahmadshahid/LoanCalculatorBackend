using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoanCalulatorCore.Infrastructure;
using LoanCalulatorCore.Model;
using LoanCalulatorCore.ViewModel.Request;

namespace LoanCalculatorApi.Controllers
{
    
    [ApiController]
    public class LoanCalculatorController : ControllerBase
    {
        private Func<LoanTypes, ILoan> _loanServices;
        public LoanCalculatorController(Func<LoanTypes,ILoan> loanServices)
        {
            _loanServices = loanServices;
        }

        [HttpPost]
        [Route("api/v1/calculate")]
        public async Task<IActionResult> CalculateLoan(LoanRequest loanRequest)
        {
            return Ok(_loanServices(loanRequest.LoanType).CalculateLoan(loanRequest));
        }

        [HttpGet]
        [Route("api/v1/getloantypes")]
        public async Task<IActionResult> GetLoanTypes()
        {
            var loanTypes = new List<KeyValuePair<int, string>>();

            // adding elements
            loanTypes.Add(new KeyValuePair<int, string>((int)LoanTypes.None, "-- Select Loan Type --"));
            loanTypes.Add(new KeyValuePair<int, string>((int)LoanTypes.HouseLoan, "House Loan"));
  
            return Ok(loanTypes);
        }


    }
}
