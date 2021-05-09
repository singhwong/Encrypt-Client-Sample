using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptKeyClient.Services
{
    public class EncryptService:IEncryptService
    {

        public string Decrypt(string str, string secret)
        {
            byte[] key = Encoding.Unicode.GetBytes(secret);
            byte[] data = Convert.FromBase64String(str);
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();
            MemoryStream MStream = new MemoryStream();
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);
            CStream.Write(data, 0, data.Length);
            CStream.FlushFinalBlock();
            byte[] temp = MStream.ToArray();
            CStream.Close();
            MStream.Close();
            return Encoding.Unicode.GetString(temp);
        }

        public string Encrypt(string str, string secret)
        {
            byte[] key = Encoding.Unicode.GetBytes(secret);
            byte[] data = Encoding.Unicode.GetBytes(str);
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();
            MemoryStream MStream = new MemoryStream();
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);
            CStream.Write(data, 0, data.Length);
            CStream.FlushFinalBlock();
            byte[] temp = MStream.ToArray();
            CStream.Close();
            MStream.Close();
            return Convert.ToBase64String(temp);
        }
    }
}
