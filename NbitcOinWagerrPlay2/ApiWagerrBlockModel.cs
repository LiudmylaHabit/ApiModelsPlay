using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace NbitcOinWagerrPlay2
{
    public class ApiWagerrBlockModel
    {
		[JsonRequired]
		[JsonProperty("block")]
		public Block Block { get; set; }

		[JsonRequired]
		[JsonProperty("txs")]
		public List<Tx> Txs { get; set; }
	}

	public partial class Block
	{
		[JsonRequired]
		[JsonProperty("txs")]
		public List<string> Txs { get; set; }

		[JsonRequired]
		[JsonProperty("rpctxs")]
		public List<Rpctx> Rpctxs { get; set; }

		[JsonRequired]
		[JsonProperty("_id")]
		public string Id { get; set; }

		[JsonRequired]
		[JsonProperty("hash")]
		public string Hash { get; set; }

		[JsonRequired]
		[JsonProperty("height")]
		public long Height { get; set; }

		[JsonRequired]
		[JsonProperty("bits")]
		public string Bits { get; set; }

		[JsonRequired]
		[JsonProperty("confirmations")]
		public long Confirmations { get; set; }

		[JsonRequired]
		[JsonProperty("createdAt")]
		public DateTimeOffset CreatedAt { get; set; }

		[JsonRequired]
		[JsonProperty("diff")]
		public string Diff { get; set; }

		[JsonRequired]
		[JsonProperty("merkle")]
		public string Merkle { get; set; }

		[JsonRequired]
		[JsonProperty("nonce")]
		public long Nonce { get; set; }

		[JsonRequired]
		[JsonProperty("prev")]
		public string Prev { get; set; }

		[JsonRequired]
		[JsonProperty("size")]
		public long Size { get; set; }

		[JsonRequired]
		[JsonProperty("ver")]
		public long Ver { get; set; }
	}

	public partial class Rpctx
	{
		[JsonProperty("txid")]
		public string Txid { get; set; }

		[JsonProperty("version")]
		public long Version { get; set; }

		[JsonProperty("size")]
		public long Size { get; set; }

		[JsonProperty("locktime")]
		public long Locktime { get; set; }

		[JsonProperty("vin")]
		public List<RpctxVin> Vin { get; set; }

		[JsonProperty("vout")]
		public List<RpctxVout> Vout { get; set; }

		[JsonProperty("hex")]
		public string Hex { get; set; }
	}

	public partial class RpctxVin
	{
		[JsonProperty("coinbase", NullValueHandling = NullValueHandling.Ignore)]
		public string Coinbase { get; set; }

		[JsonProperty("sequence")]
		public long Sequence { get; set; }

		[JsonProperty("txid", NullValueHandling = NullValueHandling.Ignore)]
		public string Txid { get; set; }

		[JsonProperty("vout", NullValueHandling = NullValueHandling.Ignore)]
		public long? Vout { get; set; }

		[JsonProperty("scriptSig", NullValueHandling = NullValueHandling.Ignore)]
		public ScriptSig ScriptSig { get; set; }
	}

	public partial class ScriptSig
	{
		[JsonProperty("asm")]
		public string Asm { get; set; }

		[JsonProperty("hex")]
		public string Hex { get; set; }
	}

	public partial class RpctxVout
	{
		[JsonProperty("value")]
		public double Value { get; set; }

		[JsonProperty("n")]
		public long N { get; set; }

		[JsonProperty("scriptPubKey")]
		public ScriptPubKey ScriptPubKey { get; set; }
	}

	public partial class ScriptPubKey
	{
		[JsonProperty("asm")]
		public string Asm { get; set; }

		[JsonProperty("hex")]
		public string Hex { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("reqSigs", NullValueHandling = NullValueHandling.Ignore)]
		public long? ReqSigs { get; set; }

		[JsonProperty("addresses", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Addresses { get; set; }
	}

	public partial class Tx
	{
		[JsonProperty("blockHash")]
		public string BlockHash { get; set; }

		[JsonProperty("blockHeight")]
		public long BlockHeight { get; set; }

		[JsonProperty("createdAt")]
		public DateTimeOffset CreatedAt { get; set; }

		[JsonProperty("txId")]
		public string TxId { get; set; }

		[JsonProperty("version")]
		public long Version { get; set; }

		[JsonProperty("vin")]
		public List<TxVin> Vin { get; set; }

		[JsonProperty("vout")]
		public List<TxVout> Vout { get; set; }
	}

	public partial class TxVin
	{
		[JsonProperty("_id")]
		public string Id { get; set; }

		[JsonProperty("sequence")]
		public long Sequence { get; set; }

		[JsonProperty("txId")]
		public string TxId { get; set; }

		[JsonProperty("vout")]
		public long Vout { get; set; }

		[JsonProperty("address")]
		public string Address { get; set; }

		[JsonProperty("value")]
		public double Value { get; set; }

		[JsonProperty("isZcSpend")]
		public bool IsZcSpend { get; set; }
	}

	public partial class TxVout
	{
		[JsonProperty("_id")]
		public string Id { get; set; }

		[JsonProperty("address")]
		public string Address { get; set; }

		[JsonProperty("n")]
		public long N { get; set; }

		[JsonProperty("value")]
		public double Value { get; set; }
	}
}
