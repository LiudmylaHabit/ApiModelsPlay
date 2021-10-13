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
                rpc = new RPCClient(new NetworkCredential("admin", "admin"), new Uri("http://52.224.84.119:55003/"), Network.Main);
 
            var block = rpc.GetBlock(1852102);
        }
    }
}
