using System;
using System.Collections.Generic;

namespace NbitcOinWagerrPlay2
{
    public class WaggerBlockNBitcoinManual
    {
        public HeaderField Header { get; set; }
        public bool HeaderOnly { get; set; }
        public List<Transaction> Transactions { get; set; }

        public bool CheckEquality(NBitcoin.Block block)
        {
            bool transactionsEquality = true;
            foreach(var transaction in this.Transactions)
            {
                if (!transaction.CheckEquality(block.Transactions[0]))
                {
                    transactionsEquality = false;
                    break;
                }
            }
            return this.Header.CheckEquality(block.Header) && block.HeaderOnly.Equals(this.HeaderOnly) && transactionsEquality;
        }
    }

    public class Bits
    {
        public double Difficulty { get; set; }

        public bool CheckEquality(NBitcoin.Target bits)
        {
            return this.Difficulty == bits.Difficulty;
        }
    }

    public class HashMerkleRoot
    {
        public int Size { get; set; }

        public bool CheckEquality(NBitcoin.BlockHeader header)
        {
            return this.Size.Equals(header.HashMerkleRoot.Size);
        }
    }

    public class HashPrevBlock
    {
        public int Size { get; set; }

        public bool CheckEquality(NBitcoin.BlockHeader header)
        {
            return this.Size.Equals(header.HashPrevBlock.Size);
        }
    }

    public class NAccumulatorCheckpoint
    {
        public int Size { get; set; }
        // What to Check?
        //public bool CheckCompares(NBitcoin.BlockHeader header)
        //{
        //    return this.Size.Equals(header.NA.Size);
        //}
    }

    public class HeaderField
    {
        public Bits Bits { get; set; }
        public uint Nonce { get; set; }
        public HashMerkleRoot HashMerkleRoot { get; set; }
        public int Version { get; set; }
        public HashPrevBlock HashPrevBlock { get; set; }
        public string BlockTime { get; set; }
        public bool IsNull { get; set; }
        public NAccumulatorCheckpoint NAccumulatorCheckpoint { get; set; }

        public bool CheckEquality(NBitcoin.BlockHeader header)
        {
            return this.Bits.CheckEquality(header.Bits) && header.Nonce.Equals(this.Nonce) && this.HashMerkleRoot.CheckEquality(header)
                && header.Version.Equals(this.Version) && header.BlockTime.Equals(DateTimeOffset.Parse(this.BlockTime)) && header.IsNull.Equals(this.IsNull);
        }
    }

    public class TotalOut
    {
        public long Satoshi { get; set; }

        public bool CheckEquality(NBitcoin.Money totalOut)
        {
            return this.Satoshi.Equals(totalOut.Satoshi);
        }
    }

    public class LockTime
    {
        public uint Value { get; set; }
        public int Height { get; set; }
        public bool IsHeightLock { get; set; }
        public bool IsTimeLock { get; set; }

        internal bool CheckEquality(NBitcoin.LockTime lockTime)
        {
            return this.Value == lockTime.Value && this.Height == lockTime.Height
                && this.IsHeightLock == lockTime.IsHeightLock && this.IsHeightLock == lockTime.IsHeightLock;
        }
    }

    public class Input
    {
        public bool IsFinal { get; set; }
        public string PrevOut { get; set; }
        public string ScriptSig { get; set; }
        public string Sequence { get; set; }
        public string WitScript { get; set; }

        public bool CheckEquality(NBitcoin.TxIn input)
        {
            return this.IsFinal == input.IsFinal && this.PrevOut == input.PrevOut.ToString() 
                && this.ScriptSig == input.ScriptSig.ToString() && this.Sequence == input.Sequence.ToString()
                && this.WitScript == input.WitScript.ToString();
        }
    }

    public class Output
    {
        public string ScriptPubKey { get; set; }
        public TotalOut Value { get; set; }

        internal bool CheckEquality(NBitcoin.TxOut actualOutput)
        {
            return this.ScriptPubKey == actualOutput.ScriptPubKey.ToString()
                && this.Value.CheckEquality(actualOutput.Value.Satoshi);
        }
    }

    public class Transaction
    {
        public bool RBF { get; set; }
        public uint Version { get; set; }
        public TotalOut TotalOut { get; set; }
        public LockTime LockTime { get; set; }
        public List<Input> Inputs { get; set; }
        public List<Output> Outputs { get; set; }
        public bool HasWitness { get; set; }
        public bool IsCoinBase { get; set; }

        public bool CheckEquality(NBitcoin.Transaction transaction)
        {

            bool equal = true;
            bool equalOutputs = true;
            bool equalInputs = true;
            equal = this.RBF.Equals(transaction.RBF);
            equal = this.Version.Equals(transaction.Version);
            equal = this.TotalOut.CheckEquality(transaction.TotalOut);
            equal = this.LockTime.CheckEquality(transaction.LockTime);

            foreach (var actualInput in transaction.Inputs)
            {
                foreach (var expectedInput in this.Inputs)
                {
                    if(!expectedInput.CheckEquality(actualInput))
                    {
                        equalInputs = false;
                        break;
                    }

                }
            }

            foreach (var actualOutput in transaction.Outputs)
            {
                foreach (var expectedOutput in this.Outputs)
                {
                    if (!expectedOutput.CheckEquality(actualOutput))
                    {
                        equalOutputs = false;
                        break;
                    }
                }
            }

            equal = this.HasWitness.Equals(transaction.HasWitness);
            equal = this.IsCoinBase.Equals(transaction.IsCoinBase);
            return equal && equalInputs && equalOutputs;
        }
    }
}