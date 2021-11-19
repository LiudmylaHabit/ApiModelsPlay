using NBitcoin;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Collections.Generic;

namespace NbitcOinWagerrPlay2
{
    class Program
    {
        //Test through Required and Miss smth
        static void Main(string[] args)
        {
          //  SendAPIGetBlockRequest(1852102); //returned block data (all)
                                             //SendGetTrxRequest("960d852781bdabef826617530e0d09444e6d2b806a5c224a9c7667f2cae202ad");
                                             //SendGetTrxRequestTryies("960d852781bdabef826617530e0d09444e6d2b806a5c224a9c7667f2cae202ad");
            var manualBlock = ReadJSON();

            var block = RPCHelper.GetWagerrBlockThroughRPC(1852102);

            bool equal = manualBlock.CheckEquality(block);

            string blocjParsed = "";
            List<string> errors = new List<string>();
            try
            {
                blocjParsed = JsonConvert.SerializeObject(block.Header, new JsonSerializerSettings
                {
                    Error = delegate (object sender, ErrorEventArgs args)
                    {
                        errors.Add(args.ErrorContext.Error.Message);
                        args.ErrorContext.Handled = true;
                    },
                    Converters = { new IsoDateTimeConverter() }
                });
            }
            catch (Exception)
            {
                
            }

            try
            {
                blocjParsed = JsonConvert.SerializeObject(block.HeaderOnly, new JsonSerializerSettings
                {
                    Error = delegate (object sender, ErrorEventArgs args)
                    {
                        errors.Add(args.ErrorContext.Error.Message);
                        args.ErrorContext.Handled = true;
                    },
                    Converters = { new IsoDateTimeConverter() }
                });
            }
            catch (Exception)
            {

            }

            //Use JSON path to serialize part https://stackoverflow.com/questions/30304128/how-to-perform-partial-object-serialization-providing-paths-using-newtonsoft-j


            bool equalMoseld = false;
            try
            {
                equalMoseld = ObjectHelper<NBitcoin.Block>.CompareModelsGeneric(block, block);
            }
            catch (Exception) 
            { 
            }
            var hash = block.Transactions[0].Inputs[0].ScriptSig.Hash;
            var otherBlock = ReadJSON();
            var witHash = block.Transactions[0].Inputs[0].ScriptSig.WitHash;
            string hashStr = hash.ToString();
            string mer = block.Transactions[0].Inputs[0].WitScript.ToString();
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
            model = JsonConvert.DeserializeObject<ApiWagerrBlockModel>(response.Content, jsonSettings);

            bool correct = ObjectHelper<ApiWagerrBlockModel>.CompareModelsGeneric(model, new ApiWagerrBlockModel());
            Console.WriteLine(correct);
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

        public static WaggerBlockNBitcoinManual ReadJSON()
        {
            string expected = "{\"Header\":{\"Bits\": {\"Difficulty\": 16369.263042351435},\"Nonce\": 0,\"HashMerkleRoot\":{\"Size\": 32},\"Version\": 7,\"HashPrevBlock\":{\"Size\": 32},\"BlockTime\": \"9/14/2021 10:11:30 AM +00:00\",\"IsNull\": false, \"NAccumulatorCheckpoint\": {\"Size\": 32}},\"HeaderOnly\": false, \"Transactions\": [{\"RBF\": false, \"Version\": 1,\"TotalOut\": {\"Satoshi\": 0},\"LockTime\": {\"Value\": 0, \"Height\": 0, \"IsHeightLock\": true,\"IsTimeLock\": true}, \"Inputs\": [{\"IsFinal\": true,\"PrevOut\": \"0000000000000000000000000000000000000000000000000000000000000000-4294967295\",\"ScriptSig\": \"c6421c 1d\",\"Sequence\": \"4294967295\", \"WitScript\": \"\"}], \"Outputs\": [{\"ScriptPubKey\": \"\",\"Value\": {\"Satoshi\": 0}}],\"HasWitness\": false,\"IsCoinBase\": true }]}";
            var block = JsonConvert.DeserializeObject<WaggerBlockNBitcoinManual>(expected);
            return block;
        }
    }
}