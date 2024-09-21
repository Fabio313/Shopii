using System.Security.Cryptography;
using System.Text;

namespace Shopii.CrossCutting.Helper
{
    public static class HashingHelper
    {
        public static string ComputeSha256Hash(string rawData)
        {
            // Criando uma instância de SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Computando o hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convertendo o array de bytes para uma string hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
