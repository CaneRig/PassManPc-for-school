using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace PasManPC.Core.Security
{
    public static class Crypting
    {
        public static byte[] Bin_AesEncrypt(byte[] plainText, byte[] Key, byte[] IV)
        {

            if (plainText.Length ==0) return new byte[0];

            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                if (IV != null)
                {
                    Array.Resize(ref IV, aesAlg.BlockSize/8);
                    aesAlg.IV = IV;
                }

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (BinaryWriter swEncrypt = new BinaryWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;
        }
        public static byte[] Bin_AesDecrypt(byte[] cipherText, byte[] Key, byte[] IV)
        {

            if (cipherText.Length == 0) return new byte[0];

            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            byte[] plaintext = new byte[cipherText.Length];

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                if (IV != null)
                {
                    Array.Resize(ref IV, aesAlg.BlockSize / 8);
                    aesAlg.IV = IV;
                }

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (BinaryReader srDecrypt = new BinaryReader(csDecrypt))
                        {
                            int len = srDecrypt.Read(plaintext,0 ,cipherText.Length);

                            Array.Resize(ref plaintext, len);
                        }
                    }
                }
            }

            return plaintext;
        }


        public static byte[] s2b_Aes(string plainText, byte[] Key, byte[] IV)
        {

            if (plainText == string.Empty) return new byte[0];

            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                if (IV != null)
                {
                    Array.Resize(ref IV, aesAlg.BlockSize/8);
                    aesAlg.IV = IV;
                }

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;
        }
        public static string b2s_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {

            if (cipherText.Length == 0) return "";

            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            string plaintext = null;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                if (IV != null)
                {
                    Array.Resize(ref IV, aesAlg.BlockSize / 8);
                    aesAlg.IV = IV;
                }

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
        
    }
}
