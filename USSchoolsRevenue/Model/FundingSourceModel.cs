using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USSchoolsRevenue
{
    public  class FundingSourceModel
    {
        public string Year { get; set; }
        public double LocalFund { get; set; }
        public double StateFund { get; set; }
        public double FederalFund { get; set; }

        public FundingSourceModel(string year, double localFund, double stateFund, double federalFund)
        {
            Year = year;
            LocalFund = localFund;
            StateFund = stateFund;
            FederalFund = federalFund;
        }
    }
}
