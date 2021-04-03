using System;
using System.Collections.Generic;
using System.Text;

namespace TI
{
	class CaesarChipher : Chipher
	{
		int key;

		public CaesarChipher()
		{
			var rmd = new Random();
			key = rmd.Next() % 24 + 1;
		}

		public CaesarChipher(int key)
        {
			this.key = key;
        }

		override public string Encrypt(string message)
		{
			var codedMessage = new StringBuilder();
			for (int i = 0; i < message.Length; i++)
			{
				if (char.IsUpper(message[i]))
				{
					codedMessage.Append((char)('A' + ((message[i] + key) % 'A' % 26)));
				}
				else if (char.IsLower(message[i]))
				{
					char a = (char)('a' + ((message[i] + key) % 'a' % 26));
					codedMessage.Append(a);
				}
				else
				{
					codedMessage.Append(message[i]);
				}
			}

			return codedMessage.ToString();
		}

		override public string Decrypt(string message)
		{
			var decodedMessage = new StringBuilder();
			for (int i = 0; i < message.Length; i++)
			{
				if (char.IsUpper(message[i]))
				{
					decodedMessage.Append((char)('A' + ((message[i] + (26 - key)) % 'A' % 26)));
				}
				else if (char.IsLower(message[i]))
				{
					char a = (char)('a' + ((message[i] + (26 - key)) % 'a' % 26));
					decodedMessage.Append(a);
				}
				else
				{
					decodedMessage.Append(message[i]);
				}
			}

			return decodedMessage.ToString();
		}
	}
}
