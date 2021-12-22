using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DailyShare.Controllers;
using MutualFund.DbHelper;
using MutualFund.Models;
using Newtonsoft.Json;

namespace MutualFund.Repository
{
    public class MutualFundRepository : IMutualFundRepository
    {
        public MutualFundDetails GetMutualFund(string mutualFundName)
        {
            string all = System.IO.File.ReadAllText(@"Dbhelp.json");
          //  List<MutualFundDetails> m = new List<MutualFundDetails>();
            //object p = JsonConvert.DeserializeObject(all);
            //m = p;
            var model = JsonConvert.DeserializeObject<List<MutualFundDetails>>(all);


            MutualFundDetails mutualFundDetails = model.FirstOrDefault(c => c.MutualFundName.ToLower() == mutualFundName.ToLower());
            return mutualFundDetails == null ? null : mutualFundDetails;
        }
    }
}
