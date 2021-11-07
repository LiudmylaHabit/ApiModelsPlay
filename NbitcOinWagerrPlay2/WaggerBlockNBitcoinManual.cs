using System;
using System.Collections.Generic;
using System.Text;

namespace NbitcOinWagerrPlay2
{
    public class WaggerBlockNBitcoinManual
    {
        public HeaderField Header { get; set; }
        public bool HeaderOnly { get; set; }
        public List<Transaction> Transactions { get; set; }

        public class Bits
        {
            public double Difficulty { get; set; }
        }

        public class HashMerkleRoot
        {
            public int Size { get; set; }
        }

        public class HashPrevBlock
        {
            public int Size { get; set; }
        }

        public class NAccumulatorCheckpoint
        {
            public int Size { get; set; }
        }

        public class HeaderField
        {
            public Bits Bits { get; set; }
            public int Nonce { get; set; }
            public HashMerkleRoot HashMerkleRoot { get; set; }
            public int Version { get; set; }
            public HashPrevBlock HashPrevBlock { get; set; }
            public string BlockTime { get; set; }
            public bool IsNull { get; set; }
            public NAccumulatorCheckpoint NAccumulatorCheckpoint { get; set; }
        }

        public class TotalOut
        {
            public object Satoshi { get; set; }
        }

        public class LockTime
        {
            public int Value { get; set; }
            public int Height { get; set; }
            public bool IsHeightLock { get; set; }
            public bool IsTimeLock { get; set; }
        }

        public class Input
        {
            public bool IsFinal { get; set; }
            public string PrevOut { get; set; }
            public string ScriptSig { get; set; }
            public string Sequence { get; set; }
            public string WitScript { get; set; }
        }

        public class Value
        {
            public object Satoshi { get; set; }
        }

        public class Output
        {
            public string ScriptPubKey { get; set; }
            public Value Value { get; set; }
        }

        public class Transaction
        {
            public bool RBF { get; set; }
            public int Version { get; set; }
            public TotalOut TotalOut { get; set; }
            public LockTime LockTime { get; set; }
            public List<Input> Inputs { get; set; }
            public List<Output> Outputs { get; set; }
            public bool HasWitness { get; set; }
            public bool IsCoinBase { get; set; }
        }         
    }
}
