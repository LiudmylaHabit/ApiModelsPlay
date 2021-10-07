using NBitcoin;

namespace NbitcOinWagerrPlay2
{
    public class WagerrConsensusFactory : ConsensusFactory
    {
		public WagerrConsensusFactory()
		{
		}

		public static WagerrConsensusFactory Instance { get; } = new WagerrConsensusFactory();

		public override BlockHeader CreateBlockHeader()
		{
			return new WagerrBlockHeader();
		}

		public override NBitcoin.Block CreateBlock()
		{
			return new WagerrBlock(new WagerrBlockHeader());
		}
	}
}
