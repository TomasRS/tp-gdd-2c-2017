﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace PagoAgilFrba.Utils
{
    public class HashSHA256
    {
        public static String getHash(String password)
        {
            SHA256Managed encrypted = new SHA256Managed();
            string hash = String.Empty;
            byte[] encriptacion = encrypted.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
            foreach (byte bit in encriptacion)
            {
                hash += bit.ToString("x2");
            }
            return hash;
        }
    }
}
