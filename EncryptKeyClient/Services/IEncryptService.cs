using System;
using System.Threading.Tasks;

namespace EncryptKeyClient.Services
{
    public interface IEncryptService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <param name="secret">自定义的4位字符，用于加密</param>
        /// <returns></returns>
        string Encrypt(string str,string secret);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <param name="secret">自定义的4位字符，用于解密(与加密时使用的相同字符！)</param>
        /// <returns></returns>
        string Decrypt(string str,string secret);
    }
}
