using System;
using System.Security.Cryptography;
using System.Text;

namespace PublishHomework
{
    public static class Md5Helper
    {
        public static string GetMD5Sign(string schoolId, string classesId,string fromId,string timestamp)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();           
            string enc_key = "efe9634f0dc0ad3184a369a22be24d3d";
            string str = $"schoolId={schoolId}&fromId={fromId}&timestamp={timestamp}&classesId={classesId}||{enc_key}";
            byte[] signByte;          
            signByte = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sign = new StringBuilder();
            for(int i = 0; i < signByte.Length; i++)
            {
                sign.Append(signByte[i].ToString("X").PadLeft(2, '0'));
            }
            return sign.ToString().ToLower();
        }        
    }
}
