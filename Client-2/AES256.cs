using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Client_2
{
    class AES256
    {
        public string Encrypt(string iPlainStr, string iCompleteEncodedKey, string dateTime)
        {
            string time = dateTime.Substring(0, 16);

            RijndaelManaged aes256 = new RijndaelManaged();
            aes256.KeySize = 256;
            aes256.BlockSize = 128;
            aes256.Mode = CipherMode.CBC;
            aes256.Padding = PaddingMode.None;
            aes256.IV = Encoding.ASCII.GetBytes(time);
            aes256.Key = Encoding.ASCII.GetBytes(Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(iCompleteEncodedKey)));
            byte[] plainText = UTF8Encoding.UTF8.GetBytes(iPlainStr);
            ICryptoTransform crypto = aes256.CreateEncryptor();
            byte[] cipherText = crypto.TransformFinalBlock(plainText, 0, plainText.Length);
            return Convert.ToBase64String(cipherText);
        }

        public string Decrypt(string iEncryptedText, string iCompleteEncodedKey, string dateTime)
        {
            string time = dateTime.Substring(0, 16);

            RijndaelManaged aes256 = new RijndaelManaged();
            aes256.KeySize = 256;
            aes256.BlockSize = 128;
            aes256.Mode = CipherMode.CBC;
            aes256.Padding = PaddingMode.None;
            aes256.IV = Encoding.ASCII.GetBytes(time);
            aes256.Key = Encoding.ASCII.GetBytes(Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(iCompleteEncodedKey)));
            ICryptoTransform decrypto = aes256.CreateDecryptor();
            byte[] encryptedBytes = Convert.FromBase64CharArray(iEncryptedText.ToCharArray(), 0, iEncryptedText.Length);
            return UTF8Encoding.UTF8.GetString(decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length));
        }
    }
}
