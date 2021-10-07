using NBitcoin;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace NbitcOinWagerrPlay2
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Hello World!");
			//HashingAlgo.MainHash();
			//SendGetBlockRequest(1852102);
			SendGetTrxRequest("960d852781bdabef826617530e0d09444e6d2b806a5c224a9c7667f2cae202ad");
			SendGetTrxRequestTryies("960d852781bdabef826617530e0d09444e6d2b806a5c224a9c7667f2cae202ad");
		}

		static void SendGetTrxRequestTryies(string txNumber)
		{
			string uri = "https://explorer.wagerr.com/api/tx/" + txNumber;
			RestClient client = new RestClient(uri)
			{
				Timeout = 300000
			};

			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("content-type", "application/json");

			var response = client.Execute(request);
			CustomTrxModel model = new CustomTrxModel();
			try
			{
				model = JsonConvert.DeserializeObject<CustomTrxModel>(response.Content);
			}
			catch (Exception) {/*ignored*/ }

			Transaction wagerrTrnx;
			try
			{
				wagerrTrnx = NBitcoin.Transaction.Parse("0100000001ca4b52683c9b77e81c375a2fad5bc9cf382bc06fde4f48c9b62dddba4d956b28000000006b48304502210096d942a91f9a30ecf50f1bbfd80b561a31a0da0eddaa7a735bdd345f2fba23aa02200b745e2438fd85232f64400f80f7d13df04af0eaef229853775dbd235a806bd30121024f2c027ed6a61bc78b0c311f7284c7e46febf191c2510a70ec00bd428586d788ffffffff02c0b9ee2b020000001976a9149f0242d5b780cbcba16794a27f9d90908531347b88ac0000000000000000156a13420105b26801007cc400000c3000000000000000000000",
					Network.Main);
			}
			catch (Exception) { }
			//string authenticationString, Uri address, Network network = null
			//var rpc = new NBitcoin.RPC.RPCClient(Network.Main);

			Uri uriOne = new Uri(@"https://explorer.wagerr.com/api/block/");
			NBitcoin.RPC.RPCClient rpc;
			try
			{
			//http://52.224.84.119:55003/
				 //rpc0 = new NBitcoin.RPC.RPCClient("", "127.0.0.1:18332");
				 //rpc = new NBitcoin.RPC.RPCClient("test123:test123", uriOne, Network.Main);
				rpc = new NBitcoin.RPC.RPCClient("", "149.202.56.33:55002", Network.Main);
				var blpck = rpc.GetBlock(1852102);
			}
			catch (Exception) { }

			var bitcoinModel = new NBitcoin.Block();
			try
			{
				bitcoinModel = JsonConvert.DeserializeObject<NBitcoin.Block>(response.Content);//JsonConvert.DeserializeObject<WagerrBlock>(response.Content);
			}
			catch (Exception) {/*ignored*/ }
		}

			static void SendGetBlockRequest(int blockNumber)
		{
			//Network net = WagerrNetworks.CreateMainnet();
			string uri = "https://explorer.wagerr.com/api/block/" + blockNumber;
			RestClient client = new RestClient(uri)
			{
				Timeout = 300000
			};

			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("content-type", "application/json");

			var response = client.Execute(request);
			CustomBlockModelConverted model = new CustomBlockModelConverted();
			try
			{
				model = JsonConvert.DeserializeObject<CustomBlockModelConverted>(response.Content);
			}
			catch (Exception ex) {/*ignored*/ }

			ParseModelAsSparkle(response.Content);
			//var blockById = Block.Filter();
			//var trnx = Transaction.Parse("0100000001831b5de4d2dd050fdb0058362d3df4b76e9c54e4ef1ea3049e958eba6bc005ab0100000049483045022100d00af05bf58b020d226dd31f21e960d92234507b7a8a5a00008133eceab0d18602202df8dcd911be1a4fc674c84767569ccaee0351ba5351862a78766768bb03919a01ffffffff0300000000000000000000e087df440000002321022ae7d4e253e0c867233b1c634647948750ae9c17a1a15d0aa7957432ed59c90eac40c1fc10000000001976a91450c30051bdaa6bbe870911dff538374458043d1f88ac00000000", 
			//	Network.Main);
			//var trnx = Transaction.Parse("01000000de42716b41ff8424e15a5d391e39270bc4d8fb807a7b54bc430211983a68bafd4d81b5c7fb302030b6d132fb0fb5c900cb1e9eed4accf1f478e4d58b8d3fbfa916316142901b0400e80", 
			//	Network.Main);
			var hex = HashingAlgo.WagerrHex();
			//var wagerrBlock = WagerrBlock.Parse(hex, Network.Main);
			//var wagerrBlock2 = WagerrBlock.Parse("01000000de42716b41ff8424e15a5d391e39270bc4d8fb807a7b54bc430211983a68bafd4d81b5c7fb302030b6d132fb0fb5c900cb1e9eed4accf1f478e4d58b8d3fbfa916316142901b0400e80");
			//var wagerrBlock = WagerrBlock.Parse("01000000010000000000000000000000000000000000000000000000000000000000000000ffffffff0603c6421c011dffffffff0100000000000000000000000000");
			var bitcoinModel = new NBitcoin.Block();
			try
			{
				bitcoinModel = JsonConvert.DeserializeObject<NBitcoin.Block>(response.Content);//JsonConvert.DeserializeObject<WagerrBlock>(response.Content);
			}
			catch (Exception ex) {/*ignored*/ }
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
			CustomTrxModel model = new CustomTrxModel();
			try
			{
				model = JsonConvert.DeserializeObject<CustomTrxModel>(response.Content);
			}
			catch (Exception) {/*ignored*/ }

			Transaction wagerrTrnx;
			try
			{
				wagerrTrnx = NBitcoin.Transaction.Parse("0100000001ca4b52683c9b77e81c375a2fad5bc9cf382bc06fde4f48c9b62dddba4d956b28000000006b48304502210096d942a91f9a30ecf50f1bbfd80b561a31a0da0eddaa7a735bdd345f2fba23aa02200b745e2438fd85232f64400f80f7d13df04af0eaef229853775dbd235a806bd30121024f2c027ed6a61bc78b0c311f7284c7e46febf191c2510a70ec00bd428586d788ffffffff02c0b9ee2b020000001976a9149f0242d5b780cbcba16794a27f9d90908531347b88ac0000000000000000156a13420105b26801007cc400000c3000000000000000000000",
					Network.Main);
			}
			catch (Exception) { }
			//string authenticationString, Uri address, Network network = null
			//var rpc = new NBitcoin.RPC.RPCClient(Network.Main);
			
			Uri uriOne = new Uri(@"https://explorer.wagerr.com/api/block/");
			NBitcoin.RPC.RPCClient rpc;
			try
			{
				//rpc0 = new NBitcoin.RPC.RPCClient("", "127.0.0.1:18332");
				//rpc = new NBitcoin.RPC.RPCClient("test123:test123", uriOne, Network.Main);
				rpc = new NBitcoin.RPC.RPCClient("", "149.202.56.33:55002", Network.Main);
				var blpck = rpc.GetBlock(1852102);
			}
			catch (Exception) { }

			var bitcoinModel = new NBitcoin.Block();
			try
			{
				bitcoinModel = JsonConvert.DeserializeObject<NBitcoin.Block>(response.Content);//JsonConvert.DeserializeObject<WagerrBlock>(response.Content);
			}
			catch (Exception) {/*ignored*/ }
		}

		static void ParseModelAsSparkle(string content)
        {
			dynamic obj = JsonConvert.DeserializeObject(content);
			dynamic result = obj.result;
			var block = new BlockImmutableModel
			{
				Height = result.height,
				TimestampInMs = result.time,
			};
		}

		public class BlockImmutableModel
		{
			/// <summary>
			/// Gets or sets the height of the block.
			/// </summary>
			public long Height { get; set; }

			/// <summary>
			/// Gets or sets the UNIX time of the block in milliseconds.
			/// </summary>
			public long TimestampInMs { get; set; }

			/// <summary>
			/// Gets or sets the transaction list of the block.
			/// </summary>
			public List<TransactionModel> Transactions { get; set; } = new List<TransactionModel>();
		}

		public class TransactionModel
		{
			/// <summary>
			/// Gets or sets the id of the transaction.
			/// </summary>
			public string Id { get; set; }

			/// <summary>
			/// Gets or sets the height of the transaction.
			/// </summary>
			public long Height { get; set; }

			/// <summary>
			/// Gets or sets the status of the transaction.
			/// </summary>
			//public TransactionStatus Status { get; set; }

			/// <summary>
			/// Gets or sets the recipient list of the transaction.
			/// </summary>
			//public List<RecipientModel> Recipients { get; set; } = new List<RecipientModel>();

			/// <summary>
			/// Gets or sets the source of the transaction.
			/// </summary>
			public string Source { get; set; }
		}
	}
}
