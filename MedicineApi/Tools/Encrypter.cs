using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MedicineApi.Tools
{
    class Encrypter
    {
        private Converting convertTool;
        /// <summary>
        /// Construct an object of encryptning class
        /// </summary>
        public Encrypter()
        {
            convertTool = new Converting();
        }

        /// <summary>
        /// Encrypt string to byte array using Rsa
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public byte[] AsByteArray(string msg, RSAParameters key)
        {
            var msgBytes = convertTool.Utf8ToByteArray(msg);
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.ImportParameters(key);
                return rsa.Encrypt(msgBytes, true);
            }
        }
        /// <summary>
        /// Encrypt string to bytearary return as utf8string
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string AsBase64String(string msg, RSAParameters key)
        {
            var msgBytes = convertTool.Utf8ToByteArray(msg);

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.ImportParameters(key);

                var encryptData = rsa.Encrypt(msgBytes, true);

                return convertTool.ToBase64String(encryptData);
            }
        }

    }
}
