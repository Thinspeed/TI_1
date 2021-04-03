using System;
using System.Collections.Generic;
using System.Text;

namespace TI
{
	class RailwayHedge : Chipher
	{
		int key;

		public RailwayHedge()
        {
			var rnd = new Random();
			key = rnd.Next() % 4 + 2;
        }

		public RailwayHedge(int key)
        {
			this.key = key;
        }

		override public string Encrypt(string message)
		{
			var table = new StringBuilder[key];
			int T = key * 2 - 2;
			for (int i = 0; i < message.Length; i++)
			{
				int row = key - 1 - Math.Abs(key - 1 - i % T);
				if (table[row] == null)
				{
					table[row] = new StringBuilder();
				}

				table[row].Append(message[i]);
			}

			var codedMessage = new StringBuilder();
			for (int i = 0; i < table.Length; i++)
            {
				codedMessage.Append(table[i]);
            }

			return codedMessage.ToString();
		}

		override public string Decrypt(string message)
        {
			var decodedMessage = new StringBuilder(message);
			int maxT = 2 * key - 2;
			int T = maxT;
			int currentRow = 0;
			int oddSymbols = 1;
			int evenSymbols = 0;
			for (int i = 0; i < message.Length; i++)
            {
				//int index = (lettersInRow % 2 == 0) ? (currentRow + (T * lettersInRow)) : (currentRow + (T * lettersInRow) + T - maxT);
				int index;
				if (currentRow == 0 || currentRow == key - 1)
				{
					index = (evenSymbols++) * T + currentRow;
				}
                else
                {
					index = ((oddSymbols + evenSymbols - 1) % 2 == 0) ? (currentRow + (T * evenSymbols++)) : (-currentRow + (T * oddSymbols++));
				}

				if (index >= message.Length)
                {
					currentRow++;
					oddSymbols = 1;
					evenSymbols = 0;
					index = ((oddSymbols + evenSymbols - 1) % 2 == 0) ? (currentRow + (T * evenSymbols++)) : (-currentRow + (T * oddSymbols++));
                }

				decodedMessage[index] = message[i];
            }

			return decodedMessage.ToString();
        }
	}
}
