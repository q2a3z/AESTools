using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kumas_SavadataTool
{
    sealed class AesManager
    {
        #region Encrypt Class
        /// AesManagedマネージャーを取得
        private static AesManaged GetAesManager(string aesKey)
        {
            //任意の半角英数16文字
            string aesIv = "1234567890123456";
            //string aesKey = "Komatsu1KumaKuma";

            AesManaged aes = new AesManaged();
            aes.KeySize = 128;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.IV = Encoding.UTF8.GetBytes(aesIv);
            aes.Key = Encoding.UTF8.GetBytes(aesKey);
            aes.Padding = PaddingMode.PKCS7;
            return aes;
        }

        /// AES暗号化
        public static byte[] AesEncrypt(byte[] byteText, string aesKey)
        {
            // AESマネージャーの取得
            AesManaged aes = GetAesManager(aesKey);
            // 暗号化
            byte[] encryptText = aes.CreateEncryptor().TransformFinalBlock(byteText, 0, byteText.Length);

            return encryptText;
        }

        /// AES復号化
        public static byte[] AesDecrypt(byte[] byteText, string aesKey)
        {
            // AESマネージャー取得
            var aes = GetAesManager(aesKey);
            // 復号化
            byte[] decryptText = aes.CreateDecryptor().TransformFinalBlock(byteText, 0, byteText.Length);

            return decryptText;
        }
        #endregion
    }
}
