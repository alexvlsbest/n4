using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;
using System.Numerics;

namespace Crypters
{
    class Crypter
    {
        int KeySize;

        byte[] Key;
        byte[] EncodedValue;

        public Crypter(int KeySize)
        {
            this.KeySize = KeySize;
            Key = new byte[this.KeySize];
            EncodedValue = new byte[this.KeySize];
            KeyGen();
        }

        public void KeyGen()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(Key);
        }

        public BigInteger GetKeyAsNumber()
        {
            BigInteger number = new BigInteger(Key);
            return number;
        }

        public BigInteger GetEncodedValueAsNumber()
        {
            BigInteger number = new BigInteger(EncodedValue);
            return number;
        }

        public void Encode(byte content)
        {
            byte[] contentArray = new byte[KeySize];
            BigInteger x = new BigInteger(contentArray);
            x = content;
            x.ToByteArray().CopyTo(contentArray, 0);
            HMACSHA256 hmac = new HMACSHA256(Key);
            hmac.Initialize();
            hmac.ComputeHash(contentArray).CopyTo(EncodedValue, 0);
        }
    }



}
