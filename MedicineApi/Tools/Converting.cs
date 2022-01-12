using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MedicineApi.Tools
{
    public class Converting
    {
        public byte[] Utf8ToByteArray(string msg)
        {
            if (string.IsNullOrEmpty(msg))
                throw new ArgumentNullException("ToByteArray threw exception : String is null or empty");
            return Encoding.UTF8.GetBytes(msg);
        }
        public byte[] FromBase64String(string msg)
        {
            if (string.IsNullOrEmpty(msg))
                throw new ArgumentNullException("ToByteArray threw exception : String is null or empty");
            return Convert.FromBase64String(msg);
        }

        public string ToBase64String(byte[] msg)
        {
            if (msg == null || msg.Length == 0)
                throw new ArgumentNullException("ToByteArray threw exception : String is null or empty");
            return Convert.ToBase64String(msg);
        }
        public string Utf8ByteToString(byte[] msg)
        {
            if (msg == null || msg.Length == 0)
                throw new ArgumentNullException("ToString threw exception : Byte[] is null or empty");
            return Encoding.UTF8.GetString(msg);
        }

    }
}
