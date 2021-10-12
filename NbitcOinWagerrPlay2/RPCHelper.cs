using NBitcoin;
using NBitcoin.RPC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NbitcOinWagerrPlay2
{
    public static class RPCHelper
    {

        public static string ConnectToRPC()
        {
            var creds = new NetworkCredential("", "");
            var rpcClient = new RPCClient(Network.Main);
            var rpcCreds = RPCClient.GetRPCAuth(creds);
            return rpcCreds;
        }

        public static void GetBlockThroughRPC()
        {
			RPCClient rpc;
			try
			{
				//http://52.224.84.119:55003/
				//rpc0 = new NBitcoin.RPC.RPCClient("", "127.0.0.1:18332");
				//rpc = new NBitcoin.RPC.RPCClient("test123:test123", uriOne, Network.Main);
				rpc = new RPCClient(ConnectToRPC(), "http://52.224.84.119:55003/", Network.Main);
				var blpck = rpc.GetBlock(1852102);
			}
			catch (Exception) { }
            //try
            //{
            //    var transaction = rpc.GetRawTransactionInfo("960d852781bdabef826617530e0d09444e6d2b806a5c224a9c7667f2cae202ad");
            //}
			
		}
    }
}
