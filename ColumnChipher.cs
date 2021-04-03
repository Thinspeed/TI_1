using System;
using System.Collections.Generic;
using System.Text;

namespace TI
{
	class ColumnChipher : Chipher
	{
		string key;
		int[] table;
		const int numberOfLetters = 26;

		public ColumnChipher(string key)
		{
			this.key = key.ToLower();
			table = new int[key.Length];
			int lettersFound = 0;
			for (int i = 0; i < numberOfLetters; i++)
            {
				for (int j = 0; j < key.Length; j++)
                {
					if (key[j] == 'a' + i)
                    {
						table[j] = lettersFound++; 
                    }
                }
            }
		}

		override public string Encrypt(string message)
		{
			var columns = new StringBuilder[table.Length];
			for (int i = 0; i < message.Length; i++)
            {
				if (columns[i % columns.Length] == null)
                {
					columns[i % columns.Length] = new StringBuilder();
                }

				columns[i % columns.Length].Append(message[i]);
			}

			var codedMessage = new StringBuilder();
			for (int i = 0; i < table.Length; i++)
            {
				int index = 0;
				while (i != table[index])
                {
					index++;
                }

				if (columns[index] != null)
                {
					codedMessage.Append(columns[index]);
                }
            }

			return codedMessage.ToString();
		}

		override public string Decrypt(string message)
		{
			var columns = new StringBuilder[table.Length];
			var lengths = new int[table.Length];
			for (int i = 0; i < lengths.Length; i++)
            {
				lengths[i] = message.Length / table.Length;
				if (i < message.Length % table.Length)
                {
					lengths[i]++;
                }
            }

			int readedLength = 0;
			for (int i = 0; i < columns.Length; i++)
            {
				int index = 0;
				while (i != table[index])
                {
					index++;
                }

				columns[index] = new StringBuilder(message.Substring(readedLength, lengths[index]));
				readedLength += lengths[index];
            }

			var decodedMessage = new StringBuilder();
			for (int i = 0; i < message.Length; i++)
            {
				int row = i / columns.Length;
				int column = i % columns.Length;
				decodedMessage.Append(columns[column][row]);
            }

			return decodedMessage.ToString();
		}
	}
}
