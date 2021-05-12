using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MoneyChecker
{
    class Encryptor
    {
        private byte[] _Key; //секретный ключ
        private byte[] _IV; //вектор инициализации
        private DESCryptoServiceProvider _dESCryptoServiceProvider;
        private string Key
        {
            set
            {
                if (value.Length == 8)
                {
                    _Key = ASCIIEncoding.ASCII.GetBytes(value);
                }
                else throw new ArgumentException("need 8 Letters");
            }
        }
        private string IV
        {
            set
            {
                if (value.Length == 8)
                {
                    _IV = ASCIIEncoding.ASCII.GetBytes(value);
                }
                else throw new ArgumentException("need 8 Letters");
            }
        }

        public Encryptor(string key, string iv)
        {
            Key = key;
            IV = iv;
            _dESCryptoServiceProvider = new DESCryptoServiceProvider();
            _dESCryptoServiceProvider.Key = _Key;
            _dESCryptoServiceProvider.IV = _IV;
        }
        public string Encrypt(string data)
        {
            ICryptoTransform ecryptor = _dESCryptoServiceProvider.CreateEncryptor();
            byte[] IDtoBytes = Encoding.Unicode.GetBytes(data);
            byte[] encryptedID = ecryptor.TransformFinalBlock(IDtoBytes, 0, IDtoBytes.Length);

            return Convert.ToBase64String(encryptedID);
        }
        public string Decrypt(string data)
        {
            ICryptoTransform descryptor = _dESCryptoServiceProvider.CreateDecryptor();
            byte[] IDtoBytes = Convert.FromBase64String(data);
            byte[] encryptedID = descryptor.TransformFinalBlock(IDtoBytes, 0, IDtoBytes.Length);

            return Encoding.Unicode.GetString(encryptedID);
        }
    }
}
