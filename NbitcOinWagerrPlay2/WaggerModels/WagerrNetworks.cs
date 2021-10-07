using NBitcoin;
using NBitcoin.DataEncoders;
using System;

namespace NbitcOinWagerrPlay2
{
    public class WagerrNetworks : NetworkSetBase
    {
		private WagerrNetworks()
		{
		}

		public static WagerrNetworks Instance { get; } = new WagerrNetworks();

		public override string CryptoCode => "WGR";

		protected override NetworkBuilder CreateMainnet()
		{
			var builder = new NetworkBuilder();
			builder.SetConsensus(new Consensus()
			{
				SubsidyHalvingInterval = 43200,
				MajorityWindow = 1000,
				PowLimit = new Target(new uint256("00000fffff000000000000000000000000000000000000000000000000000000")),
				PowTargetTimespan = TimeSpan.FromDays(1),
				PowTargetSpacing = TimeSpan.FromMinutes(1),
				PowAllowMinDifficultyBlocks = false,
				CoinbaseMaturity = 20,
				PowNoRetargeting = false,
				RuleChangeActivationThreshold = 30,
				MinerConfirmationWindow = 40,
				ConsensusFactory = WagerrConsensusFactory.Instance,
				SupportSegwit = true,
			})
			.SetNetworkType(NetworkType.Mainnet)

			// https://github.com/wagerr/wagerr/blob/master/src/chainparams.cpp#L240
			.SetBase58Bytes(Base58Type.PUBKEY_ADDRESS, new byte[] { 73 })
			.SetBase58Bytes(Base58Type.SCRIPT_ADDRESS, new byte[] { 63 })
			.SetBase58Bytes(Base58Type.SECRET_KEY, new byte[] { 199 })
			.SetBase58Bytes(Base58Type.EXT_PUBLIC_KEY, new byte[] { 0x02, 0x2D, 0x25, 0x33 })
			.SetBase58Bytes(Base58Type.EXT_SECRET_KEY, new byte[] { 0x02, 0x21, 0x31, 0x2B })
			.SetMagic(0xFD612D84)
			.SetPort(55002)
			.SetRPCPort(8332)
			.SetName("wgr-main")
			.AddAlias("wagerr-mainnet")
			.AddAlias("wagerr-main")
			.AddDNSSeeds(new[] { new DNSSeedData("default", "main.seederv1.wgr.host") });

			return builder;
		}

		protected override NetworkBuilder CreateRegtest()
		{
			var builder = new NetworkBuilder();
			builder.SetConsensus(new Consensus()
			{
				SubsidyHalvingInterval = 150,
				MajorityWindow = 1000,
				PowLimit = new Target(new uint256("7fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")),
				PowTargetTimespan = TimeSpan.FromDays(1),
				PowTargetSpacing = TimeSpan.FromMinutes(1),
				PowAllowMinDifficultyBlocks = true,
				CoinbaseMaturity = 20,
				PowNoRetargeting = true,
				RuleChangeActivationThreshold = 108,
				MinerConfirmationWindow = 144,
				ConsensusFactory = WagerrConsensusFactory.Instance,
				SupportSegwit = true,
			})
			.SetNetworkType(NetworkType.Regtest)
			.SetBase58Bytes(Base58Type.PUBKEY_ADDRESS, new byte[] { 140 })
			.SetBase58Bytes(Base58Type.SCRIPT_ADDRESS, new byte[] { 19 })
			.SetBase58Bytes(Base58Type.SECRET_KEY, new byte[] { 239 })
			.SetBase58Bytes(Base58Type.EXT_PUBLIC_KEY, new byte[] { 0x04, 0x35, 0x87, 0xCF })
			.SetBase58Bytes(Base58Type.EXT_SECRET_KEY, new byte[] { 0x04, 0x35, 0x83, 0x94 })
			.SetBech32(Bech32Type.WITNESS_PUBKEY_ADDRESS, Encoders.Bech32("bcrt"))
			.SetBech32(Bech32Type.WITNESS_SCRIPT_ADDRESS, Encoders.Bech32("bcrt"))
			.SetMagic(0xfb0c6cdb)
			.SetPort(29999)
			.SetRPCPort(18443)
			.SetName("wgr-regtest")
			.AddAlias("wagerr-regtest");

			return builder;
		}

		protected override NetworkBuilder CreateTestnet()
		{
			var builder = new NetworkBuilder();
			builder.SetConsensus(new Consensus()
			{
				SubsidyHalvingInterval = 10000,
				PowLimit = new Target(new uint256("00000fffff000000000000000000000000000000000000000000000000000000")),
				PowTargetTimespan = TimeSpan.FromDays(1),
				PowTargetSpacing = TimeSpan.FromMinutes(1),
				PowAllowMinDifficultyBlocks = false,
				CoinbaseMaturity = 20,
				PowNoRetargeting = false,
				RuleChangeActivationThreshold = 30,
				MinerConfirmationWindow = 40,
				ConsensusFactory = WagerrConsensusFactory.Instance,
				SupportSegwit = true,
			})
			.SetNetworkType(NetworkType.Testnet)
			.SetBase58Bytes(Base58Type.PUBKEY_ADDRESS, new byte[] { 140 })
			.SetBase58Bytes(Base58Type.SCRIPT_ADDRESS, new byte[] { 19 })
			.SetBase58Bytes(Base58Type.SECRET_KEY, new byte[] { 239 })
			.SetBase58Bytes(Base58Type.EXT_PUBLIC_KEY, new byte[] { 0x04, 0x35, 0x87, 0xCF })
			.SetBase58Bytes(Base58Type.EXT_SECRET_KEY, new byte[] { 0x04, 0x35, 0x83, 0x94 })
			.SetBech32(Bech32Type.WITNESS_PUBKEY_ADDRESS, Encoders.Bech32("tb"))
			.SetBech32(Bech32Type.WITNESS_SCRIPT_ADDRESS, Encoders.Bech32("tb"))
			.SetMagic(0xec2eacff)
			.SetPort(29999)
			.SetRPCPort(18332)
			.SetName("wgr-test")
			.AddAlias("wgr-testnet")
			.AddAlias("wagerr-testnet")
			.AddAlias("wagerr-test")
			.AddDNSSeeds(new[] { new DNSSeedData("default", "testnet-seeder-01.wgr.host") });

			return builder;
		}
	}
}
