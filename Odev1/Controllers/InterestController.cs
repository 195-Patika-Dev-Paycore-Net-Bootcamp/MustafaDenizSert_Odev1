using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Odev1.Entity;

namespace Odev1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        //private Interest _interest;
        //private Balance _balance;

        //public InterestController(Interest interest, Balance balance)
        //{
        //    //_interest = interest;
        //    //_balance = balance;
        //}

        [HttpGet("interest-result")]
        public IActionResult InterestResult()
        {
            Interest interest = new Interest { Principal = 28500, InterestRate = 30, Maturity = 5}; 
            var result = BalanceCalculator(interest);
           
               return Ok(result);
            
        }


        private Balance BalanceCalculator(Interest interest)
        {
            var result = Math.Pow((1 + (interest.InterestRate / 100)), interest.Maturity);
            var total = interest.Principal * result;

            Balance balance = new Balance { InterestAmount = total- interest.Principal,
                TotalBalance = total };

            return balance;
        }
    }
}
