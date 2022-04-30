using System.Security.Cryptography;
using System.Text;

namespace ApiEmpresas.Services.Utils
{
    public class Criptografia
    {
        public static string GetMD5(string valor)
        {
            var md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(valor));

            var result = string.Empty;
            foreach (var item in hash)
                result += item.ToString("x2"); //hexadecimal

            return result;
        }
    }
}



