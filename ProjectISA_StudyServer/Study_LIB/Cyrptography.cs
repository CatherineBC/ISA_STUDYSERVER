using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Study_LIB
{
    public class Cyrptography
    {
        public static string Encryption(string plainText, string key)
        {
            //membuat objek AES dengan kunci dan text yg dimasukkan 
            using (Aes aes = Aes.Create())
            {
                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = new byte[16]; //initial vector di set ke 0 (16 Karakter)

                //membuat objek enkripsi
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                //melakukan enkripsi
                byte[] cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

                //konversi byte array hasil enkripsi menjadi cipher text
                string cipherText = Convert.ToBase64String(cipherBytes);
                return cipherText;
            }
        }

        public static string Decryption(string cipherText, string key)
        {
            //membuat objek AES dengan kunci yg dimasukkan
            using (Aes aes = Aes.Create())
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = new byte[16]; //initial vector di set ke 0 (16 Karakter)

                //membuat objek enkripsi
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                //melakukan dekripsi
                byte[] plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);

                //konversi byte array hasil enkripsi menjadi cipher text
                string plainText = Encoding.UTF8.GetString(plainBytes);
                return plainText;
            }
        }
    }
}
