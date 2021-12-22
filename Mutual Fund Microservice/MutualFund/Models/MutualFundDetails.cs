using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MutualFund.Models
{
    public class MutualFundDetails
    {
        //[JsonProperty("MutualFunds")]
        public int MutualFundId { get; set; }
        public string MutualFundName { get; set; }
        public int MutualFundValue { get; set; }
    }
}
