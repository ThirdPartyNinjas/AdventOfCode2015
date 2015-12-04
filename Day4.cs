using System;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode2015_csharp
{
	public static class Day4
	{
		public static void Part1()
		{
			string input = @"bgvyzdsv";

			for (int i = 0; ; i++)
			{
				string result = MD5(input + i.ToString());
				if (result.Substring(0, 5) == "00000")
				{
					Console.WriteLine(string.Format("d4p1: The lowest number to get leading \"00000\" is: {0}", i));
					return;
				}
			}
		}

		public static void Part2()
		{
			string input = @"bgvyzdsv";

			for (int i = 0; ; i++)
			{
				string result = MD5(input + i.ToString());
				if (result.Substring(0, 6) == "000000")
				{
					Console.WriteLine(string.Format("d4p2: The lowest number to get leading \"000000\" is: {0}", i));
					return;
				}
			}
		}

		// copied directly from stackoverflow
		// http://stackoverflow.com/questions/11454004/calculate-a-md5-hash-from-a-string
		private static string MD5(string data)
		{
			byte[] encodedPassword = new UTF8Encoding().GetBytes(data);

			// need MD5 to calculate the hash
			byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

			// string representation (similar to UNIX format)
			string encoded = BitConverter.ToString(hash)
			   // without dashes
			   .Replace("-", string.Empty)
			   // make lowercase
			   .ToLower();

			return encoded;
		}
	}
}
