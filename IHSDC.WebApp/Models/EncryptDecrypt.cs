using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace IHSDC.WebApp.Models
{
    //public static string Encryption(string input)
    //{
    //    byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(input);
    //    string encrypted = Convert.ToBase64String(b);
    //    return encrypted;

    //}
    //public static string Decryption(string input)
    //{

    //    byte[] b;
    //    string decrypted;
    //    try
    //    {
    //        b = Convert.FromBase64String(input);
    //        decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
    //    }
    //    catch (FormatException fe)
    //    {
    //        decrypted = "";
    //    }
    //    return decrypted;

    //}


    
    public class EncryptDecrypt
        {

        private const string key = "!QAZ2wsx!@#$1234";
        private const string iv  = "HR$2pIjHR$2pIj12";
        //public static string key = "thisIsA32ByteKeyForAES1234567890";
        //public static string iv = "thisIs16ByteIV";

        //public static string Encryption(string plainText)
        //{
        //    using (Aes aesAlg = Aes.Create())
        //    {
        //        aesAlg.Key = Encoding.UTF8.GetBytes(key);
        //        aesAlg.IV = PadOrTruncateIV(Encoding.UTF8.GetBytes(iv), aesAlg.BlockSize / 8); // IV should be 16 bytes

        //        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        //        using (MemoryStream msEncrypt = new MemoryStream())
        //        {
        //            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        //            {
        //                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
        //                {
        //                    swEncrypt.Write(plainText);
        //                }
        //            }
        //            return Convert.ToBase64String(msEncrypt.ToArray());
        //        }
        //    }
        //}

        //public static string Decryption(string cipherText)
        //{
        //    using (Aes aesAlg = Aes.Create())
        //    {
        //        aesAlg.Key = Encoding.UTF8.GetBytes(key);
        //        aesAlg.IV = PadOrTruncateIV(Encoding.UTF8.GetBytes(iv), aesAlg.BlockSize / 8); // IV should be 16 bytes

        //        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        //        using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
        //        {
        //            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
        //            {
        //                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
        //                {
        //                    return srDecrypt.ReadToEnd();
        //                }
        //            }
        //        }
        //    }
        //}

        //private static byte[] PadOrTruncateIV(byte[] iv, int length)
        //{
        //    if (iv.Length == length)
        //    {
        //        return iv;
        //    }
        //    else if (iv.Length < length)
        //    {
        //        // Pad the IV with zeros to make it the required length 
        //        Array.Resize(ref iv, length);
        //        return iv;
        //    }
        //    else
        //    {
        //        // Truncate the IV if it's longer than the required length
        //        Array.Resize(ref iv, length);
        //        return iv;
        //    }
        //}

        public static string EncryptionData(string parameter)
        {
            byte[] parameterBytes = Encoding.UTF8.GetBytes(parameter);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                byte[] encryptedBytes = encryptor.TransformFinalBlock(parameterBytes, 0, parameterBytes.Length);

                string encryptedParameter = Convert.ToBase64String(encryptedBytes);

                return Uri.EscapeDataString(encryptedParameter);
            }
        }

        public static string DecryptionData(string encryptedParameter)
        {
            encryptedParameter = Uri.UnescapeDataString(encryptedParameter);

            byte[] encryptedBytes = Convert.FromBase64String(encryptedParameter);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

                string decryptedParameter = Encoding.UTF8.GetString(decryptedBytes);

                return decryptedParameter;


            }
        }

        public static string Encryption(string input)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(input);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;

        }
        public static string Decryption(string input)
        {

            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(input);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;

        }
    }

}