using NBitcoin;

namespace NbitcOinWagerrPlay2
{
    public class WagerrBlock : NBitcoin.Block
    {
		[System.Obsolete]
		public WagerrBlock(WagerrBlockHeader header)
			: base(header)
		{
		}

		public ConsensusFactory GetConsensusFactory()
		{
			return WagerrConsensusFactory.Instance;
		}
	}
}
