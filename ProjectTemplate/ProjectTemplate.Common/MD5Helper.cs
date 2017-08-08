using System.Security.Cryptography;
using System.Text;

namespace ProjectTemplate.Common
{
    public static class MD5Helper
    {
        public static string Encrypt(string p)
        {
            p += "ZzbHjf20170709";
            MD5 md5 = MD5.Create();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(p);
            byte[] md5Buffer = md5.ComputeHash(md5.ComputeHash(buffer));
            md5.Clear();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < md5Buffer.Length; i++)
            {
                //x2：把每个数字转换为16进制，并保存为2位数
                sb.Append(md5Buffer[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}