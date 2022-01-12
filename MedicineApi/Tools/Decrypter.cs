using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MedicineApi.Tools
{
    class Decrypter
    {

        /// <summary>
        /// Converting tool
        /// </summary>
        private Converting converting;
        /// <summary>
        /// Encryptning tool constructor
        /// </summary>
        public Decrypter()
        {
            converting = new Converting();
        }

        /// <summary>
        /// private key
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public byte[] ByteArray(byte[] msg, RSAParameters key)
        {
            try
            {
                using (var rsa = new RSACryptoServiceProvider(2048))
                {
                    rsa.ImportParameters(key);
                    return rsa.Decrypt(msg, true);
                }
            }
            catch (Exception)
            {
                throw new Exception("Execption : Decrypter line 30");
            }
        }
        /// <summary>
        /// private key
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Base64ToUtf8String(string msg, RSAParameters key)
        {
            try
            {
                using (var rsa = new RSACryptoServiceProvider(2048))
                {
                    var msgBytes = converting.FromBase64String(msg);
                    rsa.ImportParameters(key);
                    return converting.Utf8ByteToString(rsa.Decrypt(msgBytes, true));
                }
            }
            catch (Exception)
            {
               throw new Exception("Execption : Decrypter line 51");
            }
        }
    }
}