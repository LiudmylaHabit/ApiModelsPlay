using NBitcoin;
using NBitcoin.RPC;
using System;
using System.Net;

namespace NbitcOinWagerrPlay2
{
    public static class RPCHelper
    {

        public static string ConnectToRPC()
        {
            var creds = new NetworkCredential("", "");
            var rpcCreds = RPCClient.GetRPCAuth(creds);
            return rpcCreds;
        }

        public static NBitcoin.Block GetBlockThroughRPC()
        {
			RPCClient rpc;
            rpc = new RPCClient(new NetworkCredential("admin", "admin"), new Uri("http://52.224.84.119:55003/"), Network.Main);

            return rpc.GetBlock(1852102);
        }
    }
}