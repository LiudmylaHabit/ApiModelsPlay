using System;
using System.Collections.Generic;
using System.Text;

namespace NbitcOinWagerrPlay2
{
    public class ExpectedModelsCreator
    {
        public ApiWagerrBlockModel ExpectedWagerrAPIBlock()
        {
            var block = new ApiWagerrBlockModel()
            {
                Block = new Block()
                {
                    Txs = new List<string>()
                    {
                        // Empty list is enough?
                        "ca07db573671a7f456d2088091ca8521a1537fa028414fb7bf62a733b87c0aca",
                        "782905303ae6f3f6329984b65b40a45d138e0613ebb71f3f9909826286284066"
                    },
                    Rpctxs = new List<Rpctx>()
                    {
                        new Rpctx() //first rpcTx
                        {
                            Txid = "transactionID",
                            //Txid = "ca07db573671a7f456d2088091ca8521a1537fa028414fb7bf62a733b87c0aca"
                            Version = 1,
                            Size = 67,
                            Locktime = 0,
                            Vin = new List<RpctxVin>()
                            {
                                new RpctxVin()
                                {
                                    Coinbase = "Coinbase", // "03cd421c024501"
                                    Sequence = 4294967295
                                }
                            },
                            Vout = new List<RpctxVout>()
                            {
                                new RpctxVout()
                                {
                                    Value = 0,
                                    N = 0,
                                    ScriptPubKey = new ScriptPubKey()
                                    {
                                        Asm = "",
                                        Hex = "",
                                        Type = "nonstandard"
                                    }
                                }
                            },
                            Hex = ""//"01000000010000000000000000000000000000000000000000000000000000000000000000ffffffff0703cd421c024501ffffffff0100000000000000000000000000"
                        },
                        new Rpctx()
                        {
                            Txid = "TransactionId",
                            Version = 1,
                            Size = 211,
                            Locktime = 0,
                            Vin = new List<RpctxVin>()
                            {
                               // Txid = "",
                               // Vout = 1,
                               // ScriptSig = new ScriptSig
                              //  {
                              //      Asm = "",
                              //      Hex = ""
                              //  } 

                            }
                        }
                       
                    },

                }
            };
            return block;
        }
    }
}
