using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Module_3.Models;
using Module_3.Repository;
using Newtonsoft.Json;

namespace Module_3.Services
{
    public class CalculateNetWorthService: ICalculateNetWorthService
    {
        public static List<PortfolioDetails> _portFolioDetails = new List<PortfolioDetails>()
            {
                new PortfolioDetails{
                    portFolioid=1,
                    MutualFundList = new List<MutualFundDetails>()
                    {
                        new MutualFundDetails{MutualFundName = "HDFC", MutualFundUnits=44},
                        new MutualFundDetails{MutualFundName = "ICICI", MutualFundUnits=66}
                    },
                    StockList = new List<StockDetails>()
                    {
                        new StockDetails{StockCount = 19, StockName = "HDFC"},
                        new StockDetails{StockCount = 667, StockName = "AXIS"}
                    }
                },
                new PortfolioDetails
                {
                    portFolioid = 3,
                    MutualFundList = new List<MutualFundDetails>()
                    {
                        new MutualFundDetails{MutualFundName = "HDFC", MutualFundUnits=2},
                        new MutualFundDetails{MutualFundName = "ICICI", MutualFundUnits=2}
                    },
                    StockList = new List<StockDetails>()
                    {
                        new StockDetails{StockCount = 2, StockName = "HDFC"},
                        new StockDetails{StockCount = 1, StockName = "AXIS"}
                    }
                }
                

            };
        public PortfolioDetails GetPortFolioDetailsByID(int id)
        {
            PortfolioDetails portFolioDetails = new PortfolioDetails();
            try
            {
                
                portFolioDetails = _portFolioDetails.FirstOrDefault(e => e.portFolioid == id);
            }
            catch (Exception ex)
            {
            }
            return portFolioDetails;
        }
        public int CalculateNetWorth(PortfolioDetails portFolio)
        {
            int netWorth = 0;

            using var client = new HttpClient();

            foreach (var stock in portFolio.StockList)
            {
                int quantity = portFolio.StockList.FirstOrDefault(x => x.StockName == stock.StockName).StockCount;
                string stockName = stock.StockName;
                string uri = $"http://localhost:4883/api/DailySharePrice/{stockName}";

                var response = client.GetAsync(uri).Result;
                if(response != null)
                {
                    DailyStockDetails stockDetails = JsonConvert.DeserializeObject<DailyStockDetails>(response.Content.ReadAsStringAsync().Result);
                    int price = quantity * stockDetails.StockValue;
                    netWorth += price;
                }              
            }

            foreach (var mutualFund in portFolio.MutualFundList)
            {
                //implement httpclient here for mutual fund microservice
                int quantity = portFolio.MutualFundList.FirstOrDefault(x => x.MutualFundName == mutualFund.MutualFundName).MutualFundUnits;
                var mutualFundName = mutualFund.MutualFundName;
                string uri = $"http://localhost:45678/api/MutualFundNav/{mutualFundName}";
                var response = client.GetAsync(uri).Result;
                if(response != null)
                {
                    DailyMutualFundDetails mutualFundDetails = JsonConvert.DeserializeObject<DailyMutualFundDetails>(response.Content.ReadAsStringAsync().Result);

                    int price = quantity * mutualFundDetails.MutualFundValue;
                    netWorth += price;
                }
            }

            return netWorth;
        }
    }
}
