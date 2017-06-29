using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionPractice
{
    class EncryptionHelper
    {



        private RijndaelManaged CreateCipher()
        {
            RijndaelManaged cipher = new RijndaelManaged();
            cipher.KeySize = 256;
            cipher.BlockSize = 128;
            cipher.Padding = PaddingMode.ISO10126;
            cipher.Mode = CipherMode.CBC;
            byte[] key = HexToByteArray("B374A26A71490437AA024E4FADD5B497FDFF1A8EA6FF12F6FB65AF2720B59CCF");
            cipher.Key = key;
            return cipher;
        }
        public byte[] HexToByteArray(string hexString)
        {
            if (0 != (hexString.Length % 2))
            {
                throw new ApplicationException("Hex string must be multiple of 2 in length");
            }

            int byteCount = hexString.Length / 2;
            byte[] byteValues = new byte[byteCount];
            for (int i = 0; i < byteCount; i++)
            {
                byteValues[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return byteValues;
        }


        public void Encrypt(string plainText)
        {
            RijndaelManaged rijndael = CreateCipher();
            Console.WriteLine(Convert.ToBase64String(rijndael.IV));
            ICryptoTransform cryptoTransform = rijndael.CreateEncryptor();
            byte[] plain = Encoding.UTF8.GetBytes(plainText);
            byte[] cipherText = cryptoTransform.TransformFinalBlock(plain, 0, plain.Length);
            Console.WriteLine(Convert.ToBase64String(cipherText));
        }

        public void Decrypt(string iv, string cipherText)
        {
            RijndaelManaged cipher = CreateCipher();
            cipher.IV = Convert.FromBase64String(iv);
            ICryptoTransform cryptTransform = cipher.CreateDecryptor();
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            byte[] plainText = cryptTransform.TransformFinalBlock(cipherTextBytes, 0, cipherTextBytes.Length);

            Console.WriteLine(Encoding.UTF8.GetString(plainText));
        }
    }
}
