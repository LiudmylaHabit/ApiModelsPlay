using NBitcoin;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace NbitcOinWagerrPlay2
{
    class Program
    {
        //Test through Required and Miss smth
        static void Main(string[] args)
        {
            SendAPIGetBlockRequest(1852102); //norm - returned block data (all)
            //SendGetTrxRequest("960d852781bdabef826617530e0d09444e6d2b806a5c224a9c7667f2cae202ad");
            //SendGetTrxRequestTryies("960d852781bdabef826617530e0d09444e6d2b806a5c224a9c7667f2cae202ad");
            var block = RPCHelper.GetWagerrBlockThroughRPC(1852102);
            Console.ReadKey();
        }

        static void SendAPIGetBlockRequest(int blockNumber)
        {
            string uri = "https://explorer.wagerr.com/api/block/" + blockNumber;
            RestClient client = new RestClient(uri)
            {
                Timeout = 300000
            };

            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");

            var response = client.Execute(request);
            ApiWagerrBlockModel model = new ApiWagerrBlockModel();
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.MissingMemberHandling = MissingMemberHandling.Error;
            try
            {
                model = JsonConvert.DeserializeObject<ApiWagerrBlockModel>(response.Content, jsonSettings); //Work correctly
            }
            catch (Exception ex) {/*ignored*/ }

            ObjectHelper<ApiWagerrBlockModel>.CompareModelsGeneric(model, new ApiWagerrBlockModel());
        }

        static void SendGetTrxRequest(string txNumber)
        {
            string uri = "https://explorer.wagerr.com/api/tx/" + txNumber;
            RestClient client = new RestClient(uri)
            {
                Timeout = 300000
            };

            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");

            var response = client.Execute(request);
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.MissingMemberHandling = MissingMemberHandling.Error;
            ApiWagerrTransactionModel model = new ApiWagerrTransactionModel();
            try
            {
                model = JsonConvert.DeserializeObject<ApiWagerrTransactionModel>(response.Content, jsonSettings);
            }
            catch (Exception) {/*ignored*/ }

            NBitcoin.Transaction wagerrTrnx;
            try
            {
                wagerrTrnx = NBitcoin.Transaction.Parse("0100000001ca4b52683c9b77e81c375a2fad5bc9cf382bc06fde4f48c9b62dddba4d956b28000000006b48304502210096d942a91f9a30ecf50f1bbfd80b561a31a0da0eddaa7a735bdd345f2fba23aa02200b745e2438fd85232f64400f80f7d13df04af0eaef229853775dbd235a806bd30121024f2c027ed6a61bc78b0c311f7284c7e46febf191c2510a70ec00bd428586d788ffffffff02c0b9ee2b020000001976a9149f0242d5b780cbcba16794a27f9d90908531347b88ac0000000000000000156a13420105b26801007cc400000c3000000000000000000000",
                    Network.Main);
            }
            catch (Exception) { }
        }
    }
}