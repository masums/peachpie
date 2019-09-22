using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Pchp.Core;

namespace Pchp.Library
{
    [PhpExtension(openssl)]
    public static class OpenSSL
    {
        /// <summary>
        /// The extension name.
        /// </summary>
        const string openssl = "openssl";

        #region Constants

        /// <summary>
        /// OpenSSL version identifier.
        /// </summary>
        public static string OPENSSL_VERSION_TEXT => typeof(AesCryptoServiceProvider).Assembly.FullName;

        /// <summary>
        /// MNNFFPPS: major minor fix patch status (2b HEX)
        /// status: 0 => development, [1-e] => beta, f => release
        /// </summary>
        public static int OPENSSL_VERSION_NUMBER
        {
            get
            {
                var v = typeof(AesCryptoServiceProvider).Assembly.GetName().Version;
                return
                    v.Major << 24 |
                    v.Minor << 16 |
                    v.Revision << 8 |
                    0;
            }
        }


        /// <summary>
        /// Used as default algorithm by openssl_sign() and openssl_verify().
        /// </summary>
        public const int OPENSSL_ALGO_SHA1 = 1;
        public const int OPENSSL_ALGO_SHA224 = 6;
        public const int OPENSSL_ALGO_SHA256 = 7;
        public const int OPENSSL_ALGO_SHA384 = 8;
        public const int OPENSSL_ALGO_SHA512 = 9;
        public const int OPENSSL_ALGO_RMD160 = 10;

        public const int OPENSSL_ALGO_MD5 = 2;
        public const int OPENSSL_ALGO_MD4 = 3;

        //public const int OPENSSL_ALGO_DSS1

        ///// <summary>
        ///// As of PHP 5.2.13 and PHP 5.3.2, this constant is only available if PHP is compiled with MD2 support.This requires passing in the -DHAVE_OPENSSL_MD2_H CFLAG when compiling PHP, and enable-md2 when compiling OpenSSL 1.0.0+.
        ///// </summary>
        //public const int OPENSSL_ALGO_MD2


        /// <summary>
        /// Whether SNI support is available or not.
        /// </summary>
        public const int OPENSSL_TLSEXT_SERVER_NAME = 1;

        public const int OPENSSL_CIPHER_RC2_40 = 0;
        public const int OPENSSL_CIPHER_RC2_128 = 0;
        public const int OPENSSL_CIPHER_RC2_64 = 0;
        //public const int OPENSSL_CIPHER_DES = 3;
        public const int OPENSSL_CIPHER_3DES = 4;
        public const int OPENSSL_CIPHER_AES_128_CBC = 5;
        public const int OPENSSL_CIPHER_AES_192_CBC = 6;
        public const int OPENSSL_CIPHER_AES_256_CBC = 7;

        #endregion

        /// <summary>
        /// Generate a pseudo-random string of bytes.
        /// </summary>
        public static PhpString openssl_random_pseudo_bytes(int length, ref bool crypto_strong)
        {
            crypto_strong = true;
            return openssl_random_pseudo_bytes(length);
        }

        /// <summary>
        /// Generate a pseudo-random string of bytes.
        /// </summary>
        public static PhpString openssl_random_pseudo_bytes(int length)
        {
            var bytes = new byte[length];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            return new PhpString(bytes);
        }

        public static PhpArray openssl_x509_parse(string x509cert, bool shortnames = true)
        {
            // new X509Certificate2( byte[] ) ...

            throw new NotImplementedException();
        }
    }
}
