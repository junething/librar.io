using LibrarioAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using BCrypt.Net;
using System;
using System.Security;
using System.Text;
namespace LibrarioAPI.Services
{
    public class Crypto
    {
		private static Random random = new Random();
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        public static string NewSalt(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        
		public static string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
		public static bool VerifyPassword(string text, string hash) => BCrypt.Net.BCrypt.Verify(text, hash);

		public static string RandomString(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return res.ToString();
        }
        public string Login(Credentials creds) {
            return "l";
        }


        public class InvalidCredentials : Exception
        {
            public InvalidCredentials() { }
            public InvalidCredentials(string message) : base(message) { }
            public InvalidCredentials(string message, Exception inner) : base(message, inner) { }
        }
	}
}