using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MedicineApi.Tools
{
    public class RngGenerator
    {
        public byte[] GetRandomNumber(int length)
        {
            try
            {
                using (var randomNumberGenerator = new RNGCryptoServiceProvider())
                {
                    var randomNumber = new byte[length];
                    randomNumberGenerator.GetBytes(randomNumber);
                    return randomNumber;
                }
            }
            catch (Exception)
            {
                throw new Exception("Execption : Decrypter line 9");
            }
        }

        public RSAParameters[] GenerateKey()
        {
            try
            {
                using (var rsa = new RSACryptoServiceProvider(2048))
                {
                    //dont want to store key in key container
                    rsa.PersistKeyInCsp = false;
                    return new RSAParameters[] { rsa.ExportParameters(false), rsa.ExportParameters(true) };
                }
            }
            catch (Exception)
            {

                throw new Exception("Execption : RngGenerator line 21");
            }
        }
    }
}
