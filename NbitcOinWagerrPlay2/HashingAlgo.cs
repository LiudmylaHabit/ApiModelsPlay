using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace NbitcOinWagerrPlay2
{
    public static class HashingAlgo
    {
        public static void MainHash()
        {
            //Block 125552
            //https://en.bitcoin.it/wiki/Block_hashing_algorithm
            Debug.Assert(BitConverter.IsLittleEndian == true);
            Byte[] version = BitConverter.GetBytes(1);
            Byte[] prevBlockHash = SwapOrder(StringToByteArray("00000000000008a3a41b85b8b29ad444def299fee21793cd8b9e567eab02cd81")); //предыдущий блок (height -1)
            Byte[] rootHash = SwapOrder(StringToByteArray("2b12fcf1b09288fcaff797d71e950e71ae42b91e8bdb2304758dfcffc2b620e3")); //корень Меркла

            Byte[] time = BitConverter.GetBytes(1305998791); // 21.05.2011 17:26:31 - метка времени последнего блока
            Byte[] bits = BitConverter.GetBytes(440711666); // поле "биты" 440 711 666
            Byte[] nonce = BitConverter.GetBytes(2504433986); //нонс - 2 504 433 986

            //Check byte lengths
            Debug.Assert(version.Length == 4);
            Debug.Assert(time.Length == 4);
            Debug.Assert(bits.Length == 4);
            Debug.Assert(nonce.Length == 4);


            Debug.Assert(prevBlockHash.Length == 32);
            Debug.Assert(rootHash.Length == 32);

            //concat it all
            Byte[] hex_header = new Byte[80];
            version.CopyTo(hex_header, 0);
            prevBlockHash.CopyTo(hex_header, 4);
            rootHash.CopyTo(hex_header, 36);
            time.CopyTo(hex_header, 68);
            bits.CopyTo(hex_header, 72);
            nonce.CopyTo(hex_header, 76);

            using (SHA256Managed SHAhash = new SHA256Managed())
            {
                Byte[] pass1 = SHAhash.ComputeHash(hex_header);
                Byte[] pass2 = SHAhash.ComputeHash(pass1);

                Byte[] final = SwapOrder(pass2);

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder stringBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int ii = 0; ii < final.Length; ii++)
                {
                    stringBuilder.Append(final[ii].ToString("x2"));
                }

                // Return the hexadecimal string.
                Console.WriteLine(stringBuilder.ToString());

                //http://blockexplorer.com/block/00000000000000001e8d6829a8a21adc5d38d0a473b144b6765798e61f98bd1d
                Debug.Assert(stringBuilder.ToString() == "00000000000000001e8d6829a8a21adc5d38d0a473b144b6765798e61f98bd1d");
            }

            Console.ReadKey();
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static Byte[] SwapOrder(Byte[] input)
        {
            return input.Reverse().ToArray();
        }

        public static string WagerrHex()
        {
            Byte[] version = BitConverter.GetBytes(1);
            Byte[] prevBlockHash = SwapOrder(StringToByteArray("de42716b41ff8424e15a5d391e39270bc4d8fb807a7b54bc430211983a68bafd")); //предыдущий блок (height -1)
            Byte[] rootHash = SwapOrder(StringToByteArray("4d81b5c7fb302030b6d132fb0fb5c900cb1e9eed4accf1f478e4d58b8d3fbfa9")); //корень Меркла

            Byte[] time = BitConverter.GetBytes(1631614290); // 21.05.2011 17:26:31 - метка времени последнего блока
            Byte[] bits = BitConverter.GetBytes(453247208); // поле "биты" 440 711 666
            Byte[] nonce = BitConverter.GetBytes(0); //нонс - 2 504 433 986

            //Check byte lengths
            Debug.Assert(version.Length == 4);
            Debug.Assert(time.Length == 4);
            Debug.Assert(bits.Length == 4);
            Debug.Assert(nonce.Length == 4);


            Debug.Assert(prevBlockHash.Length == 32);
            Debug.Assert(rootHash.Length == 32);

            //concat it all
            Byte[] hex_header = new Byte[80];
            version.CopyTo(hex_header, 0);
            prevBlockHash.CopyTo(hex_header, 4);
            rootHash.CopyTo(hex_header, 36);
            time.CopyTo(hex_header, 68);
            bits.CopyTo(hex_header, 72);
            nonce.CopyTo(hex_header, 76);
            Console.WriteLine(hex_header);
            try
            {
                var block = WagerrBlock.Load(hex_header, NBitcoin.Network.Main);

            }
            catch (Exception) {}

            try
            {
                WagerrConsensusFactory cF = new WagerrConsensusFactory();
                var block1 = WagerrBlock.Load(hex_header, cF);

            }
            catch (Exception) { }

            using (SHA256Managed SHAhash = new SHA256Managed())
            {
                Byte[] pass1 = SHAhash.ComputeHash(hex_header);
                Byte[] pass2 = SHAhash.ComputeHash(pass1);

                Byte[] final = SwapOrder(pass2);

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder stringBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int ii = 0; ii < final.Length; ii++)
                {
                    stringBuilder.Append(final[ii].ToString("x2"));
                }

                // Return the hexadecimal string.
                Console.WriteLine(stringBuilder.ToString());
            }

            using (SHA256Managed SHAhash = new SHA256Managed())
            {
                Byte[] final = SwapOrder(hex_header);
                StringBuilder stringBuilder = new StringBuilder();
                for (int ii = 0; ii < final.Length; ii++)
                {
                    stringBuilder.Append(final[ii].ToString("x2"));
                }
                Console.WriteLine("New attemp");
                Console.WriteLine(stringBuilder.ToString());
            }
            return hex_header.ToString();
        }
    }     
}