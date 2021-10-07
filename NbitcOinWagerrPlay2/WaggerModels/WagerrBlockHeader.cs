using NBitcoin;
using System;

namespace NbitcOinWagerrPlay2
{
    public class WagerrBlockHeader : NBitcoin.BlockHeader
    {
		private uint256 _nAccumulatorCheckpoint;

		[Obsolete]
		public WagerrBlockHeader()
		{
			SetNull();
		}

		public WagerrBlockHeader(string hex, Network network)
		: this(hex, network?.Consensus?.ConsensusFactory ?? throw new ArgumentNullException(nameof(network)))
		{
		}

		public WagerrBlockHeader(string hex, Consensus consensus)
			: this(hex, consensus?.ConsensusFactory ?? throw new ArgumentNullException(nameof(consensus)))
		{
		}

		public WagerrBlockHeader(string hex, ConsensusFactory consensusFactory)
			: base(hex, consensusFactory)
		{
		}

		public uint256 NAccumulatorCheckpoint
		{
			get => _nAccumulatorCheckpoint;
			set => _nAccumulatorCheckpoint = value;
		}

		public override void ReadWrite(BitcoinStream stream)
		{
			stream.ReadWrite(ref nVersion);
			stream.ReadWrite(ref hashPrevBlock);
			stream.ReadWrite(ref hashMerkleRoot);
			stream.ReadWrite(ref nTime);
			stream.ReadWrite(ref nBits);
			stream.ReadWrite(ref nNonce);

			if (nVersion > 3 && nVersion < 7)
			{
				stream.ReadWrite(ref _nAccumulatorCheckpoint);
			}
		}

		protected override void SetNull()
		{
			base.SetNull();
			_nAccumulatorCheckpoint = 0uL;
		}
	}
}
