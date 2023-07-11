using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BBC_ComOnline.Helper
{
    public class AppHelper
    {
        public static string GetMd5Hash(string input) 
        {
            MD5 md5Hash = MD5.Create();
            // Convierte el string del input a un arreglo de byte y captura el Hash
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            //Crea un nuevo StringBuilder para coleccionar los bytes y crea un string
            StringBuilder sb = new StringBuilder();

            //Recorremos cada byte de los datos Hasheados y formateamos cada uno a un string hexadecimal.
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            //Devolvemos el string hexadecimal.
            return sb.ToString();
        }
    }
}