using LibrarioAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using BCrypt.Net;
using System;
namespace LibrarioAPI.Services
{
    public class Security
    {
		private static Random random = new Random();
        public static string NewSalt(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string HashPassword(string password, string salt) {
            return BCrypt.Net.BCrypt.HashPassword(password + salt);
        }
	}
}