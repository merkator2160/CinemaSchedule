using System;
using System.Linq;
using System.Security.Cryptography;

namespace CinemaSchedule.Common.Helpers
{
	public static class KeyHelper
	{
		public static String CreateToken(Int32 length)
		{
			const String charPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			var random = new Random();

			return new String(Enumerable.Repeat(charPool, length)
				.Select(s => s[random.Next(s.Length)]).ToArray());
		}
		public static String CreateRandomBase64String(Int32 length)
		{
			var randomBytes = new Byte[length];
			new RNGCryptoServiceProvider().GetBytes(randomBytes);

			return Convert.ToBase64String(randomBytes);
		}
	}
}