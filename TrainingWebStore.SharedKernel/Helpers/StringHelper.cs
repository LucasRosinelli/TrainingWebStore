using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TrainingWebStore.SharedKernel.Helpers
{
    public class StringHelper
    {
        private static readonly string EncryptSalt = "|20b7e76f-9867-4c5c-b995-ebea43c590cf";

        public static string Encrypt(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            value = string.Concat(value, EncryptSalt);
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(value));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString(Constants.StringFormat_x2));
            }

            return sb.ToString();
        }
    }
}